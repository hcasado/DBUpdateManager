namespace DBUpdateManager
{
    partial class frmFileEdit
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
            this.FileContent = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // FileContent
            // 
            this.FileContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileContent.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileContent.Location = new System.Drawing.Point(0, 0);
            this.FileContent.Name = "FileContent";
            this.FileContent.Size = new System.Drawing.Size(292, 272);
            this.FileContent.TabIndex = 0;
            this.FileContent.Text = "";
            // 
            // frmFileEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 272);
            this.Controls.Add(this.FileContent);
            this.Name = "frmFileEdit";
            this.Text = "frmFileEdit";
            this.Load += new System.EventHandler(this.frmFileEdit_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox FileContent;
    }
}