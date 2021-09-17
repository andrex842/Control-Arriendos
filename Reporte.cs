using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arriendos
{
    class Reporte
    {
        public string Codigo_Arr { get; set; }
        public string Identificacion { get; set; }
        public string Codigo { get; set; }
        public string Facturado { get; set; }
        public string FechaIni { get; set; }
        public string FechaFin { get; set; }
        public string Estado { get; set; }

        public Reporte() { }
    }
}
