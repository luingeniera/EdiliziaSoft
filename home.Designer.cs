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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Solicitudes = new System.Windows.Forms.ToolStripMenuItem();
            this.GSolicitudes = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDeLocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bienesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sincronizaciónSIPRECOREVIT = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
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
            this.menuStrip1.Size = new System.Drawing.Size(1100, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Solicitudes
            // 
            this.Solicitudes.Name = "Solicitudes";
            this.Solicitudes.Size = new System.Drawing.Size(93, 24);
            this.Solicitudes.Text = "Solicitudes";
            this.Solicitudes.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // GSolicitudes
            // 
            this.GSolicitudes.Name = "GSolicitudes";
            this.GSolicitudes.Size = new System.Drawing.Size(166, 24);
            this.GSolicitudes.Text = "Gestión de solicitudes";
            this.GSolicitudes.Click += new System.EventHandler(this.gestiónESToolStripMenuItem_Click);
            // 
            // gestiónDeLocalToolStripMenuItem
            // 
            this.gestiónDeLocalToolStripMenuItem.Name = "gestiónDeLocalToolStripMenuItem";
            this.gestiónDeLocalToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.gestiónDeLocalToolStripMenuItem.Text = "Gestión de local";
            this.gestiónDeLocalToolStripMenuItem.Click += new System.EventHandler(this.gestiónDeLocalToolStripMenuItem_Click);
            // 
            // bienesToolStripMenuItem
            // 
            this.bienesToolStripMenuItem.Name = "bienesToolStripMenuItem";
            this.bienesToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.bienesToolStripMenuItem.Text = "Bienes";
            this.bienesToolStripMenuItem.Click += new System.EventHandler(this.bienesToolStripMenuItem_Click);
            // 
            // sincronizaciónSIPRECOREVIT
            // 
            this.sincronizaciónSIPRECOREVIT.Name = "sincronizaciónSIPRECOREVIT";
            this.sincronizaciónSIPRECOREVIT.Size = new System.Drawing.Size(222, 24);
            this.sincronizaciónSIPRECOREVIT.Text = "Sincronización SIPRECO-REVIT";
            this.sincronizaciónSIPRECOREVIT.Click += new System.EventHandler(this.sincronizaciónSIPRECOREVITToolStripMenuItem_Click);
            // 
            // calendarioToolStripMenuItem
            // 
            this.calendarioToolStripMenuItem.Name = "calendarioToolStripMenuItem";
            this.calendarioToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.calendarioToolStripMenuItem.Text = "Calendario";
            this.calendarioToolStripMenuItem.Click += new System.EventHandler(this.calendarioToolStripMenuItem_Click);
            // 
            // home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 532);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "home";
            this.Text = "Principal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}