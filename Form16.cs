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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private void Form16_Load(object sender, EventArgs e)
        {

            


            string connstr = "server=127.0.0.1; Port=3306; database=arriendos; UId=andres1; pwd=Bogota2018**;";
            MySqlConnection conn = new MySqlConnection(connstr);
            try
            {

                conn.Open();
                string sql = "SELECT * FROM Arriendos";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                MySqlDataReader resultado = cmd.ExecuteReader();
                List<Reporte> lrp = new List<Reporte>();

                while (resultado.Read())
                {


                    Reporte rp = new Reporte();
                    rp.Codigo_Arr = resultado[0].ToString();
                    rp.Identificacion = resultado[1].ToString();
                    rp.Codigo = resultado[2].ToString();
                    rp.Facturado = resultado[3].ToString();
                    rp.FechaIni = resultado[4].ToString();
                    rp.FechaFin = resultado[5].ToString();
                    rp.Estado = resultado[6].ToString();
                    lrp.Add(rp);
                    rp = null;

                }
                resultado.Close();
                ReportDataSource rds = new ReportDataSource("Reporte", lrp);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Arriendos.Report1.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.RefreshReport();

            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
                


            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form Formulario1 = new Form2();
            Formulario1.Show();
        }
    }
}
