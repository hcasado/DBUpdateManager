namespace DBUpdateManager
{
    partial class frmMensaje
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
            this.cmdDetalles = new System.Windows.Forms.Button();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdDetalles
            // 
            this.cmdDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDetalles.Location = new System.Drawing.Point(325, 94);
            this.cmdDetalles.Name = "cmdDetalles";
            this.cmdDetalles.Size = new System.Drawing.Size(75, 23);
            this.cmdDetalles.TabIndex = 0;
            this.cmdDetalles.Text = "Detalles";
            this.cmdDetalles.UseVisualStyleBackColor = true;
            this.cmdDetalles.Click += new System.EventHandler(this.cmdDetalles_Click);
            // 
            // txtDetalle
            // 
            this.txtDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetalle.Location = new System.Drawing.Point(16, 129);
            this.txtDetalle.Multiline = true;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDetalle.Size = new System.Drawing.Size(384, 132);
            this.txtDetalle.TabIndex = 2;
            this.txtDetalle.TextChanged += new System.EventHandler(this.txtDetalle_TextChanged);
            // 
            // txtMensaje
            // 
            this.txtMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMensaje.Location = new System.Drawing.Point(16, 13);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.ReadOnly = true;
            this.txtMensaje.Size = new System.Drawing.Size(384, 75);
            this.txtMensaje.TabIndex = 3;
            // 
            // frmMensaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 273);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.txtDetalle);
            this.Controls.Add(this.cmdDetalles);
            this.Name = "frmMensaje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mensaje del sistema";
            this.Load += new System.EventHandler(this.frmMensaje_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdDetalles;
        private System.Windows.Forms.TextBox txtDetalle;
        private System.Windows.Forms.TextBox txtMensaje;
    }
}