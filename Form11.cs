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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form Formulario1 = new Form2();
            Formulario1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (MySqlConnection con = new MySqlConnection("server=127.0.0.1; Port=3306; database=arriendos; UId=andres1; pwd=Bogota2018**;"))
            {

                if (textBox5.Text == "")
                {
                    MessageBox.Show("Por favor Ingrese El Dato a Consultar", "Sin Informacion");
                    return;
                }

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Predios WHERE Codigo =@Codigo", con);
                cmd.Parameters.AddWithValue("@Codigo", textBox5.Text);
                con.Open();
                MySqlDataReader resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {


                    textBox7.Text = resultado["Direccion"].ToString();
                    textBox8.Text = resultado["Concepto"].ToString();
                    textBox9.Text = resultado["Valor"].ToString();
                    textBox12.Text = resultado["Estado"].ToString();

                    MessageBox.Show("Recuerde que solo puede editar los Datos expuestos acontinuación", "Advertencia");

                    textBox5.Enabled = false;

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
            textBox5.Enabled = true;

            using (MySqlConnection con = new MySqlConnection("server=127.0.0.1; Port=3306; database=arriendos; UId=andres1; pwd=Bogota2018**;"))
            {
                string query = "UPDATE Predios SET Direccion =@Direccion,Concepto=@Concepto,Valor=@Valor,Estado=@Estado WHERE Codigo =@Codigo";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Codigo", textBox5.Text);
                cmd.Parameters.AddWithValue("@Direccion", textBox7.Text);
                cmd.Parameters.AddWithValue("@Concepto", textBox8.Text);
                cmd.Parameters.AddWithValue("@Valor", textBox9.Text);
                cmd.Parameters.AddWithValue("@Estado", textBox12.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Datos Actualizados Correctamente", "Perfecto");

                textBox5.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox12.Clear();
            }
        }
    }
}
