namespace WindowsFormsApplication1.Config
{
    partial class Preferencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preferencias));
            this.btCambioPass = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btCambioPass
            // 
            this.btCambioPass.Enabled = false;
            this.btCambioPass.Image = ((System.Drawing.Image)(resources.GetObject("btCambioPass.Image")));
            this.btCambioPass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCambioPass.Location = new System.Drawing.Point(12, 38);
            this.btCambioPass.Name = "btCambioPass";
            this.btCambioPass.Size = new System.Drawing.Size(262, 40);
            this.btCambioPass.TabIndex = 0;
            this.btCambioPass.Text = "Cambiar Datos de usuario";
            this.btCambioPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCambioPass.UseVisualStyleBackColor = true;
            this.btCambioPass.Click += new System.EventHandler(this.btCambioPass_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(12, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(262, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cambiar Contraseña";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Preferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 142);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btCambioPass);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Preferencias";
            this.Text = "Preferencias";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btCambioPass;
        private System.Windows.Forms.Button button1;
    }
}