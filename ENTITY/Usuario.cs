using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Usuario
    {
        public int Usuario_id { get; set; }
        public string ChatID { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }

        public Usuario()
        {
            
        }

        public Usuario(string documento, string nombre, string apellido, string telefono)
        {
            Documento = documento;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
        }
    }
}
