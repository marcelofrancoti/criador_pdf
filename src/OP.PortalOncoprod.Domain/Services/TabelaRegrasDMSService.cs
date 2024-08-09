using SistemaIndexador.Domain.Interfaces.Repository;
using SistemaIndexador.Domain.Interfaces.Service;
using SistemaIndexador.Domain.Entities;
using System;
using SistemaIndexador.Domain.DTO;
using System.Collections.Generic;

namespace SistemaIndexador.Domain.Services
{
    public class TabelaRegrasDMSService : ITabelaRegrasDMSService
    {
        private readonly ITabelaPrecoOncoprodRepository _TabelaRegrasDMSRepository;

        public TabelaRegrasDMSService(ITabelaPrecoOncoprodRepository TabelaRegrasDMSRepository)
        {
            _TabelaRegrasDMSRepository = TabelaRegrasDMSRepository;
        }

        public TabelaRegrasDMS Adicionar(TabelaRegrasDMS tabelaPrecoOncoprod)
        {
            return _TabelaRegrasDMSRepository.Adicionar(tabelaPrecoOncoprod);
        }

        public TabelaRegrasDMS Atualizar(TabelaRegrasDMS tabelaPrecoOncoprod)
        {
            return _TabelaRegrasDMSRepository.Atualizar(tabelaPrecoOncoprod);
        }
    
        public TabelaRegrasDMS ObterPorDescricao(string descricao)
        {
            return _TabelaRegrasDMSRepository.ObterPorDescricao(descricao);
        }

        public TabelaRegrasDMS ObterPorId(int id)
        {
            return _TabelaRegrasDMSRepository.ObterPorId(id);
        }

        public TabelaRegrasDMS ObterPorLaboratorio(string laboratorio)
        {
            return _TabelaRegrasDMSRepository.ObterPorCodGrupo(laboratorio);
        }

        public TabelaRegrasDMS ObterPorNomeQuimico(string nomeQuimico)
        {
            return _TabelaRegrasDMSRepository.ObterPorGrupoAutorizacao(nomeQuimico);
        }

        public Paged<TabelaRegrasDMS> ObterTodos(string nome, int pageSize, int pageNumber)
        {
            return _TabelaRegrasDMSRepository.ObterTodos(nome, pageSize, pageNumber);
        }

        public void ObterPorCodigo(string codigo)
        {
             _TabelaRegrasDMSRepository.ObterPorCodigo(codigo);
        }

        public void ExcluirExcel()
        {
            _TabelaRegrasDMSRepository.ExcluirExcel();
        }
        public void Remover(int id)
        {
            _TabelaRegrasDMSRepository.Remover(id);
        }

        public void Dispose()
        {
            _TabelaRegrasDMSRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public TabelaRegrasDMS ObterPorIdTabela(int id)
        {
            return _TabelaRegrasDMSRepository.ObterPorIdTabela(id);
        }

        public List<TabelaRegrasDMS> ObterTodos()
        {
            return _TabelaRegrasDMSRepository.ObterTodos();
        }
    }
}
