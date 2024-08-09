using SistemaIndexador.Domain.DTO;
using SistemaIndexador.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SistemaIndexador.Domain.Interfaces.Service
{
    public interface ITabelaRegrasDMSService : IDisposable
    {
        TabelaRegrasDMS Adicionar(TabelaRegrasDMS tabelaPrecoOncoprod);
        TabelaRegrasDMS ObterPorId(int id);
        void ObterPorCodigo(string id);
        TabelaRegrasDMS ObterPorDescricao(string descricao);
        TabelaRegrasDMS ObterPorNomeQuimico(string nomeQuimico);
        TabelaRegrasDMS ObterPorLaboratorio(string laboratorio);
        Paged<TabelaRegrasDMS> ObterTodos(string nome, int pageSize, int pageNumber);
        TabelaRegrasDMS Atualizar(TabelaRegrasDMS tabelaPrecoOncoprod);
        void ExcluirExcel();
        void Remover(int id);
        TabelaRegrasDMS ObterPorIdTabela(int id);
        List<TabelaRegrasDMS> ObterTodos();
    }
}
