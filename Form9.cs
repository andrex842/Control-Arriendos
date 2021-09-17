using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arriendos
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(Bmp, 0, 0);
            
        }

        Bitmap Bmp;

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            button1.Visible = false;

            
            

            Graphics gr = this.CreateGraphics();
            Bmp = new Bitmap(this.Size.Width, this.Size.Height, gr);
            Graphics mg = Graphics.FromImage(Bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.Document.DefaultPageSettings.Landscape = true;

            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.Document = printDocument1;
            DialogResult result = printDialog1.ShowDialog();

            printPreviewDialog1.ShowDialog();
            

            button4.Visible = true;
            button1.Visible = true;

            



        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
