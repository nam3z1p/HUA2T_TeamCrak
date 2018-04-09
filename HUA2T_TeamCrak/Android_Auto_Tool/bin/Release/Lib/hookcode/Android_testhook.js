        console.log("[+] Script loaded successfully ");
        Java.perform(function () {
            var tv_class = Java.use("android.widget.TextView");
            tv_class.setText.overload("java.lang.CharSequence").implementation = function (x) {
                var string_to_send = x.toString();
                send(string_to_send); 
                this.setText.overload("java.lang.CharSequence").call(this,x);
                
            }
        });
