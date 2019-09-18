namespace WindowsFormsApplication1
{
    partial class Picking
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
            this.dgPicking = new System.Windows.Forms.DataGridView();
            this.Bien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btConfirmar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgPicking)).BeginInit();
            this.SuspendLayout();
            // 
            // dgPicking
            // 
            this.dgPicking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPicking.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Bien});
            this.dgPicking.Location = new System.Drawing.Point(40, 30);
            this.dgPicking.Name = "dgPicking";
            this.dgPicking.Size = new System.Drawing.Size(293, 244);
            this.dgPicking.TabIndex = 0;
            // 
            // Bien
            // 
            this.Bien.HeaderText = "Bien";
            this.Bien.Name = "Bien";
            this.Bien.Width = 250;
            // 
            // btConfirmar
            // 
            this.btConfirmar.Location = new System.Drawing.Point(40, 300);
            this.btConfirmar.Name = "btConfirmar";
            this.btConfirmar.Size = new System.Drawing.Size(125, 35);
            this.btConfirmar.TabIndex = 1;
            this.btConfirmar.Text = "Confirmar";
            this.btConfirmar.UseVisualStyleBackColor = true;
            this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(208, 300);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(125, 35);
            this.btCancelar.TabIndex = 2;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // Picking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 345);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btConfirmar);
            this.Controls.Add(this.dgPicking);
            this.Name = "Picking";
            this.Text = "Picking";
            ((System.ComponentModel.ISupportInitialize)(this.dgPicking)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPicking;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bien;
        private System.Windows.Forms.Button btConfirmar;
        private System.Windows.Forms.Button btCancelar;
    }
}