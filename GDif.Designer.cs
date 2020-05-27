namespace WindowsFormsApplication1
{
    partial class GDif
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GDif));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cbResponsable = new System.Windows.Forms.ComboBox();
            this.cbComprobante = new System.Windows.Forms.ComboBox();
            this.cbNumero = new System.Windows.Forms.ComboBox();
            this.cbNivel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtdesde = new System.Windows.Forms.DateTimePicker();
            this.dthasta = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbEntrega = new System.Windows.Forms.RadioButton();
            this.rbAuditoria = new System.Windows.Forms.RadioButton();
            this.rbDevolucion = new System.Windows.Forms.RadioButton();
            this.cbLocales = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbNivel = new System.Windows.Forms.Label();
            this.lbLocal = new System.Windows.Forms.Label();
            this.dgvDiferencias = new System.Windows.Forms.DataGridView();
            this.cbReimprimir = new System.Windows.Forms.CheckBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cbEdificio = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiferencias)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(463, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Fecha hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Numero Comprobante";
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Fecha desde";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Tipo de Comprobante";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(662, 9);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(92, 60);
            this.btnBuscar.TabIndex = 30;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cbResponsable
            // 
            this.cbResponsable.FormattingEnabled = true;
            this.cbResponsable.Location = new System.Drawing.Point(158, 69);
            this.cbResponsable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbResponsable.Name = "cbResponsable";
            this.cbResponsable.Size = new System.Drawing.Size(123, 21);
            this.cbResponsable.TabIndex = 29;
            // 
            // cbComprobante
            // 
            this.cbComprobante.FormattingEnabled = true;
            this.cbComprobante.Location = new System.Drawing.Point(24, 69);
            this.cbComprobante.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbComprobante.Name = "cbComprobante";
            this.cbComprobante.Size = new System.Drawing.Size(108, 21);
            this.cbComprobante.TabIndex = 27;
            // 
            // cbNumero
            // 
            this.cbNumero.Enabled = false;
            this.cbNumero.FormattingEnabled = true;
            this.cbNumero.Location = new System.Drawing.Point(315, 116);
            this.cbNumero.Name = "cbNumero";
            this.cbNumero.Size = new System.Drawing.Size(145, 21);
            this.cbNumero.TabIndex = 36;
            // 
            // cbNivel
            // 
            this.cbNivel.Enabled = false;
            this.cbNivel.FormattingEnabled = true;
            this.cbNivel.Location = new System.Drawing.Point(158, 116);
            this.cbNivel.Name = "cbNivel";
            this.cbNivel.Size = new System.Drawing.Size(152, 21);
            this.cbNivel.TabIndex = 35;
            this.cbNivel.SelectedValueChanged += new System.EventHandler(this.cbNivel_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(156, 54);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Responsable";
            // 
            // dtdesde
            // 
            this.dtdesde.Location = new System.Drawing.Point(353, 32);
            this.dtdesde.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtdesde.Name = "dtdesde";
            this.dtdesde.Size = new System.Drawing.Size(96, 20);
            this.dtdesde.TabIndex = 38;
            this.dtdesde.Value = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            // 
            // dthasta
            // 
            this.dthasta.Location = new System.Drawing.Point(465, 32);
            this.dthasta.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dthasta.Name = "dthasta";
            this.dthasta.Size = new System.Drawing.Size(104, 20);
            this.dthasta.TabIndex = 39;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbEntrega);
            this.panel1.Controls.Add(this.rbAuditoria);
            this.panel1.Controls.Add(this.rbDevolucion);
            this.panel1.Location = new System.Drawing.Point(24, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 25);
            this.panel1.TabIndex = 40;
            // 
            // rbEntrega
            // 
            this.rbEntrega.AutoSize = true;
            this.rbEntrega.Checked = true;
            this.rbEntrega.Location = new System.Drawing.Point(14, 3);
            this.rbEntrega.Name = "rbEntrega";
            this.rbEntrega.Size = new System.Drawing.Size(106, 17);
            this.rbEntrega.TabIndex = 0;
            this.rbEntrega.TabStop = true;
            this.rbEntrega.Text = "Entrega de Local";
            this.rbEntrega.UseVisualStyleBackColor = true;
            // 
            // rbAuditoria
            // 
            this.rbAuditoria.AutoSize = true;
            this.rbAuditoria.Location = new System.Drawing.Point(251, 3);
            this.rbAuditoria.Name = "rbAuditoria";
            this.rbAuditoria.Size = new System.Drawing.Size(68, 17);
            this.rbAuditoria.TabIndex = 2;
            this.rbAuditoria.Text = "Auditoría";
            this.rbAuditoria.UseVisualStyleBackColor = true;
            // 
            // rbDevolucion
            // 
            this.rbDevolucion.AutoSize = true;
            this.rbDevolucion.Location = new System.Drawing.Point(126, 3);
            this.rbDevolucion.Name = "rbDevolucion";
            this.rbDevolucion.Size = new System.Drawing.Size(123, 17);
            this.rbDevolucion.TabIndex = 1;
            this.rbDevolucion.Text = "Devolución de Local";
            this.rbDevolucion.UseVisualStyleBackColor = true;
            // 
            // cbLocales
            // 
            this.cbLocales.FormattingEnabled = true;
            this.cbLocales.Location = new System.Drawing.Point(294, 69);
            this.cbLocales.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbLocales.Name = "cbLocales";
            this.cbLocales.Size = new System.Drawing.Size(184, 21);
            this.cbLocales.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(292, 54);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Local";
            // 
            // lbNivel
            // 
            this.lbNivel.AutoSize = true;
            this.lbNivel.Enabled = false;
            this.lbNivel.Location = new System.Drawing.Point(156, 99);
            this.lbNivel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNivel.Name = "lbNivel";
            this.lbNivel.Size = new System.Drawing.Size(31, 13);
            this.lbNivel.TabIndex = 43;
            this.lbNivel.Text = "Nivel";
            // 
            // lbLocal
            // 
            this.lbLocal.AutoSize = true;
            this.lbLocal.Enabled = false;
            this.lbLocal.Location = new System.Drawing.Point(315, 99);
            this.lbLocal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLocal.Name = "lbLocal";
            this.lbLocal.Size = new System.Drawing.Size(53, 13);
            this.lbLocal.TabIndex = 44;
            this.lbLocal.Text = "Nro Local";
            // 
            // dgvDiferencias
            // 
            this.dgvDiferencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiferencias.Location = new System.Drawing.Point(31, 160);
            this.dgvDiferencias.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvDiferencias.Name = "dgvDiferencias";
            this.dgvDiferencias.RowTemplate.Height = 24;
            this.dgvDiferencias.Size = new System.Drawing.Size(812, 213);
            this.dgvDiferencias.TabIndex = 45;
            this.dgvDiferencias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiferencias_CellClick_1);
            // 
            // cbReimprimir
            // 
            this.cbReimprimir.AutoSize = true;
            this.cbReimprimir.Location = new System.Drawing.Point(598, 130);
            this.cbReimprimir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbReimprimir.Name = "cbReimprimir";
            this.cbReimprimir.Size = new System.Drawing.Size(158, 17);
            this.cbReimprimir.TabIndex = 50;
            this.cbReimprimir.Text = "Reimprimir automaticamente";
            this.cbReimprimir.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Enabled = false;
            this.btnConfirmar.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmar.Image")));
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.Location = new System.Drawing.Point(728, 394);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(126, 39);
            this.btnConfirmar.TabIndex = 51;
            this.btnConfirmar.Text = "Confirmar diferencias";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 99);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 53;
            this.label9.Text = "Edificio";
            // 
            // cbEdificio
            // 
            this.cbEdificio.FormattingEnabled = true;
            this.cbEdificio.Location = new System.Drawing.Point(25, 116);
            this.cbEdificio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbEdificio.Name = "cbEdificio";
            this.cbEdificio.Size = new System.Drawing.Size(126, 21);
            this.cbEdificio.TabIndex = 52;
            this.cbEdificio.SelectedValueChanged += new System.EventHandler(this.cbEdificio_SelectedValueChanged);
            // 
            // GDif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 442);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbEdificio);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.cbReimprimir);
            this.Controls.Add(this.dgvDiferencias);
            this.Controls.Add(this.lbLocal);
            this.Controls.Add(this.lbNivel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbLocales);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dthasta);
            this.Controls.Add(this.dtdesde);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbNumero);
            this.Controls.Add(this.cbNivel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cbResponsable);
            this.Controls.Add(this.cbComprobante);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GDif";
            this.Text = " Gestión de Diferencias";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GDif_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiferencias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cbResponsable;
        private System.Windows.Forms.ComboBox cbComprobante;
        private System.Windows.Forms.ComboBox cbNumero;
        private System.Windows.Forms.ComboBox cbNivel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtdesde;
        private System.Windows.Forms.DateTimePicker dthasta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbEntrega;
        private System.Windows.Forms.RadioButton rbAuditoria;
        private System.Windows.Forms.RadioButton rbDevolucion;
        private System.Windows.Forms.ComboBox cbLocales;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbNivel;
        private System.Windows.Forms.Label lbLocal;
        private System.Windows.Forms.DataGridView dgvDiferencias;
        private System.Windows.Forms.CheckBox cbReimprimir;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbEdificio;
    }
}