using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arriendos
{
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Formulario1 = new Form3();
            Formulario1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Formulario1 = new Form2();
            Formulario1.Show();
            this.Close();
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            esclarecerform.ShowAsyc(this);
        }
    }
}
