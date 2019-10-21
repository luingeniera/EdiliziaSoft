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
    public partial class Picking : Form
    {
        private Glocal FrmLocal;
        public Picking(Glocal FrmLocal)
        {
            InitializeComponent();
            this.FrmLocal = FrmLocal;
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            DataTable tmpTable = new DataTable();
            tmpTable.Columns.Add("bien", typeof(string));
            tmpTable.Columns.Add("matches", typeof(string));
            for (int i = 0; i < dgPicking.Rows.Count-1; i++)
            {
                tmpTable.Rows.Add();
                tmpTable.Rows[i][0] = dgPicking[0, i].Value;
                tmpTable.Rows[i][1] = "0";
            }
            FrmLocal.dtReturnPicking = tmpTable;
            Close();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            DataTable tmpTable = new DataTable();
            FrmLocal.dtReturnPicking = tmpTable;
            Close();
        }

        private void Picking_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(Convert.ToString(FrmLocal.dtReturnPicking.Rows.Count));
        }
    }
}
