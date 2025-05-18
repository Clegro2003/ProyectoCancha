using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Cancha
    {
        public int Id_cancha { get; set; }
        public string Estado { get; set; }
        public decimal Precio { get; set; }
        public TipoCancha TipoCancha { get; set; }
        public List<Reserva> Reservas = new List<Reserva>();
    }
}
