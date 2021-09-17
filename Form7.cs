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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();

        }
        DateTime hoy = DateTime.Now;
        private void Form7_Load(object sender, EventArgs e)
        {
            label6.Text = hoy.ToShortDateString();
            label9.Text = Form6.Identificacion;

            using (MySqlConnection con = new MySqlConnection("server=127.0.0.1; Port=3306; database=arriendos; UId=andres1; pwd=Bogota2018**;"))
            {



                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Arrendatario WHERE Identificacion=@Identificacion", con);

                cmd.Parameters.AddWithValue("@Identificacion", label9.Text);

                con.Open();

                MySqlDataReader resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {
                    label10.Text = resultado["Nombre"].ToString();
                    con.Close();
                }


                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM Arriendos WHERE Identificacion=@Identificacion", con);

                cmd1.Parameters.AddWithValue("@Identificacion", label9.Text);
                con.Open();

                MySqlDataReader resultado1 = cmd1.ExecuteReader();

                if (resultado1.Read())
                {

                    label12.Text = resultado1["Codigo"].ToString();
                    label18.Text = resultado1["Codigo_Arr"].ToString();
                    label20.Text = resultado1["Facturado"].ToString();
                    label22.Text = resultado1["FechaIni"].ToString();
                    label24.Text = resultado1["FechaFin"].ToString();

                    con.Close();

                }


                MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM Predios WHERE Codigo=@Codigo", con);

                cmd2.Parameters.AddWithValue("@Codigo", label12.Text);
                con.Open();

                MySqlDataReader resultado2 = cmd2.ExecuteReader();

                if (resultado2.Read())
                {
                    label14.Text = resultado2["Direccion"].ToString();
                    label16.Text = resultado2["Concepto"].ToString();
                    label2.Text = resultado2["Valor"].ToString();
                    label29.Text = resultado2["Estado"].ToString();

                    con.Close();
                }





            }

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ComboBox1.Text == "") 
            
            {
                MessageBox.Show("Selecciones el MES a FACTURAR!", "ERROR");
                return;
            }

            else 
            
            { 
            MySqlConnection con = new MySqlConnection("server=127.0.0.1; Port=3306; database=arriendos; UId=andres1; pwd=Bogota2018**;");


            string query = "INSERT INTO Facturas(FechaFac,MesPago,Identificacion,Nombre,Codigo,Direccion,Detalles,Codigo_Arr,Facturado,Valor,FechaInic,FechaFina) VALUES (@FechaFac,@MesPago,@Identificacion,@Nombre,@Codigo,@Direccion,@Detalles,@Codigo_Arr,@Facturado,@Valor,@FechaInic,@FechaFina)";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.AddWithValue("@FechaFac", label6.Text);
            cmd.Parameters.AddWithValue("@MesPago", ComboBox1.Text);
            cmd.Parameters.AddWithValue("@Identificacion", label9.Text);
            cmd.Parameters.AddWithValue("@Nombre", label10.Text);
            cmd.Parameters.AddWithValue("@Codigo", label12.Text);
            cmd.Parameters.AddWithValue("@Direccion", label14.Text);
            cmd.Parameters.AddWithValue("@Detalles", label16.Text);
            cmd.Parameters.AddWithValue("@Codigo_Arr", label18.Text);
            cmd.Parameters.AddWithValue("@Facturado", label20.Text);
            cmd.Parameters.AddWithValue("@Valor", label2.Text);
            cmd.Parameters.AddWithValue("@FechaInic", label22.Text);
            cmd.Parameters.AddWithValue("@FechaFina", label24.Text);
            cmd.ExecuteNonQuery();


            MessageBox.Show("Factura Generada Correctamente!", "PERFECTO");

            con.Close();

                Form Formulario1 = new Form2();
                Formulario1.Show();
                this.Close();
            }

        }
    }
}
