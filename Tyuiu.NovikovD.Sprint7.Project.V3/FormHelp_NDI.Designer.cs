namespace Tyuiu.NovikovD.Sprint7.Project.V3
{
    partial class FormHelp_NDI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHelp_NDI));
            this.groupBoxHelp_NDI = new System.Windows.Forms.GroupBox();
            this.textBoxHelp_NDI = new System.Windows.Forms.TextBox();
            this.groupBoxHelp_NDI.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxHelp_NDI
            // 
            this.groupBoxHelp_NDI.Controls.Add(this.textBoxHelp_NDI);
            this.groupBoxHelp_NDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxHelp_NDI.Location = new System.Drawing.Point(0, 0);
            this.groupBoxHelp_NDI.Name = "groupBoxHelp_NDI";
            this.groupBoxHelp_NDI.Size = new System.Drawing.Size(480, 120);
            this.groupBoxHelp_NDI.TabIndex = 0;
            this.groupBoxHelp_NDI.TabStop = false;
            // 
            // textBoxHelp_NDI
            // 
            this.textBoxHelp_NDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxHelp_NDI.Location = new System.Drawing.Point(3, 16);
            this.textBoxHelp_NDI.Multiline = true;
            this.textBoxHelp_NDI.Name = "textBoxHelp_NDI";
            this.textBoxHelp_NDI.ReadOnly = true;
            this.textBoxHelp_NDI.Size = new System.Drawing.Size(474, 101);
            this.textBoxHelp_NDI.TabIndex = 0;
            this.textBoxHelp_NDI.Text = resources.GetString("textBoxHelp_NDI.Text");
            // 
            // FormHelp_NDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 120);
            this.Controls.Add(this.groupBoxHelp_NDI);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHelp_NDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справка";
            this.groupBoxHelp_NDI.ResumeLayout(false);
            this.groupBoxHelp_NDI.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxHelp_NDI;
        private System.Windows.Forms.TextBox textBoxHelp_NDI;
    }
}
