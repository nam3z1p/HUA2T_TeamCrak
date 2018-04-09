console.log("[+] Script loaded successfully ");

function sleep(milliseconds) {
  var start = new Date().getTime();
  for (var i = 0; i < 1e7; i++) {
    if ((new Date().getTime() - start) > milliseconds){
      break;
    }
  }
}

function crackNext() {    
    if(ObjC.available){
        
        send("\n\n")
        send("======================");
        send("== Start Class Dump ==");       
        send("======================");
        
        //Search class & method
        var matchstring_class="devappdelegate";
        //matchstring_method = ""
        
        for(var className in ObjC.classes){
            if (ObjC.classes.hasOwnProperty(className))
            {
                if(className.toLowerCase().indexOf(matchstring_class) != "-1"){
                    sleep(1000);
                    send("\n\n")
                    send("========================================================================");
                    send("[*] "+className);
                    send("========================================================================");
                    try
                    {
                        var methods = eval('ObjC.classes.' + className + '.$methods');
                        for (var i = 0; i < methods.length; i++)
                        {
                            try
                            {   
                                //if(methods[i].toLowerCase().indexOf(matchstring_method) == "-1"){}
                                    send("[-] "+methods[i]);
                                
                            }
                            catch(err)
                            {
                                console.log("[!] Exception1: " + err.message);
                            }
                        }
                    }
                    catch(err)
                    {
                        console.log("[!] Exception2: " + err.message);
                    }
                }
            }
        }
        send("========================================================================");
        console.log("[*] Completed: Find All Methods of a Specific Class");
        //file.close();
    }
    else{
        console.log("Objective-C Runtime is not available!");
    }
}    

setTimeout(crackNext, 0);
    

