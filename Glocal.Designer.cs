﻿namespace WindowsFormsApplication1
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
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLocales)).BeginInit();
            this.SuspendLayout();
            // 
            // rbEntrega
            // 
            this.rbEntrega.AutoSize = true;
            this.rbEntrega.Location = new System.Drawing.Point(14, 3);
            this.rbEntrega.Name = "rbEntrega";
            this.rbEntrega.Size = new System.Drawing.Size(106, 17);
            this.rbEntrega.TabIndex = 0;
            this.rbEntrega.TabStop = true;
            this.rbEntrega.Text = "Entrega de Local";
            this.rbEntrega.UseVisualStyleBackColor = true;
            // 
            // rbDevolucion
            // 
            this.rbDevolucion.AutoSize = true;
            this.rbDevolucion.Location = new System.Drawing.Point(126, 3);
            this.rbDevolucion.Name = "rbDevolucion";
            this.rbDevolucion.Size = new System.Drawing.Size(123, 17);
            this.rbDevolucion.TabIndex = 1;
            this.rbDevolucion.TabStop = true;
            this.rbDevolucion.Text = "Devolución de Local";
            this.rbDevolucion.UseVisualStyleBackColor = true;
            // 
            // rbAuditoria
            // 
            this.rbAuditoria.AutoSize = true;
            this.rbAuditoria.Location = new System.Drawing.Point(251, 3);
            this.rbAuditoria.Name = "rbAuditoria";
            this.rbAuditoria.Size = new System.Drawing.Size(68, 17);
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
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 25);
            this.panel1.TabIndex = 3;
            // 
            // cbNivel
            // 
            this.cbNivel.FormattingEnabled = true;
            this.cbNivel.Location = new System.Drawing.Point(26, 62);
            this.cbNivel.Name = "cbNivel";
            this.cbNivel.Size = new System.Drawing.Size(152, 21);
            this.cbNivel.TabIndex = 4;
            this.cbNivel.Text = "Nivel";
            this.cbNivel.SelectedValueChanged += new System.EventHandler(this.cbNivel_SelectedValueChanged);
            // 
            // cbNumero
            // 
            this.cbNumero.FormattingEnabled = true;
            this.cbNumero.Location = new System.Drawing.Point(215, 62);
            this.cbNumero.Name = "cbNumero";
            this.cbNumero.Size = new System.Drawing.Size(172, 21);
            this.cbNumero.TabIndex = 5;
            this.cbNumero.Text = "Número";
            // 
            // lblLocal
            // 
            this.lblLocal.AutoSize = true;
            this.lblLocal.Location = new System.Drawing.Point(23, 100);
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new System.Drawing.Size(56, 13);
            this.lblLocal.TabIndex = 6;
            this.lblLocal.Text = "label1XXX";
            // 
            // lblResponsable
            // 
            this.lblResponsable.AutoSize = true;
            this.lblResponsable.Location = new System.Drawing.Point(212, 100);
            this.lblResponsable.Name = "lblResponsable";
            this.lblResponsable.Size = new System.Drawing.Size(72, 13);
            this.lblResponsable.TabIndex = 7;
            this.lblResponsable.Text = "Responsable:";
            // 
            // lblActivos
            // 
            this.lblActivos.AutoSize = true;
            this.lblActivos.Location = new System.Drawing.Point(530, 100);
            this.lblActivos.Name = "lblActivos";
            this.lblActivos.Size = new System.Drawing.Size(73, 13);
            this.lblActivos.TabIndex = 8;
            this.lblActivos.Text = "Cant. Activos:";
            // 
            // dgLocales
            // 
            this.dgLocales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLocales.Location = new System.Drawing.Point(26, 127);
            this.dgLocales.Name = "dgLocales";
            this.dgLocales.Size = new System.Drawing.Size(640, 329);
            this.dgLocales.TabIndex = 9;
            // 
            // btBuscar
            // 
            this.btBuscar.Location = new System.Drawing.Point(533, 61);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(105, 20);
            this.btBuscar.TabIndex = 10;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // Glocal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 489);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.dgLocales);
            this.Controls.Add(this.lblActivos);
            this.Controls.Add(this.lblResponsable);
            this.Controls.Add(this.lblLocal);
            this.Controls.Add(this.cbNumero);
            this.Controls.Add(this.cbNivel);
            this.Controls.Add(this.panel1);
            this.Name = "Glocal";
            this.Text = "Glocal";
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
    }
}