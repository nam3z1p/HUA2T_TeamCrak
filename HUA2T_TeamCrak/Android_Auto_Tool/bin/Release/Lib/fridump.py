import textwrap
import frida
import os
import sys
import frida.core
import argparse
import string
import re

def dump_to_file(session,base,size,error,directory):
        try:
                filename = str(hex(base))+'_dump.data'
                dump =  session.read_bytes(base, size)
                f = open(os.path.join(directory,filename), 'wb')
                f.write(dump)
                f.close()
                return error
        except:
               return error

def splitter(session,base,size,max_size,error,directory):
        times = size/max_size
        diff = size % max_size
        global cur_base
        cur_base = base
        for time in range(times):
                dump_to_file(session, cur_base, max_size, error, directory)
                cur_base = cur_base + max_size
        if diff is not 0:
            dump_to_file(session, cur_base, diff, error, directory)


def strings(filename,directory, min=4):
    strings_file = os.path.join(directory,"strings.txt")
    path = os.path.join(directory,filename)
    str_list = re.findall("[A-Za-z0-9/\-:;.,_$%'!()[\]<> \#]+",open(path,"rb").read())
    with open(strings_file,"ab") as st:
        for string in str_list:
            if len(string)>min:
                st.write(string+"\n")        

def pause_exit(retCode, message):
    sys.exit(retCode)
    
def MENU():
    parser = argparse.ArgumentParser(
        prog='fridump',
        formatter_class=argparse.RawDescriptionHelpFormatter,
        description=textwrap.dedent(""))

    parser.add_argument('process', help='the process that you will be injecting to')
    parser.add_argument('-o', '--out', type=str, help='provide full output directory path. (def: \'dump\')', metavar="dir")
    parser.add_argument('-u', '--usb', action='store_true', help='device connected over usb')
    parser.add_argument('-s', '--strings', action='store_true', help='run strings on all dump files. Saved in output dir.')
    args = parser.parse_args()
    return args
        
arguments = MENU()

try:
    APP_NAME = int(arguments.process)
except:
    APP_NAME = arguments.process
DIRECTORY = arguments.out
USB = arguments.usb
STRINGS = arguments.strings
MAX_SIZE = 20971520
PERMS = 'rw-'

session = None
try:
    if USB:
        session = frida.get_usb_device().attach(APP_NAME)
    else:
        session = frida.attach(APP_NAME)
except:
    sys.exit(0)

mem_access_viol = ""

Memories = session.enumerate_ranges(PERMS)

i = 0
l = len(Memories)

for memory in Memories:
    base = memory.base_address
    size = memory.size
    if size > MAX_SIZE:
        mem_access_viol = splitter(session, base, size, MAX_SIZE, mem_access_viol, DIRECTORY)
        continue
    mem_access_viol = dump_to_file(session, base, size, mem_access_viol, DIRECTORY)


if STRINGS:
    files = os.listdir(DIRECTORY)
    i = 0
    l = len(files)
    for f1 in files:
        strings(f1, DIRECTORY)
