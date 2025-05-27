namespace Tyuiu.NovikovD.Sprint7.Project.V3
{
    partial class FormAbout_NDI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxAbout_NDI = new System.Windows.Forms.TextBox();
            this.groupBoxAbout_NDI = new System.Windows.Forms.GroupBox();
            this.groupBoxAbout_NDI.SuspendLayout();
            this.SuspendLayout();
            //
            // textBoxAbout_NDI
            //
            this.textBoxAbout_NDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxAbout_NDI.Location = new System.Drawing.Point(3, 16);
            this.textBoxAbout_NDI.Multiline = true;
            this.textBoxAbout_NDI.Name = "textBoxAbout_NDI";
            this.textBoxAbout_NDI.ReadOnly = true;
            this.textBoxAbout_NDI.Size = new System.Drawing.Size(351, 105);
            this.textBoxAbout_NDI.TabIndex = 0;
            this.textBoxAbout_NDI.Text = "Разработчик: Новиков Д. И..\r\nГруппа: АСОиУБ-23-1\r\n\r\nПрограмма разработана в рамка" +
    "х проявления своих навыков в языке C#\r\n\r\nВнутреннее имя: Tyuiu.NovikovD.Sprint7." +
    "Project.V3\r\n";
            this.textBoxAbout_NDI.TextChanged += new System.EventHandler(this.textBoxAbout_NDI_TextChanged);
            //
            // groupBoxAbout_NDI
            //
            this.groupBoxAbout_NDI.Controls.Add(this.textBoxAbout_NDI);
            this.groupBoxAbout_NDI.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAbout_NDI.Name = "groupBoxAbout_NDI";
            this.groupBoxAbout_NDI.Size = new System.Drawing.Size(357, 124);
            this.groupBoxAbout_NDI.TabIndex = 1;
            this.groupBoxAbout_NDI.TabStop = false;
            //
            // FormAbout_NDI
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 148);
            this.Controls.Add(this.groupBoxAbout_NDI);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout_NDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "О программе";
            this.Load += new System.EventHandler(this.FormAbout_NDI_Load);
            this.groupBoxAbout_NDI.ResumeLayout(false);
            this.groupBoxAbout_NDI.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAbout_NDI;
        private System.Windows.Forms.GroupBox groupBoxAbout_NDI;
    }
}
