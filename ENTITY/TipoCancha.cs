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

        public TipoCancha()
        {
            
        }

        public TipoCancha(int tipoId, string nombreCancha)
        {
            TipoId = tipoId;
            NombreCancha = nombreCancha;
        }
    }
}
