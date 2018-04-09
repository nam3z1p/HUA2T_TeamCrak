/*
 * SharpDevelop으로 작성되었습니다.
 * 사용자: nam3z1p
 * 날짜: 2017-11-15
 * 시간: 오전 9:27
 * 
 * 이 템플리트를 변경하려면 [도구->옵션->코드 작성->표준 헤더 편집]을 이용하십시오.
 */
namespace Android_Auto_Tool
{
	partial class Extract
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
			this.ExtractFile_View = new System.Windows.Forms.ListView();
			this.FileName_View = new System.Windows.Forms.ColumnHeader();
			this.Size_View = new System.Windows.Forms.ColumnHeader();
			this.Hash_View = new System.Windows.Forms.ColumnHeader();
			this.FileOpenView = new System.Windows.Forms.TextBox();
			this.FileOpen = new System.Windows.Forms.Button();
			this.DirectoryOpen = new System.Windows.Forms.Button();
			this.Extract_Button = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.Image_View)).BeginInit();
			this.SuspendLayout();
			// 
			// Image_View
			// 
			this.Image_View.BackColor = System.Drawing.SystemColors.Control;
			this.Image_View.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Image_View.Location = new System.Drawing.Point(23, 209);
			this.Image_View.Name = "Image_View";
			this.Image_View.Size = new System.Drawing.Size(314, 239);
			this.Image_View.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.Image_View.TabIndex = 0;
			this.Image_View.TabStop = false;
			// 
			// ExtractFile_View
			// 
			this.ExtractFile_View.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.FileName_View,
									this.Size_View,
									this.Hash_View});
			this.ExtractFile_View.GridLines = true;
			this.ExtractFile_View.Location = new System.Drawing.Point(23, 9);
			this.ExtractFile_View.Name = "ExtractFile_View";
			this.ExtractFile_View.Size = new System.Drawing.Size(640, 181);
			this.ExtractFile_View.TabIndex = 1;
			this.ExtractFile_View.UseCompatibleStateImageBehavior = false;
			this.ExtractFile_View.View = System.Windows.Forms.View.Details;
			this.ExtractFile_View.SelectedIndexChanged += new System.EventHandler(this.ExtractFile_ViewSelectedIndexChanged);
			// 
			// FileName_View
			// 
			this.FileName_View.Text = "Filename";
			this.FileName_View.Width = 387;
			// 
			// Size_View
			// 
			this.Size_View.Text = "Size";
			this.Size_View.Width = 63;
			// 
			// Hash_View
			// 
			this.Hash_View.Text = "Hash - [MD5]";
			this.Hash_View.Width = 185;
			// 
			// FileOpenView
			// 
			this.FileOpenView.BackColor = System.Drawing.SystemColors.Window;
			this.FileOpenView.Font = new System.Drawing.Font("굴림체", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.FileOpenView.Location = new System.Drawing.Point(357, 209);
			this.FileOpenView.Multiline = true;
			this.FileOpenView.Name = "FileOpenView";
			this.FileOpenView.ReadOnly = true;
			this.FileOpenView.Size = new System.Drawing.Size(306, 29);
			this.FileOpenView.TabIndex = 2;
			this.FileOpenView.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// FileOpen
			// 
			this.FileOpen.Location = new System.Drawing.Point(380, 253);
			this.FileOpen.Name = "FileOpen";
			this.FileOpen.Size = new System.Drawing.Size(112, 25);
			this.FileOpen.TabIndex = 3;
			this.FileOpen.Text = "FileOpen";
			this.FileOpen.UseVisualStyleBackColor = true;
			this.FileOpen.Click += new System.EventHandler(this.FileOpen_Click);
			// 
			// DirectoryOpen
			// 
			this.DirectoryOpen.Location = new System.Drawing.Point(532, 253);
			this.DirectoryOpen.Name = "DirectoryOpen";
			this.DirectoryOpen.Size = new System.Drawing.Size(103, 25);
			this.DirectoryOpen.TabIndex = 4;
			this.DirectoryOpen.Text = "DirectoryOpen";
			this.DirectoryOpen.UseVisualStyleBackColor = true;
			this.DirectoryOpen.Click += new System.EventHandler(this.DirectoryOpen_Click);
			// 
			// Extract_Button
			// 
			this.Extract_Button.Location = new System.Drawing.Point(357, 293);
			this.Extract_Button.Name = "Extract_Button";
			this.Extract_Button.Size = new System.Drawing.Size(306, 155);
			this.Extract_Button.TabIndex = 5;
			this.Extract_Button.Text = "Extract";
			this.Extract_Button.UseVisualStyleBackColor = true;
			this.Extract_Button.Click += new System.EventHandler(this.Extract_Click);
			// 
			// Extract_Tool
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(700, 460);
			this.Controls.Add(this.Extract_Button);
			this.Controls.Add(this.DirectoryOpen);
			this.Controls.Add(this.FileOpen);
			this.Controls.Add(this.FileOpenView);
			this.Controls.Add(this.ExtractFile_View);
			this.Controls.Add(this.Image_View);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Extract_Tool";
			this.Text = "Extract_Tool";
			((System.ComponentModel.ISupportInitialize)(this.Image_View)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ColumnHeader Hash_View;
		private System.Windows.Forms.Button Extract_Button;
		private System.Windows.Forms.Button DirectoryOpen;
		private System.Windows.Forms.TextBox FileOpenView;
		private System.Windows.Forms.Button FileOpen;
		private System.Windows.Forms.ColumnHeader Size_View;
		private System.Windows.Forms.ColumnHeader FileName_View;
		private System.Windows.Forms.ListView ExtractFile_View;
		private System.Windows.Forms.PictureBox Image_View;
	}
}
