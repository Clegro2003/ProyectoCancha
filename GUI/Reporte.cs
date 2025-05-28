using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Reporte: Form
    {
        BotPrincipal _BotPrincipal;
        ServicioReporte _ServicioReporte;
        public Reporte()
        {
            _BotPrincipal = new BotPrincipal();
            InitializeComponent();
            _ServicioReporte = new ServicioReporte();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            _BotPrincipal.Iniciar();
            btnUltimos7Dias_Click(null, null);
            CargarGraficoPastel();
            
        }

        private void CargarGraficoBarras(DateTime desde, DateTime hasta)
        {
            var datos = _ServicioReporte.ObtenerReservasPorDia(desde, hasta);
            ctBarras.Series[0].Points.Clear();

            foreach (DataRow row in datos.Rows)
            {
                DateTime fecha = Convert.ToDateTime(row["fecha"]);
                int cantidad = Convert.ToInt32(row["cantidad"]);
                ctBarras.Series[0].Points.AddXY(fecha.ToString("dd/MM"), cantidad);
            }
        }

        private void CargarGraficoPastel()
        {
            var datos = _ServicioReporte.ObtenerPorcentajeTipoCancha();
            ctPastel.Series[0].Points.Clear();

            foreach (DataRow row in datos.Rows)
            {
                string tipo = row["nombre_cancha"].ToString();
                int cantidad = Convert.ToInt32(row["cantidad"]);
                ctPastel.Series[0].Points.AddXY(tipo, cantidad);
            }
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;
            CargarGraficoBarras(hoy, hoy);
        }

        private void btnUltimos7Dias_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;
            DateTime hace7Dias = hoy.AddDays(-6); // Incluye hoy
            CargarGraficoBarras(hace7Dias, hoy);
        }

        private void btnUltimos30Dias_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;
            DateTime hace30Dias = hoy.AddDays(-29); // Incluye hoy
            CargarGraficoBarras(hace30Dias, hoy);
        }

        private void btnEsteMes_Click(object sender, EventArgs e)
        {
            DateTime primerDiaMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime hoy = DateTime.Today;
            CargarGraficoBarras(primerDiaMes, hoy);
        }
    }
}
