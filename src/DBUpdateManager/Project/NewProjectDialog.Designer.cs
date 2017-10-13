namespace DBUpdateManager.Project
{
    partial class NewProjectDialog
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.txtScriptRootFolder = new System.Windows.Forms.TextBox();
            this.cmdScriptFolder = new System.Windows.Forms.Button();
            this.cmdLocation = new System.Windows.Forms.Button();
            this.cmdConnectionString = new System.Windows.Forms.Button();
            this.bottomPanel.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.TabIndex = 2;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.txtName);
            this.pnlBody.Controls.Add(this.cmdConnectionString);
            this.pnlBody.Controls.Add(this.lblName);
            this.pnlBody.Controls.Add(this.cmdLocation);
            this.pnlBody.Controls.Add(this.lblLocation);
            this.pnlBody.Controls.Add(this.cmdScriptFolder);
            this.pnlBody.Controls.Add(this.label1);
            this.pnlBody.Controls.Add(this.txtScriptRootFolder);
            this.pnlBody.Controls.Add(this.label2);
            this.pnlBody.Controls.Add(this.txtConnectionString);
            this.pnlBody.Controls.Add(this.txtLocation);
            this.pnlBody.TabIndex = 0;
            // 
            // cmdAccept
            // 
            this.cmdAccept.TabIndex = 0;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(122, 15);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(140, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(18, 18);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(18, 46);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(48, 13);
            this.lblLocation.TabIndex = 2;
            this.lblLocation.Text = "Location";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Scripts Folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Connection String";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(122, 46);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(322, 20);
            this.txtLocation.TabIndex = 3;
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(122, 110);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(322, 20);
            this.txtConnectionString.TabIndex = 8;
            // 
            // txtScriptRootFolder
            // 
            this.txtScriptRootFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScriptRootFolder.Location = new System.Drawing.Point(122, 77);
            this.txtScriptRootFolder.Name = "txtScriptRootFolder";
            this.txtScriptRootFolder.Size = new System.Drawing.Size(322, 20);
            this.txtScriptRootFolder.TabIndex = 5;
            // 
            // cmdScriptFolder
            // 
            this.cmdScriptFolder.Location = new System.Drawing.Point(450, 74);
            this.cmdScriptFolder.Name = "cmdScriptFolder";
            this.cmdScriptFolder.Size = new System.Drawing.Size(27, 23);
            this.cmdScriptFolder.TabIndex = 6;
            this.cmdScriptFolder.Text = "...";
            this.cmdScriptFolder.UseVisualStyleBackColor = true;
            this.cmdScriptFolder.Click += new System.EventHandler(this.cmdScriptFolder_Click);
            // 
            // cmdLocation
            // 
            this.cmdLocation.Location = new System.Drawing.Point(450, 44);
            this.cmdLocation.Name = "cmdLocation";
            this.cmdLocation.Size = new System.Drawing.Size(27, 23);
            this.cmdLocation.TabIndex = 4;
            this.cmdLocation.Text = "...";
            this.cmdLocation.UseVisualStyleBackColor = true;
            this.cmdLocation.Click += new System.EventHandler(this.cmdLocation_Click);
            // 
            // cmdConnectionString
            // 
            this.cmdConnectionString.Location = new System.Drawing.Point(450, 108);
            this.cmdConnectionString.Name = "cmdConnectionString";
            this.cmdConnectionString.Size = new System.Drawing.Size(27, 23);
            this.cmdConnectionString.TabIndex = 9;
            this.cmdConnectionString.Text = "...";
            this.cmdConnectionString.UseVisualStyleBackColor = true;
            this.cmdConnectionString.Click += new System.EventHandler(this.cmdConnectionString_Click);
            // 
            // NewProjectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 273);
            this.Name = "NewProjectDialog";
            this.Text = "NewProjectDialog";
            this.bottomPanel.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.TextBox txtScriptRootFolder;
        private System.Windows.Forms.Button cmdScriptFolder;
        private System.Windows.Forms.Button cmdLocation;
        private System.Windows.Forms.Button cmdConnectionString;
    }
}