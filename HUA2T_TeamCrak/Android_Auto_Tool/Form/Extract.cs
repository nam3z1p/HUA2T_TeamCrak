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
	/// Description of Extract.
	/// </summary>
	public partial class Extract : Form
	{
		
		string filePath = Application.StartupPath;
		string selectedFileExtractName = "";
		string selectedFolderExtractName = "";
		string selectedImageFile = "";
		string code = @"
import clr
clr.AddReference('stdlib')

import sys,mmap,os,time,shutil,System,hashlib
from glob import glob

def Output_Extract_delete():
	if os.path.exists('./Extract_File/Extract_Output'):
		shutil.rmtree('./Extract_File/Extract_Output', ignore_errors=False)	
		
def Directory_Image_Extract(dirname):
    filenames = os.listdir(dirname)

    for filename in filenames:
        full_filename = os.path.join(dirname, filename)
        if (os.path.getsize(full_filename)):
        	extract_jpg(full_filename)
        	extract_png(full_filename)
        	extract_gif(full_filename)
        
def File_Image_Extract(filename):
    extract_jpg(filename)
    extract_png(filename)
    extract_gif(filename)        
			
def extract_jpg(fname):
    header = reduce(lambda x, y: x+y, map(chr, [0xff, 0xd8, 0xff, 0xe0]))
    trailer = reduce(lambda x, y: x+y, map(chr, [0xff, 0xd9]))
    type = 'jpg'
    extract_file(fname, header, trailer, type)

def extract_png(fname):
	header = reduce(lambda x, y: x+y, map(chr, [0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A]))
	trailer = reduce(lambda x, y: x+y, map(chr, [0x49, 0x45, 0x4E, 0x44, 0xAE, 0x42, 0x60, 0x82]))
	type = 'png'
	extract_file(fname, header, trailer, type)

def extract_gif(fname):
	header = reduce(lambda x, y: x+y, map(chr, [0x47, 0x49, 0x46, 0x38, 0x39, 0x61]))
	trailer = reduce(lambda x, y: x+y, map(chr, [0x00, 0x3B]))
	type = 'gif'
	extract_file(fname, header, trailer, type)
	
def extract_file(fname, header, trailer, type):
	found_idx = 0
   		
	with open(fname, 'r+b') as f:
		fmap = mmap.mmap(f.fileno(), 0)

		pos = fmap.find(header)
		while pos != -1:
			pos_old = pos	   
			pos_tr = fmap.find(trailer, pos + 4)
			pos = fmap.find(header, pos + 2)
			
			onlyfname = fname.split('\\')[-1]
			
			ExtractOutputFolder = './Extract_File/Extract_Output/%s/'%(onlyfname)
			if not os.path.exists(ExtractOutputFolder):
				os.mkdir(ExtractOutputFolder)
			
			fout = open('%s%s_%s.%s' % (ExtractOutputFolder, type, str(found_idx), type), 'wb')
			fmap.seek(pos_old)
			if pos == -1 :
				fout.write(fmap.read(pos_tr - pos_old + 2))
			else :
				fout.write(fmap.read(min(pos,pos_tr) - pos_old + 2))
			fout.close()
			found_idx = found_idx + 1
		fmap.close()

def Extract_Image_List():
	basedir = r'.\Extract_File\Extract_Output'
	files = []
	if os.path.isdir(basedir):
		files = System.IO.Directory.GetFiles(basedir)
	
		a = glob(basedir + '/*/')
		while True:
		    try:
		        files += System.IO.Directory.GetFiles(a.pop())
		    except:
		        break
		
		files=filter(lambda f: f.endswith(('.png','.jpg','.jpeg','.gif')), files)
		return files
	return files
	
def HashCheck(filepath):
    f = open(filepath, 'rb')
    data = f.read()
    f.close()

    hashdata = []
    hashdata.append(str(os.path.getsize(filepath)))
    hashdata.append(hashlib.md5(data).hexdigest())
    return hashdata
";
				
		
		public Extract()
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

		void ExtractFile_ViewSelectedIndexChanged(object sender, EventArgs e)
		{
			selectedImageFile = ExtractFile_View.Items[ExtractFile_View.FocusedItem.Index].SubItems[0].Text;
			if (Image_View.Image != null){
				Image_View.Image.Dispose();
			}
			Bitmap bmp = new Bitmap(selectedImageFile);
			Image_View.Image = bmp;
		}
		
		void FileOpen_Click(object sender, EventArgs e)
		{
			selectedFolderExtractName = "";			
			OpenFileDialog open = new OpenFileDialog();
			
			open.Filter = "ALLFiles(*.*)|*.*";
			open.InitialDirectory=filePath+@"\Extract_File";
			open.Title = "FILE OPEN";
			
			if(open.ShowDialog() == DialogResult.OK)
			{	
				string filefullname = open.FileName;
				string onlyfilename = filefullname.Substring(filefullname.LastIndexOf("\\")+1);
				this.FileOpenView.Text = onlyfilename;
				selectedFileExtractName = filefullname;
			}
			
		}
		
		void DirectoryOpen_Click(object sender, EventArgs e)
		{
			selectedFileExtractName = "";			
			FolderBrowserDialog open = new FolderBrowserDialog();
			open.SelectedPath=filePath+@"\Extract_File\";
			
			if(open.ShowDialog() == DialogResult.OK)
			{	
				string fullFoldername = open.SelectedPath;
				string onlyfilename = fullFoldername.Substring(fullFoldername.LastIndexOf("\\")+1);
				this.FileOpenView.Text = onlyfilename;
				selectedFolderExtractName = fullFoldername;
			}
		}
		
		
		void ExtractImage_View_ListSave()
		{
			var engine = IronPython.Hosting.Python.CreateEngine();
			var scope = engine.CreateScope();

			var source = engine.CreateScriptSourceFromString(code, Microsoft.Scripting.SourceCodeKind.Statements);
			source.Execute(scope);
			
			var ExtractImageList_python = scope.GetVariable<Func<object>>("Extract_Image_List");           
			var HashCheck = scope.GetVariable<Func<object, object>>("HashCheck");				
			
			List ExtractImageList = (List)ExtractImageList_python();
            List<string> ExtractImageList_C = new List<string>();
            ExtractFile_View.Items.Clear();
            
            foreach (string data in ExtractImageList)
            {
            	List orignal_hashDataList = (List)HashCheck(data);
		        List<string> orignal_hashDataList_C = new List<string>();
		            
		        foreach (string hashData in orignal_hashDataList)
		        {
		          	orignal_hashDataList_C.Add(hashData);
		        }
				
		        ListViewItem lvt = new ListViewItem();
		        lvt.Text = data;
		        lvt.SubItems.Add(orignal_hashDataList_C[0]);
		        lvt.SubItems.Add(orignal_hashDataList_C[1]);
		        ExtractFile_View.Items.Add(lvt);
		        ExtractFile_View.FullRowSelect = true;
            }
            ExtractFile_View.EndUpdate();
		}
		
		void Extract_Click(object sender, EventArgs e)
		{			
			if (Image_View.Image != null){
				Image_View.Image.Dispose();
			}
			
			var engine = IronPython.Hosting.Python.CreateEngine();
			var scope = engine.CreateScope();
			var source = engine.CreateScriptSourceFromString(code, Microsoft.Scripting.SourceCodeKind.Statements);
			source.Execute(scope);
            
			var File_Image_Extract = scope.GetVariable<Func<string, string>>("File_Image_Extract");
			var Directory_Image_Extract = scope.GetVariable<Func<string, string>>("Directory_Image_Extract");
			var Output_Extract_delete = scope.GetVariable<Func<string>>("Output_Extract_delete");
			
			if(selectedFileExtractName!=""){
				Output_Extract_delete();
				LoadingForm f = new LoadingForm();
				f.Function = (() => {  					
					File_Image_Extract(selectedFileExtractName);
				              });
				f.StartPosition = FormStartPosition.CenterParent;
				f.ShowDialog();
				ExtractImage_View_ListSave();
			}else if (selectedFolderExtractName!=""){
				Output_Extract_delete();				
				LoadingForm f = new LoadingForm();
				f.Function = (() => {  
					Directory_Image_Extract(selectedFolderExtractName);
				              });
				f.StartPosition = FormStartPosition.CenterParent;
				f.ShowDialog();
				ExtractImage_View_ListSave();				
			}else{
				MessageBox.Show("plz... FileOpen");
			}
				
		}
		
	}
}
