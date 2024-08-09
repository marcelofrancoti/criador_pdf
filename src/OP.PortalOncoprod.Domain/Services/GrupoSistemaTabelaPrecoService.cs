using SistemaIndexador.Domain.DTO;
using SistemaIndexador.Domain.Entities;
using SistemaIndexador.Domain.Interfaces.Repository;
using SistemaIndexador.Domain.Interfaces.Service;
using System;


namespace SistemaIndexador.Domain.Services
{
    public class GrupoSistemaTabelaPrecoService : IGrupoSistemaTabelaPrecoService
    {
        private readonly IGrupoSistemaTabelaPrecoRepository _GrupoSistemaTabelaPreco;

        public GrupoSistemaTabelaPrecoService(IGrupoSistemaTabelaPrecoRepository GrupoSistemaTabela)
        {
            _GrupoSistemaTabelaPreco = GrupoSistemaTabela;
        }

       public GrupoSistemaTabelaPreco Adicionar(GrupoSistemaTabelaPreco tabelaPrecoOncoprod)
        {
            return _GrupoSistemaTabelaPreco.Adicionar(tabelaPrecoOncoprod);
        }

        public GrupoSistemaTabelaPreco Atualizar(GrupoSistemaTabelaPreco tabelaPrecoOncoprod)
        {
            return _GrupoSistemaTabelaPreco.Atualizar(tabelaPrecoOncoprod);
        }

        public void Dispose()
        {
            _GrupoSistemaTabelaPreco.Dispose();
            GC.SuppressFinalize(this);
        }

        public void ObterPorCodigo(int id)
        {
            _GrupoSistemaTabelaPreco.ObterPorCodigo(id);
        }

        public GrupoSistemaTabelaPreco ObterPorDescricao(string descricao)
        {
            return _GrupoSistemaTabelaPreco.ObterPorDescricao(descricao);
        }

        public GrupoSistemaTabelaPreco ObterPorId(int id)
        {
            return _GrupoSistemaTabelaPreco.ObterPorId(id);
        }

        public Paged<GrupoSistemaTabelaPreco> ObterTodos(string nome, int pageSize, int pageNumber)
        {
            return _GrupoSistemaTabelaPreco.ObterTodos(nome, pageSize, pageNumber);
        }

        public void Remover(int id)
        {
            _GrupoSistemaTabelaPreco.Remover(id);
        }
    }
}
