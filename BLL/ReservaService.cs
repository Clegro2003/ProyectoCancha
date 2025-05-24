using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReservaService:IService<Reserva>
    {
        private readonly ReservaRepository _reservaRepo;

        public ReservaService()
        {
            _reservaRepo = new ReservaRepository();
        }

        public string Guardar(Reserva reserva)
        {
            return _reservaRepo.Guardar(reserva);
        }

        public List<Reserva> Consultar()
        {
            return _reservaRepo.Consultar();
        }
    }
}
