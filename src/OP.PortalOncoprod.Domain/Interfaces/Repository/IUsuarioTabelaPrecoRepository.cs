using SistemaIndexador.Domain.DTO;
using SistemaIndexador.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndexador.Domain.Interfaces.Repository
{
    public interface IUsuarioTabelaPrecoRepository : IRepository<UsuarioTabelaRegrasDMS>
    {
       List<UsuarioTabelaRegrasDMS> ObterPorUsuarioId(string usuarioId);

    }
}
