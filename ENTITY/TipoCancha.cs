using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class TipoCancha
    {
        public int TipoId { get; set; }
        public string NombreCancha { get; set; }

        public List<Cancha> Canchas = new List<Cancha>();
    }
}
