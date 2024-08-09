using System;
using System.Collections.Generic;
using SistemaIndexador.Domain.DTO;
using SistemaIndexador.Domain.Entities;

namespace SistemaIndexador.Domain.Interfaces.Service
{
    public interface IUsuarioService : IDisposable
    {
        Usuario Adicionar(Usuario usuario);
        Usuario ObterPorLogin(string login, string senha);
        Usuario ObterPorEmail(string email);
        Paged<Usuario> ObterTodos();
    }
}
