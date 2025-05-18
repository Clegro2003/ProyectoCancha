using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class MetodoPago
    {
        public int IdMetodoPago { get; set; }
        public string NombreMetodoPago { get; set; }

        public List<Pago> Pagos = new List<Pago>();
    }
}
