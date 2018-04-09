using System;
using System.Diagnostics;
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
	/// Description of Form1.
	/// </summary>
	public partial class Hook : Form
	{
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]		
		static extern bool AllocConsole();
		
		[DllImport("kernel32.dll", SetLastError = true)]
		static extern bool FreeConsole();

		string filePath = Application.StartupPath;
		string selectedMenu = "";
		string selectedPID = "";
		string selectedJsFilename="";
		string code = @"
import clr
clr.AddReference('stdlib')
import os, sys, subprocess
from threading import Timer

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
		
";
					
		
		public Hook()
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
		}

		System.Diagnostics.Process pro = new System.Diagnostics.Process();

		void Hooking_button_Click(object sender, EventArgs e)
		{
			
			AllocConsole();
			System.Diagnostics.ProcessStartInfo proInfo = new System.Diagnostics.ProcessStartInfo();
		
			proInfo.FileName = @"cmd";
			proInfo.CreateNoWindow = false;
			proInfo.UseShellExecute = false;
			proInfo.RedirectStandardInput=true;
			pro.StartInfo = proInfo;
			pro.Start();
			
			if(Mobile_RadioButton.Checked){
				pro.StandardInput.Write(@".\\Lib\\fridaHook.py -S .\Lib\hookcode\"+selectedJsFilename+" "+selectedPID+"" + Environment.NewLine);
			}
			if(iOS_ClassDump_radioButton.Checked){
				pro.StandardInput.Write(@".\\Lib\\fridaHook.py -S .\Lib\hookcode\"+selectedJsFilename+" -C "+selectedPID+"" + Environment.NewLine);
			}
			if(Windows_radioButton.Checked){
				pro.StandardInput.Write(@".\\Lib\\fridaHook.py -S .\Lib\hookcode\"+selectedJsFilename+" -W "+selectedPID+"" + Environment.NewLine);
			}
			pro.Close();
			FreeConsole();
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
			if(Windows_radioButton.Checked){
				
	            var ProcessList_python = scope.GetVariable<Func<object,object,object,object>>("ProcessList");
	            List ProcessList = new List();
            
	            LoadingForm f = new LoadingForm();
				f.Function = (() => {  					
					ProcessList = (List)ProcessList_python(".\\Lib\\application.py","","");
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
				
			}else if (SelectMenu.SelectedItem.ToString()=="USB"){

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
		
		void JsFileOpen_Click(object sender, EventArgs e)
		{
			OpenFileDialog open = new OpenFileDialog();
			
			open.Filter = "JS FILE(*.js)|*.js|ALLFiles(*.*)|*.*";
			open.InitialDirectory=filePath+@"\Lib\hookcode";
			open.Title = "FILE OPEN";
			
			if(open.ShowDialog() == DialogResult.OK)
			{	
				string filefullname = open.FileName;
				string onlyfilename = filefullname.Substring(filefullname.LastIndexOf("\\")+1);
				this.FileOpenView.Text = onlyfilename;
				selectedJsFilename = onlyfilename;
			}
		}
	}
}
