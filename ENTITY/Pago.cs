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
        public int IdMetodoPago { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public decimal Monto { get; set; }

        public Reserva Reserva { get; set; }
        public MetodoPago MetodoPago { get; set; }
    }
}
