using SistemaIndexador.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace SistemaIndexador.Application.Interfaces
{
    public interface ITabelaRegrasDMSAppService
    {
        TabelaRegrasDMSViewModel Adicionar(TabelaRegrasDMSViewModel tabelaPrecoOncoprodViewModel);
        TabelaRegrasDMSViewModel ObterPorId(int id);
        void ObterPorCodigo(string id);
        TabelaRegrasDMSViewModel ObterPorDescricao(string descricao);
        TabelaRegrasDMSViewModel ObterPorNomeQuimico(string nomeQuimico);
        TabelaRegrasDMSViewModel ObterPorLaboratorio(string laboratorio);
        PagedViewModel<TabelaRegrasDMSViewModel> ObterTodos(string descricao, int pageSize, int pageNumber);
        List<TabelaRegrasDMSViewModel> ObterTodos();
       TabelaRegrasDMSViewModel Atualizar(TabelaRegrasDMSViewModel tabelaPrecoOncoprodViewModel);
        void ExcluirExcel();
        void Remover(int id);
        TabelaRegrasDMSViewModel ObterPorIdTabela(int value);
    }
}
