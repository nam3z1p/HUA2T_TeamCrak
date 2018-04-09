/*
 * SharpDevelop으로 작성되었습니다.
 * 사용자: nam3z1p
 * 날짜: 2017-11-14
 * 시간: 오전 9:10
 * 
 * 이 템플리트를 변경하려면 [도구->옵션->코드 작성->표준 헤더 편집]을 이용하십시오.
 */
namespace Android_Auto_Tool
{
	partial class HashCheck
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
			this.Original_Filename_View = new System.Windows.Forms.TextBox();
			this.Original_File_label = new System.Windows.Forms.Label();
			this.Signed_File_label = new System.Windows.Forms.Label();
			this.Signed_Filename_View = new System.Windows.Forms.TextBox();
			this.Original_FileClick = new System.Windows.Forms.Button();
			this.Signed_FileClick = new System.Windows.Forms.Button();
			this.HashCheck_button = new System.Windows.Forms.Button();
			this.Original_FileHash_View = new System.Windows.Forms.TextBox();
			this.Signed_FileHash_View = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// Original_Filename_View
			// 
			this.Original_Filename_View.BackColor = System.Drawing.SystemColors.Window;
			this.Original_Filename_View.Font = new System.Drawing.Font("굴림체", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.Original_Filename_View.Location = new System.Drawing.Point(173, 19);
			this.Original_Filename_View.Multiline = true;
			this.Original_Filename_View.Name = "Original_Filename_View";
			this.Original_Filename_View.ReadOnly = true;
			this.Original_Filename_View.Size = new System.Drawing.Size(314, 28);
			this.Original_Filename_View.TabIndex = 0;
			this.Original_Filename_View.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Original_File_label
			// 
			this.Original_File_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Original_File_label.Location = new System.Drawing.Point(31, 19);
			this.Original_File_label.Name = "Original_File_label";
			this.Original_File_label.Size = new System.Drawing.Size(126, 28);
			this.Original_File_label.TabIndex = 1;
			this.Original_File_label.Text = "Original_File";
			this.Original_File_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Signed_File_label
			// 
			this.Signed_File_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Signed_File_label.Location = new System.Drawing.Point(31, 64);
			this.Signed_File_label.Name = "Signed_File_label";
			this.Signed_File_label.Size = new System.Drawing.Size(126, 28);
			this.Signed_File_label.TabIndex = 2;
			this.Signed_File_label.Text = "Signed_File";
			this.Signed_File_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Signed_Filename_View
			// 
			this.Signed_Filename_View.BackColor = System.Drawing.SystemColors.Window;
			this.Signed_Filename_View.Font = new System.Drawing.Font("굴림체", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.Signed_Filename_View.Location = new System.Drawing.Point(173, 64);
			this.Signed_Filename_View.Multiline = true;
			this.Signed_Filename_View.Name = "Signed_Filename_View";
			this.Signed_Filename_View.ReadOnly = true;
			this.Signed_Filename_View.Size = new System.Drawing.Size(314, 28);
			this.Signed_Filename_View.TabIndex = 3;
			this.Signed_Filename_View.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Original_FileClick
			// 
			this.Original_FileClick.Location = new System.Drawing.Point(502, 19);
			this.Original_FileClick.Name = "Original_FileClick";
			this.Original_FileClick.Size = new System.Drawing.Size(76, 28);
			this.Original_FileClick.TabIndex = 4;
			this.Original_FileClick.Text = "FileOpen";
			this.Original_FileClick.UseVisualStyleBackColor = true;
			this.Original_FileClick.Click += new System.EventHandler(this.Original_FileClickClick);
			// 
			// Signed_FileClick
			// 
			this.Signed_FileClick.Location = new System.Drawing.Point(502, 64);
			this.Signed_FileClick.Name = "Signed_FileClick";
			this.Signed_FileClick.Size = new System.Drawing.Size(76, 28);
			this.Signed_FileClick.TabIndex = 5;
			this.Signed_FileClick.Text = "FileOpen";
			this.Signed_FileClick.UseVisualStyleBackColor = true;
			this.Signed_FileClick.Click += new System.EventHandler(this.Signed_FileClickClick);
			// 
			// HashCheck_button
			// 
			this.HashCheck_button.Location = new System.Drawing.Point(594, 19);
			this.HashCheck_button.Name = "HashCheck_button";
			this.HashCheck_button.Size = new System.Drawing.Size(75, 73);
			this.HashCheck_button.TabIndex = 6;
			this.HashCheck_button.Text = "HASH CHECK";
			this.HashCheck_button.UseVisualStyleBackColor = true;
			this.HashCheck_button.Click += new System.EventHandler(this.HashCheck_Click);
			// 
			// Original_FileHash_View
			// 
			this.Original_FileHash_View.Location = new System.Drawing.Point(31, 116);
			this.Original_FileHash_View.Multiline = true;
			this.Original_FileHash_View.Name = "Original_FileHash_View";
			this.Original_FileHash_View.Size = new System.Drawing.Size(638, 151);
			this.Original_FileHash_View.TabIndex = 7;
			// 
			// Signed_FileHash_View
			// 
			this.Signed_FileHash_View.Location = new System.Drawing.Point(31, 283);
			this.Signed_FileHash_View.Multiline = true;
			this.Signed_FileHash_View.Name = "Signed_FileHash_View";
			this.Signed_FileHash_View.Size = new System.Drawing.Size(638, 151);
			this.Signed_FileHash_View.TabIndex = 8;
			// 
			// HashCheck
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(700, 460);
			this.Controls.Add(this.Signed_FileHash_View);
			this.Controls.Add(this.Original_FileHash_View);
			this.Controls.Add(this.HashCheck_button);
			this.Controls.Add(this.Signed_FileClick);
			this.Controls.Add(this.Original_FileClick);
			this.Controls.Add(this.Signed_Filename_View);
			this.Controls.Add(this.Signed_File_label);
			this.Controls.Add(this.Original_File_label);
			this.Controls.Add(this.Original_Filename_View);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "HashCheck";
			this.Text = "Second";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox Signed_FileHash_View;
		private System.Windows.Forms.TextBox Original_FileHash_View;
		private System.Windows.Forms.Button HashCheck_button;
		private System.Windows.Forms.Button Signed_FileClick;
		private System.Windows.Forms.Button Original_FileClick;
		private System.Windows.Forms.TextBox Signed_Filename_View;
		private System.Windows.Forms.Label Signed_File_label;
		private System.Windows.Forms.Label Original_File_label;
		private System.Windows.Forms.TextBox Original_Filename_View;
	}
}
