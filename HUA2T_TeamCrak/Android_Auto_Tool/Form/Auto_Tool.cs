using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
 
using IronPython;
using IronPython.Hosting;
using IronPython.Runtime;
using IronPython.Modules;


namespace Android_Auto_Tool
{

	
	public partial class Auto_Tool : Form
	{
		string main = 
@"												          


			#######                       #####          #####         
			   #    ######   ##   #    # #     # #####  #     # #    # 
			   #    #       #  #  ##  ## #       #    # # ### # #   #  
			   #    #####  #    # # ## # #       #    # # ### # ####   
			   #    #      ###### #    # #       #####  # ####  #  #   
			   #    #      #    # #    # #     # #   #  #       #   #  
			   #    ###### #    # #    #  #####  #    #  #####  #    #     




		 ########################################################################		  
		 #                                                                      #		  
		 #                        Android Auto Tools                            #		  
		 #                                                                      #		  
		 #                                                                      #		  
		 #                                                                      #		  
		 #                                           - A3Security, TeamCR@K     #		  
		 #                                                     	     by nam3z1p #		  
		 ########################################################################		  
							          
";

		string filePath = Application.StartupPath;
		string selectedMenu = "";
		string selectedDevice = "";
		string selectedFilename = "";
		string code = @"
import clr
clr.AddReference('stdlib')
import os, sys, subprocess
from threading import Timer

def DevicesList_python():
	kill = lambda process: process.kill()
	command = 'adb devices'
	popen = subprocess.Popen(command, stdout=subprocess.PIPE, stderr=subprocess.PIPE, shell=True)
	my_timer = Timer(1*60, kill, [popen])
	
	try:
		my_timer.start()
		(stdoutdata, stderrdata) = popen.communicate()		
	finally:
		my_timer.cancel()
		return stdoutdata.split()

def CMD_python(cmd):
	kill = lambda process: process.kill()
	command = cmd
	popen = subprocess.Popen(command, stdout=subprocess.PIPE, stderr=subprocess.PIPE, shell=True)
	my_timer = Timer(2*60, kill, [popen])
	
	try:
		my_timer.start()
		(stdoutdata, stderrdata) = popen.communicate()
	finally:
		my_timer.cancel()
		return unicode(stdoutdata, 'cp949')
";
		

		public Auto_Tool()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			this.TopLevel = false; 

			cmd_view.Text = main;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
			
		void SelectMenuSelectedIndexChanged(object sender, EventArgs e)
		{
			selectedMenu = SelectMenu.SelectedItem.ToString();
		}
		
		void DeviceViewSelectedIndexChanged(object sender, EventArgs e)
		{
			string[] selectedDevice1 = DeviceView.SelectedItem.ToString().Split(',');
			selectedDevice = selectedDevice1[0];
		}
		
		void FileOpen_Click(object sender, EventArgs e)
		{
						
			OpenFileDialog open = new OpenFileDialog();
			
			open.Filter = "APK FILE(*.apk)|*.apk|ALLFiles(*.*)|*.*";
			open.InitialDirectory=filePath+@"\Input_File";
			open.Title = "FILE OPEN";
			
			if(open.ShowDialog() == DialogResult.OK)
			{	
				string filefullname = open.FileName;
				string onlyfilename = filefullname.Substring(filefullname.LastIndexOf("\\")+1);
				this.FileOpenView.Text = onlyfilename;
				selectedFilename = onlyfilename;
			}
		}
		
		void DeviceList_Click(object sender, EventArgs e)
		{
			
			var engine = IronPython.Hosting.Python.CreateEngine();
			var scope = engine.CreateScope();

			var source = engine.CreateScriptSourceFromString(code, Microsoft.Scripting.SourceCodeKind.Statements);
			source.Execute(scope);
			
            var devicesList_python = scope.GetVariable<Func<object>>("DevicesList_python");
            List devicesList = new List();
            
            LoadingForm f = new LoadingForm();
			f.Function = (() => {  
				devicesList = (List)devicesList_python();
			              });
			f.StartPosition = FormStartPosition.CenterParent;
			f.ShowDialog();
             
            List<string> devicesList_C = new List<string>();
            
            devicesList_C.Clear();
            
            foreach (string data in devicesList)
            {
            	devicesList_C.Add(data);
            }
            
            DeviceView.Items.Clear();
            
            string result = "";
            result = devicesList_C.Find(item => item == "started");
			
            if (result!=null){
            	for (int i=20; i < devicesList_C.Count; i=i+2){
	            	DeviceView.Items.Add(""+devicesList_C[i]+" , ["+devicesList_C[i+1]+"]");
            	}
            }else{
            	for (int i=4; i < devicesList_C.Count; i=i+2){
	            	DeviceView.Items.Add(""+devicesList_C[i]+" , ["+devicesList_C[i+1]+"]");
	            }
            }

		}
		
		void cmd_click(object sender, EventArgs e)
		{
			
			var engine = IronPython.Hosting.Python.CreateEngine();
			var scope = engine.CreateScope();

			var source = engine.CreateScriptSourceFromString(code, Microsoft.Scripting.SourceCodeKind.Statements);
			source.Execute(scope);
            
			var cmd_Python = scope.GetVariable<Func<string, string>>("CMD_python");
			
			string[] split_Filename = selectedFilename.Split('.');
			string[] selectedApktool = Directory.GetFiles(".\\Lib","apktool_*.jar");
			
			if(selectedMenu=="Decompile"){
				if (selectedFilename==""){
					MessageBox.Show("File Select Plz....");
				}else{
					string cmd_Decompile_View="";
					string cmd_Decompile = "java -Xmx512m -jar "+selectedApktool[0]+" d .\\Input_File\\"+selectedFilename+" -o .\\Output_Decompile\\"+split_Filename[0];

					cmd_view.AppendText("---------------------------------------------------------------------------------------------------------\r\n");
					cmd_view.AppendText("[+] "+selectedFilename+" Decompiling ...\r\n");
					
					LoadingForm f = new LoadingForm();
					f.Function = (() => {  			              	
						cmd_Decompile_View = cmd_Python(cmd_Decompile);
					              });
					f.StartPosition = FormStartPosition.CenterParent;
					f.ShowDialog();
					
					cmd_view.AppendText(cmd_Decompile_View);
				    cmd_view.AppendText("[+] Decompiling Complete\r\n");		
				}
			}else if(selectedMenu=="Sign-Compile"){
				if (selectedFilename==""){
					MessageBox.Show("File Select Plz....");
				}else{				
					string cmd_Compile_View= "";
					string cmd_Sign_View = "";
					string cmd_Compile = "java -Xmx512m -jar "+selectedApktool[0]+" b .\\Output_Decompile\\"+split_Filename[0]+" -o .\\Output_SignedFile\\Modify_"+selectedFilename;
					string cmd_Sign = "java -Xmx512m -jar .\\Lib\\signapk.jar .\\Lib\\testkey.x509.pem .\\Lib\\testkey.pk8 .\\Output_SignedFile\\Modify_"+selectedFilename+" .\\Output_SignedFile\\Signed_"+selectedFilename;
					
					cmd_view.AppendText("---------------------------------------------------------------------------------------------------------\r\n");
					cmd_view.AppendText("[+] "+selectedFilename+" Building ...\r\n");
					cmd_Python("del /Q .\\Output_SignedFile\\*.*");
					
					LoadingForm f1 = new LoadingForm();
					f1.Function = (() => {  
						cmd_Compile_View = cmd_Python(cmd_Compile);
					              });
					f1.StartPosition = FormStartPosition.CenterParent;
					f1.ShowDialog();

					cmd_view.AppendText(cmd_Compile_View);
			        
					cmd_view.AppendText("[+] Building Complete\r\n");
					cmd_view.AppendText("[+] Modify_"+selectedFilename+" Signing ...\r\n");
					
					LoadingForm f2 = new LoadingForm();
					f2.Function = (() => {  
						cmd_Sign_View = cmd_Python(cmd_Sign);
					              });
					f2.StartPosition = FormStartPosition.CenterParent;
					f2.ShowDialog();			
					
					cmd_view.AppendText(cmd_Sign_View);
					cmd_Python("del .\\Output_SignedFile\\Modify_"+selectedFilename);
					cmd_view.AppendText("[+] Signed_"+selectedFilename+" Signing Complete\r\n");
				}
			}else if(selectedMenu=="Re-Install"){
				if (selectedDevice==""){
					MessageBox.Show("Device Select Plz....");
				}else{
					string cmd_Re_Install_View = "";
					string cmd_Re_Install = "adb -s "+selectedDevice+" -d install -r .\\Output_SignedFile\\Signed_"+selectedFilename;
					
					cmd_view.AppendText("---------------------------------------------------------------------------------------------------------\r\n");
					cmd_view.AppendText("[+] Signed_"+selectedFilename+" installing ...\r\n");
					
					LoadingForm f = new LoadingForm();
					f.Function = (() => {  
						cmd_Re_Install_View = cmd_Python(cmd_Re_Install);
					              });
					f.StartPosition = FormStartPosition.CenterParent;
					f.ShowDialog();

					cmd_view.AppendText(cmd_Re_Install_View);
					cmd_view.AppendText("[+] Signed_"+selectedFilename+" Install Complete\r\n");
				}
			}else{
				MessageBox.Show("plz... Select Menu");
			}
		}
		
		
	}
}

