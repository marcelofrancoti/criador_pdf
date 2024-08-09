using System;
using SistemaIndexador.Domain.Interfaces.Service;
using SistemaIndexador.Domain.Entities;
using SistemaIndexador.Domain.Interfaces.Repository;
using System.Collections.Generic;
using SistemaIndexador.Domain.DTO;

namespace SistemaIndexador.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public Usuario ObterPorEmail(string email)
        {
            return _usuarioRepository.ObterPorEmail(email);
        }

        public Usuario ObterPorLogin(string login, string senha)
        {
            return _usuarioRepository.ObterPorLogin(login, senha);
        }
        public void Dispose()
        {
            _usuarioRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Usuario Adicionar(Usuario usuario)
        {
         
            return _usuarioRepository.Adicionar(usuario);
        }

        public Paged<Usuario> ObterTodos()
        {
            return _usuarioRepository.ObterTodos();
        }
    }
}
