using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TipoCanchaService : IService<TipoCancha>
    {
        TipoCanchaRepository tipocanchaRepository;

        public TipoCanchaService()
        {
            tipocanchaRepository = new TipoCanchaRepository();
        }
        public List<TipoCancha> Consultar()
        {
            return tipocanchaRepository.Consultar();
        }

        public string Guardar(TipoCancha entity)
        {
            throw new NotImplementedException();
        }
    }
}
