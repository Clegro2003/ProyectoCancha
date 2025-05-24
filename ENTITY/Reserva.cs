using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public int IdCancha { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string Estado { get; set; }
        public Cancha Cancha { get; set; }

        public Reserva()
        {
            
        }

        public Reserva(int idReserva, int idCancha, int idUsuario, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin, string estado, Cancha cancha)
        {
            IdReserva = idReserva;
            IdCancha = idCancha;
            IdUsuario = idUsuario;
            Fecha = fecha;
            HoraInicio = horaInicio;
            HoraFin = horaFin;
            Estado = estado;
            Cancha = cancha;
        }
    }
}
