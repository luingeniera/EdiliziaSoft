namespace WindowsFormsApplication1
{
    partial class Glocal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Glocal));
            this.rbEntrega = new System.Windows.Forms.RadioButton();
            this.rbDevolucion = new System.Windows.Forms.RadioButton();
            this.rbAuditoria = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbNivel = new System.Windows.Forms.ComboBox();
            this.cbNumero = new System.Windows.Forms.ComboBox();
            this.lblLocal = new System.Windows.Forms.Label();
            this.lblResponsable = new System.Windows.Forms.Label();
            this.lblActivos = new System.Windows.Forms.Label();
            this.dgLocales = new System.Windows.Forms.DataGridView();
            this.btBuscar = new System.Windows.Forms.Button();
            this.btnEntregar = new System.Windows.Forms.Button();
            this.cbEntrega = new System.Windows.Forms.ComboBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblComprobante = new System.Windows.Forms.Label();
            this.btPicking = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLocales)).BeginInit();
            this.SuspendLayout();
            // 
            // rbEntrega
            // 
            this.rbEntrega.AutoSize = true;
            this.rbEntrega.Location = new System.Drawing.Point(19, 4);
            this.rbEntrega.Margin = new System.Windows.Forms.Padding(4);
            this.rbEntrega.Name = "rbEntrega";
            this.rbEntrega.Size = new System.Drawing.Size(137, 21);
            this.rbEntrega.TabIndex = 0;
            this.rbEntrega.TabStop = true;
            this.rbEntrega.Text = "Entrega de Local";
            this.rbEntrega.UseVisualStyleBackColor = true;
            // 
            // rbDevolucion
            // 
            this.rbDevolucion.AutoSize = true;
            this.rbDevolucion.Location = new System.Drawing.Point(168, 4);
            this.rbDevolucion.Margin = new System.Windows.Forms.Padding(4);
            this.rbDevolucion.Name = "rbDevolucion";
            this.rbDevolucion.Size = new System.Drawing.Size(157, 21);
            this.rbDevolucion.TabIndex = 1;
            this.rbDevolucion.TabStop = true;
            this.rbDevolucion.Text = "Devolución de Local";
            this.rbDevolucion.UseVisualStyleBackColor = true;
            // 
            // rbAuditoria
            // 
            this.rbAuditoria.AutoSize = true;
            this.rbAuditoria.Location = new System.Drawing.Point(335, 4);
            this.rbAuditoria.Margin = new System.Windows.Forms.Padding(4);
            this.rbAuditoria.Name = "rbAuditoria";
            this.rbAuditoria.Size = new System.Drawing.Size(85, 21);
            this.rbAuditoria.TabIndex = 2;
            this.rbAuditoria.TabStop = true;
            this.rbAuditoria.Text = "Auditoría";
            this.rbAuditoria.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbEntrega);
            this.panel1.Controls.Add(this.rbAuditoria);
            this.panel1.Controls.Add(this.rbDevolucion);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 31);
            this.panel1.TabIndex = 3;
            // 
            // cbNivel
            // 
            this.cbNivel.FormattingEnabled = true;
            this.cbNivel.Location = new System.Drawing.Point(34, 60);
            this.cbNivel.Margin = new System.Windows.Forms.Padding(4);
            this.cbNivel.Name = "cbNivel";
            this.cbNivel.Size = new System.Drawing.Size(201, 24);
            this.cbNivel.TabIndex = 4;
            this.cbNivel.Text = "Nivel";
            this.cbNivel.SelectedValueChanged += new System.EventHandler(this.cbNivel_SelectedValueChanged);
            // 
            // cbNumero
            // 
            this.cbNumero.FormattingEnabled = true;
            this.cbNumero.Location = new System.Drawing.Point(254, 60);
            this.cbNumero.Margin = new System.Windows.Forms.Padding(4);
            this.cbNumero.Name = "cbNumero";
            this.cbNumero.Size = new System.Drawing.Size(192, 24);
            this.cbNumero.TabIndex = 5;
            this.cbNumero.Text = "Número";
            // 
            // lblLocal
            // 
            this.lblLocal.AutoSize = true;
            this.lblLocal.Location = new System.Drawing.Point(31, 123);
            this.lblLocal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new System.Drawing.Size(56, 17);
            this.lblLocal.TabIndex = 6;
            this.lblLocal.Text = "Oficina:";
            // 
            // lblResponsable
            // 
            this.lblResponsable.AutoSize = true;
            this.lblResponsable.Location = new System.Drawing.Point(283, 123);
            this.lblResponsable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResponsable.Name = "lblResponsable";
            this.lblResponsable.Size = new System.Drawing.Size(95, 17);
            this.lblResponsable.TabIndex = 7;
            this.lblResponsable.Text = "Responsable:";
            // 
            // lblActivos
            // 
            this.lblActivos.AutoSize = true;
            this.lblActivos.Location = new System.Drawing.Point(529, 123);
            this.lblActivos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActivos.Name = "lblActivos";
            this.lblActivos.Size = new System.Drawing.Size(94, 17);
            this.lblActivos.TabIndex = 8;
            this.lblActivos.Text = "Cant. Activos:";
            // 
            // dgLocales
            // 
            this.dgLocales.AllowUserToOrderColumns = true;
            this.dgLocales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLocales.Location = new System.Drawing.Point(35, 156);
            this.dgLocales.Margin = new System.Windows.Forms.Padding(4);
            this.dgLocales.Name = "dgLocales";
            this.dgLocales.Size = new System.Drawing.Size(853, 374);
            this.dgLocales.TabIndex = 9;
            // 
            // btBuscar
            // 
            this.btBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btBuscar.Image")));
            this.btBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBuscar.Location = new System.Drawing.Point(477, 41);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(95, 43);
            this.btBuscar.TabIndex = 10;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // btnEntregar
            // 
            this.btnEntregar.Location = new System.Drawing.Point(687, 554);
            this.btnEntregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEntregar.Name = "btnEntregar";
            this.btnEntregar.Size = new System.Drawing.Size(201, 33);
            this.btnEntregar.TabIndex = 12;
            this.btnEntregar.Text = "Entregar";
            this.btnEntregar.UseVisualStyleBackColor = true;
            this.btnEntregar.Click += new System.EventHandler(this.btnEntregar_Click);
            // 
            // cbEntrega
            // 
            this.cbEntrega.Enabled = false;
            this.cbEntrega.FormattingEnabled = true;
            this.cbEntrega.Location = new System.Drawing.Point(35, 559);
            this.cbEntrega.Margin = new System.Windows.Forms.Padding(4);
            this.cbEntrega.Name = "cbEntrega";
            this.cbEntrega.Size = new System.Drawing.Size(243, 24);
            this.cbEntrega.TabIndex = 13;
            this.cbEntrega.Text = "Entregar a:";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(477, 554);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(201, 33);
            this.btnConfirmar.TabIndex = 14;
            this.btnConfirmar.Text = "Confirmar Entrega";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Visible = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblComprobante
            // 
            this.lblComprobante.AutoSize = true;
            this.lblComprobante.Location = new System.Drawing.Point(757, 122);
            this.lblComprobante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComprobante.Name = "lblComprobante";
            this.lblComprobante.Size = new System.Drawing.Size(0, 17);
            this.lblComprobante.TabIndex = 15;
            // 
            // btPicking
            // 
            this.btPicking.Enabled = false;
            this.btPicking.Image = ((System.Drawing.Image)(resources.GetObject("btPicking.Image")));
            this.btPicking.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPicking.Location = new System.Drawing.Point(785, 105);
            this.btPicking.Margin = new System.Windows.Forms.Padding(4);
            this.btPicking.Name = "btPicking";
            this.btPicking.Size = new System.Drawing.Size(103, 43);
            this.btPicking.TabIndex = 16;
            this.btPicking.Text = "Picking";
            this.btPicking.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPicking.UseVisualStyleBackColor = true;
            this.btPicking.Click += new System.EventHandler(this.btPicking_Click);
            // 
            // Glocal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 602);
            this.Controls.Add(this.btPicking);
            this.Controls.Add(this.lblComprobante);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.cbEntrega);
            this.Controls.Add(this.btnEntregar);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.dgLocales);
            this.Controls.Add(this.lblActivos);
            this.Controls.Add(this.lblResponsable);
            this.Controls.Add(this.lblLocal);
            this.Controls.Add(this.cbNumero);
            this.Controls.Add(this.cbNivel);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Glocal";
            this.Text = "Gestión de Locales";
            this.Load += new System.EventHandler(this.Glocal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLocales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbEntrega;
        private System.Windows.Forms.RadioButton rbDevolucion;
        private System.Windows.Forms.RadioButton rbAuditoria;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbNivel;
        private System.Windows.Forms.ComboBox cbNumero;
        private System.Windows.Forms.Label lblLocal;
        private System.Windows.Forms.Label lblResponsable;
        private System.Windows.Forms.Label lblActivos;
        private System.Windows.Forms.DataGridView dgLocales;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Button btnEntregar;
        private System.Windows.Forms.ComboBox cbEntrega;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblComprobante;
        private System.Windows.Forms.Button btPicking;
    }
}