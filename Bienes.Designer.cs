namespace WindowsFormsApplication1
{
    partial class Bienes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bienes));
            this.dgBienes = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cbLocales = new System.Windows.Forms.ComboBox();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.cbFamilia = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.PDF = new System.Windows.Forms.Button();
            this.cbRubro = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgBienes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgBienes
            // 
            this.dgBienes.AllowUserToAddRows = false;
            this.dgBienes.AllowUserToDeleteRows = false;
            this.dgBienes.AllowUserToOrderColumns = true;
            this.dgBienes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgBienes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBienes.Location = new System.Drawing.Point(67, 130);
            this.dgBienes.Margin = new System.Windows.Forms.Padding(4);
            this.dgBienes.Name = "dgBienes";
            this.dgBienes.ReadOnly = true;
            this.dgBienes.Size = new System.Drawing.Size(1009, 405);
            this.dgBienes.TabIndex = 10;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(628, 40);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(68, 74);
            this.btnBuscar.TabIndex = 21;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // cbLocales
            // 
            this.cbLocales.FormattingEnabled = true;
            this.cbLocales.Location = new System.Drawing.Point(344, 90);
            this.cbLocales.Name = "cbLocales";
            this.cbLocales.Size = new System.Drawing.Size(259, 24);
            this.cbLocales.TabIndex = 20;
            this.cbLocales.Text = "Todos";
            this.cbLocales.SelectedValueChanged += new System.EventHandler(this.cbLocales_SelectedValueChanged);
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(67, 90);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(259, 24);
            this.cbTipo.TabIndex = 19;
            this.cbTipo.Text = "Todos";
            this.cbTipo.SelectedValueChanged += new System.EventHandler(this.cbTipo_SelectedValueChanged);
            // 
            // cbFamilia
            // 
            this.cbFamilia.FormattingEnabled = true;
            this.cbFamilia.Location = new System.Drawing.Point(344, 40);
            this.cbFamilia.Name = "cbFamilia";
            this.cbFamilia.Size = new System.Drawing.Size(259, 24);
            this.cbFamilia.TabIndex = 18;
            this.cbFamilia.Text = "Todos";
            this.cbFamilia.SelectedValueChanged += new System.EventHandler(this.cbFamilia_SelectedValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(845, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 29);
            this.button2.TabIndex = 17;
            this.button2.Text = "Imprimir";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // PDF
            // 
            this.PDF.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.PDF.Location = new System.Drawing.Point(845, 25);
            this.PDF.Name = "PDF";
            this.PDF.Size = new System.Drawing.Size(75, 26);
            this.PDF.TabIndex = 16;
            this.PDF.Text = "PDF";
            this.PDF.UseVisualStyleBackColor = true;
            this.PDF.Click += new System.EventHandler(this.PDF_Click);
            // 
            // cbRubro
            // 
            this.cbRubro.FormattingEnabled = true;
            this.cbRubro.Location = new System.Drawing.Point(67, 40);
            this.cbRubro.Name = "cbRubro";
            this.cbRubro.Size = new System.Drawing.Size(259, 24);
            this.cbRubro.TabIndex = 15;
            this.cbRubro.Text = "Todos";
            this.cbRubro.SelectedValueChanged += new System.EventHandler(this.cbRubro_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Rubro";
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tipo de Bien";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Familia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Locales";
            // 
            // Bienes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 590);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cbLocales);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.cbFamilia);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.PDF);
            this.Controls.Add(this.cbRubro);
            this.Controls.Add(this.dgBienes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Bienes";
            this.Text = "Bienes";
            this.Load += new System.EventHandler(this.Bienes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBienes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cbLocales;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.ComboBox cbFamilia;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button PDF;
        private System.Windows.Forms.ComboBox cbRubro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgBienes;
    }
}