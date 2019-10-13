namespace WindowsFormsApplication1
{
    partial class home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(home));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Solicitudes = new System.Windows.Forms.ToolStripMenuItem();
            this.GSolicitudes = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDeLocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprobantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bienesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sincronizaciónSIPRECOREVIT = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btPreferencias = new System.Windows.Forms.Button();
            this.tcNotificaciones = new System.Windows.Forms.TabControl();
            this.TbNoti = new System.Windows.Forms.TabPage();
            this.gestiónDeDiferenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprobantesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tcNotificaciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Solicitudes,
            this.GSolicitudes,
            this.gestiónDeLocalToolStripMenuItem,
            this.bienesToolStripMenuItem,
            this.sincronizaciónSIPRECOREVIT,
            this.calendarioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(887, 42);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Solicitudes
            // 
            this.Solicitudes.Name = "Solicitudes";
            this.Solicitudes.Size = new System.Drawing.Size(93, 38);
            this.Solicitudes.Text = "Solicitudes";
            this.Solicitudes.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // GSolicitudes
            // 
            this.GSolicitudes.Name = "GSolicitudes";
            this.GSolicitudes.Size = new System.Drawing.Size(166, 38);
            this.GSolicitudes.Text = "Gestión de solicitudes";
            this.GSolicitudes.Click += new System.EventHandler(this.gestiónESToolStripMenuItem_Click);
            // 
            // gestiónDeLocalToolStripMenuItem
            // 
            this.gestiónDeLocalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comprobantesToolStripMenuItem,
            this.gestiónDeDiferenciasToolStripMenuItem,
            this.comprobantesToolStripMenuItem1});
            this.gestiónDeLocalToolStripMenuItem.Name = "gestiónDeLocalToolStripMenuItem";
            this.gestiónDeLocalToolStripMenuItem.Size = new System.Drawing.Size(70, 38);
            this.gestiónDeLocalToolStripMenuItem.Text = "Locales";
            this.gestiónDeLocalToolStripMenuItem.Click += new System.EventHandler(this.gestiónDeLocalToolStripMenuItem_Click);
            // 
            // comprobantesToolStripMenuItem
            // 
            this.comprobantesToolStripMenuItem.Name = "comprobantesToolStripMenuItem";
            this.comprobantesToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.comprobantesToolStripMenuItem.Text = "Gestión de Local";
            this.comprobantesToolStripMenuItem.Click += new System.EventHandler(this.comprobantesToolStripMenuItem_Click);
            // 
            // bienesToolStripMenuItem
            // 
            this.bienesToolStripMenuItem.Name = "bienesToolStripMenuItem";
            this.bienesToolStripMenuItem.Size = new System.Drawing.Size(64, 38);
            this.bienesToolStripMenuItem.Text = "Bienes";
            this.bienesToolStripMenuItem.Click += new System.EventHandler(this.bienesToolStripMenuItem_Click);
            // 
            // sincronizaciónSIPRECOREVIT
            // 
            this.sincronizaciónSIPRECOREVIT.Name = "sincronizaciónSIPRECOREVIT";
            this.sincronizaciónSIPRECOREVIT.Size = new System.Drawing.Size(222, 38);
            this.sincronizaciónSIPRECOREVIT.Text = "Sincronización SIPRECO-REVIT";
            this.sincronizaciónSIPRECOREVIT.Click += new System.EventHandler(this.sincronizaciónSIPRECOREVITToolStripMenuItem_Click);
            // 
            // calendarioToolStripMenuItem
            // 
            this.calendarioToolStripMenuItem.Name = "calendarioToolStripMenuItem";
            this.calendarioToolStripMenuItem.Size = new System.Drawing.Size(93, 38);
            this.calendarioToolStripMenuItem.Text = "Calendario";
            this.calendarioToolStripMenuItem.Click += new System.EventHandler(this.calendarioToolStripMenuItem_Click);
            // 
            // btPreferencias
            // 
            this.btPreferencias.AutoSize = true;
            this.btPreferencias.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btPreferencias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPreferencias.ForeColor = System.Drawing.Color.Transparent;
            this.btPreferencias.Image = ((System.Drawing.Image)(resources.GetObject("btPreferencias.Image")));
            this.btPreferencias.Location = new System.Drawing.Point(837, 3);
            this.btPreferencias.Name = "btPreferencias";
            this.btPreferencias.Size = new System.Drawing.Size(33, 33);
            this.btPreferencias.TabIndex = 2;
            this.btPreferencias.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btPreferencias.UseVisualStyleBackColor = false;
            this.btPreferencias.Click += new System.EventHandler(this.btPreferencias_Click);
            // 
            // tcNotificaciones
            // 
            this.tcNotificaciones.Controls.Add(this.TbNoti);
            this.tcNotificaciones.ItemSize = new System.Drawing.Size(90, 21);
            this.tcNotificaciones.Location = new System.Drawing.Point(12, 45);
            this.tcNotificaciones.Name = "tcNotificaciones";
            this.tcNotificaciones.SelectedIndex = 0;
            this.tcNotificaciones.Size = new System.Drawing.Size(857, 139);
            this.tcNotificaciones.TabIndex = 3;
            // 
            // TbNoti
            // 
            this.TbNoti.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TbNoti.Location = new System.Drawing.Point(4, 25);
            this.TbNoti.Name = "TbNoti";
            this.TbNoti.Size = new System.Drawing.Size(849, 110);
            this.TbNoti.TabIndex = 0;
            this.TbNoti.Text = "NOTIFICACIONES";
            // 
            // gestiónDeDiferenciasToolStripMenuItem
            // 
            this.gestiónDeDiferenciasToolStripMenuItem.Name = "gestiónDeDiferenciasToolStripMenuItem";
            this.gestiónDeDiferenciasToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.gestiónDeDiferenciasToolStripMenuItem.Text = "Gestión de Diferencias";
            this.gestiónDeDiferenciasToolStripMenuItem.Click += new System.EventHandler(this.gestiónDeDiferenciasToolStripMenuItem_Click);
            // 
            // comprobantesToolStripMenuItem1
            // 
            this.comprobantesToolStripMenuItem1.Name = "comprobantesToolStripMenuItem1";
            this.comprobantesToolStripMenuItem1.Size = new System.Drawing.Size(233, 26);
            this.comprobantesToolStripMenuItem1.Text = "Comprobantes";
            this.comprobantesToolStripMenuItem1.Click += new System.EventHandler(this.comprobantesToolStripMenuItem1_Click);
            // 
            // home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 421);
            this.Controls.Add(this.tcNotificaciones);
            this.Controls.Add(this.btPreferencias);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "home";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.home_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tcNotificaciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Solicitudes;
        private System.Windows.Forms.ToolStripMenuItem GSolicitudes;
        private System.Windows.Forms.ToolStripMenuItem gestiónDeLocalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bienesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sincronizaciónSIPRECOREVIT;
        private System.Windows.Forms.ToolStripMenuItem calendarioToolStripMenuItem;
        private System.Windows.Forms.Button btPreferencias;
        private System.Windows.Forms.TabControl tcNotificaciones;
        private System.Windows.Forms.TabPage TbNoti;
        private System.Windows.Forms.ToolStripMenuItem comprobantesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónDeDiferenciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprobantesToolStripMenuItem1;
    }
}