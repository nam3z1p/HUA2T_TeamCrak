/*
 * Created by SharpDevelop.
 * User: nam3z1p
 * Date: 2017-12-21
 * Time: 오후 3:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Android_Auto_Tool
{
	partial class Hook
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.Hooking_button = new System.Windows.Forms.Button();
			this.Process_View = new System.Windows.Forms.ListView();
			this.PID = new System.Windows.Forms.ColumnHeader();
			this.ProcessName = new System.Windows.Forms.ColumnHeader();
			this.AddressInsert = new System.Windows.Forms.TextBox();
			this.SelectMenu = new System.Windows.Forms.ComboBox();
			this.ProccessList_Button = new System.Windows.Forms.Button();
			this.Mobile_RadioButton = new System.Windows.Forms.RadioButton();
			this.JsFileOpen = new System.Windows.Forms.Button();
			this.FileOpenView = new System.Windows.Forms.TextBox();
			this.iOS_ClassDump_radioButton = new System.Windows.Forms.RadioButton();
			this.Windows_radioButton = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// Hooking_button
			// 
			this.Hooking_button.Location = new System.Drawing.Point(334, 145);
			this.Hooking_button.Name = "Hooking_button";
			this.Hooking_button.Size = new System.Drawing.Size(341, 288);
			this.Hooking_button.TabIndex = 0;
			this.Hooking_button.Text = "Hooking Start";
			this.Hooking_button.UseVisualStyleBackColor = true;
			this.Hooking_button.Click += new System.EventHandler(this.Hooking_button_Click);
			// 
			// Process_View
			// 
			this.Process_View.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.PID,
									this.ProcessName});
			this.Process_View.GridLines = true;
			this.Process_View.Location = new System.Drawing.Point(24, 29);
			this.Process_View.Name = "Process_View";
			this.Process_View.Size = new System.Drawing.Size(290, 404);
			this.Process_View.TabIndex = 1;
			this.Process_View.UseCompatibleStateImageBehavior = false;
			this.Process_View.View = System.Windows.Forms.View.Details;
			this.Process_View.SelectedIndexChanged += new System.EventHandler(this.Process_ViewSelectedIndexChanged);
			// 
			// PID
			// 
			this.PID.Text = "PID";
			this.PID.Width = 48;
			// 
			// ProcessName
			// 
			this.ProcessName.Text = "ProcessName";
			this.ProcessName.Width = 237;
			// 
			// AddressInsert
			// 
			this.AddressInsert.BackColor = System.Drawing.SystemColors.Control;
			this.AddressInsert.Location = new System.Drawing.Point(415, 76);
			this.AddressInsert.Multiline = true;
			this.AddressInsert.Name = "AddressInsert";
			this.AddressInsert.ReadOnly = true;
			this.AddressInsert.Size = new System.Drawing.Size(155, 20);
			this.AddressInsert.TabIndex = 17;
			this.AddressInsert.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// SelectMenu
			// 
			this.SelectMenu.FormattingEnabled = true;
			this.SelectMenu.Items.AddRange(new object[] {
									"USB",
									"DEVICE"});
			this.SelectMenu.Location = new System.Drawing.Point(334, 76);
			this.SelectMenu.Name = "SelectMenu";
			this.SelectMenu.Size = new System.Drawing.Size(66, 20);
			this.SelectMenu.TabIndex = 19;
			this.SelectMenu.Text = "USB";
			this.SelectMenu.SelectedIndexChanged += new System.EventHandler(this.SelectMenuSelectedIndexChanged);
			// 
			// ProccessList_Button
			// 
			this.ProccessList_Button.Location = new System.Drawing.Point(582, 76);
			this.ProccessList_Button.Name = "ProccessList_Button";
			this.ProccessList_Button.Size = new System.Drawing.Size(93, 20);
			this.ProccessList_Button.TabIndex = 18;
			this.ProccessList_Button.Text = "ProcessList";
			this.ProccessList_Button.UseVisualStyleBackColor = true;
			this.ProccessList_Button.Click += new System.EventHandler(this.ProccessList_ButtonClick);
			// 
			// Mobile_RadioButton
			// 
			this.Mobile_RadioButton.Checked = true;
			this.Mobile_RadioButton.Location = new System.Drawing.Point(362, 33);
			this.Mobile_RadioButton.Name = "Mobile_RadioButton";
			this.Mobile_RadioButton.Size = new System.Drawing.Size(75, 29);
			this.Mobile_RadioButton.TabIndex = 26;
			this.Mobile_RadioButton.TabStop = true;
			this.Mobile_RadioButton.Text = "Mobile";
			this.Mobile_RadioButton.UseVisualStyleBackColor = true;
			// 
			// JsFileOpen
			// 
			this.JsFileOpen.Location = new System.Drawing.Point(582, 105);
			this.JsFileOpen.Name = "JsFileOpen";
			this.JsFileOpen.Size = new System.Drawing.Size(93, 26);
			this.JsFileOpen.TabIndex = 29;
			this.JsFileOpen.Text = "JsFileOpen";
			this.JsFileOpen.UseVisualStyleBackColor = true;
			this.JsFileOpen.Click += new System.EventHandler(this.JsFileOpen_Click);
			// 
			// FileOpenView
			// 
			this.FileOpenView.BackColor = System.Drawing.SystemColors.Window;
			this.FileOpenView.Font = new System.Drawing.Font("굴림체", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.FileOpenView.Location = new System.Drawing.Point(334, 105);
			this.FileOpenView.Multiline = true;
			this.FileOpenView.Name = "FileOpenView";
			this.FileOpenView.ReadOnly = true;
			this.FileOpenView.Size = new System.Drawing.Size(236, 26);
			this.FileOpenView.TabIndex = 28;
			this.FileOpenView.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// iOS_ClassDump_radioButton
			// 
			this.iOS_ClassDump_radioButton.Location = new System.Drawing.Point(441, 33);
			this.iOS_ClassDump_radioButton.Name = "iOS_ClassDump_radioButton";
			this.iOS_ClassDump_radioButton.Size = new System.Drawing.Size(126, 29);
			this.iOS_ClassDump_radioButton.TabIndex = 30;
			this.iOS_ClassDump_radioButton.Text = "iOS_ClassDump";
			this.iOS_ClassDump_radioButton.UseVisualStyleBackColor = true;
			// 
			// Windows_radioButton
			// 
			this.Windows_radioButton.Location = new System.Drawing.Point(572, 33);
			this.Windows_radioButton.Name = "Windows_radioButton";
			this.Windows_radioButton.Size = new System.Drawing.Size(74, 29);
			this.Windows_radioButton.TabIndex = 31;
			this.Windows_radioButton.Text = "Windows";
			this.Windows_radioButton.UseVisualStyleBackColor = true;
			// 
			// Hook
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(700, 460);
			this.Controls.Add(this.Windows_radioButton);
			this.Controls.Add(this.iOS_ClassDump_radioButton);
			this.Controls.Add(this.JsFileOpen);
			this.Controls.Add(this.FileOpenView);
			this.Controls.Add(this.Mobile_RadioButton);
			this.Controls.Add(this.AddressInsert);
			this.Controls.Add(this.SelectMenu);
			this.Controls.Add(this.ProccessList_Button);
			this.Controls.Add(this.Process_View);
			this.Controls.Add(this.Hooking_button);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Hook";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.RadioButton Windows_radioButton;
		private System.Windows.Forms.RadioButton iOS_ClassDump_radioButton;
		private System.Windows.Forms.TextBox FileOpenView;
		private System.Windows.Forms.Button JsFileOpen;
		private System.Windows.Forms.RadioButton Mobile_RadioButton;
		private System.Windows.Forms.Button ProccessList_Button;
		private System.Windows.Forms.ComboBox SelectMenu;
		private System.Windows.Forms.TextBox AddressInsert;
		private System.Windows.Forms.ColumnHeader ProcessName;
		private System.Windows.Forms.ColumnHeader PID;
		private System.Windows.Forms.ListView Process_View;
		private System.Windows.Forms.Button Hooking_button;
	}
}
