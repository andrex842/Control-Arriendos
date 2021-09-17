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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection("server=127.0.0.1; Port=3306; database=arriendos; UId=andres1; pwd=Bogota2018**;"))
            {


                if (textBox1.Text == "")
                {
                    MessageBox.Show("Por favor Ingrese El Dato a Consultar", "Sin Informacion");
                }

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Arrendatario WHERE Identificacion=@Identificacion", con);
                cmd.Parameters.AddWithValue("@Identificacion", textBox1.Text);

                con.Open();
                MySqlDataReader resultado = cmd.ExecuteReader();
                if (resultado.Read())
                {


                    textBox2.Text = resultado["Nombre"].ToString();
                    textBox3.Text = resultado["TelFijo"].ToString();
                    textBox4.Text = resultado["TelCel"].ToString();
                    

                }
                else
                {
                    MessageBox.Show("Datos No Encontrado", "Lo Sentimos");
                    return;
                }

                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection("server=127.0.0.1; Port=3306; database=arriendos; UId=andres1; pwd=Bogota2018**;"))
            {


                if (textBox1.Text == "")
                {
                    MessageBox.Show("Por favor Ingrese El Dato a Consultar", "Sin Informacion");
                }

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Predios WHERE Codigo=@Codigo", con);
                cmd.Parameters.AddWithValue("@Codigo", textBox5.Text);

                con.Open();
                MySqlDataReader resultado = cmd.ExecuteReader();
                if (resultado.Read())
                {


                    
                    textBox7.Text = resultado["Direccion"].ToString();
                    textBox8.Text = resultado["Concepto"].ToString();
                    textBox9.Text = resultado["Valor"].ToString();
                    textBox12.Text = resultado["Estado"].ToString();

                    if(textBox12.Text =="ARRENDADO")
                    {
                        MessageBox.Show("El Predio " + textBox5.Text+ " se Encuentra Arrendado", "ERROR");
                        
                        textBox7.Clear();
                        textBox8.Clear();
                        textBox9.Clear();
                        textBox12.Clear();
                        textBox5.Clear();
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Datos No Encontrado", "Lo Sentimos");
                    return;
                }

                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (textBox10.Text ==""| textBox1.Text == ""| textBox5.Text == "" | textBox11.Text == "" | textBox6.Text == "" | comboBox3.Text == "")
            {
                MessageBox.Show("Debe Completar los campos de Arrendamiento", "Error");
                return;
            }
            else { 

            MySqlConnection con = new MySqlConnection("server=127.0.0.1; Port=3306; database=arriendos; UId=andres1; pwd=Bogota2018**;");


            string query = "INSERT INTO Arriendos(Codigo_Arr,Identificacion, Codigo, Facturado, FechaIni, FechaFin, Estado) VALUES (@Codigo_Arr, @Identificacion, @Codigo, @Facturado, @FechaIni,@FechaFin, @Estado)";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Codigo_Arr", textBox10.Text);
            cmd.Parameters.AddWithValue("@Identificacion", textBox1.Text);
            cmd.Parameters.AddWithValue("@Codigo", textBox5.Text);
            cmd.Parameters.AddWithValue("@Facturado", ComboBox1.Text);
            cmd.Parameters.AddWithValue("@FechaIni", textBox6.Text);
            cmd.Parameters.AddWithValue("@FechaFin", textBox11.Text);
            cmd.Parameters.AddWithValue("@Estado", comboBox3.Text);
            cmd.ExecuteNonQuery();


            MessageBox.Show("Datos Guardados Correctamente", "Perfecto");

            con.Close();

             string quer = "UPDATE Predios SET Estado=@Estado WHERE Codigo=@Codigo";
             con.Open();
             MySqlCommand cmd1 = new MySqlCommand(quer, con);

             cmd1.Parameters.AddWithValue("@Estado", comboBox3.Text);
             cmd1.Parameters.AddWithValue("@Codigo", textBox5.Text);
             cmd1.ExecuteNonQuery();
             con.Close();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            ComboBox1.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;

            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form Formulario1 = new Form2();
            Formulario1.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox6.Text = dateTimePicker1.Value.Date.ToShortDateString();

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker2_ValueChanged_1(object sender, EventArgs e)
        {
            textBox11.Text = dateTimePicker2.Value.Date.ToShortDateString();
        }
    }
    
    
}
