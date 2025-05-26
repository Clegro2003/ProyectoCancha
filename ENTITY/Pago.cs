using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Pago
    {
        public int IdPago { get; set; }
        public int IdReserva { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }

        public Reserva Reserva { get; set; }

        public Pago()
        {
            
        }

        public Pago(int idPago, int idReserva, DateTime fecha, decimal monto, Reserva reserva)
        {
            IdPago = idPago;
            IdReserva = idReserva;
            Fecha = fecha;
            Monto = monto;
            Reserva = reserva;
        }
    }
}
