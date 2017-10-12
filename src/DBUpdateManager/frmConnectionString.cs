using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DBUpdateManager
{
    public partial class frmConnectionString : Form
    {
        private const string kPassword = "Password";
        private const string kUserId = "User ID";
        private const string kInitialCatalog = "Initial Catalog";
        private const string kDataSource = "Data Source";
        
        private const string kConnectionString = "Password={3}; User ID={2}; Initial Catalog={1}; Data Source={0}";
        private string _ConnectionString = string.Empty;
        
        private bool __probado = false;
        private bool Probado
        {
            get { return __probado; }
            set 
            {
                __probado = value;
                cmdAcept.Enabled = __probado;
                lblOK.Visible = __probado;
            }
        }

        public string ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }
        

        public frmConnectionString()
        {
            InitializeComponent();
            this.Probado = false;
        }

        private void cmdProbar_Click(object sender, EventArgs e)
        {

            try
            {
                _ConnectionString = GetConnectionString();

                SqlConnection cnn = new SqlConnection(_ConnectionString);
                cnn.Open();
                cnn.Close();

                this.Probado = true;
                this.AcceptButton = cmdAcept;
                
            }
            catch (Exception)
            {
                this.Probado = false;
                MessageBox.Show("FAIL");
                
            }
          
        }

        private string GetConnectionString()
        {
            string cnnStr = string.Format(kConnectionString,
                                           txtServer.Text,
                                           txtDB.Text,
                                           txtUser.Text,
                                           txtPassword.Text);

            return cnnStr;
        }

        private void cmdAcept_Click(object sender, EventArgs e)
        {
            if (this.Probado)
            {
                _ConnectionString = GetConnectionString();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe probar la coneccion a la base de datos");
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            _ConnectionString = string.Empty;

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmConnectionString_Load(object sender, EventArgs e)
        {
            string[] cnnParameters = _ConnectionString.Split(';');

            txtPassword.Text = GetValue(kPassword, cnnParameters);
            txtUser.Text = GetValue(kUserId, cnnParameters);
            txtServer.Text = GetValue(kDataSource, cnnParameters);
            txtDB.Text = GetValue(kInitialCatalog, cnnParameters);

        }

        private string GetValue(string key, string[] array)
        {
            string valor = string.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                int posicion = array[i].IndexOf(key);
                if (posicion >= 0)
                {
                    valor = array[i].Substring(posicion + key.Length + 1);
                }
            }

            return valor;
        }

    }
}
