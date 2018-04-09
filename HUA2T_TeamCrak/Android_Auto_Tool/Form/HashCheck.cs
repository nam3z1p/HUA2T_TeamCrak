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
	/// Description of HashCheck.
	/// </summary>
	public partial class HashCheck : Form
	{
		
		string filePath = Application.StartupPath;
		string orignalFileName = "";
		string signedFileName = "";
		string code = @"
import clr
clr.AddReference('stdlib')
import os, sys, hashlib

def HashCheck(filepath):
    f = open(filepath, 'rb')
    data = f.read()
    f.close()

    hashdata = []
    hashdata.append(str(os.path.getsize(filepath)))
    hashdata.append(hashlib.md5(data).hexdigest())
    hashdata.append(hashlib.sha1(data).hexdigest())
    hashdata.append(hashlib.sha256(data).hexdigest())
    return hashdata

";
		
		public HashCheck()
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
		
		void Original_FileClickClick(object sender, EventArgs e)
		{
			OpenFileDialog open = new OpenFileDialog();
			
			open.Filter = "APK FILE(*.apk)|*.apk|ALLFiles(*.*)|*.*";
			open.InitialDirectory=filePath+@"\Input_File";
			open.Title = "FILE OPEN";
			
			if(open.ShowDialog() == DialogResult.OK)
			{	
				string filefullname = open.FileName;
				string onlyfilename = filefullname.Substring(filefullname.LastIndexOf("\\")+1);
				this.Original_Filename_View.Text = onlyfilename;
				orignalFileName = onlyfilename;
			}
		}
		
		void Signed_FileClickClick(object sender, EventArgs e)
		{
			
			OpenFileDialog open = new OpenFileDialog();
			
			open.Filter = "APK FILE(*.apk)|*.apk|ALLFiles(*.*)|*.*";
			open.InitialDirectory=filePath+@"\Output_SignedFile";
			open.Title = "FILE OPEN";
			
			if(open.ShowDialog() == DialogResult.OK)
			{	
				string filefullname = open.FileName;
				string onlyfilename = filefullname.Substring(filefullname.LastIndexOf("\\")+1);
				this.Signed_Filename_View.Text = onlyfilename;
				signedFileName = onlyfilename;
			}
		}
		

		void HashCheck_Click(object sender, EventArgs e)
		{
			
			var engine = IronPython.Hosting.Python.CreateEngine();
			var scope = engine.CreateScope();
			var source = engine.CreateScriptSourceFromString(code, Microsoft.Scripting.SourceCodeKind.Statements);
			source.Execute(scope);
			var HashCheck = scope.GetVariable<Func<object, object>>("HashCheck");	
			
			if(orignalFileName!=""&&signedFileName!=""){
				
				List orignal_hashDataList = (List)HashCheck(".\\Input_FIle\\"+orignalFileName);
	            List<string> orignal_hashDataList_C = new List<string>();
	            
	            foreach (string data in orignal_hashDataList)
	            {
	            	orignal_hashDataList_C.Add(data);
	            }
	            
	            Original_FileHash_View.Clear();
				
	            Original_FileHash_View.AppendText("Orignal_FileName : "+orignalFileName+"\r\n");
	            Original_FileHash_View.AppendText("---------------------------------------------------------------------------------------------------------\r\n");
	            Original_FileHash_View.AppendText("File_Size	 :  "+orignal_hashDataList_C[0]+" Byte\r\n");
	            Original_FileHash_View.AppendText("MD5	 :  "+orignal_hashDataList_C[1]+" \r\n");
	            Original_FileHash_View.AppendText("SHA-1	 :  "+orignal_hashDataList_C[2]+" \r\n");
	            Original_FileHash_View.AppendText("SHA-256	 :  "+orignal_hashDataList_C[3]+" \r\n");

	            List signed_hashDataList = (List)HashCheck(".\\Output_SignedFile\\"+signedFileName);
	            List<string> signed_hashDataList_C = new List<string>();
	            
	            foreach (string data in signed_hashDataList)
	            {
	            	signed_hashDataList_C.Add(data);
	            }

	            Signed_FileHash_View.Clear();
	            Signed_FileHash_View.AppendText("Signed_FileName : "+signedFileName+"\r\n");
	            Signed_FileHash_View.AppendText("---------------------------------------------------------------------------------------------------------\r\n");
	            Signed_FileHash_View.AppendText("File_Size	 :  "+signed_hashDataList_C[0]+" Byte\r\n");
	            Signed_FileHash_View.AppendText("MD5	 :  "+signed_hashDataList_C[1]+" \r\n");
	            Signed_FileHash_View.AppendText("SHA-1	 :  "+signed_hashDataList_C[2]+" \r\n");
	            Signed_FileHash_View.AppendText("SHA-256	 :  "+signed_hashDataList_C[3]+" \r\n");
			}else{
				MessageBox.Show("plz... FileOpen");
			}

		}

	}
}
