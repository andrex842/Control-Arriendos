using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arriendos
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            using (MySqlConnection con = new MySqlConnection("server=127.0.0.1; Port=3306; database=arriendos; UId=andres1; pwd=Bogota2018**;"))
            {

                if (TxtConsultaid1.Text == "")
                {
                    MessageBox.Show("Por favor Ingrese El Dato a Consultar", "Sin Informacion");
                    return;
                }

                if (comboBox3.Text == "")
                {
                    MessageBox.Show("Por favor Seleccione El Dato a Consultar", "Sin Informacion");
                    return;
                }




                if (comboBox3.Text == "FACTURA NUMERO")

                {
                    comboBox3.Text = "Codigo_Fact";

                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM Facturas WHERE " + comboBox3.Text + "=@Codigo_Fact", con);
                    cmd.Parameters.AddWithValue("@Codigo_Fact", TxtConsultaid1.Text);
                    con.Open();

                    MySqlDataAdapter adaptador = new MySqlDataAdapter();
                    adaptador.SelectCommand = cmd;
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dataGridView1.DataSource = tabla;

                    con.Close();


                }


                if (comboBox3.Text == "FECHA DE FACTURA")

                {
                    comboBox3.Text = "FechaDia";
                    MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM Facturas WHERE " + comboBox3.Text + "=@FechaFac", con);
                    cmd1.Parameters.AddWithValue("@FechaFac", TxtConsultaid1.Text);
                    con.Open();

                    MySqlDataAdapter adaptador1 = new MySqlDataAdapter();
                    adaptador1.SelectCommand = cmd1;
                    DataTable tabla1 = new DataTable();
                    adaptador1.Fill(tabla1);
                    dataGridView1.DataSource = tabla1;


                    con.Close();


                }


                if (comboBox3.Text == "MES DE PAGO")

                {
                    comboBox3.Text = "MesPago";
                    MySqlCommand cmd3 = new MySqlCommand("SELECT * FROM Facturas WHERE " + comboBox3.Text + "=@MesPago", con);
                    cmd3.Parameters.AddWithValue("@MesPago", TxtConsultaid1.Text);
                    con.Open();

                    MySqlDataAdapter adaptador3 = new MySqlDataAdapter();
                    adaptador3.SelectCommand = cmd3;
                    DataTable tabla3 = new DataTable();
                    adaptador3.Fill(tabla3);
                    dataGridView1.DataSource = tabla3;

                    con.Close();


                }


                if (comboBox3.Text == "IDENTIFICACION")

                {
                    comboBox3.Text = "IDENTIFICACION";
                    MySqlCommand cmd4 = new MySqlCommand("SELECT * FROM Facturas WHERE " + comboBox3.Text + "=@Identificacion", con);
                    cmd4.Parameters.AddWithValue("@Identificacion", TxtConsultaid1.Text);
                    con.Open();

                    MySqlDataAdapter adaptador4 = new MySqlDataAdapter();
                    adaptador4.SelectCommand = cmd4;
                    DataTable tabla4 = new DataTable();
                    adaptador4.Fill(tabla4);
                    dataGridView1.DataSource = tabla4;



                    con.Close();


                }


                if (comboBox3.Text == "CODIGO PREDIO")

                {
                    comboBox3.Text = "Codigo";
                    MySqlCommand cmd5 = new MySqlCommand("SELECT * FROM Facturas WHERE " + comboBox3.Text + "=@Codigo", con);
                    cmd5.Parameters.AddWithValue("@Codigo", TxtConsultaid1.Text);
                    con.Open();

                    MySqlDataAdapter adaptador5 = new MySqlDataAdapter();
                    adaptador5.SelectCommand = cmd5;
                    DataTable tabla5 = new DataTable();
                    adaptador5.Fill(tabla5);
                    dataGridView1.DataSource = tabla5;



                    con.Close();


                }

                if (comboBox3.Text == "VALOR")

                {
                    comboBox3.Text = "VALOR";
                    MySqlCommand cmd6 = new MySqlCommand("SELECT * FROM Facturas WHERE " + comboBox3.Text + "=@Valor", con);
                    cmd6.Parameters.AddWithValue("@Valor", TxtConsultaid1.Text);
                    con.Open();

                    MySqlDataAdapter adaptador6 = new MySqlDataAdapter();
                    adaptador6.SelectCommand = cmd6;
                    DataTable tabla6 = new DataTable();
                    adaptador6.Fill(tabla6);
                    dataGridView1.DataSource = tabla6;



                    con.Close();


                }
                
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TxtConsultaid1.Clear();
            comboBox3.SelectedIndex = 0;
            dataGridView1.DataSource = null;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form Formulario1 = new Form2();
            Formulario1.Show();

        }


        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DialogResult Res = MessageBox.Show("Seguro Quiere Generar el Pago?", "Alerta", MessageBoxButtons.YesNo);

            if (Res == DialogResult.Yes)
            {
                Form9 frm = new Form9();
                frm.Show();




                frm.label9.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                frm.label4.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                frm.label11.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                frm.label22.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                frm.label23.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                frm.label24.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                frm.label26.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                frm.label28.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                frm.label10.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                frm.label17.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                frm.label35.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                frm.label34.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                frm.label33.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                frm.label31.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                frm.label29.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                frm.label5.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            }

            if (Res == DialogResult.No)
            {
                return;

            }

        }

        private void Form8_Load(object sender, EventArgs e)
        {

            using (MySqlConnection con = new MySqlConnection("server=127.0.0.1; Port=3306; database=arriendos; UId=andres1; pwd=Bogota2018**;")) 
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Facturas", con);
                
                con.Open();

                MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                adaptador.SelectCommand = cmd;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridView1.DataSource = tabla;

                con.Close();

                

               

            }
        }
    }
}
