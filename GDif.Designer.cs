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
            this.label4.Location = new System.Drawing.Point(664, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 34;
            this.label4.Text = "Fecha hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 17);
            this.label3.TabIndex = 33;
            this.label3.Text = "Numero Comprobante";
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(468, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 32;
            this.label2.Text = "Fecha desde";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "Tipo de Comprobante";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(883, 11);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(123, 74);
            this.btnBuscar.TabIndex = 30;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cbResponsable
            // 
            this.cbResponsable.FormattingEnabled = true;
            this.cbResponsable.Location = new System.Drawing.Point(211, 85);
            this.cbResponsable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbResponsable.Name = "cbResponsable";
            this.cbResponsable.Size = new System.Drawing.Size(163, 24);
            this.cbResponsable.TabIndex = 29;
            // 
            // cbComprobante
            // 
            this.cbComprobante.FormattingEnabled = true;
            this.cbComprobante.Location = new System.Drawing.Point(32, 85);
            this.cbComprobante.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbComprobante.Name = "cbComprobante";
            this.cbComprobante.Size = new System.Drawing.Size(143, 24);
            this.cbComprobante.TabIndex = 27;
            // 
            // cbNumero
            // 
            this.cbNumero.Enabled = false;
            this.cbNumero.FormattingEnabled = true;
            this.cbNumero.Location = new System.Drawing.Point(420, 143);
            this.cbNumero.Margin = new System.Windows.Forms.Padding(4);
            this.cbNumero.Name = "cbNumero";
            this.cbNumero.Size = new System.Drawing.Size(192, 24);
            this.cbNumero.TabIndex = 36;
            // 
            // cbNivel
            // 
            this.cbNivel.Enabled = false;
            this.cbNivel.FormattingEnabled = true;
            this.cbNivel.Location = new System.Drawing.Point(211, 143);
            this.cbNivel.Margin = new System.Windows.Forms.Padding(4);
            this.cbNivel.Name = "cbNivel";
            this.cbNivel.Size = new System.Drawing.Size(201, 24);
            this.cbNivel.TabIndex = 35;
            this.cbNivel.SelectedValueChanged += new System.EventHandler(this.cbNivel_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 37;
            this.label5.Text = "Responsable";
            // 
            // dtdesde
            // 
            this.dtdesde.Location = new System.Drawing.Point(471, 39);
            this.dtdesde.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtdesde.Name = "dtdesde";
            this.dtdesde.Size = new System.Drawing.Size(173, 22);
            this.dtdesde.TabIndex = 38;
            this.dtdesde.Value = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            this.dtdesde.ValueChanged += new System.EventHandler(this.dtdesde_ValueChanged_1);
            // 
            // dthasta
            // 
            this.dthasta.Location = new System.Drawing.Point(667, 39);
            this.dthasta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dthasta.Name = "dthasta";
            this.dthasta.Size = new System.Drawing.Size(137, 22);
            this.dthasta.TabIndex = 39;
            this.dthasta.ValueChanged += new System.EventHandler(this.dthasta_ValueChanged_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbEntrega);
            this.panel1.Controls.Add(this.rbAuditoria);
            this.panel1.Controls.Add(this.rbDevolucion);
            this.panel1.Location = new System.Drawing.Point(32, 30);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 31);
            this.panel1.TabIndex = 40;
            // 
            // rbEntrega
            // 
            this.rbEntrega.AutoSize = true;
            this.rbEntrega.Checked = true;
            this.rbEntrega.Location = new System.Drawing.Point(19, 4);
            this.rbEntrega.Margin = new System.Windows.Forms.Padding(4);
            this.rbEntrega.Name = "rbEntrega";
            this.rbEntrega.Size = new System.Drawing.Size(137, 21);
            this.rbEntrega.TabIndex = 0;
            this.rbEntrega.TabStop = true;
            this.rbEntrega.Text = "Entrega de Local";
            this.rbEntrega.UseVisualStyleBackColor = true;
            // 
            // rbAuditoria
            // 
            this.rbAuditoria.AutoSize = true;
            this.rbAuditoria.Location = new System.Drawing.Point(335, 4);
            this.rbAuditoria.Margin = new System.Windows.Forms.Padding(4);
            this.rbAuditoria.Name = "rbAuditoria";
            this.rbAuditoria.Size = new System.Drawing.Size(85, 21);
            this.rbAuditoria.TabIndex = 2;
            this.rbAuditoria.Text = "Auditoría";
            this.rbAuditoria.UseVisualStyleBackColor = true;
            // 
            // rbDevolucion
            // 
            this.rbDevolucion.AutoSize = true;
            this.rbDevolucion.Location = new System.Drawing.Point(168, 4);
            this.rbDevolucion.Margin = new System.Windows.Forms.Padding(4);
            this.rbDevolucion.Name = "rbDevolucion";
            this.rbDevolucion.Size = new System.Drawing.Size(157, 21);
            this.rbDevolucion.TabIndex = 1;
            this.rbDevolucion.Text = "Devolución de Local";
            this.rbDevolucion.UseVisualStyleBackColor = true;
            // 
            // cbLocales
            // 
            this.cbLocales.FormattingEnabled = true;
            this.cbLocales.Location = new System.Drawing.Point(392, 85);
            this.cbLocales.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbLocales.Name = "cbLocales";
            this.cbLocales.Size = new System.Drawing.Size(244, 24);
            this.cbLocales.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(389, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 42;
            this.label6.Text = "Local";
            // 
            // lbNivel
            // 
            this.lbNivel.AutoSize = true;
            this.lbNivel.Enabled = false;
            this.lbNivel.Location = new System.Drawing.Point(208, 122);
            this.lbNivel.Name = "lbNivel";
            this.lbNivel.Size = new System.Drawing.Size(39, 17);
            this.lbNivel.TabIndex = 43;
            this.lbNivel.Text = "Nivel";
            // 
            // lbLocal
            // 
            this.lbLocal.AutoSize = true;
            this.lbLocal.Enabled = false;
            this.lbLocal.Location = new System.Drawing.Point(420, 122);
            this.lbLocal.Name = "lbLocal";
            this.lbLocal.Size = new System.Drawing.Size(69, 17);
            this.lbLocal.TabIndex = 44;
            this.lbLocal.Text = "Nro Local";
            // 
            // dgvDiferencias
            // 
            this.dgvDiferencias.AllowUserToAddRows = false;
            this.dgvDiferencias.AllowUserToDeleteRows = false;
            this.dgvDiferencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiferencias.Location = new System.Drawing.Point(41, 197);
            this.dgvDiferencias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDiferencias.Name = "dgvDiferencias";
            this.dgvDiferencias.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvDiferencias.RowTemplate.Height = 24;
            this.dgvDiferencias.Size = new System.Drawing.Size(1322, 632);
            this.dgvDiferencias.TabIndex = 45;
            this.dgvDiferencias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiferencias_CellClick_1);
            this.dgvDiferencias.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvDiferencias_ColumnAdded);
            // 
            // cbReimprimir
            // 
            this.cbReimprimir.AutoSize = true;
            this.cbReimprimir.Location = new System.Drawing.Point(797, 160);
            this.cbReimprimir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbReimprimir.Name = "cbReimprimir";
            this.cbReimprimir.Size = new System.Drawing.Size(209, 21);
            this.cbReimprimir.TabIndex = 50;
            this.cbReimprimir.Text = "Reimprimir automaticamente";
            this.cbReimprimir.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Enabled = false;
            this.btnConfirmar.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmar.Image")));
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.Location = new System.Drawing.Point(1195, 852);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(168, 48);
            this.btnConfirmar.TabIndex = 51;
            this.btnConfirmar.Text = "Confirmar diferencias";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 17);
            this.label9.TabIndex = 53;
            this.label9.Text = "Edificio";
            // 
            // cbEdificio
            // 
            this.cbEdificio.FormattingEnabled = true;
            this.cbEdificio.Location = new System.Drawing.Point(33, 143);
            this.cbEdificio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbEdificio.Name = "cbEdificio";
            this.cbEdificio.Size = new System.Drawing.Size(167, 24);
            this.cbEdificio.TabIndex = 52;
            this.cbEdificio.SelectedValueChanged += new System.EventHandler(this.cbEdificio_SelectedValueChanged);
            // 
            // GDif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 933);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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