using SistemaIndexador.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndexador.Application.Interfaces
{
    public interface IGrupoSistemaAppService : IDisposable
    {
        GrupoSistemaViewModel Adicionar(GrupoSistemaViewModel grupoSistemaTabela);
        GrupoSistemaViewModel ObterPorId(int id);
        void ObterPorCodigo(int id);
        GrupoSistemaViewModel ObterPorDescricao(string descricao);
        PagedViewModel<GrupoSistemaViewModel> ObterTodos(string descricao, int pageSize, int pageNumber);
        GrupoSistemaViewModel Atualizar(GrupoSistemaViewModel grupoSistemaTabela);
        
        void Remover(int id);
    }
}
