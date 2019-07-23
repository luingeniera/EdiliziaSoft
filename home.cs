using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Solicitudes sol = new Solicitudes();
            sol.Show();
        }

        private void gestiónESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gsolicitudes Gsol = new Gsolicitudes ();
            Gsol.Show();
        }

        private void sincronizaciónSIPRECOREVITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sincro Sincro = new Sincro();
            Sincro.Show();
        }

        private void bienesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bienes Bien = new Bienes();
            Bien.Show();
        }

        private void calendarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calendario Cal = new Calendario();
            Cal.Show();
        }

        private void gestiónDeLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Glocal Local = new Glocal();
            Local.Show();
        }
    }
}
