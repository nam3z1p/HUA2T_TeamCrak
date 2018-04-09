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
	/// <summary>
	/// Description of Dump.
	/// </summary>
	public partial class Dump : Form
	{
		
		string filePath = Application.StartupPath;
		string selectedMenu = "";
		string selectedDevice = "";
		string selectedProcessName = "";
		string selectedPID = "";
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
		
def ProcessList(cmd,option,address):
	kill = lambda process: process.kill()
	command = '%s -%s %s'%(cmd,option,address)
	popen = subprocess.Popen(command, stdout=subprocess.PIPE, stderr=subprocess.PIPE, shell=True)
	my_timer = Timer(2*60, kill, [popen])
	
	try:
		my_timer.start()
		(stdoutdata, stderrdata) = popen.communicate()		
	finally:
		my_timer.cancel()
        stdoutdata=unicode(stdoutdata,'utf-8')
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
			
		
		public Dump()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.TopLevel = false; //Toplevel release
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Process_ViewSelectedIndexChanged(object sender, EventArgs e)
		{
			selectedPID = Process_View.Items[Process_View.FocusedItem.Index].SubItems[0].Text;
			selectedProcessName = Process_View.Items[Process_View.FocusedItem.Index].SubItems[1].Text;
		}
		
		void DeviceViewSelectedIndexChanged(object sender, EventArgs e)
		{
			string[] selectedDevice1 = DeviceView.SelectedItem.ToString().Split(',');
			selectedDevice = selectedDevice1[0];			
		}		
					
		void SelectMenuSelectedIndexChanged(object sender, EventArgs e)
		{
			
			selectedMenu = SelectMenu.SelectedItem.ToString();
			
			if (SelectMenu.SelectedItem.ToString()=="DEVICE"){
				AddressInsert.ReadOnly = false;
				AddressInsert.BackColor = System.Drawing.SystemColors.Window;;
			}else{
				AddressInsert.ReadOnly = true;
				AddressInsert.BackColor = System.Drawing.SystemColors.Control;
			}
		}
		
		void ProccessList_ButtonClick(object sender, EventArgs e)
		{
			var engine = IronPython.Hosting.Python.CreateEngine();
			var scope = engine.CreateScope();
			var paths = engine.GetSearchPaths();
			
			paths.Add(@".\Lib");
			engine.SetSearchPaths(paths);

			var source = engine.CreateScriptSourceFromString(code, Microsoft.Scripting.SourceCodeKind.Statements);
			source.Execute(scope);
			
			if (SelectMenu.SelectedItem.ToString()=="USB"){
				
	            var ProcessList_python = scope.GetVariable<Func<object,object,object,object>>("ProcessList");

	            List ProcessList = new List();
            
	            LoadingForm f = new LoadingForm();
				f.Function = (() => {  					
					ProcessList = (List)ProcessList_python(".\\Lib\\application.py","U","");
				              });
				f.StartPosition = FormStartPosition.CenterParent;
				f.ShowDialog();
 
	            List<string> ProcessList_C = new List<string>();
	            
	            ProcessList_C.Clear();
	            
	            foreach (string data in ProcessList)
	            {
	            	ProcessList_C.Add(data);	
	            }
	            
	            Process_View.Items.Clear();

	            if(ProcessList_C[0]=="Failed"){
	            	MessageBox.Show("Frdia-Server Start Plz....");
	            }else{
					int i=2;
					while(true){
						int testnum=0;				
						ListViewItem lvt = new ListViewItem();
							
						if(int.TryParse(ProcessList_C[i], out testnum)){
					    	lvt.Text = ProcessList_C[i];
							i++;
						}
						if(i+1<ProcessList_C.Count){
							if(!int.TryParse(ProcessList_C[i+1], out testnum)){
								if(!int.TryParse(ProcessList_C[i+2], out testnum)){
									lvt.SubItems.Add(""+ProcessList_C[i]+" "+ProcessList_C[i+1]+" "+ProcessList_C[i+1]);
									i=i+2;									
								}else{
									lvt.SubItems.Add(""+ProcessList_C[i]+" "+ProcessList_C[i+1]);
									i++;
								}
							}else if(ProcessList_C[i]=="Flex"){
								lvt.SubItems.Add(""+ProcessList_C[i]+" "+ProcessList_C[i+1]);
								i++;
							}else{
								lvt.SubItems.Add(ProcessList_C[i]);
							}
							i++;
						}else{
							lvt.SubItems.Add(ProcessList_C[i]);
							break;
						}
					Process_View.Items.Add(lvt);
					Process_View.FullRowSelect = true;
				    }	
				Process_View.EndUpdate();	
	           }
			}else if(SelectMenu.SelectedItem.ToString()=="DEVICE"){
				
	            var ProcessList_python = scope.GetVariable<Func<object,object,object,object>>("ProcessList");
	            string address = AddressInsert.Text.ToString();
	            
	           	List ProcessList = new List();
            
	            LoadingForm f = new LoadingForm();
				f.Function = (() => {  
					ProcessList = (List)ProcessList_python(".\\Lib\\application.py","D",address);
				              });
				f.StartPosition = FormStartPosition.CenterParent;
				f.ShowDialog();
				
	            List<string> ProcessList_C = new List<string>();
	            
	            ProcessList_C.Clear();
	            
	            foreach (string data in ProcessList)
	            {
	            	ProcessList_C.Add(data);
	            }
	            
	            Process_View.Items.Clear();
				
	            if(ProcessList_C[0]=="Failed"){
	            	MessageBox.Show("Frdia-Server Start Plz....");
	            }else{
					int i=2;
					while(true){
						int testnum=0;				
						ListViewItem lvt = new ListViewItem();
							
						if(int.TryParse(ProcessList_C[i], out testnum)){
					    	lvt.Text = ProcessList_C[i];
							i++;
						}
						if(i+1<ProcessList_C.Count){
							if(!int.TryParse(ProcessList_C[i+1], out testnum)){
								if(!int.TryParse(ProcessList_C[i+2], out testnum)){
									lvt.SubItems.Add(""+ProcessList_C[i]+" "+ProcessList_C[i+1]+" "+ProcessList_C[i+1]);
									i=i+2;									
								}else{
									lvt.SubItems.Add(""+ProcessList_C[i]+" "+ProcessList_C[i+1]);
									i++;
								}
							}else if(ProcessList_C[i]=="Flex"){
								lvt.SubItems.Add(""+ProcessList_C[i]+" "+ProcessList_C[i+1]);
								i++;
							}else{
								lvt.SubItems.Add(ProcessList_C[i]);
							}
							i++;
						}else{
							lvt.SubItems.Add(ProcessList_C[i]);
							break;
						}
					Process_View.Items.Add(lvt);
					Process_View.FullRowSelect = true;
				    }	
				Process_View.EndUpdate();	
	           }
			}else{
				MessageBox.Show("error");						
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
		
		void FridaServerInstall_Click(object sender, EventArgs e)
		{
			
			if (selectedDevice==""){
				MessageBox.Show("Device Select Plz....");
			}else{
				System.Diagnostics.ProcessStartInfo proInfo = new System.Diagnostics.ProcessStartInfo();
				System.Diagnostics.Process pro = new System.Diagnostics.Process();
				proInfo.FileName = @"cmd";
				proInfo.CreateNoWindow = true;
				proInfo.UseShellExecute = false;
				proInfo.RedirectStandardOutput=true;
				proInfo.RedirectStandardInput=true;
				proInfo.RedirectStandardError=true;
				pro.StartInfo = proInfo;
				pro.Start();
				
				LoadingForm f = new LoadingForm();
				f.Function = (() => {  
				    if(Emulator_RadioButton.Checked){
						pro.StandardInput.Write(@"adb -s "+selectedDevice+" push ./Lib/frida-server-android-x86 /data/local/tmp/" + Environment.NewLine);
						pro.StandardInput.Write(@"adb -s "+selectedDevice+" shell chmod 777 /data/local/tmp/frida-server-android-x86" + Environment.NewLine);							              		
				   	}else{
						pro.StandardInput.Write(@"adb -s "+selectedDevice+" push ./Lib/frida-server-android-arm /data/local/tmp/" + Environment.NewLine);
						pro.StandardInput.Write(@"adb -s "+selectedDevice+" shell su -c \"chmod 777 /data/local/tmp/frida-server-android-arm\"" + Environment.NewLine);			
				    }
					pro.StandardInput.Close();
					pro.WaitForExit();					              	
				              });
				f.StartPosition = FormStartPosition.CenterParent;
				f.ShowDialog();

				pro.Close();
				
				var engine = IronPython.Hosting.Python.CreateEngine();
				var scope = engine.CreateScope();
				var source = engine.CreateScriptSourceFromString(code, Microsoft.Scripting.SourceCodeKind.Statements);
				source.Execute(scope);
				var cmd_Python = scope.GetVariable<Func<string, string>>("CMD_python");
				
				string cmd_FridaServerFile_View ="";
				string cmd_FridaServerFile="";
					
				if(Emulator_RadioButton.Checked){
					cmd_FridaServerFile = "adb -s "+selectedDevice+" shell \"ls -al /data/local/tmp/ | grep frida-server-android-x86\"";
				}else{
					cmd_FridaServerFile = "adb -s "+selectedDevice+" shell \"ls -al /data/local/tmp/ | grep frida-server-android-arm\"";
				}
				
				LoadingForm f2 = new LoadingForm();
				f2.Function = (() => {  
					cmd_FridaServerFile_View = cmd_Python(cmd_FridaServerFile);
				              });
				f2.StartPosition = FormStartPosition.CenterParent;
				f2.ShowDialog();
				
				cmd_view.AppendText("-----------------------------------------------------\r\n");			
				cmd_view.AppendText(cmd_FridaServerFile_View);
				cmd_view.AppendText("-----------------------------------------------------\r\n");
				cmd_view.AppendText("[+] FridaSever Install Complete\r\n");					
			}
			
		}
		
		void FridaServerEXE_buttonClick(object sender, EventArgs e)
		{
			if (selectedDevice==""){
				MessageBox.Show("Device Select Plz....");
			}else{
				System.Diagnostics.ProcessStartInfo proInfo = new System.Diagnostics.ProcessStartInfo();
				System.Diagnostics.Process pro = new System.Diagnostics.Process();
				proInfo.FileName = @"cmd";
				proInfo.CreateNoWindow = true;
				proInfo.UseShellExecute = false;
				proInfo.RedirectStandardOutput=true;
				proInfo.RedirectStandardInput=true;
				proInfo.RedirectStandardError=true;
				pro.StartInfo = proInfo;
				pro.Start();
				
				LoadingForm f = new LoadingForm();
				f.Function = (() => {
				    if(Emulator_RadioButton.Checked){
				    	pro.StandardInput.Write(@"adb -s "+selectedDevice+" shell /data/local/tmp/frida-server-android-x86 &" + Environment.NewLine);					              	
				    }else{
						pro.StandardInput.Write(@"adb -s "+selectedDevice+" shell su -c \"/data/local/tmp/frida-server-android-arm &\"" + Environment.NewLine);
				    }
					pro.StandardInput.Close();
					pro.WaitForExit(200);
				              });
				f.StartPosition = FormStartPosition.CenterParent;
				f.ShowDialog();
				pro.Close();
				
				var engine = IronPython.Hosting.Python.CreateEngine();
				var scope = engine.CreateScope();
				var source = engine.CreateScriptSourceFromString(code, Microsoft.Scripting.SourceCodeKind.Statements);
				source.Execute(scope);
	            
				var cmd_Python = scope.GetVariable<Func<string, string>>("CMD_python");
				string cmd_FridaServerPS_View = "";
				string cmd_FridaServerPS = "adb -s "+selectedDevice+" shell \"ps | grep frida-server-*\"";

				LoadingForm f2 = new LoadingForm();
				f2.Function = (() => {  
					cmd_FridaServerPS_View = cmd_Python(cmd_FridaServerPS);
				              });
				f2.StartPosition = FormStartPosition.CenterParent;
				f2.ShowDialog();				

				cmd_view.AppendText("-----------------------------------------------------\r\n");			
				cmd_view.AppendText(cmd_FridaServerPS_View);
				cmd_view.AppendText("-----------------------------------------------------\r\n");
				cmd_view.AppendText("[+] FridaSever Start Complete\r\n");
			}
			
		}		
		
		void Memory_Dump_ButtonClick(object sender, EventArgs e)
		{
			if (selectedProcessName==""){
				MessageBox.Show("Process Select Plz....");
			}else{
				System.Diagnostics.ProcessStartInfo proInfo = new System.Diagnostics.ProcessStartInfo();
				System.Diagnostics.Process pro = new System.Diagnostics.Process();
				
				proInfo.FileName = @"cmd";
				proInfo.CreateNoWindow = true;
				proInfo.UseShellExecute = false;
				
				proInfo.RedirectStandardOutput=true;
				proInfo.RedirectStandardInput=true;
				proInfo.RedirectStandardError=true;
				
				pro.StartInfo.WorkingDirectory = filePath+@"/";
				pro.StartInfo = proInfo;			
				pro.Start();
				
				string sDirPath;
	            sDirPath = Application.StartupPath + "\\Dump\\Memory_Dump\\"+selectedProcessName;
	            DirectoryInfo di = new DirectoryInfo(sDirPath);
	            if (di.Exists == false)
	            {
	                di.Create();
	            }

				LoadingForm f = new LoadingForm();
				f.Function = (() => {				              	
					pro.StandardInput.Write(@".\\Lib\\fridump.py -u -s -o "".\\Dump\\Memory_Dump\\"+selectedProcessName+"\" "+selectedPID+""+Environment.NewLine);				
					pro.StandardInput.Close();				
					pro.WaitForExit();
				              });
				f.StartPosition = FormStartPosition.CenterParent;
				f.ShowDialog();	
				pro.Close();				
				
				cmd_view.AppendText("-----------------------------------------------------\r\n");				
				cmd_view.AppendText("[+] "+selectedProcessName+" Memory_Dump Complete\r\n");
			}
		}
		
		void Data_Dump_ButtonClick(object sender, EventArgs e)
		{
			if (selectedDevice==""||selectedProcessName==""){
				MessageBox.Show("Device && Process Select Plz....");
			}else{
				System.Diagnostics.ProcessStartInfo proInfo = new System.Diagnostics.ProcessStartInfo();
				System.Diagnostics.Process pro = new System.Diagnostics.Process();
				
				proInfo.FileName = @"cmd";
				proInfo.CreateNoWindow = true;
				proInfo.UseShellExecute = false;
				
				proInfo.RedirectStandardOutput=true;
				proInfo.RedirectStandardInput=true;
				proInfo.RedirectStandardError=true;
				
				pro.StartInfo.WorkingDirectory = filePath+@"/";
				pro.StartInfo = proInfo;			
				pro.Start();
				
				string sDirPath;
	            sDirPath = Application.StartupPath + "\\Dump\\Data_Dump\\"+selectedProcessName;
	            DirectoryInfo di = new DirectoryInfo(sDirPath);
	            if (di.Exists == false)
	            {
	                di.Create();
	            }

				LoadingForm f = new LoadingForm();
				f.Function = (() => {
				    if(Emulator_RadioButton.Checked){
						pro.StandardInput.Write(@"adb -s "+selectedDevice+" shell chmod -R 777 /data/data/"+selectedProcessName+"" + Environment.NewLine);				              		
				    }else{
						pro.StandardInput.Write(@"adb -s "+selectedDevice+" shell su -c \"chmod -R 777 /data/data/"+selectedProcessName+"\"" + Environment.NewLine);
				    }				              	
		            pro.StandardInput.Write(@"adb -s "+selectedDevice+" pull /data/data/"+selectedProcessName+" .\\Dump\\Data_Dump\\"+selectedProcessName+""+ Environment.NewLine);
				              });
				f.StartPosition = FormStartPosition.CenterParent;
				f.ShowDialog();	            
				pro.StandardInput.Close();
				pro.StandardOutput.ReadToEnd();
				pro.WaitForExit();
				pro.Close();
				
				var engine = IronPython.Hosting.Python.CreateEngine();
				var scope = engine.CreateScope();
				var source = engine.CreateScriptSourceFromString(code, Microsoft.Scripting.SourceCodeKind.Statements);
				source.Execute(scope);
	            
				var cmd_Python = scope.GetVariable<Func<string, string>>("CMD_python");
				
				string cmd_DataDumpFile_View ="";
				string cmd_DataDumpFile = "";
				if(Emulator_RadioButton.Checked){
					cmd_DataDumpFile = "adb -s "+selectedDevice+" shell \"ls -al /data/data/ | grep "+selectedProcessName+"\"";			              		
				}else{
					cmd_DataDumpFile = "adb -s "+selectedDevice+" shell su -c \"ls -al /data/data/ | grep "+selectedProcessName+"\"";
				}	
				 

				LoadingForm f2 = new LoadingForm();
				f2.Function = (() => {  
					cmd_DataDumpFile_View = cmd_Python(cmd_DataDumpFile);
				              });
				f2.StartPosition = FormStartPosition.CenterParent;
				f2.ShowDialog();
				
				cmd_view.AppendText("-----------------------------------------------------\r\n");			
				cmd_view.AppendText(cmd_DataDumpFile_View);
				cmd_view.AppendText("-----------------------------------------------------\r\n");
				cmd_view.AppendText("[+] "+selectedProcessName+" Data_Dump Complete\r\n");
			}
		}

		
		void CMD_Usage_Manual_buttonClick(object sender, EventArgs e)
		{
			
				string CMD_Usage_Manual = @"-----------------------------------------------------
[CMD Usage] How to run it manually
[frida-server Start]
adb -s [devices] shell su -c ""/data/local/tmp/frida-server &""
[Memory Dump]
.\Lib\Orignal_fridump.py -u -s -o "".\Dump\Memory_Dump\[ProcessName]"" [ProcessName or PID]
-----------------------------------------------------
";
				cmd_view.AppendText(CMD_Usage_Manual);
			
		}
		
		
	}
}
