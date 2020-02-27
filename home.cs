using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
           
        }
        private void home_Load(object sender, EventArgs e)
        {
       
    
            // TabPage tabnotificaciones = new TabPage();
            //tabnotificaciones.Name = "tabnoti";
            //tabnotificaciones.Text = "Notificaciones";
            //tabnotificaciones.BackColor = Color.Gray;
         
            //tabnotificaciones.Font = new Font("Verdana", 12);
          
           // tcNotificaciones.TabPages.Add(tabnotificaciones);


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
            //Por ahora lo comento.
            //Calendario Cal = new Calendario();
            //Cal.Show();
        }

        private void gestiónDeLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void btPreferencias_Click(object sender, EventArgs e)
        {
            Preferencias.Preference preferencias = new Preferencias.Preference();
            preferencias.Show();
        }

        private void comprobantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Glocal Local = new Glocal();
            Local.Show();
        }

        private void comprobantesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reimpresion Reimpresion = new Reimpresion();
            Reimpresion.Show();
        }

        private void gestiónDeDiferenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDif Diferencias = new GDif();
            Diferencias.Show();
        }

        private void limpiarBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();
            string sqlQuery = "";

            sqlQuery = "use edilizia; SET SQL_SAFE_UPDATES = 0; delete FROM edilizia.assets_room_transaction; delete FROM edilizia.transaction; " +
            " delete from edilizia.diferences; update edilizia.assets_by_room set idRoom = 2 where idRoom = 1; update edilizia.rooms_by_users set id_user_responsible = null where id_user_responsible is not null; ";
            MySqlDataReader dataReaderTrans = DB.GetData(sqlQuery);
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }
    }
}
