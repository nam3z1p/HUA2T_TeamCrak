using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;



namespace Android_Auto_Tool
{
	/// <summary>
	/// Description of LoadingForm.
	/// </summary>
	public partial class LoadingForm : Form
	{
	
	    public Action Function { get; set; }
	 
	    public LoadingForm()
	    {			
	        InitializeComponent();
	        this.Shown += new EventHandler(Form_Loaded);
	 
	    }
	    private void Form_Loaded(object sender, EventArgs e)
	    {
	        var thread = new Thread(
	            () =>
	            {
	                Function.Invoke();
	                this.Invoke(
	                    (Action)(() =>
	                    {
	                        this.Close();
	                    }));
	            });
	        thread.Start();
	    }
	}
}