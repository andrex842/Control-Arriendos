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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DateTime hoy = DateTime.Now;

        private void button1_Click(object sender, EventArgs e)
        {
            Loging(textBox1.Text, textBox2.Text);
        }

        

        public void Loging(string Usuario, string Pass)
        {
            MySqlConnection conectar = new MySqlConnection("server=192.168.0.10; Port=3306; database=arriendos; UId=andres1; pwd=Bogota2018**;");
            conectar.Open();

            MySqlCommand codigo = new MySqlCommand();
            MySqlConnection conectamos = new MySqlConnection();
            codigo.Connection = conectar;

            codigo.CommandText = ("SELECT Usuario,Pass FROM Usuario_Arriendo WHERE Usuario = '" + textBox1.Text + "' AND Pass= '" + textBox2.Text + "'");
            MySqlDataReader leer = codigo.ExecuteReader();

            if (leer.Read())
            {
                this.Hide();
                Form2 frm = new Form2();
                frm.Show();

            }
            else
            {
                MessageBox.Show("Usuario, Contraseña y/o Dependencia Incorrecto");
            }
            conectar.Close();


               
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {

                if (textBox2.PasswordChar == '*')
                {
                    textBox2.PasswordChar = '\0';

                }
            }

            else
            {
                textBox2.PasswordChar = '*';


            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Loging(textBox1.Text, textBox2.Text);
            }
        }

        internal static string Usuario;
        private void Form1_Load(object sender, EventArgs e)
        {
            label7.Text = hoy.ToShortDateString();
            label6.Text = hoy.ToShortTimeString();
            Usuario = textBox1.Text;
            esclarese1form.ShowAsyc(this);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Usuario = textBox1.Text;
        }
    }
}
