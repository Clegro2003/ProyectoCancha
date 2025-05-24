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
        public string Nombre_Cancha { get; set; }
        public string Estado { get; set; }
        public decimal Precio { get; set; }
        public TipoCancha TipoCancha { get; set; }

        public Cancha()
        {
            
        }

        public Cancha(int id_cancha, string nombre_Cancha, string estado, decimal precio, TipoCancha tipoCancha)
        {
            Id_cancha = id_cancha;
            Nombre_Cancha = nombre_Cancha;
            Estado = estado;
            Precio = precio;
            TipoCancha = tipoCancha;
        }
    }
}
