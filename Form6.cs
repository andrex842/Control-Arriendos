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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        internal static string Identificacion;
        private void Form6_Load(object sender, EventArgs e)
        {
            Identificacion = textBox1.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            {
                MessageBox.Show("Debe completar los campos", "ERROR");
                return;
            }

            Identificacion = textBox1.Text;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=127.0.0.1; Port=3306; database=arriendos; UId=andres1; pwd=Bogota2018**;");

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT Identificacion FROM Arriendos WHERE Identificacion=@Identificacion", con);
                cmd.Parameters.AddWithValue("Identificacion", textBox1.Text);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {

                    this.Close();
                    Form7 frm = new Form7();
                    frm.Show();


                }
                else
                {
                    MessageBox.Show("Identificacion No encontrada");

                }

            }

            catch (Exception i)
            {
                MessageBox.Show(i.Message);

            }
            finally

            {
                con.Close();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form Formulario1 = new Form2();
            Formulario1.Show();
        }
    }
}
