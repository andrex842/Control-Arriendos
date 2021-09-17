using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arriendos
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Debe completar los campos", "ERROR");
                return;
            }

            MySqlConnection con = new MySqlConnection("server=127.0.0.1; Port=3306; database=arriendos; UId=andres1; pwd=Bogota2018**;");


            string query = "INSERT INTO Predios (Codigo,Direccion,Concepto,Valor,Estado) VALUES (@Codigo, @Direccion, @Concepto, @Valor, @Estado)";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Codigo", textBox1.Text);
            cmd.Parameters.AddWithValue("@Direccion", textBox2.Text);
            cmd.Parameters.AddWithValue("@Concepto", textBox3.Text);
            cmd.Parameters.AddWithValue("@Valor", textBox4.Text);
            cmd.Parameters.AddWithValue("@Estado", comboBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Predio Almacenado Correctamente", "Perfecto");

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox3.SelectedIndex = 0;

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form Formulario1 = new Form2();
            Formulario1.Show();
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
