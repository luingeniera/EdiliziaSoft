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
            this.PDF = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLocales)).BeginInit();
            this.SuspendLayout();
            // 
            // rbEntrega
            // 
            this.rbEntrega.AutoSize = true;
            this.rbEntrega.Location = new System.Drawing.Point(19, 4);
            this.rbEntrega.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.rbDevolucion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.rbAuditoria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 31);
            this.panel1.TabIndex = 3;
            // 
            // cbNivel
            // 
            this.cbNivel.FormattingEnabled = true;
            this.cbNivel.Location = new System.Drawing.Point(35, 76);
            this.cbNivel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbNivel.Name = "cbNivel";
            this.cbNivel.Size = new System.Drawing.Size(201, 24);
            this.cbNivel.TabIndex = 4;
            this.cbNivel.Text = "Nivel";
            this.cbNivel.SelectedValueChanged += new System.EventHandler(this.cbNivel_SelectedValueChanged);
            // 
            // cbNumero
            // 
            this.cbNumero.FormattingEnabled = true;
            this.cbNumero.Location = new System.Drawing.Point(287, 76);
            this.cbNumero.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbNumero.Name = "cbNumero";
            this.cbNumero.Size = new System.Drawing.Size(228, 24);
            this.cbNumero.TabIndex = 5;
            this.cbNumero.Text = "Número";
            // 
            // lblLocal
            // 
            this.lblLocal.AutoSize = true;
            this.lblLocal.Location = new System.Drawing.Point(31, 123);
            this.lblLocal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new System.Drawing.Size(73, 17);
            this.lblLocal.TabIndex = 6;
            this.lblLocal.Text = "label1XXX";
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
            this.lblActivos.Location = new System.Drawing.Point(707, 123);
            this.lblActivos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActivos.Name = "lblActivos";
            this.lblActivos.Size = new System.Drawing.Size(94, 17);
            this.lblActivos.TabIndex = 8;
            this.lblActivos.Text = "Cant. Activos:";
            // 
            // dgLocales
            // 
            this.dgLocales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLocales.Location = new System.Drawing.Point(35, 156);
            this.dgLocales.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgLocales.Name = "dgLocales";
            this.dgLocales.Size = new System.Drawing.Size(853, 405);
            this.dgLocales.TabIndex = 9;
            // 
            // btBuscar
            // 
            this.btBuscar.Location = new System.Drawing.Point(711, 75);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(140, 25);
            this.btBuscar.TabIndex = 10;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // PDF
            // 
            this.PDF.Location = new System.Drawing.Point(775, 38);
            this.PDF.Name = "PDF";
            this.PDF.Size = new System.Drawing.Size(75, 23);
            this.PDF.TabIndex = 11;
            this.PDF.Text = "PDF";
            this.PDF.UseVisualStyleBackColor = true;
            this.PDF.Click += new System.EventHandler(this.PDF_Click);
            // 
            // Glocal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 602);
            this.Controls.Add(this.PDF);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.dgLocales);
            this.Controls.Add(this.lblActivos);
            this.Controls.Add(this.lblResponsable);
            this.Controls.Add(this.lblLocal);
            this.Controls.Add(this.cbNumero);
            this.Controls.Add(this.cbNivel);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Glocal";
            this.Text = "Gestión de Local";
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
        private System.Windows.Forms.Button PDF;
    }
}