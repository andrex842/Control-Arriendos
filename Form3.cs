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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text =="")
            {
                MessageBox.Show("Debe completar los campos", "ERROR");
                return;
            }

            MySqlConnection con = new MySqlConnection("server=127.0.0.1; Port=3306; database=arriendos; UId=andres1; pwd=Bogota2018**;");

            
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT Identificacion FROM Arrendatario WHERE Identificacion=@Identificacion", con);
                cmd.Parameters.AddWithValue("Identificacion", textBox2.Text);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {

                Form Formulario1 = new Form17();
                Formulario1.Show();
                this.Close();


                }
                else
                {
                    

                string query = "INSERT INTO Arrendatario(Identificacion,Nombre,TelFijo,TelCel) VALUES ( '" + textBox2.Text + "', '" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                MySqlCommand cmd1 = new MySqlCommand(query, con);
                cmd1.ExecuteNonQuery();


                Form Formulario1 = new Form18();
                Formulario1.Show();
                this.Close();


                }

            con.Close();


        }

        

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form Formulario1 = new Form2();
            Formulario1.Show();
        }
    }
}
