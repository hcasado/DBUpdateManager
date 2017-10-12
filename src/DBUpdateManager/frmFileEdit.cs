using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBUpdateManager
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmFileEdit : Form
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileFullName"></param>
        public frmFileEdit(string fileFullName)
        {
            InitializeComponent();

            FileContent.LoadFile(fileFullName, RichTextBoxStreamType.PlainText);
        }

        private void frmFileEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
