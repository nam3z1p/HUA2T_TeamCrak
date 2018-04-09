/*
 * SharpDevelop으로 작성되었습니다.
 * 사용자: nam3z1p
 * 날짜: 2017-11-16
 * 시간: 오후 1:10
 * 
 * 이 템플리트를 변경하려면 [도구->옵션->코드 작성->표준 헤더 편집]을 이용하십시오.
 */
namespace Android_Auto_Tool
{
	partial class Dump
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
			this.Process_View = new System.Windows.Forms.ListView();
			this.PID = new System.Windows.Forms.ColumnHeader();
			this.ProcessName = new System.Windows.Forms.ColumnHeader();
			this.ProccessList_Button = new System.Windows.Forms.Button();
			this.SelectMenu = new System.Windows.Forms.ComboBox();
			this.AddressInsert = new System.Windows.Forms.TextBox();
			this.cmd_view = new System.Windows.Forms.TextBox();
			this.FridaServerEXE_button = new System.Windows.Forms.Button();
			this.DeviceView = new System.Windows.Forms.ComboBox();
			this.DeviceList = new System.Windows.Forms.Button();
			this.FridaServerInstall_button = new System.Windows.Forms.Button();
			this.Memory_Dump_Button = new System.Windows.Forms.Button();
			this.Data_Dump_Button = new System.Windows.Forms.Button();
			this.CMD_Usage_Manual_button = new System.Windows.Forms.Button();
			this.Phone_RadioButton = new System.Windows.Forms.RadioButton();
			this.Emulator_RadioButton = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
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
			this.Process_View.TabIndex = 0;
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
			// ProccessList_Button
			// 
			this.ProccessList_Button.Location = new System.Drawing.Point(578, 59);
			this.ProccessList_Button.Name = "ProccessList_Button";
			this.ProccessList_Button.Size = new System.Drawing.Size(93, 20);
			this.ProccessList_Button.TabIndex = 10;
			this.ProccessList_Button.Text = "ProcessList";
			this.ProccessList_Button.UseVisualStyleBackColor = true;
			this.ProccessList_Button.Click += new System.EventHandler(this.ProccessList_ButtonClick);
			// 
			// SelectMenu
			// 
			this.SelectMenu.FormattingEnabled = true;
			this.SelectMenu.Items.AddRange(new object[] {
									"USB",
									"DEVICE"});
			this.SelectMenu.Location = new System.Drawing.Point(330, 59);
			this.SelectMenu.Name = "SelectMenu";
			this.SelectMenu.Size = new System.Drawing.Size(66, 20);
			this.SelectMenu.TabIndex = 11;
			this.SelectMenu.Text = "USB";
			this.SelectMenu.SelectedIndexChanged += new System.EventHandler(this.SelectMenuSelectedIndexChanged);
			// 
			// AddressInsert
			// 
			this.AddressInsert.BackColor = System.Drawing.SystemColors.Control;
			this.AddressInsert.Location = new System.Drawing.Point(411, 59);
			this.AddressInsert.Multiline = true;
			this.AddressInsert.Name = "AddressInsert";
			this.AddressInsert.ReadOnly = true;
			this.AddressInsert.Size = new System.Drawing.Size(155, 20);
			this.AddressInsert.TabIndex = 0;
			this.AddressInsert.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// cmd_view
			// 
			this.cmd_view.BackColor = System.Drawing.SystemColors.Window;
			this.cmd_view.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.cmd_view.Location = new System.Drawing.Point(330, 298);
			this.cmd_view.Multiline = true;
			this.cmd_view.Name = "cmd_view";
			this.cmd_view.ReadOnly = true;
			this.cmd_view.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.cmd_view.Size = new System.Drawing.Size(341, 135);
			this.cmd_view.TabIndex = 12;
			// 
			// FridaServerEXE_button
			// 
			this.FridaServerEXE_button.Location = new System.Drawing.Point(411, 117);
			this.FridaServerEXE_button.Name = "FridaServerEXE_button";
			this.FridaServerEXE_button.Size = new System.Drawing.Size(155, 26);
			this.FridaServerEXE_button.TabIndex = 14;
			this.FridaServerEXE_button.Text = "FridaServer Start";
			this.FridaServerEXE_button.UseVisualStyleBackColor = true;
			this.FridaServerEXE_button.Click += new System.EventHandler(this.FridaServerEXE_buttonClick);
			// 
			// DeviceView
			// 
			this.DeviceView.FormattingEnabled = true;
			this.DeviceView.Location = new System.Drawing.Point(330, 29);
			this.DeviceView.Name = "DeviceView";
			this.DeviceView.Size = new System.Drawing.Size(236, 20);
			this.DeviceView.TabIndex = 15;
			this.DeviceView.Text = "Device Select Plz....";
			this.DeviceView.SelectedIndexChanged += new System.EventHandler(this.DeviceViewSelectedIndexChanged);
			// 
			// DeviceList
			// 
			this.DeviceList.Location = new System.Drawing.Point(578, 29);
			this.DeviceList.Name = "DeviceList";
			this.DeviceList.Size = new System.Drawing.Size(93, 20);
			this.DeviceList.TabIndex = 16;
			this.DeviceList.Text = "DeviceList";
			this.DeviceList.UseVisualStyleBackColor = true;
			this.DeviceList.Click += new System.EventHandler(this.DeviceList_Click);
			// 
			// FridaServerInstall_button
			// 
			this.FridaServerInstall_button.Location = new System.Drawing.Point(411, 85);
			this.FridaServerInstall_button.Name = "FridaServerInstall_button";
			this.FridaServerInstall_button.Size = new System.Drawing.Size(155, 26);
			this.FridaServerInstall_button.TabIndex = 17;
			this.FridaServerInstall_button.Text = "FridaServer Install";
			this.FridaServerInstall_button.UseVisualStyleBackColor = true;
			this.FridaServerInstall_button.Click += new System.EventHandler(this.FridaServerInstall_Click);
			// 
			// Memory_Dump_Button
			// 
			this.Memory_Dump_Button.Location = new System.Drawing.Point(330, 149);
			this.Memory_Dump_Button.Name = "Memory_Dump_Button";
			this.Memory_Dump_Button.Size = new System.Drawing.Size(341, 68);
			this.Memory_Dump_Button.TabIndex = 18;
			this.Memory_Dump_Button.Text = "Memory Dump";
			this.Memory_Dump_Button.UseVisualStyleBackColor = true;
			this.Memory_Dump_Button.Click += new System.EventHandler(this.Memory_Dump_ButtonClick);
			// 
			// Data_Dump_Button
			// 
			this.Data_Dump_Button.Location = new System.Drawing.Point(330, 223);
			this.Data_Dump_Button.Name = "Data_Dump_Button";
			this.Data_Dump_Button.Size = new System.Drawing.Size(341, 68);
			this.Data_Dump_Button.TabIndex = 19;
			this.Data_Dump_Button.Text = "Data Dump";
			this.Data_Dump_Button.UseVisualStyleBackColor = true;
			this.Data_Dump_Button.Click += new System.EventHandler(this.Data_Dump_ButtonClick);
			// 
			// CMD_Usage_Manual_button
			// 
			this.CMD_Usage_Manual_button.Location = new System.Drawing.Point(578, 88);
			this.CMD_Usage_Manual_button.Name = "CMD_Usage_Manual_button";
			this.CMD_Usage_Manual_button.Size = new System.Drawing.Size(92, 54);
			this.CMD_Usage_Manual_button.TabIndex = 20;
			this.CMD_Usage_Manual_button.Text = "CMD Usage Manual";
			this.CMD_Usage_Manual_button.UseVisualStyleBackColor = true;
			this.CMD_Usage_Manual_button.Click += new System.EventHandler(this.CMD_Usage_Manual_buttonClick);
			// 
			// Phone_RadioButton
			// 
			this.Phone_RadioButton.Checked = true;
			this.Phone_RadioButton.Location = new System.Drawing.Point(330, 88);
			this.Phone_RadioButton.Name = "Phone_RadioButton";
			this.Phone_RadioButton.Size = new System.Drawing.Size(63, 26);
			this.Phone_RadioButton.TabIndex = 21;
			this.Phone_RadioButton.TabStop = true;
			this.Phone_RadioButton.Text = "Phone";
			this.Phone_RadioButton.UseVisualStyleBackColor = true;
			// 
			// Emulator_RadioButton
			// 
			this.Emulator_RadioButton.Location = new System.Drawing.Point(330, 117);
			this.Emulator_RadioButton.Name = "Emulator_RadioButton";
			this.Emulator_RadioButton.Size = new System.Drawing.Size(75, 25);
			this.Emulator_RadioButton.TabIndex = 22;
			this.Emulator_RadioButton.Text = "Emulator";
			this.Emulator_RadioButton.UseVisualStyleBackColor = true;
			// 
			// Dump
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(700, 460);
			this.Controls.Add(this.Emulator_RadioButton);
			this.Controls.Add(this.Phone_RadioButton);
			this.Controls.Add(this.CMD_Usage_Manual_button);
			this.Controls.Add(this.Data_Dump_Button);
			this.Controls.Add(this.Memory_Dump_Button);
			this.Controls.Add(this.FridaServerInstall_button);
			this.Controls.Add(this.DeviceList);
			this.Controls.Add(this.DeviceView);
			this.Controls.Add(this.FridaServerEXE_button);
			this.Controls.Add(this.cmd_view);
			this.Controls.Add(this.AddressInsert);
			this.Controls.Add(this.SelectMenu);
			this.Controls.Add(this.ProccessList_Button);
			this.Controls.Add(this.Process_View);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Dump";
			this.Text = "Dump";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.RadioButton Emulator_RadioButton;
		private System.Windows.Forms.RadioButton Phone_RadioButton;
		private System.Windows.Forms.Button CMD_Usage_Manual_button;
		private System.Windows.Forms.Button Data_Dump_Button;
		private System.Windows.Forms.Button Memory_Dump_Button;
		private System.Windows.Forms.Button FridaServerInstall_button;
		private System.Windows.Forms.Button DeviceList;
		private System.Windows.Forms.ComboBox DeviceView;
		private System.Windows.Forms.Button FridaServerEXE_button;
		private System.Windows.Forms.TextBox cmd_view;
		private System.Windows.Forms.TextBox AddressInsert;
		private System.Windows.Forms.ComboBox SelectMenu;
		private System.Windows.Forms.Button ProccessList_Button;
		private System.Windows.Forms.ColumnHeader ProcessName;
		private System.Windows.Forms.ColumnHeader PID;
		private System.Windows.Forms.ListView Process_View;
	}
}
