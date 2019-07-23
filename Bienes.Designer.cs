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
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.PDF = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dgBienes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgBienes)).BeginInit();
            this.SuspendLayout();
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(67, 26);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(259, 24);
            this.cbTipo.TabIndex = 0;
            this.cbTipo.Text = "Tipo de Bien";
            this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // PDF
            // 
            this.PDF.Image = ((System.Drawing.Image)(resources.GetObject("PDF.Image")));
            this.PDF.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.PDF.Location = new System.Drawing.Point(845, 26);
            this.PDF.Name = "PDF";
            this.PDF.Size = new System.Drawing.Size(75, 23);
            this.PDF.TabIndex = 1;
            this.PDF.Text = "PDF";
            this.PDF.UseVisualStyleBackColor = true;
            this.PDF.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(845, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "Imprimir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // Bienes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 664);
            this.Controls.Add(this.dgBienes);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.PDF);
            this.Controls.Add(this.cbTipo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Bienes";
            this.Text = "Bienes";
            this.Load += new System.EventHandler(this.Bienes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBienes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Button PDF;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgBienes;


    }
}