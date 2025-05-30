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
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class Dashboard_Reporte : Form
    {

        BotPrincipal _BotPrincipal;
        ServicioReporte _ServicioReporte;
        ReservaService _ReservaService;
        public Dashboard_Reporte()
        {
            InitializeComponent();
            _BotPrincipal = new BotPrincipal();
            _ServicioReporte = new ServicioReporte();
            _ReservaService = new ReservaService();
        }

        private void Dashboard_Reporte_Load(object sender, EventArgs e)
        {
            _BotPrincipal.Iniciar();
            //this.WindowState = FormWindowState.Maximized;
            btnUltimos7Dias_Click(null, null);
            DateTime hoy = DateTime.Today;
            DateTime desde = new DateTime(hoy.Year, hoy.Month, 1);
            DateTime hasta = desde.AddMonths(1).AddDays(-1);

            CargarReserva(desde, hasta);
            CargarGraficoBarras(desde, hasta);
        }
        private void CargarReserva(DateTime desde, DateTime hasta)
        {
            var lista = _ServicioReporte.Consultar(desde, hasta);
            Console.WriteLine($"🔍 Total reservas consultadas: {lista}");
            dgvDashboard.DataSource = lista.Select(r => new
            {
                r.IdReserva,
                Cancha = r.Cancha.Nombre_Cancha,
                r.Fecha,
                r.HoraInicio,
                r.HoraFin,
                r.Estado
            }).ToList();
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

        private void CargarGraficoPastel(DateTime desde, DateTime hasta)
        {
            var datos = _ServicioReporte.ObtenerPorcentajeTipoCancha(desde, hasta);
            ctPastel.Series[0].Points.Clear();
            ctPastel.Series[0].ChartType = SeriesChartType.Pie;
            ctPastel.Series[0].IsValueShownAsLabel = true; // Mostrar etiqueta

            // Calcular total de reservas para sacar porcentaje
            int total = 0;
            foreach (DataRow row in datos.Rows)
            {
                total += Convert.ToInt32(row["cantidad"]);
            }

            foreach (DataRow row in datos.Rows)
            {
                string tipo = row["nombre_cancha"].ToString();
                int cantidad = Convert.ToInt32(row["cantidad"]);
                double porcentaje = (double)cantidad / total * 100;

                // Crear el punto manualmente
                DataPoint punto = new DataPoint();
                punto.YValues = new double[] { cantidad };
                punto.Label = $"{porcentaje:F1}%";
                // Ej: Techada: 45.5%
                punto.LegendText = tipo;

                ctPastel.Series[0].Points.Add(punto);
            }

        }
        private void CargarGraficoPorHora(DateTime fecha)
        {
            var datos = _ServicioReporte.ObtenerReservasPorHora(fecha);
            ctBarras.Series[0].Points.Clear();
            ctBarras.Series[0].Name = "Reservas por hora";

            foreach (DataRow row in datos.Rows)
            {
                TimeSpan hora = (TimeSpan)row["horainicio"];
                int cantidad = Convert.ToInt32(row["cantidad"]);
                string horaStr = hora.ToString(@"hh\:mm");
                ctBarras.Series[0].Points.AddXY(horaStr, cantidad);
            }

            ctBarras.ChartAreas[0].AxisX.Title = "Hora de inicio";
            ctBarras.ChartAreas[0].AxisY.Title = "Cantidad de reservas";
            ctBarras.Titles.Clear();
            ctBarras.Titles.Add("Reservas por hora de inicio");
        }


        private void ActualizarTotales(DateTime desde, DateTime hasta)
        {
            int totalReservas = _ServicioReporte.ObtenerTotalReservas(desde, hasta);
            int totalHoras = _ServicioReporte.ObtenerTotalHorasReservadas(desde, hasta);

            lblTotalReservas.Text = totalReservas.ToString();
            lblTotalHoras.Text = totalHoras.ToString();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ctBarras_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

      

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;
            CargarGraficoPastel(hoy, hoy);
            ActualizarTotales(hoy, hoy);
            CargarReserva(hoy, hoy);
        }

        private void btnUltimos7Dias_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;
            DateTime hace7Dias = hoy.AddDays(-6);

            CargarGraficoPastel(hace7Dias, hoy);
            ActualizarTotales(hace7Dias, hoy);
            CargarReserva(hace7Dias, hoy);
        }

        private void btnEsteMes_Click(object sender, EventArgs e)
        {
            DateTime primerDiaMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime hoy = DateTime.Today;

            CargarGraficoPastel(primerDiaMes, hoy);
            ActualizarTotales(primerDiaMes, hoy);
            CargarReserva(primerDiaMes, hoy);
        }

        private void btnUltimos30Dias_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;
            DateTime hace30Dias = hoy.AddDays(-29);

            CargarGraficoPastel(hace30Dias, hoy);
            ActualizarTotales(hace30Dias, hoy);
            CargarReserva(hace30Dias, hoy);
        }

        private void btnVerPorHora_Click(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dtpFechaHora.Value.Date;
            CargarGraficoPorHora(fechaSeleccionada);
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTituloTotalReservas_Click(object sender, EventArgs e)
        {

        }

        private void dtpFechaHora_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dtpFechaHora.Value.Date;
            CargarGraficoPorHora(fechaSeleccionada);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
