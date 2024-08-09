using SistemaIndexador.Domain.DTO;
using SistemaIndexador.Domain.Entities;
using System.Collections.Generic;

namespace SistemaIndexador.Domain.Interfaces.Repository
{
    public interface ITabelaPrecoOncoprodRepository : IRepository<TabelaRegrasDMS>
    {
        TabelaRegrasDMS ObterPorDescricao(string descricao);
        TabelaRegrasDMS ObterPorGrupoAutorizacao(string nomeQuimico);
        TabelaRegrasDMS ObterPorCodGrupo(string laboratorio);
        void ExcluirExcel();
        TabelaRegrasDMS ObterPorId(int id);
        void ObterPorCodigo(string Codigo);
        Paged<TabelaRegrasDMS> ObterTodos(string nome, int pageSize, int pageNumber);
        List<TabelaRegrasDMS> ObterTodos();
        TabelaRegrasDMS ObterPorIdTabela(int id);
    }
}
