using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Config
{
    public partial class Preferencias : Form
    {
        public Preferencias()
        {
            InitializeComponent();
        }

        private void btCambioPass_Click(object sender, EventArgs e)
        {
            Config.CambiarPass cambio = new Config.CambiarPass();
            cambio.Show();
        }
    }
}
