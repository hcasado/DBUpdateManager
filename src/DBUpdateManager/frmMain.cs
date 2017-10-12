﻿using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

using Labs.GestorActualizacionBD.Framework;

namespace DBUpdateManager
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmMain : Form
    {
        /// <summary>
        /// Estas son las incidencias que se han recuperado del repositorio de scripts
        /// </summary>
        private Dictionary<Int32, Incidencia> registroDeIncidencias = new Dictionary<int, Incidencia>();

        private string kVersionUp = "CREATE TABLE [dbo].[__versiones]([id] [uniqueidentifier] NOT NULL,	[nombre] [varchar](50) NULL, [version] [varchar](50) NULL, CONSTRAINT [PK_VERSIONES] PRIMARY KEY CLUSTERED ( [id] ASC ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]";

        private string kBitacoraActualizacionUp = "CREATE TABLE [dbo].[__bitacora_de_actualizacion]( [id] [uniqueidentifier] NOT NULL, [nombre_script] [varchar](255) NOT NULL, [fecha_aplicacion] [datetime] NULL, [nro_incidencia] [int] NOT NULL, [tipo_script] [varchar](50) NULL, [secuencia_script] [int] NULL, CONSTRAINT [PK_BITACORA_ACTUALIZACION] PRIMARY KEY NONCLUSTERED ( 	[id] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]";



        /// <summary>
        /// 
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            Version v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            string version = " - v{0}.{1}.{2}";
            this.Text += string.Format(version, v.Major, v.Minor, v.Build);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ReadAndLoadData();
        }

        private void ReadAndLoadData()
        {
            txtTargetDB.Text = Configuracion.Instancia.ConnectionString;
            txtSourceFolder.Text = Configuracion.Instancia.CarpetaDeIncidencias;

            if (txtTargetDB.Text.Length > 0)
            {
                LeerIncidenciasAplicadas();
            }

            if (txtSourceFolder.Text.Length > 0)
            {
                LeerRepositorioDeIncidencias();
            }

            MostrarRepositorioDeIncidencias();
            MostrarIncidenciasAplicadas();
        }

        private void cmdSelectSourceFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                txtSourceFolder.Text = folder.SelectedPath;
                Configuracion.Instancia.CarpetaDeIncidencias = folder.SelectedPath;

                LeerRepositorioDeIncidencias();
            }
        }

        private void LeerRepositorioDeIncidencias()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                var gestor = new GestorDeIncidencias();
                DirectoryInfo scriptDirectoryInfo = new DirectoryInfo(txtSourceFolder.Text);

                if (scriptDirectoryInfo.Exists)
                {
                    List<Incidencia> incidencias = gestor.CrearIncidencias(scriptDirectoryInfo);
                    IndexarIncidencias(incidencias);

                    MostrarRepositorioDeIncidencias();
                }
                else
                {
                    txtSourceFolder.Text = string.Empty;
                }
            }
            catch (ApplicationException appEx)
            {
                MessageBox.Show(appEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                this.Cursor = Cursors.Default;
            }


        }

        private void IndexarIncidencias(List<Incidencia> listaIncidencias)
        {
            foreach (Incidencia incidencia in listaIncidencias)
            {
                if (!registroDeIncidencias.ContainsKey(incidencia.Nro))
                {
                    registroDeIncidencias.Add(incidencia.Nro, incidencia);
                }
                else
                {
                    registroDeIncidencias[incidencia.Nro].Merge(incidencia);
                }
            }
        }

        private void MostrarRepositorioDeIncidencias()
        {
            RellenarArbol(tvwSource, registroDeIncidencias.Values, true && !mnuSoloIncidenciasNoAplicadas.Checked, true);
        }

        private void LimpiarArbol(TreeView vistaArbol)
        {
            vistaArbol.Nodes.Clear();
        }

        private void RellenarArbol(TreeView vistaArbol, IEnumerable<Incidencia> incidencias, bool mostrarIncidenciasAplicadas, bool mostrarIncidenciasNoAplicadas)
        {
            LimpiarArbol(vistaArbol);

            var incidenciasOrdenadas = from i in incidencias orderby i.Nro descending select i;

            foreach (Incidencia i in incidenciasOrdenadas)
            {

                if ((mostrarIncidenciasAplicadas && i.Aplicada) || (mostrarIncidenciasNoAplicadas && !i.Aplicada))
                {
                    IncidenciaTreeNode nodoIncidencia = new IncidenciaTreeNode(i.Nombre);
                    foreach (Script s in i.Scripts.Values)
                    {
                        ScriptTreeNode nodoScript = new ScriptTreeNode(s.Nombre);


                        FileTreeNode nodoDeArchivoDeImplementacion = new FileTreeNode(s.UpFile);
                        nodoScript.Nodes.Add(nodoDeArchivoDeImplementacion);

                        FileTreeNode nodoDeArchivoDeDesimplementacion = new FileTreeNode(s.DownFile);
                        nodoScript.Nodes.Add(nodoDeArchivoDeDesimplementacion);

                        nodoScript.Tag = s;
                        nodoIncidencia.Nodes.Add(nodoScript);
                    }

                    nodoIncidencia.Tag = i;

                    vistaArbol.Nodes.Add(nodoIncidencia);
                }

            }
        }

        private void AddScripts(TreeNode root, DirectoryInfo source)
        {
            FileInfo[] files = source.GetFiles("*.sql");
            foreach (FileInfo file in files)
            {
                root.Nodes.Add(new TreeNode(file.Name));
            }
        }

        private void cmdSelectTargetDB_Click(object sender, EventArgs e)
        {
            frmConnectionString frm = new frmConnectionString();
            frm.ConnectionString = txtTargetDB.Text;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtTargetDB.Text = frm.ConnectionString;
                Configuracion.Instancia.ConnectionString = frm.ConnectionString;

                LimpiarArbol(tvwTarget);
                registroDeIncidencias.Clear();

                LeerIncidenciasAplicadas();

                try
                {
                    Configuracion.Instancia.ConnectionString = frm.ConnectionString;
                }
                catch (Exception ex)
                {
                    string mensaje =
                        "Las incidencias aplicadas han sido cargadas, pero no se ha podido guardar la ConnectionString actual";

                    MessageBox.Show(mensaje);
                }
            }



        }

        private void LeerIncidenciasAplicadas()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                var gestor = new GestorDeIncidencias();
                List<Incidencia> incidencias = gestor.LeerIncidenciasAplicadas();
                IndexarIncidencias(incidencias);
                MostrarIncidenciasAplicadas();
                cmdInicializar.Enabled = false;
            }
            catch (ApplicationException appEx)
            {
                MessageBox.Show(appEx.Message);
                cmdInicializar.Enabled = true;
            }

            this.Cursor = Cursors.Default;
        }

        private void MostrarIncidenciasAplicadas()
        {
            RellenarArbol(tvwTarget, registroDeIncidencias.Values, true && !mnuSoloIncidenciasNoAplicadas.Checked, false);
        }


        private IOrderedEnumerable<Incidencia> ObtenerIncidenciasSeleccionadas(TreeView vistaArbol, SortDirection direction)
        {

            IList<Incidencia> listaIncidencias = new List<Incidencia>();
            Incidencia incidencia = null;

            foreach (TreeNode n in vistaArbol.Nodes)
            {
                if (n.Checked)
                {
                    incidencia = (Incidencia)n.Tag;
                    listaIncidencias.Add(incidencia);
                }
            }

            // siempre listar las incidencias en orden secuencial progresivo
            IOrderedEnumerable<Incidencia> incidenciasOrdenadas = null;
            if (direction == SortDirection.Ascending)
            {
                incidenciasOrdenadas = from i in listaIncidencias orderby i.Nro ascending select i;
            }
            else
            {
                incidenciasOrdenadas = from i in listaIncidencias orderby i.Nro descending select i;
            }

            return incidenciasOrdenadas;
        }

        private void cmdDeploy_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (txtSourceFolder.Text == string.Empty)
            {
                string mensaje = "Debe indicar la carpeta origen. La misma debe contener las incidencias a aplicar";
                MessageBox.Show(mensaje);
                this.Cursor = Cursors.Default;
                return;
            }

            try
            {
                var gestor = new GestorDeIncidencias();
                string directorioActual = string.Empty;
                string scriptActual = string.Empty;

                try
                {
                    var listaIncidencias = ObtenerIncidenciasSeleccionadas(tvwSource, SortDirection.Ascending);
                    gestor.BeginTransaction();

                    foreach (Incidencia incidencia in listaIncidencias)
                    {
                        directorioActual = incidencia.Nombre;

                        foreach (Script script in incidencia.Scripts.Values)
                        {
                            scriptActual = script.Nombre;
                            gestor.AplicarScript(script);
                            gestor.SaveTransaction(script.Nombre + "_" + script.Secuencia);
                        }

                        DeseleccionarNodo(tvwSource, incidencia);

                        incidencia.Aplicada = true;
                    }

                    gestor.CommitTransaction();
                }
                catch (Exception ex)
                {
                    gestor.RollbackTransaction();
                    var listaIncidencias = ObtenerIncidenciasSeleccionadas(tvwSource, SortDirection.Ascending);
                    foreach (var i in listaIncidencias)
                    {
                        i.Aplicada = false;
                    }

                    frmMensaje frm = new frmMensaje();
                    frm.Mensaje = string.Format("Se ha producido un error al aplicar el script {0} de la incidencia {1}.", scriptActual, directorioActual);
                    frm.Detalle = ex.Message + "\n" + "\n" + ex.StackTrace;
                    frm.ShowDialog();
                }

                LeerIncidenciasAplicadas();
                LeerRepositorioDeIncidencias();
                MostrarIncidenciasAplicadas();
                MostrarRepositorioDeIncidencias();

            }
            catch (ApplicationException appEx)
            {
                MessageBox.Show(appEx.Message);
            }

            this.Cursor = Cursors.Default;
        }

        private void cmdRevert_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                var gestor = new GestorDeIncidencias();
                string directorioActual = string.Empty;
                string scriptActual = string.Empty;
                IEnumerable<Incidencia> listaIncidencias = new List<Incidencia>();
                try
                {
                    gestor.BeginTransaction();
                    listaIncidencias = ObtenerIncidenciasSeleccionadas(tvwTarget, SortDirection.Descending);
                    foreach (var incidencia in listaIncidencias)
                    {

                        directorioActual = incidencia.Nombre;

                        // recupera los scripts en orden inverso.
                        for (int i = incidencia.Scripts.Keys.Count - 1; i >= 0; i--)
                        {
                            scriptActual = incidencia.Scripts[i + 1].Nombre;
                            gestor.RevertirScript(incidencia.Scripts[i + 1]);
                        }

                        incidencia.Aplicada = false;
                    }

                    gestor.CommitTransaction();

                }
                catch (Exception ex)
                {
                    gestor.RollbackTransaction();
                    foreach (var i in listaIncidencias) i.Aplicada = false;

                    frmMensaje frm = new frmMensaje();
                    frm.Mensaje = string.Format("Se ha producido un error al revertir el script {0} de la incidencia {1}.", scriptActual, directorioActual);
                    frm.Detalle = ex.Message + "\n" + "\n" + ex.StackTrace;
                    frm.ShowDialog();
                }

                LeerIncidenciasAplicadas();
                LeerRepositorioDeIncidencias();
                MostrarIncidenciasAplicadas();
                MostrarRepositorioDeIncidencias();
            }
            catch (ApplicationException appEx)
            {
                MessageBox.Show(appEx.Message);
            }

            this.Cursor = Cursors.Default;
        }

        private void tvwTarget_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Tag == null)
            {
                return;
            }

            if (e.Node.Level > 0 && e.Action != TreeViewAction.Unknown)
            {
                e.Cancel = true;
                return;
            }

            if (!e.Node.Tag.GetType().Equals(typeof(Incidencia)))
            {
                return;
            }

            int nroIncidencia = ((Incidencia)e.Node.Tag).Nro;
            Incidencia incidencia = null;
            if (registroDeIncidencias.TryGetValue(nroIncidencia, out incidencia))
            {
                e.Node.Tag = incidencia;
            }
            else
            {
                e.Cancel = true;
                MessageBox.Show("No se ha localizado el script de vuelta atras");
            }


        }

        private void tvwTarget_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode node in e.Node.Nodes)
            {
                node.Checked = e.Node.Checked;
            }
        }

        private void tvwSource_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode node in e.Node.Nodes)
            {
                node.Checked = e.Node.Checked;
            }
        }

        private void tvwSource_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Tag == null)
            {
                return;
            }

            if (e.Node.Level > 0 && e.Action != TreeViewAction.Unknown)
            {
                e.Cancel = true;
                return;
            }

            if (!e.Node.Tag.GetType().Equals(typeof(Incidencia)))
            {
                return;
            }

            int nroIncidencia = ((Incidencia)e.Node.Tag).Nro;
            Incidencia incidencia = null;
            if (registroDeIncidencias.TryGetValue(nroIncidencia, out incidencia))
            {
                if (incidencia.Aplicada)
                {
                    e.Cancel = true;
                    MessageBox.Show(string.Format("La incidencia {0} ya se encuentra aplicada", nroIncidencia));
                }

            }
        }

        private void DeseleccionarNodo(TreeView vistaArbol, Incidencia incidencia)
        {
            foreach (TreeNode nodo in vistaArbol.Nodes)
            {
                if (nodo.Tag.GetType().Equals(typeof(Incidencia)))
                {
                    if (((Incidencia)nodo.Tag).Nro == incidencia.Nro)
                    {
                        nodo.Checked = false;
                        break;
                    }
                }
            }
        }

        private void tvwSource_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var selectedNode = ((TreeView)sender).SelectedNode;

                if (selectedNode is IncidenciaTreeNode)
                {
                    try
                    {
                        string path = ((Labs.GestorActualizacionBD.Framework.Incidencia)((IncidenciaTreeNode)selectedNode).Tag).PathFisico;
                        Process p = new Process();
                        p.StartInfo = new ProcessStartInfo("explorer.exe", path);
                        p.Start();
                    }
                    catch (Exception ex)
                    {
                        string mensaje = ex.Message;
                    }
                }
                else if (selectedNode is FileTreeNode)
                {
                    try
                    {
                        Script script = (Labs.GestorActualizacionBD.Framework.Script)((ScriptTreeNode)selectedNode.Parent).Tag;
                        string path = script.Incidencia.PathFisico;
                        string filename = selectedNode.Text;
                        string fullFileName = path + @"\\" + filename;
                        new frmFileEdit(fullFileName).ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        string mensaje = ex.Message;
                    }
                }

            }
        }

        private void cmdRegistrar_Click(object sender, EventArgs e)
        {
            string mensaje =
                "Al registrar un paquete, los scripts no se aplican (no hay execucion de los scripts), solo se registran en la base de datos como aplicados. Esta opcion se utiliza para que en la base de datos figuren los scripts aplicados manualmente. ¿Desea continuar?";

            if (MessageBox.Show(mensaje, "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;

                if (txtSourceFolder.Text == string.Empty)
                {
                    MessageBox.Show("Debe indicar la carpeta origen. La misma debe contener las incidencias a aplicar");
                    this.Cursor = Cursors.Default;
                    return;
                }

                try
                {
                    var gestor = new GestorDeIncidencias();
                    string directorioActual = string.Empty;
                    string scriptActual = string.Empty;

                    try
                    {
                        var listaIncidencias = ObtenerIncidenciasSeleccionadas(tvwSource, SortDirection.Ascending);
                        gestor.BeginTransaction();

                        foreach (Incidencia incidencia in listaIncidencias)
                        {
                            directorioActual = incidencia.Nombre;

                            foreach (Script script in incidencia.Scripts.Values)
                            {
                                scriptActual = script.Nombre;
                                gestor.RegistrarAplicacionDeScript(script);
                            }

                            DeseleccionarNodo(tvwSource, incidencia);
                        }

                        gestor.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        gestor.RollbackTransaction();
                        frmMensaje frm = new frmMensaje();
                        frm.Mensaje = string.Format("Se ha producido un error al aplicar el script {0} de la incidencia {1}.", scriptActual, directorioActual);
                        frm.Detalle = ex.Message + "\n" + "\n" + ex.StackTrace;
                        frm.ShowDialog();
                    }

                    LeerIncidenciasAplicadas();

                }
                catch (ApplicationException appEx)
                {
                    MessageBox.Show(appEx.Message);
                }

                this.Cursor = Cursors.Default;
            }

        }

        private void chkSeleccionarTodosNinguno_CheckStateChanged(object sender, EventArgs e)
        {
            switch (chkSeleccionarTodosNinguno.CheckState)
            {
                case CheckState.Checked:
                    foreach (TreeNode nodo in tvwSource.Nodes)
                    {
                        nodo.Checked = true;
                    }
                    break;

                case CheckState.Unchecked:
                    break;

                case CheckState.Indeterminate:
                    foreach (TreeNode nodo in tvwSource.Nodes)
                    {
                        nodo.Checked = false;
                    }
                    break;
            }
        }

        private void mnuSoloIncidenciasNoAplicadas_Click(object sender, EventArgs e)
        {
            MostrarIncidenciasAplicadas();
            MostrarRepositorioDeIncidencias();
        }

        private void mnuAyuda_Click(object sender, EventArgs e)
        {
            var frm = new frmHelp();
            frm.ShowDialog();
        }

        private void cmdTipos_Click(object sender, EventArgs e)
        {
            string[] names = Enum.GetNames(typeof(TipoDeScript));
            var message = string.Join(" | ", names);
            MessageBox.Show(message);


        }

        private void cmdInicializar_Click(object sender, EventArgs e)
        {
            var gestor = new GestorDeTransacciones();

            try
            {
                gestor.BeginTransaction();
                
                gestor.EjecutarSql(kVersionUp);
                gestor.EjecutarSql(kBitacoraActualizacionUp);

                gestor.CommitTransaction();
            }
            catch (Exception ex)
            {
                gestor.RollbackTransaction();
                frmMensaje frm = new frmMensaje();
                frm.Mensaje = "Se produjo un error inicializando la base de datos.";
                frm.Detalle = ex.Message + "\n" + "\n" + ex.StackTrace;
                frm.ShowDialog();
            }

            ReadAndLoadData();
        }

    }
}