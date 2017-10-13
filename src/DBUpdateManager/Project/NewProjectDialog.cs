using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBUpdateManager.Common;
using DBUpdateManager.Core.Project;

namespace DBUpdateManager.Project
{
    public partial class NewProjectDialog : BaseDialog
    {

        public ProjectFile Project { get; private set; }

        public NewProjectDialog()
        {
            InitializeComponent();
        }

        private void cmdLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                txtLocation.Text = folder.SelectedPath;
            }
        }

        private void cmdScriptFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                txtScriptRootFolder.Text = folder.SelectedPath;
            }
        }

        private void cmdConnectionString_Click(object sender, EventArgs e)
        {
            frmConnectionString frm = new frmConnectionString();
            frm.ConnectionString = txtConnectionString.Text;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtConnectionString.Text = frm.ConnectionString;
            }
        }

        private bool IsInputDataValid() 
        {
            bool valid = true;

            if (string.IsNullOrWhiteSpace(this.txtName.Text)) { valid = false; }
            else if (string.IsNullOrWhiteSpace(this.txtLocation.Text)) { valid = false; }
            else if (string.IsNullOrWhiteSpace(this.txtScriptRootFolder.Text)) { valid = false; }
            else if (string.IsNullOrWhiteSpace(this.txtConnectionString.Text)) { valid = false; }

            return valid;
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            if (this.IsInputDataValid())
            {
                this.Project = new ProjectFile();
                this.Project.Name = this.txtName.Text;
                this.Project.Location = this.txtLocation.Text;
                this.Project.Content.ScriptRootFolder = this.txtScriptRootFolder.Text;
                this.Project.Content.ConnectionString = this.txtConnectionString.Text;
                this.Close();
            }
        }

    }
}
