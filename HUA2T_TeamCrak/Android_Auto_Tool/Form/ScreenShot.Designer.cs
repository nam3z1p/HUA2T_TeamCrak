/*
 * SharpDevelop으로 작성되었습니다.
 * 사용자: nam3z1p
 * 날짜: 2017-11-14
 * 시간: 오후 12:35
 * 
 * 이 템플리트를 변경하려면 [도구->옵션->코드 작성->표준 헤더 편집]을 이용하십시오.
 */
namespace Android_Auto_Tool
{
	partial class ScreenShot
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
			this.Image_View = new System.Windows.Forms.PictureBox();
			this.DeviceList = new System.Windows.Forms.Button();
			this.DeviceView = new System.Windows.Forms.ComboBox();
			this.Capture_button = new System.Windows.Forms.Button();
			this.Height_label = new System.Windows.Forms.Label();
			this.Width_label = new System.Windows.Forms.Label();
			this.Width_TextBox = new System.Windows.Forms.TextBox();
			this.Height_TextBox = new System.Windows.Forms.TextBox();
			this.SelectMenu = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.Image_View)).BeginInit();
			this.SuspendLayout();
			// 
			// Image_View
			// 
			this.Image_View.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Image_View.Location = new System.Drawing.Point(23, 12);
			this.Image_View.Name = "Image_View";
			this.Image_View.Size = new System.Drawing.Size(350, 436);
			this.Image_View.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.Image_View.TabIndex = 0;
			this.Image_View.TabStop = false;
			// 
			// DeviceList
			// 
			this.DeviceList.Location = new System.Drawing.Point(392, 71);
			this.DeviceList.Name = "DeviceList";
			this.DeviceList.Size = new System.Drawing.Size(296, 119);
			this.DeviceList.TabIndex = 8;
			this.DeviceList.Text = "DeviceList";
			this.DeviceList.UseVisualStyleBackColor = true;
			this.DeviceList.Click += new System.EventHandler(this.DeviceList_Click);
			// 
			// DeviceView
			// 
			this.DeviceView.FormattingEnabled = true;
			this.DeviceView.Location = new System.Drawing.Point(392, 18);
			this.DeviceView.Name = "DeviceView";
			this.DeviceView.Size = new System.Drawing.Size(296, 20);
			this.DeviceView.TabIndex = 7;
			this.DeviceView.Text = "Device Select Plz....";
			this.DeviceView.SelectedIndexChanged += new System.EventHandler(this.DeviceViewSelectedIndexChanged);
			// 
			// Capture_button
			// 
			this.Capture_button.Location = new System.Drawing.Point(392, 196);
			this.Capture_button.Name = "Capture_button";
			this.Capture_button.Size = new System.Drawing.Size(296, 252);
			this.Capture_button.TabIndex = 9;
			this.Capture_button.Text = "Capture";
			this.Capture_button.UseVisualStyleBackColor = true;
			this.Capture_button.Click += new System.EventHandler(this.Capture_buttonClick);
			// 
			// Height_label
			// 
			this.Height_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Height_label.Location = new System.Drawing.Point(581, 44);
			this.Height_label.Name = "Height_label";
			this.Height_label.Size = new System.Drawing.Size(45, 20);
			this.Height_label.TabIndex = 13;
			this.Height_label.Text = "height";
			this.Height_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Width_label
			// 
			this.Width_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Width_label.Location = new System.Drawing.Point(471, 44);
			this.Width_label.Name = "Width_label";
			this.Width_label.Size = new System.Drawing.Size(43, 20);
			this.Width_label.TabIndex = 14;
			this.Width_label.Text = "width";
			this.Width_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Width_TextBox
			// 
			this.Width_TextBox.Location = new System.Drawing.Point(520, 44);
			this.Width_TextBox.Name = "Width_TextBox";
			this.Width_TextBox.ReadOnly = true;
			this.Width_TextBox.Size = new System.Drawing.Size(54, 21);
			this.Width_TextBox.TabIndex = 15;
			this.Width_TextBox.Text = "430";
			this.Width_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Height_TextBox
			// 
			this.Height_TextBox.Location = new System.Drawing.Point(633, 44);
			this.Height_TextBox.Name = "Height_TextBox";
			this.Height_TextBox.ReadOnly = true;
			this.Height_TextBox.Size = new System.Drawing.Size(55, 21);
			this.Height_TextBox.TabIndex = 16;
			this.Height_TextBox.Text = "760";
			this.Height_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// SelectMenu
			// 
			this.SelectMenu.FormattingEnabled = true;
			this.SelectMenu.Items.AddRange(new object[] {
									"Default",
									"Resize"});
			this.SelectMenu.Location = new System.Drawing.Point(392, 44);
			this.SelectMenu.Name = "SelectMenu";
			this.SelectMenu.Size = new System.Drawing.Size(72, 20);
			this.SelectMenu.TabIndex = 17;
			this.SelectMenu.Text = "Default";
			this.SelectMenu.SelectedIndexChanged += new System.EventHandler(this.SelectMenuSelectedIndexChanged);
			// 
			// ScreenShot
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(700, 460);
			this.Controls.Add(this.SelectMenu);
			this.Controls.Add(this.Height_TextBox);
			this.Controls.Add(this.Width_TextBox);
			this.Controls.Add(this.Width_label);
			this.Controls.Add(this.Height_label);
			this.Controls.Add(this.Capture_button);
			this.Controls.Add(this.DeviceList);
			this.Controls.Add(this.DeviceView);
			this.Controls.Add(this.Image_View);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "ScreenShot";
			this.Text = "ScreenShot";
			((System.ComponentModel.ISupportInitialize)(this.Image_View)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ComboBox SelectMenu;
		private System.Windows.Forms.Label Width_label;
		private System.Windows.Forms.Label Height_label;
		private System.Windows.Forms.TextBox Height_TextBox;
		private System.Windows.Forms.TextBox Width_TextBox;
		private System.Windows.Forms.Button Capture_button;
		private System.Windows.Forms.ComboBox DeviceView;
		private System.Windows.Forms.Button DeviceList;
		private System.Windows.Forms.PictureBox Image_View;
	}
}
