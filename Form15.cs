using Microsoft.Reporting.WinForms;
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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {

            string connstr2 = "server=127.0.0.1; Port=3306; database=arriendos; UId=andres1; pwd=Bogota2018**;";
            MySqlConnection conn2 = new MySqlConnection(connstr2);
            try
            {

                conn2.Open();
                string sql2 = "Select * from Facturas";
                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.Connection = conn2;
                cmd2.CommandText = sql2;
                MySqlDataReader resultado2 = cmd2.ExecuteReader();
                List<Reporte2> lrp2 = new List<Reporte2>();

                while (resultado2.Read())
                {


                    Reporte2 rp2 = new Reporte2();
                    rp2.Codigo_Fact = resultado2[0].ToString();
                    rp2.FechaFac = resultado2[1].ToString();
                    rp2.MesPago = resultado2[2].ToString();
                    rp2.Identificacion = resultado2[3].ToString();
                    rp2.Nombre = resultado2[4].ToString();
                    rp2.Codigo = resultado2[5].ToString();
                    rp2.Direccion = resultado2[6].ToString();
                    rp2.Detalles= resultado2[7].ToString();
                    rp2.Codigo_Arr= resultado2[8].ToString();
                    rp2.Facturado = resultado2[9].ToString();
                    rp2.Valor = resultado2[10].ToString();
                    rp2.FechaInic = resultado2[11].ToString();
                    rp2.FechaFina= resultado2[12].ToString();
                    lrp2.Add(rp2);
                    rp2 = null;

                }
                resultado2.Close();
                
                ReportDataSource rds2 = new ReportDataSource("Reporte2", lrp2);
                this.reportViewer2.LocalReport.ReportEmbeddedResource = "Arriendos.Report2.rdlc";
                this.reportViewer2.LocalReport.DataSources.Clear();
                this.reportViewer2.LocalReport.DataSources.Add(rds2);
                this.reportViewer2.RefreshReport();

            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.ToString());
            }
            conn2.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form Formulario1 = new Form2();
            Formulario1.Show();
        }
    }
}
