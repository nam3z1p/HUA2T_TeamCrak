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
	/// Description of ScreenShot.
	/// </summary>
	public partial class ScreenShot : Form
	{
		
		string filePath = Application.StartupPath;
		string selectedMenu = "";
		string selectedDevice = "";
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
		
";
		
		public ScreenShot()
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

		void SelectMenuSelectedIndexChanged(object sender, EventArgs e)
		{
			selectedMenu = SelectMenu.SelectedItem.ToString();
			
			if (SelectMenu.SelectedItem.ToString()=="Resize"){
				Width_TextBox.ReadOnly = false;
				Width_TextBox.BackColor = System.Drawing.SystemColors.Window;
				Height_TextBox.ReadOnly = false;
				Height_TextBox.BackColor = System.Drawing.SystemColors.Window;
			}else{
				Width_TextBox.ReadOnly = true;
				Width_TextBox.BackColor = System.Drawing.SystemColors.Control;			
				Height_TextBox.ReadOnly = true;
				Height_TextBox.BackColor = System.Drawing.SystemColors.Control;	
			}
		}
		
		void DeviceViewSelectedIndexChanged(object sender, EventArgs e)
		{
			string[] selectedDevice1 = DeviceView.SelectedItem.ToString().Split(',');
			selectedDevice = selectedDevice1[0];
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
		

		void Capture_buttonClick(object sender, EventArgs e)
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

				pro.StandardInput.Write(@"adb -s "+selectedDevice+" shell screencap -p /sdcard/temp_image.jpg" + Environment.NewLine);
				pro.StandardInput.Write(@"adb -s "+selectedDevice+" pull /sdcard/temp_image.jpg ./ScreenShot/temp_image.jpg" + Environment.NewLine);
				pro.StandardInput.Write(@"adb -s "+selectedDevice+" shell rm /sdcard/temp_image.jpg" + Environment.NewLine);
				
				pro.StandardInput.Close();
				pro.WaitForExit();
				pro.Close();
				
				Bitmap bmp = new Bitmap(".\\ScreenShot\\temp_image.jpg");
				Size resize = new Size(430,760);
				
				if (SelectMenu.SelectedItem.ToString() == "Resize"){
					resize.Height =  Convert.ToInt32(Height_TextBox.Text.ToString());
					resize.Width = Convert.ToInt32(Width_TextBox.Text.ToString());
				}
				
				Bitmap resizeImage = new Bitmap(bmp, resize);
				
				int i=0;
				while(true){				
					if(!File.Exists(".\\ScreenShot\\image_"+(++i).ToString()+".jpg")){
						resizeImage.Save(".\\ScreenShot\\image_"+i.ToString()+".jpg");
						break;
					}
				}
	
				Image_View.Image = resizeImage;
				bmp.Dispose();
				pro.StartInfo = proInfo;
				pro.Start();
				pro.StandardInput.Write(@"del /Q .\\ScreenShot\\temp_image.jpg" + Environment.NewLine);
				pro.StandardInput.Close();
				pro.WaitForExit();
				pro.Close();
			}
		}
		
	}
}
