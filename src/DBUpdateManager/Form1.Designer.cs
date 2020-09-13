namespace DBUpdateManager
{
    partial class frmMain
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tableBody = new System.Windows.Forms.TableLayoutPanel();
            this.tvwTarget = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkSeleccionarAplicadosTodosNinguno = new System.Windows.Forms.CheckBox();
            this.cmdSelectTargetDB = new System.Windows.Forms.Button();
            this.txtTargetDB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tvwSource = new System.Windows.Forms.TreeView();
            this.pnlScriptSource = new System.Windows.Forms.Panel();
            this.chkSeleccionarTodosNinguno = new System.Windows.Forms.CheckBox();
            this.cmdSelectSourceFolder = new System.Windows.Forms.Button();
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.lblScriptSource = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmdRegistrar = new System.Windows.Forms.Button();
            this.cmdDeploy = new System.Windows.Forms.Button();
            this.cmdRevert = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmdInicializar = new System.Windows.Forms.Button();
            this.cmdTipos = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mnuPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnOpciones = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSoloIncidenciasNoAplicadas = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain.SuspendLayout();
            this.tableBody.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlScriptSource.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.mnuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tableBody);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 28);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1056, 655);
            this.pnlMain.TabIndex = 1;
            // 
            // tableBody
            // 
            this.tableBody.ColumnCount = 3;
            this.tableBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableBody.Controls.Add(this.tvwTarget, 2, 1);
            this.tableBody.Controls.Add(this.panel2, 2, 0);
            this.tableBody.Controls.Add(this.tvwSource, 0, 1);
            this.tableBody.Controls.Add(this.pnlScriptSource, 0, 0);
            this.tableBody.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableBody.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableBody.Location = new System.Drawing.Point(0, 0);
            this.tableBody.Margin = new System.Windows.Forms.Padding(4);
            this.tableBody.Name = "tableBody";
            this.tableBody.RowCount = 2;
            this.tableBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tableBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBody.Size = new System.Drawing.Size(1056, 655);
            this.tableBody.TabIndex = 5;
            // 
            // tvwTarget
            // 
            this.tvwTarget.CheckBoxes = true;
            this.tvwTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwTarget.Location = new System.Drawing.Point(598, 176);
            this.tvwTarget.Margin = new System.Windows.Forms.Padding(4);
            this.tvwTarget.Name = "tvwTarget";
            this.tvwTarget.Size = new System.Drawing.Size(454, 475);
            this.tvwTarget.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.chkSeleccionarAplicadosTodosNinguno);
            this.panel2.Controls.Add(this.cmdSelectTargetDB);
            this.panel2.Controls.Add(this.txtTargetDB);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(598, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(454, 164);
            this.panel2.TabIndex = 4;
            // 
            // chkSeleccionarAplicadosTodosNinguno
            // 
            this.chkSeleccionarAplicadosTodosNinguno.AutoSize = true;
            this.chkSeleccionarAplicadosTodosNinguno.Location = new System.Drawing.Point(19, 64);
            this.chkSeleccionarAplicadosTodosNinguno.Margin = new System.Windows.Forms.Padding(4);
            this.chkSeleccionarAplicadosTodosNinguno.Name = "chkSeleccionarAplicadosTodosNinguno";
            this.chkSeleccionarAplicadosTodosNinguno.Size = new System.Drawing.Size(127, 21);
            this.chkSeleccionarAplicadosTodosNinguno.TabIndex = 6;
            this.chkSeleccionarAplicadosTodosNinguno.Text = "Todos/Ninguno";
            this.chkSeleccionarAplicadosTodosNinguno.ThreeState = true;
            this.chkSeleccionarAplicadosTodosNinguno.UseVisualStyleBackColor = true;
            this.chkSeleccionarAplicadosTodosNinguno.CheckedChanged += new System.EventHandler(this.chkSeleccionarAplicadosTodosNinguno_CheckedChanged);
            this.chkSeleccionarAplicadosTodosNinguno.CheckStateChanged += new System.EventHandler(this.chkSeleccionarAplicadosTodosNinguno_CheckStateChanged);
            // 
            // cmdSelectTargetDB
            // 
            this.cmdSelectTargetDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSelectTargetDB.Location = new System.Drawing.Point(391, 32);
            this.cmdSelectTargetDB.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSelectTargetDB.Name = "cmdSelectTargetDB";
            this.cmdSelectTargetDB.Size = new System.Drawing.Size(40, 25);
            this.cmdSelectTargetDB.TabIndex = 5;
            this.cmdSelectTargetDB.Text = "...";
            this.cmdSelectTargetDB.UseVisualStyleBackColor = true;
            this.cmdSelectTargetDB.Click += new System.EventHandler(this.cmdSelectTargetDB_Click_1);
            // 
            // txtTargetDB
            // 
            this.txtTargetDB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetDB.Location = new System.Drawing.Point(19, 32);
            this.txtTargetDB.Margin = new System.Windows.Forms.Padding(4);
            this.txtTargetDB.Name = "txtTargetDB";
            this.txtTargetDB.ReadOnly = true;
            this.txtTargetDB.Size = new System.Drawing.Size(362, 22);
            this.txtTargetDB.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "DB Destino";
            // 
            // tvwSource
            // 
            this.tvwSource.CheckBoxes = true;
            this.tvwSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwSource.HideSelection = false;
            this.tvwSource.Location = new System.Drawing.Point(4, 176);
            this.tvwSource.Margin = new System.Windows.Forms.Padding(4);
            this.tvwSource.Name = "tvwSource";
            this.tvwSource.Size = new System.Drawing.Size(453, 475);
            this.tvwSource.TabIndex = 0;
            this.tvwSource.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwSource_BeforeCheck);
            this.tvwSource.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwSource_AfterCheck);
            this.tvwSource.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tvwSource_MouseClick);
            // 
            // pnlScriptSource
            // 
            this.pnlScriptSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlScriptSource.Controls.Add(this.chkSeleccionarTodosNinguno);
            this.pnlScriptSource.Controls.Add(this.cmdSelectSourceFolder);
            this.pnlScriptSource.Controls.Add(this.txtSourceFolder);
            this.pnlScriptSource.Controls.Add(this.lblScriptSource);
            this.pnlScriptSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScriptSource.Location = new System.Drawing.Point(4, 4);
            this.pnlScriptSource.Margin = new System.Windows.Forms.Padding(4);
            this.pnlScriptSource.Name = "pnlScriptSource";
            this.pnlScriptSource.Size = new System.Drawing.Size(453, 164);
            this.pnlScriptSource.TabIndex = 2;
            // 
            // chkSeleccionarTodosNinguno
            // 
            this.chkSeleccionarTodosNinguno.AutoSize = true;
            this.chkSeleccionarTodosNinguno.Location = new System.Drawing.Point(20, 64);
            this.chkSeleccionarTodosNinguno.Margin = new System.Windows.Forms.Padding(4);
            this.chkSeleccionarTodosNinguno.Name = "chkSeleccionarTodosNinguno";
            this.chkSeleccionarTodosNinguno.Size = new System.Drawing.Size(127, 21);
            this.chkSeleccionarTodosNinguno.TabIndex = 4;
            this.chkSeleccionarTodosNinguno.Text = "Todos/Ninguno";
            this.chkSeleccionarTodosNinguno.ThreeState = true;
            this.chkSeleccionarTodosNinguno.UseVisualStyleBackColor = true;
            this.chkSeleccionarTodosNinguno.CheckedChanged += new System.EventHandler(this.chkSeleccionarTodosNinguno_CheckedChanged);
            this.chkSeleccionarTodosNinguno.CheckStateChanged += new System.EventHandler(this.chkSeleccionarTodosNinguno_CheckStateChanged);
            // 
            // cmdSelectSourceFolder
            // 
            this.cmdSelectSourceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSelectSourceFolder.Location = new System.Drawing.Point(390, 32);
            this.cmdSelectSourceFolder.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSelectSourceFolder.Name = "cmdSelectSourceFolder";
            this.cmdSelectSourceFolder.Size = new System.Drawing.Size(40, 25);
            this.cmdSelectSourceFolder.TabIndex = 2;
            this.cmdSelectSourceFolder.Text = "...";
            this.cmdSelectSourceFolder.UseVisualStyleBackColor = true;
            this.cmdSelectSourceFolder.Click += new System.EventHandler(this.cmdSelectSourceFolder_Click);
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceFolder.Location = new System.Drawing.Point(20, 32);
            this.txtSourceFolder.Margin = new System.Windows.Forms.Padding(4);
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.ReadOnly = true;
            this.txtSourceFolder.Size = new System.Drawing.Size(361, 22);
            this.txtSourceFolder.TabIndex = 1;
            // 
            // lblScriptSource
            // 
            this.lblScriptSource.AutoSize = true;
            this.lblScriptSource.Location = new System.Drawing.Point(16, 11);
            this.lblScriptSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScriptSource.Name = "lblScriptSource";
            this.lblScriptSource.Size = new System.Drawing.Size(105, 17);
            this.lblScriptSource.TabIndex = 0;
            this.lblScriptSource.Text = "Carpeta Origen";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cmdRegistrar);
            this.flowLayoutPanel1.Controls.Add(this.cmdDeploy);
            this.flowLayoutPanel1.Controls.Add(this.cmdRevert);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(465, 176);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(125, 475);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // cmdRegistrar
            // 
            this.cmdRegistrar.Location = new System.Drawing.Point(12, 11);
            this.cmdRegistrar.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.cmdRegistrar.Name = "cmdRegistrar";
            this.cmdRegistrar.Size = new System.Drawing.Size(100, 28);
            this.cmdRegistrar.TabIndex = 3;
            this.cmdRegistrar.Text = "Registrar >>";
            this.cmdRegistrar.UseVisualStyleBackColor = true;
            this.cmdRegistrar.Visible = false;
            this.cmdRegistrar.Click += new System.EventHandler(this.cmdRegistrar_Click);
            // 
            // cmdDeploy
            // 
            this.cmdDeploy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDeploy.Location = new System.Drawing.Point(12, 61);
            this.cmdDeploy.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.cmdDeploy.Name = "cmdDeploy";
            this.cmdDeploy.Size = new System.Drawing.Size(100, 28);
            this.cmdDeploy.TabIndex = 2;
            this.cmdDeploy.Text = "Aplicar >>";
            this.cmdDeploy.UseVisualStyleBackColor = true;
            this.cmdDeploy.Click += new System.EventHandler(this.cmdDeploy_Click);
            // 
            // cmdRevert
            // 
            this.cmdRevert.Location = new System.Drawing.Point(12, 111);
            this.cmdRevert.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.cmdRevert.Name = "cmdRevert";
            this.cmdRevert.Size = new System.Drawing.Size(100, 28);
            this.cmdRevert.TabIndex = 3;
            this.cmdRevert.Text = "<< Revertir ";
            this.cmdRevert.UseVisualStyleBackColor = true;
            this.cmdRevert.Click += new System.EventHandler(this.cmdRevert_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.cmdInicializar);
            this.flowLayoutPanel2.Controls.Add(this.cmdTipos);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(465, 4);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(125, 164);
            this.flowLayoutPanel2.TabIndex = 7;
            // 
            // cmdInicializar
            // 
            this.cmdInicializar.Location = new System.Drawing.Point(12, 11);
            this.cmdInicializar.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.cmdInicializar.Name = "cmdInicializar";
            this.cmdInicializar.Size = new System.Drawing.Size(100, 55);
            this.cmdInicializar.TabIndex = 1;
            this.cmdInicializar.Text = "Inicializar";
            this.cmdInicializar.UseVisualStyleBackColor = true;
            this.cmdInicializar.Click += new System.EventHandler(this.cmdInicializar_Click);
            // 
            // cmdTipos
            // 
            this.cmdTipos.Location = new System.Drawing.Point(12, 88);
            this.cmdTipos.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.cmdTipos.Name = "cmdTipos";
            this.cmdTipos.Size = new System.Drawing.Size(100, 55);
            this.cmdTipos.TabIndex = 0;
            this.cmdTipos.Text = " Tipos de scripts";
            this.cmdTipos.UseVisualStyleBackColor = true;
            this.cmdTipos.Click += new System.EventHandler(this.cmdTipos_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 683);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1056, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "StatusStrip";
            // 
            // mnuPrincipal
            // 
            this.mnuPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnOpciones});
            this.mnuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnuPrincipal.Name = "mnuPrincipal";
            this.mnuPrincipal.Size = new System.Drawing.Size(1056, 28);
            this.mnuPrincipal.TabIndex = 4;
            this.mnuPrincipal.Text = "Menu Principal";
            // 
            // mnOpciones
            // 
            this.mnOpciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSoloIncidenciasNoAplicadas});
            this.mnOpciones.Name = "mnOpciones";
            this.mnOpciones.Size = new System.Drawing.Size(85, 24);
            this.mnOpciones.Text = "&Opciones";
            // 
            // mnuSoloIncidenciasNoAplicadas
            // 
            this.mnuSoloIncidenciasNoAplicadas.CheckOnClick = true;
            this.mnuSoloIncidenciasNoAplicadas.Name = "mnuSoloIncidenciasNoAplicadas";
            this.mnuSoloIncidenciasNoAplicadas.Size = new System.Drawing.Size(347, 26);
            this.mnuSoloIncidenciasNoAplicadas.Text = "Mostrar Solo Incidencias No Aplicadas";
            this.mnuSoloIncidenciasNoAplicadas.Click += new System.EventHandler(this.mnuSoloIncidenciasNoAplicadas_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 705);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mnuPrincipal);
            this.MainMenuStrip = this.mnuPrincipal;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DB Update Manager";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.pnlMain.ResumeLayout(false);
            this.tableBody.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlScriptSource.ResumeLayout(false);
            this.pnlScriptSource.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.mnuPrincipal.ResumeLayout(false);
            this.mnuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlScriptSource;
        private System.Windows.Forms.Button cmdSelectSourceFolder;
        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.Label lblScriptSource;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TreeView tvwSource;
        private System.Windows.Forms.Button cmdDeploy;
        private System.Windows.Forms.Button cmdRegistrar;
        private System.Windows.Forms.CheckBox chkSeleccionarTodosNinguno;
        private System.Windows.Forms.MenuStrip mnuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnOpciones;
        private System.Windows.Forms.ToolStripMenuItem mnuSoloIncidenciasNoAplicadas;
        private System.Windows.Forms.TableLayoutPanel tableBody;
        private System.Windows.Forms.TreeView tvwTarget;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cmdRevert;
        private System.Windows.Forms.Button cmdSelectTargetDB;
        private System.Windows.Forms.TextBox txtTargetDB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button cmdTipos;
        private System.Windows.Forms.Button cmdInicializar;
        private System.Windows.Forms.CheckBox chkSeleccionarAplicadosTodosNinguno;

    }
}

