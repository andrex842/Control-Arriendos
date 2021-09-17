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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.Usuario;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form Formulario1 = new Form3();
            Formulario1.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form Formulario1 = new Form4();
            Formulario1.Show();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form Formulario1 = new Form5();
            Formulario1.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form Formulario1 = new Form6();
            Formulario1.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form Formulario1 = new Form8();
            Formulario1.Show();
            this.Close();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form Formulario1 = new Form10();
            Formulario1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Form Formulario1 = new Form11();
            Formulario1.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
            Form Formulario1 = new Form14();
            Formulario1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form Formulario1 = new Form12();
            Formulario1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Form Formulario1 = new Form13();
            Formulario1.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
            Form Formulario1 = new Form16();
            Formulario1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form Formulario1 = new Form15();
            Formulario1.Show();
        }
    }
}
