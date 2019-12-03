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
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvDiferencias = new System.Windows.Forms.DataGridView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiferencias)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 34;
            this.label4.Text = "Fecha hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(485, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 17);
            this.label3.TabIndex = 33;
            this.label3.Text = "Numero Comprobante";
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 64);
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
            this.btnBuscar.Location = new System.Drawing.Point(780, 37);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(181, 74);
            this.btnBuscar.TabIndex = 30;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cbResponsable
            // 
            this.cbResponsable.FormattingEnabled = true;
            this.cbResponsable.Location = new System.Drawing.Point(32, 140);
            this.cbResponsable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbResponsable.Name = "cbResponsable";
            this.cbResponsable.Size = new System.Drawing.Size(259, 24);
            this.cbResponsable.TabIndex = 29;
            // 
            // cbComprobante
            // 
            this.cbComprobante.FormattingEnabled = true;
            this.cbComprobante.Location = new System.Drawing.Point(485, 37);
            this.cbComprobante.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbComprobante.Name = "cbComprobante";
            this.cbComprobante.Size = new System.Drawing.Size(259, 24);
            this.cbComprobante.TabIndex = 27;
            // 
            // cbNumero
            // 
            this.cbNumero.FormattingEnabled = true;
            this.cbNumero.Location = new System.Drawing.Point(545, 187);
            this.cbNumero.Margin = new System.Windows.Forms.Padding(4);
            this.cbNumero.Name = "cbNumero";
            this.cbNumero.Size = new System.Drawing.Size(192, 24);
            this.cbNumero.TabIndex = 36;
            this.cbNumero.Text = "Número";
            // 
            // cbNivel
            // 
            this.cbNivel.FormattingEnabled = true;
            this.cbNivel.Location = new System.Drawing.Point(311, 187);
            this.cbNivel.Margin = new System.Windows.Forms.Padding(4);
            this.cbNivel.Name = "cbNivel";
            this.cbNivel.Size = new System.Drawing.Size(201, 24);
            this.cbNivel.TabIndex = 35;
            this.cbNivel.Text = "Nivel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 37;
            this.label5.Text = "Responsable";
            // 
            // dtdesde
            // 
            this.dtdesde.Location = new System.Drawing.Point(29, 85);
            this.dtdesde.Name = "dtdesde";
            this.dtdesde.Size = new System.Drawing.Size(200, 22);
            this.dtdesde.TabIndex = 38;
            this.dtdesde.Value = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            // 
            // dthasta
            // 
            this.dthasta.Location = new System.Drawing.Point(249, 86);
            this.dthasta.Name = "dthasta";
            this.dthasta.Size = new System.Drawing.Size(200, 22);
            this.dthasta.TabIndex = 39;
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
            this.cbLocales.Location = new System.Drawing.Point(32, 187);
            this.cbLocales.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbLocales.Name = "cbLocales";
            this.cbLocales.Size = new System.Drawing.Size(259, 24);
            this.cbLocales.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 42;
            this.label6.Text = "Local";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(308, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 17);
            this.label7.TabIndex = 43;
            this.label7.Text = "Nivel";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(545, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 44;
            this.label8.Text = "Nro Local";
            // 
            // dgvDiferencias
            // 
            this.dgvDiferencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiferencias.Location = new System.Drawing.Point(41, 243);
            this.dgvDiferencias.Name = "dgvDiferencias";
            this.dgvDiferencias.RowTemplate.Height = 24;
            this.dgvDiferencias.Size = new System.Drawing.Size(965, 216);
            this.dgvDiferencias.TabIndex = 45;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(766, 115);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(215, 122);
            this.richTextBox1.TabIndex = 47;
            this.richTextBox1.Text = "";
            // 
            // GDif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 496);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.dgvDiferencias);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
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
            this.Name = "GDif";
            this.Text = " ";
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvDiferencias;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}