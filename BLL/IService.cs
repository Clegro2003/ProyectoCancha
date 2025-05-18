using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IService<T>
    {
        string Guardar(T entity);
        List<T> Consultar();
    }
}
