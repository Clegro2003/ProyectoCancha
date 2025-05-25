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

        public List<Reserva> ConsultarReservas(int chat)
        {
            return _reservaRepo.ConsultarReservas(chat);
        }

        public string Cancelar(int id)
        {
            return _reservaRepo.Eliminar(id);
        }
        public List<Reserva> Consultar()
        {
            return _reservaRepo.Consultar();
        }
    }
}
