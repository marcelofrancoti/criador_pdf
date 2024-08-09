using SistemaIndexador.Domain.DTO;
using SistemaIndexador.Domain.Entities;
using System.Collections.Generic;

namespace SistemaIndexador.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario ObterPorLogin(string login, string senha);
        Usuario ObterPorEmail(string email);
        Paged<Usuario> ObterTodos();
    }
}
