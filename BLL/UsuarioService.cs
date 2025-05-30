﻿using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{

    public class UsuarioService: IService<Usuario>
    {
        private UsuarioRepository usuarioRepository;
        public UsuarioService()
        {
            usuarioRepository = new UsuarioRepository();
        }

        public List<Usuario> Consultar()
        {
            return usuarioRepository.Consultar();
        }

        public string Guardar(Usuario entity)
        {
            return usuarioRepository.Guardar(entity);
        }

        public Usuario ConsultarPorChatID(string chatID)
        {
            return usuarioRepository.ConsultarPorChatID(chatID);
        }

        public bool ConsultatPorID(string Id)
        {
            return usuarioRepository.ConsultarUsuarioPorID(Id);
        }
    }
}
