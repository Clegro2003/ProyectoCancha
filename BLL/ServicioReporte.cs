using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public DataTable ObtenerPorcentajeTipoCancha()
        {
            return _ReporteRepository.PorcentajeTipoCancha();
        }
    }
}
