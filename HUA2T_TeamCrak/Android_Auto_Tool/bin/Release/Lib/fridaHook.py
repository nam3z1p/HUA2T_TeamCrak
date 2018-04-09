# -*- coding: utf-8 -*-
import frida, sys, time, argparse, textwrap, os
reload(sys)
sys.setdefaultencoding('cp949')


def main_title() :
    print "######################################################"
    print "##                                                  ##"    
    print u"##          TeamCr@k Frida Hooking 1.0.0            ##"
    print "##                                                  ##"
    print "##                           Developed by TeamCR@K  ##"
    print "##                                         2017.12  ##"
    print "######################################################"
    
jscode=""
class_name=""
Classdump_filename = ".\Dump\classdump.log"

def pause_exit(retCode, message):
    sys.exit(retCode)

def MENU():
    parser = argparse.ArgumentParser(
        prog='fridaHook',
        formatter_class=argparse.RawDescriptionHelpFormatter,
        description=textwrap.dedent(""))
        
    parser.add_argument('-S', '--scriptname', type=str, help='scriptname', metavar="scriptname")
    parser.add_argument('-W', '--windows', action='store_true', help='windows_Mode')
    parser.add_argument('-C', '--classdump', action='store_true', help='classdump')    
    parser.add_argument('process', type=int, help='the process that you will be injecting to')
    args = parser.parse_args()
    return args

def On_Message(message, payload):
    try:
        if message:
            print("[Hooking] {0}".format(message['payload']))
    except Exception as e:
        print(message)
        print(e)            

def Windows_Message(message, payload):
    try:
        if message:
           print "[%s] -> %s" % (message, payload)
    except Exception as e:
        print(message)
        print(e)               
        
def ClassDump_Message(message, payload):
    try:
        if message["type"]=="send":
            if message['payload']:                
                f = open(Classdump_filename,'a')
                data = "{0}\n".format(message['payload'])
                f.write(data)            
                f.close
                print("[Hooking] {0}".format(message['payload']))          
    except Exception as e:
        print(message)
        print(e)    

if __name__ == '__main__':

    main_title()
    
    arguments = MENU()

    app_pid = arguments.process
    scriptname = arguments.scriptname
    
    if arguments.scriptname :
        with open(scriptname, "r") as f:
            jscode = f.read()
    else:
        print '[-] Error input ScriptName Plz ...'
        exit(0)
        
    print('[+] Running')

       
    try:
        if not arguments.windows :
            device = frida.get_device_manager().enumerate_devices()[-1]
            time.sleep(1)
        print('[+] Hooking (pid or Name : {}) is starting. '.format(app_pid)) 
    except Exception as e:
        print(e)
        
    if arguments.windows :
        session = frida.attach(app_pid)
        #모듈 로딩
        #print([x.name for x in session.enumerate_modules()])
    else :
        session = device.attach(app_pid)

    script = session.create_script(jscode)
    if arguments.windows :
        script.on('message', Windows_Message)
    elif arguments.classdump :
        if not os.path.exists(".\Dump"): 
            os.makedirs(".\Dump")
        if os.path.exists(Classdump_filename):
            os.remove(Classdump_filename)
        script.on('message', ClassDump_Message)
    else:
        script.on('message', On_Message)
    script.load()
    sys.stdin.read()

