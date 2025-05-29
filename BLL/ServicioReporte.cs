using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServicioReporte
    {
        ReporteRepository _ReporteRepository;
        public ServicioReporte()
        {
            _ReporteRepository = new ReporteRepository();
        }

        public DataTable ObtenerReservasPorDia(DateTime desde, DateTime hasta)
        {
            return _ReporteRepository.ReservasPorDia(desde, hasta);
        }

        public DataTable ObtenerPorcentajeTipoCancha(DateTime desde, DateTime hasta)
        {
            return _ReporteRepository.PorcentajeTipoCancha(desde, hasta);
        }

        public List<Reserva> Consultar(DateTime desde, DateTime hasta)
        {
            // sin filtro de fecha
            return _ReporteRepository.ObtenerReservasPorRango(desde, hasta);
        }


        public DataTable ObtenerReservasPorHora(DateTime fecha)
        {
            return _ReporteRepository.ReservasPorHora(fecha);
        }

        public int ObtenerTotalReservas(DateTime desde, DateTime hasta)
        {
            return _ReporteRepository.ObtenerTotalReservas(desde, hasta);
        }

        public int ObtenerTotalHorasReservadas(DateTime desde, DateTime hasta)
        {
            return _ReporteRepository.ObtenerTotalHorasReservadas(desde, hasta);
        }

    }
}
