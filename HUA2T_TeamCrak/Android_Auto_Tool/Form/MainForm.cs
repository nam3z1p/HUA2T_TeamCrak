using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Android_Auto_Tool
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			// First form load
	        TabPage tpFirst = new TabPage(); // Create
	        tpFirst.Controls.Add(new Auto_Tool()); // Load form
	        tpFirst.Controls[0].Show();
	        tpFirst.Text = "Auto_Tool";
	
	        tabControl1.Controls.Add(tpFirst); // Add page
	
	        // Second form load
	        TabPage tpSecond = new TabPage();
	        tpSecond.Controls.Add(new HashCheck());
	        tpSecond.Controls[0].Show();
	        tpSecond.Text = "HashCheck";
	
	        tabControl1.Controls.Add(tpSecond);
	        
	        // Third form load
	        TabPage tpThird = new TabPage();
	        tpThird.Controls.Add(new ScreenShot());
	        tpThird.Controls[0].Show();
	        tpThird.Text = "ScreenShot";
	
	        tabControl1.Controls.Add(tpThird);
	        
	        // Fourth form load
	        TabPage tpFourth = new TabPage();
	        tpFourth.Controls.Add(new Extract());
	        tpFourth.Controls[0].Show();
	        tpFourth.Text = "FileExtract";
	
	        tabControl1.Controls.Add(tpFourth);	

			// Fifth form load
	        TabPage tpFifth = new TabPage();
	        tpFifth.Controls.Add(new Dump());
	        tpFifth.Controls[0].Show();
	        tpFifth.Text = "MemoryDump";
	
	        tabControl1.Controls.Add(tpFifth);	      	        

			// Sixth form load
	        TabPage tpSixth = new TabPage();
	        tpSixth.Controls.Add(new Hook());
	        tpSixth.Controls[0].Show();
	        tpSixth.Text = "FunctionHook";
	
	        tabControl1.Controls.Add(tpSixth);	 	
	
	        // Seven form load
	        TabPage tpSeven = new TabPage();
	        tpSeven.Controls.Add(new RootingBypass());
	        tpSeven.Controls[0].Show();
	        tpSeven.Text = "RootingBypass";
	
	        tabControl1.Controls.Add(tpSeven);	        
		}
		
		void Form_Closing(object sender, FormClosingEventArgs e)
		{
				
			Process[] processList = Process.GetProcessesByName("adb");
			
			if(processList.Length >0){
				processList[0].Kill();
			}

		}
	}
}
