import textwrap
import frida
import os
import sys
import frida.core
import argparse
import logging
import string
import re

logo = """
        ______    _     _
        |  ___|  (_)   | |
        | |_ _ __ _  __| |_   _ _ __ ___  _ __
        |  _| '__| |/ _` | | | | '_ ` _ \| '_ \\
        | | | |  | | (_| | |_| | | | | | | |_) |
        \_| |_|  |_|\__,_|\__,_|_| |_| |_| .__/
                                         | |
                                         |_|
        """


# Reading bytes from session and saving it to a file
def dump_to_file(session,base,size,error,directory):
        try:
                filename = str(hex(base))+'_dump.data'
                dump =  session.read_bytes(base, size)
                f = open(os.path.join(directory,filename), 'wb')
                f.write(dump)
                f.close()
                return error
        except:
               print "Oops, memory access violation!"

               return error

#Read bytes that are bigger than the max_size value, split them into chunks and save them to a file
def splitter(session,base,size,max_size,error,directory):
        times = size/max_size
        diff = size % max_size
        if diff is 0:
            logging.debug("Number of chunks:"+str(times+1))
        else:
            logging.debug("Number of chunks:"+str(times))
        global cur_base
        cur_base = base

        for time in range(times):
                logging.debug("Save bytes: "+str(hex(cur_base))+" till "+str(hex(cur_base+max_size)))
                dump_to_file(session, cur_base, max_size, error, directory)
                cur_base = cur_base + max_size

        if diff is not 0:
            logging.debug("Save bytes: "+str(hex(cur_base))+" till "+str(hex(cur_base+diff)))
            dump_to_file(session, cur_base, diff, error, directory)


# Progress bar function
def printProgress (times, total, prefix ='', suffix ='', decimals = 2, bar = 100):
    filled = int(round(bar * times / float(total)))
    percents = round(100.00 * (times / float(total)), decimals)
    bar = '#' * filled + '-' * (bar - filled)
    sys.stdout.write('%s [%s] %s%s %s\r' % (prefix, bar, percents, '%', suffix)),
    sys.stdout.flush()
    if times == total:
        print("\n")


# A very basic implementations of Strings
def strings(filename,directory, min=4):
    strings_file = os.path.join(directory,"strings.txt")
    path = os.path.join(directory,filename)

    str_list = re.findall("[A-Za-z0-9/\-:;.,_$%'!()[\]<> \#]+",open(path,"rb").read())
    with open(strings_file,"ab") as st:
        for string in str_list:
            if len(string)>min:
                logging.debug(string)
                st.write(string+"\n")        
        
        
# Main Menu
def MENU():
    parser = argparse.ArgumentParser(
        prog='fridump',
        formatter_class=argparse.RawDescriptionHelpFormatter,
        description=textwrap.dedent(""))

    parser.add_argument('process', help='the process that you will be injecting to')
    parser.add_argument('-o', '--out', type=str, help='provide full output directory path. (def: \'dump\')',
                        metavar="dir")
    parser.add_argument('-u', '--usb', action='store_true', help='device connected over usb')
    parser.add_argument('-v', '--verbose', action='store_true', help='verbose')
    parser.add_argument('-r','--read-only',action='store_true', help="dump read-only parts of memory. More data, more errors")
    parser.add_argument('-s', '--strings', action='store_true',
                        help='run strings on all dump files. Saved in output dir.')
    parser.add_argument('--max-size', type=int, help='maximum size of dump file in bytes (def: 20971520)',
                        metavar="bytes")
    args = parser.parse_args()
    return args
    
def pause_exit(retCode, message):
    print(message)
    sys.exit(retCode)
    
print logo
arguments = MENU()

# Define Configurations
#APP_NAME = arguments.process
try:
    APP_NAME = int(arguments.process)
except:
    APP_NAME = arguments.process
DIRECTORY = ""
USB = arguments.usb
DEBUG_LEVEL = logging.INFO
STRINGS = arguments.strings
MAX_SIZE = 20971520
PERMS = 'rw-'

if arguments.read_only:
    PERMS = 'r--'

if arguments.verbose:
    DEBUG_LEVEL = logging.DEBUG
logging.basicConfig(format='%(levelname)s:%(message)s', level=DEBUG_LEVEL)

# Start a new Session
session = None
try:
    if USB:
        session = frida.get_usb_device().attach(APP_NAME)
    else:
        session = frida.attach(APP_NAME)
except:
    print "Can't connect to App. Have you connected the device?"
    sys.exit(0)


# Selecting Output directory
if arguments.out is not None:
    DIRECTORY = arguments.out
    if not os.path.exists(DIRECTORY):
        print "Creating directory..."
        os.makedirs(DIRECTORY)

else:
    print "Current Directory: " + str(os.getcwd())
    DIRECTORY = os.path.join(os.getcwd(), "dump")
    print "Output directory is set to: " + DIRECTORY
    if not os.path.exists(DIRECTORY):
        print "Creating directory..."
        os.makedirs(DIRECTORY)

mem_access_viol = ""

print "Starting Memory dump..."

Memories = session.enumerate_ranges(PERMS)

if arguments.max_size is not None:
    MAX_SIZE = arguments.max_size

i = 0
l = len(Memories)

# Performing the memory dump
for memory in Memories:
    base = memory.base_address
    logging.debug("Base Address: " + str(hex(base)))
    logging.debug("")
    size = memory.size
    logging.debug("Size: " + str(size))
    if size > MAX_SIZE:
        logging.debug("Too big, splitting the dump into chunks")
        mem_access_viol = splitter(session, base, size, MAX_SIZE, mem_access_viol, DIRECTORY)
        continue
    mem_access_viol = dump_to_file(session, base, size, mem_access_viol, DIRECTORY)
    i += 1
    printProgress(i, l, prefix='Progress:', suffix='Complete', bar=50)
print

# Run Strings if selected

if STRINGS:
    files = os.listdir(DIRECTORY)
    i = 0
    l = len(files)
    print "Running strings on all files:"
    for f1 in files:
        strings(f1, DIRECTORY)
        i += 1
        printProgress(i, l, prefix='Progress:', suffix='Complete', bar=50)
print "Finished!"
raw_input('Press Enter to exit...')
