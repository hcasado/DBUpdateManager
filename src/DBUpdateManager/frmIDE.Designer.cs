namespace DBUpdateManager
{
    partial class frmIDE
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
            this.menuIDE = new System.Windows.Forms.MenuStrip();
            this.mnFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewProject = new System.Windows.Forms.ToolStripMenuItem();
            this.statusIDE = new System.Windows.Forms.StatusStrip();
            this.menuIDE.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuIDE
            // 
            this.menuIDE.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnFile});
            this.menuIDE.Location = new System.Drawing.Point(0, 0);
            this.menuIDE.Name = "menuIDE";
            this.menuIDE.Size = new System.Drawing.Size(592, 24);
            this.menuIDE.TabIndex = 5;
            this.menuIDE.Text = "Menu Principal";
            // 
            // mnFile
            // 
            this.mnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnNew});
            this.mnFile.Name = "mnFile";
            this.mnFile.Size = new System.Drawing.Size(35, 20);
            this.mnFile.Text = "&File";
            // 
            // mnNew
            // 
            this.mnNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewProject});
            this.mnNew.Name = "mnNew";
            this.mnNew.Size = new System.Drawing.Size(152, 22);
            this.mnNew.Text = "&New";
            // 
            // mnuNewProject
            // 
            this.mnuNewProject.Name = "mnuNewProject";
            this.mnuNewProject.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.mnuNewProject.Size = new System.Drawing.Size(177, 22);
            this.mnuNewProject.Text = "&Project";
            this.mnuNewProject.Click += new System.EventHandler(this.mnuNewProject_Click);
            // 
            // statusIDE
            // 
            this.statusIDE.Location = new System.Drawing.Point(0, 351);
            this.statusIDE.Name = "statusIDE";
            this.statusIDE.Size = new System.Drawing.Size(592, 22);
            this.statusIDE.TabIndex = 6;
            this.statusIDE.Text = "StatusStrip";
            // 
            // frmIDE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 373);
            this.Controls.Add(this.statusIDE);
            this.Controls.Add(this.menuIDE);
            this.IsMdiContainer = true;
            this.Name = "frmIDE";
            this.Text = "DB Update Manager";
            this.menuIDE.ResumeLayout(false);
            this.menuIDE.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuIDE;
        private System.Windows.Forms.ToolStripMenuItem mnFile;
        private System.Windows.Forms.ToolStripMenuItem mnNew;
        private System.Windows.Forms.StatusStrip statusIDE;
        private System.Windows.Forms.ToolStripMenuItem mnuNewProject;
    }
}