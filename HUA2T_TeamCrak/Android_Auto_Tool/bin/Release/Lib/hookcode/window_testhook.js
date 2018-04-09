    console.log("[+] Script loaded successfully ");

    try
    {
        var moduleName = "USER32.DLL";
        var funcName = "SetWindowTextW";
        var sendPtr = Module.findExportByName(moduleName, funcName);
        
        console.log('[+] Dll Injection Module '+moduleName); 
        console.log('[+] '+funcName+' address: ' + sendPtr.toString()); 
        
        Interceptor.attach(sendPtr, { 
            onEnter: function (args) { 
                
                console.log("[+] Hooking : " + Memory.readUtf16String(args[1]));                
                
            }, 
            onLeave: function (retval) {  
            }
        });
    }
    catch(err)
    {
        console.log("[!] Exception: " + err.message);
    }

