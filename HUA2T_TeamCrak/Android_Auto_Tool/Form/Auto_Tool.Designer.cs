/*
 * SharpDevelop으로 작성되었습니다.
 * 사용자: nam3z1p
 * 날짜: 2017-11-10
 * 시간: 오후 1:44
 * 
 * 이 템플리트를 변경하려면 [도구->옵션->코드 작성->표준 헤더 편집]을 이용하십시오.
 */
namespace Android_Auto_Tool
{
	partial class Auto_Tool
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
			this.cmd_view = new System.Windows.Forms.TextBox();
			this.cmd_button = new System.Windows.Forms.Button();
			this.FileOpenView = new System.Windows.Forms.TextBox();
			this.FileOpen = new System.Windows.Forms.Button();
			this.SelectMenu = new System.Windows.Forms.ComboBox();
			this.DeviceView = new System.Windows.Forms.ComboBox();
			this.DeviceList = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cmd_view
			// 
			this.cmd_view.BackColor = System.Drawing.SystemColors.Window;
			this.cmd_view.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.cmd_view.Location = new System.Drawing.Point(18, 75);
			this.cmd_view.Multiline = true;
			this.cmd_view.Name = "cmd_view";
			this.cmd_view.ReadOnly = true;
			this.cmd_view.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.cmd_view.Size = new System.Drawing.Size(659, 362);
			this.cmd_view.TabIndex = 0;
			// 
			// cmd_button
			// 
			this.cmd_button.Location = new System.Drawing.Point(544, 12);
			this.cmd_button.Name = "cmd_button";
			this.cmd_button.Size = new System.Drawing.Size(134, 48);
			this.cmd_button.TabIndex = 1;
			this.cmd_button.Text = "COMMAND";
			this.cmd_button.UseVisualStyleBackColor = true;
			this.cmd_button.Click += new System.EventHandler(this.cmd_click);
			// 
			// FileOpenView
			// 
			this.FileOpenView.BackColor = System.Drawing.SystemColors.Window;
			this.FileOpenView.Font = new System.Drawing.Font("굴림체", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.FileOpenView.Location = new System.Drawing.Point(132, 12);
			this.FileOpenView.Multiline = true;
			this.FileOpenView.Name = "FileOpenView";
			this.FileOpenView.ReadOnly = true;
			this.FileOpenView.Size = new System.Drawing.Size(296, 26);
			this.FileOpenView.TabIndex = 2;
			this.FileOpenView.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// FileOpen
			// 
			this.FileOpen.Location = new System.Drawing.Point(444, 12);
			this.FileOpen.Name = "FileOpen";
			this.FileOpen.Size = new System.Drawing.Size(89, 26);
			this.FileOpen.TabIndex = 3;
			this.FileOpen.Text = "FileOpen";
			this.FileOpen.UseVisualStyleBackColor = true;
			this.FileOpen.Click += new System.EventHandler(this.FileOpen_Click);
			// 
			// SelectMenu
			// 
			this.SelectMenu.FormattingEnabled = true;
			this.SelectMenu.ItemHeight = 12;
			this.SelectMenu.Items.AddRange(new object[] {
									"Decompile",
									"Sign-Compile",
									"Re-Install"});
			this.SelectMenu.Location = new System.Drawing.Point(18, 29);
			this.SelectMenu.Name = "SelectMenu";
			this.SelectMenu.Size = new System.Drawing.Size(100, 20);
			this.SelectMenu.TabIndex = 4;
			this.SelectMenu.Text = "Select";
			this.SelectMenu.SelectedIndexChanged += new System.EventHandler(this.SelectMenuSelectedIndexChanged);
			// 
			// DeviceView
			// 
			this.DeviceView.FormattingEnabled = true;
			this.DeviceView.Location = new System.Drawing.Point(132, 45);
			this.DeviceView.Name = "DeviceView";
			this.DeviceView.Size = new System.Drawing.Size(296, 20);
			this.DeviceView.TabIndex = 5;
			this.DeviceView.Text = "Do you want Re-Install? Device Select Plz....";
			this.DeviceView.SelectedIndexChanged += new System.EventHandler(this.DeviceViewSelectedIndexChanged);
			// 
			// DeviceList
			// 
			this.DeviceList.Location = new System.Drawing.Point(444, 44);
			this.DeviceList.Name = "DeviceList";
			this.DeviceList.Size = new System.Drawing.Size(89, 21);
			this.DeviceList.TabIndex = 6;
			this.DeviceList.Text = "DeviceList";
			this.DeviceList.UseVisualStyleBackColor = true;
			this.DeviceList.Click += new System.EventHandler(this.DeviceList_Click);
			// 
			// Auto_Tool
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(700, 460);
			this.Controls.Add(this.DeviceList);
			this.Controls.Add(this.DeviceView);
			this.Controls.Add(this.SelectMenu);
			this.Controls.Add(this.FileOpen);
			this.Controls.Add(this.FileOpenView);
			this.Controls.Add(this.cmd_button);
			this.Controls.Add(this.cmd_view);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Auto_Tool";
			this.Text = "First";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button DeviceList;
		private System.Windows.Forms.ComboBox DeviceView;
		private System.Windows.Forms.ComboBox SelectMenu;
		private System.Windows.Forms.Button FileOpen;
		private System.Windows.Forms.TextBox FileOpenView;
		private System.Windows.Forms.Button cmd_button;
		private System.Windows.Forms.TextBox cmd_view;
		

	}
}
