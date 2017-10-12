using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DBUpdateManager
{
    public partial class frmMensaje : Form
    {
        public frmMensaje()
        {
            InitializeComponent();
        }

        public string Mensaje = string.Empty;
        public string Detalle = string.Empty;

        private void txtDetalle_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdDetalles_Click(object sender, EventArgs e)
        {
            this.Height = 300;
        }

        private void frmMensaje_Load(object sender, EventArgs e)
        {
            txtMensaje.Text = Mensaje;
            txtDetalle.Text = Detalle;
        }

        protected override void OnShown(EventArgs e)
        {
            this.Height = 150;
            base.OnShown(e);
        }

    }
}
