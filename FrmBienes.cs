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
using WindowsFormsApplication1;

namespace WindowsFormsApplication1
{
    public partial class FrmBienes : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        public FrmBienes()
        {
            InitializeComponent();
         }

       
        private void Bienes_Load(object sender, EventArgs e)
        {
            
         // cbTipo.DataSource = bindingSource1;
           
            //DB.GetData("select * from users");
     


            if (dataReaderBienes.HasRows)
            {

                dataReaderBienes.Read();

             //devuelve que tenes en el el dataredear   MessageBox.Show(dataReaderBienes.GetString(1));

                DataTable dt = new DataTable();
                dt.Load(dataReaderBienes);

                #region TipodeBien
                string Tipo = "";
                cbTipo.Items.Clear(); 
                for (int x = 2010; x <= 2030; x++)
                {
                    cbTipo.Items.Add(x);

                }
                #endregion



                List<Bienes> categorias = Negocio.Controlador.GetCategorias();

                foreach (Entidades.categoriaEmpleado objCategoria in categorias)
                {

                    cbcategoria.Items.Add(objCategoria.descripcion);
                }

                //cbTipo.Items.Insert(0, "prueba");

                //cbTipo.DataSource = dt;
                //cbTipo.DisplayMember = "description";
                //cbTipo.ValueMember = "code";

                //List<Elementos> Lista = new List<Elementos>();
                //OleDbDataReader reader = getCom(getSelect(Campo, Valor, tb)).ExecuteReader();
                //if (reader.HasRows)
                //{
                //    while (reader.Read())
                //        Lista.Add(new Elementos() { codigo = Convert.ToInt32(reader[Valor]), Cadena = reader[Campo].ToString() });

            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

  
}
}