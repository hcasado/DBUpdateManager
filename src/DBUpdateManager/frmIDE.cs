using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBUpdateManager.Core.Project;

namespace DBUpdateManager
{
    public partial class frmIDE : Form
    {
        public frmIDE()
        {
            InitializeComponent();
        }

        private void mnuNewProject_Click(object sender, EventArgs e)
        {
            var frm = new Project.NewProjectDialog();
            frm.ShowDialog();
            var project = frm.Project;
            if (project != null)
            {
                var pm = new ProjectManager();
                pm.Save(project);

                var frmMain = new frmMain(project);
                frmMain.MdiParent = this;
                frmMain.Show();
            }
        }

        private void mnuOpenProject_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Project Files";

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = "dpj";
            openFileDialog1.Filter = "Project files (*." + ProjectFile.kFileExtension + ")|*." + ProjectFile.kFileExtension;
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var project = new ProjectManager().Load(openFileDialog1.FileName);
                var frmMain = new frmMain(project);
                frmMain.MdiParent = this;
                frmMain.Show();
            }
        }

    }
}
