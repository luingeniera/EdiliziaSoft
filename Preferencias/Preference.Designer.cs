namespace WindowsFormsApplication1.Preferencias
{
    partial class Preference
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preference));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rbtUsuario = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtpassactual = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtpass2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(413, 302);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rbtUsuario);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(405, 273);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos de Usuario";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rbtUsuario
            // 
            this.rbtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rbtUsuario.Location = new System.Drawing.Point(28, 21);
            this.rbtUsuario.Name = "rbtUsuario";
            this.rbtUsuario.Size = new System.Drawing.Size(339, 219);
            this.rbtUsuario.TabIndex = 0;
            this.rbtUsuario.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtpassactual);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtUser);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtpass2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.cmdAceptar);
            this.tabPage2.Controls.Add(this.txtpass);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(405, 273);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cambio de Contraseña";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtpassactual
            // 
            this.txtpassactual.Location = new System.Drawing.Point(176, 67);
            this.txtpassactual.Name = "txtpassactual";
            this.txtpassactual.Size = new System.Drawing.Size(183, 22);
            this.txtpassactual.TabIndex = 81;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 67);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 17);
            this.label5.TabIndex = 80;
            this.label5.Text = "Contraseña Actual";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(176, 39);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(183, 22);
            this.txtUser.TabIndex = 79;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 160);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(311, 15);
            this.label4.TabIndex = 78;
            this.label4.Text = "*La contraseña debe tener como máximo 15 caracteres";
            // 
            // txtpass2
            // 
            this.txtpass2.Location = new System.Drawing.Point(176, 128);
            this.txtpass2.Margin = new System.Windows.Forms.Padding(4);
            this.txtpass2.Name = "txtpass2";
            this.txtpass2.Size = new System.Drawing.Size(183, 22);
            this.txtpass2.TabIndex = 73;
            this.txtpass2.TextChanged += new System.EventHandler(this.txtpass2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 17);
            this.label3.TabIndex = 77;
            this.label3.Text = "Repetir contraseña";
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Enabled = false;
            this.cmdAceptar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAceptar.Image")));
            this.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdAceptar.Location = new System.Drawing.Point(258, 214);
            this.cmdAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(116, 52);
            this.cmdAceptar.TabIndex = 74;
            this.cmdAceptar.Text = "Confirmar";
            this.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdAceptar.UseVisualStyleBackColor = true;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(176, 98);
            this.txtpass.Margin = new System.Windows.Forms.Padding(4);
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '*';
            this.txtpass.Size = new System.Drawing.Size(183, 22);
            this.txtpass.TabIndex = 72;
            this.txtpass.TextChanged += new System.EventHandler(this.txtpass_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 17);
            this.label2.TabIndex = 76;
            this.label2.Text = "Nueva contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 75;
            this.label1.Text = "Usuario";
            // 
            // Preference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 360);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Preference";
            this.Text = "Preferencias de Usuario";
            this.Load += new System.EventHandler(this.Preference_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox rbtUsuario;
        private System.Windows.Forms.TextBox txtpassactual;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtpass2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}