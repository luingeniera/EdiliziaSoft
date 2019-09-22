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
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgBienes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgBienes
            // 
            this.dgBienes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBienes.Location = new System.Drawing.Point(67, 130);
            this.dgBienes.Margin = new System.Windows.Forms.Padding(4);
            this.dgBienes.Name = "dgBienes";
            this.dgBienes.Size = new System.Drawing.Size(853, 405);
            this.dgBienes.TabIndex = 10;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(628, 25);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(130, 26);
            this.btnBuscar.TabIndex = 21;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // cbLocales
            // 
            this.cbLocales.FormattingEnabled = true;
            this.cbLocales.Location = new System.Drawing.Point(344, 64);
            this.cbLocales.Name = "cbLocales";
            this.cbLocales.Size = new System.Drawing.Size(259, 24);
            this.cbLocales.TabIndex = 20;
            this.cbLocales.Text = "Locales";
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(67, 64);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(259, 24);
            this.cbTipo.TabIndex = 19;
            this.cbTipo.Text = "Tipo de Bien";
            // 
            // cbFamilia
            // 
            this.cbFamilia.FormattingEnabled = true;
            this.cbFamilia.Location = new System.Drawing.Point(344, 28);
            this.cbFamilia.Name = "cbFamilia";
            this.cbFamilia.Size = new System.Drawing.Size(259, 24);
            this.cbFamilia.TabIndex = 18;
            this.cbFamilia.Text = "Familia";
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
            // cbCategoria
            // 
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(67, 28);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(259, 24);
            this.cbCategoria.TabIndex = 15;
            this.cbCategoria.Text = "Categoria";
            // 
            // Bienes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 664);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cbLocales);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.cbFamilia);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.PDF);
            this.Controls.Add(this.cbCategoria);
            this.Controls.Add(this.dgBienes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Bienes";
            this.Text = "Bienes";
            this.Load += new System.EventHandler(this.Bienes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBienes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgBienes;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cbLocales;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.ComboBox cbFamilia;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button PDF;
        private System.Windows.Forms.ComboBox cbCategoria;
    }
}