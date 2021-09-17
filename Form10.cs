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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form Formulario1 = new Form2();
            Formulario1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {


            using (MySqlConnection con = new MySqlConnection("server=127.0.0.1; Port=3306; database=arriendos; UId=andres1; pwd=Bogota2018**;"))
            {

                if (textBox1.Text == "")
                {
                    MessageBox.Show("Por favor Ingrese El Dato a Consultar", "Sin Informacion");
                    return;
                }

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Arrendatario WHERE Identificacion =@Identificacion", con);
                cmd.Parameters.AddWithValue("@Identificacion", textBox1.Text);
                con.Open();
                MySqlDataReader resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {


                    textBox2.Text = resultado["Nombre"].ToString();
                    textBox3.Text = resultado["TelFijo"].ToString();
                    textBox4.Text = resultado["TelCel"].ToString();

                    MessageBox.Show("Datos encontrados", "Advertencia");

                    textBox1.Enabled = false;

                }
                else
                {
                    MessageBox.Show("Datos No Encontrado", "Error");
                    return;
                }
                con.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;

            using (MySqlConnection con = new MySqlConnection("server=127.0.0.1; Port=3306; database=arriendos; UId=andres1; pwd=Bogota2018**;"))
            {
                string query = "UPDATE Arrendatario SET Nombre =@Nombre,TelFijo=@TelFijo,TelCel=@TelCel WHERE Identificacion =@Identificacion";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Identificacion", textBox1.Text);
                cmd.Parameters.AddWithValue("@Nombre", textBox2.Text);
                cmd.Parameters.AddWithValue("@TelFijo", textBox3.Text);
                cmd.Parameters.AddWithValue("@TelCel", textBox4.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Datos Actualizados Correctamente", "Perfecto");

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;

            using (MySqlConnection con = new MySqlConnection("server=127.0.0.1; Port=3306; database=arriendos; UId=andres1; pwd=Bogota2018**;"))
            {
                string query = "DELETE from Arrendatario WHERE Identificacion =@Identificacion";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Identificacion", textBox1.Text);

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Arrendatario Eliminado Correctamente", "Perfecto");

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
        }
    }
}
