using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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
	/// Description of RootingBypass.
	/// </summary>
	public partial class RootingBypass : Form
	{
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]		
		static extern bool AllocConsole();
		
		[DllImport("kernel32.dll", SetLastError = true)]
		static extern bool FreeConsole();		

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
			
		
		public RootingBypass()
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
		
		System.Diagnostics.Process pro = new System.Diagnostics.Process();
		
		void RootingBypassStart_ButtonClick(object sender, EventArgs e)
		{

			AllocConsole();
			System.Diagnostics.ProcessStartInfo proInfo = new System.Diagnostics.ProcessStartInfo();
		
			proInfo.FileName = @"cmd";
			proInfo.CreateNoWindow = false;
			proInfo.UseShellExecute = false;
			proInfo.RedirectStandardInput=true;
			pro.StartInfo = proInfo;
			pro.Start();
			pro.StandardInput.Write(@"adb -s "+selectedDevice+" shell su -c \"/data/local/tmp/rootingbypass "+selectedProcessName+"\"" + Environment.NewLine);
			pro.Close();
			FreeConsole();
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
		
		void RootingBypassInstall_buttonClick(object sender, EventArgs e)
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
					pro.StandardInput.Write(@"adb -s "+selectedDevice+" push ./Lib/rootingbypass /data/local/tmp/" + Environment.NewLine);
					pro.StandardInput.Write(@"adb -s "+selectedDevice+" push ./Lib/targetlist.dat /data/local/tmp/" + Environment.NewLine);					
					pro.StandardInput.Write(@"adb -s "+selectedDevice+" shell su -c \"chmod 777 /data/local/tmp/rootingbypass\"" + Environment.NewLine);
					pro.StandardInput.Write(@"adb -s "+selectedDevice+" shell su -c \"chmod 777 /data/local/tmp/targetlist.dat\"" + Environment.NewLine);
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
				
				string cmd_RootingBypassFile_View ="";
				string cmd_RootingBypassFile="";

				cmd_RootingBypassFile = "adb -s "+selectedDevice+" shell \"ls -al /data/local/tmp/ | grep rootingbypass\"";
				
				LoadingForm f2 = new LoadingForm();
				f2.Function = (() => {  
					cmd_RootingBypassFile_View = cmd_Python(cmd_RootingBypassFile);
				              });
				f2.StartPosition = FormStartPosition.CenterParent;
				f2.ShowDialog();
				
				cmd_view.AppendText("-----------------------------------------------------\r\n");			
				cmd_view.AppendText(cmd_RootingBypassFile_View);
				cmd_view.AppendText("-----------------------------------------------------\r\n");
				cmd_view.AppendText("[+] RootingBypass Install Complete\r\n");					
			}
		}
	}
}
