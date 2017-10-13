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
                frmMain.Show();
            }
        }

    }
}
