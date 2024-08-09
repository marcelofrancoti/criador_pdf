using System;
using System.Collections.Generic;
using SistemaIndexador.Application.AutoMapper;
using SistemaIndexador.Application.ViewModels;

namespace SistemaIndexador.Application.Interfaces
{
    public interface IUsuarioAppService : IDisposable
    {
        UsuarioViewModel Adicionar(UsuarioViewModel usuarioViewModel);
        UsuarioViewModel ObterPorLogin(string login, string senha);
        UsuarioViewModel ObterPorEmail(string email);
        PagedViewModel<UsuarioViewModel> ObterTodos();
    }
}
