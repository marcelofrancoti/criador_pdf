using AutoMapper;
using SistemaIndexador.Application.Interfaces;
using SistemaIndexador.Application.ViewModels;
using SistemaIndexador.Domain.Entities;
using SistemaIndexador.Domain.Interfaces.Service;
using SistemaIndexador.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace SistemaIndexador.Application
{
    public class TabelaRegrasDMSAppService : ApplicationService, ITabelaRegrasDMSAppService
    {
        private readonly ITabelaRegrasDMSService _TabelaRegrasDMSService;

        public TabelaRegrasDMSAppService(ITabelaRegrasDMSService TabelaRegrasDMSService, IUnitOfWork uow)
            : base(uow)
        {
            _TabelaRegrasDMSService = TabelaRegrasDMSService;
        }

        public TabelaRegrasDMSViewModel Adicionar(TabelaRegrasDMSViewModel tabelaPrecoOncoprodViewModel)
        {
            var tabelaPrecoOncoprod = Mapper.Map<TabelaRegrasDMS>(tabelaPrecoOncoprodViewModel);

            BeginTransaction();

            var TabelaPrecoOncoprodReturn = _TabelaRegrasDMSService.Adicionar(tabelaPrecoOncoprod);
            tabelaPrecoOncoprodViewModel = Mapper.Map<TabelaRegrasDMSViewModel>(TabelaPrecoOncoprodReturn);

            Commit();

            return tabelaPrecoOncoprodViewModel;
        }

        public TabelaRegrasDMSViewModel Atualizar(TabelaRegrasDMSViewModel tabelaPrecoOncoprodViewModel)
        {
            BeginTransaction();
            _TabelaRegrasDMSService.Atualizar(Mapper.Map<TabelaRegrasDMS>(tabelaPrecoOncoprodViewModel));
            Commit();
            return tabelaPrecoOncoprodViewModel;
        }

        public TabelaRegrasDMSViewModel ObterPorDescricao(string descricao)
        {
            return Mapper.Map<TabelaRegrasDMSViewModel>(_TabelaRegrasDMSService.ObterPorDescricao(descricao));
        }

        public TabelaRegrasDMSViewModel ObterPorId(int id)
        {
            return Mapper.Map<TabelaRegrasDMSViewModel>(_TabelaRegrasDMSService.ObterPorId(id));
        }

        public TabelaRegrasDMSViewModel ObterPorLaboratorio(string laboratorio)
        {
            return Mapper.Map<TabelaRegrasDMSViewModel>(_TabelaRegrasDMSService.ObterPorLaboratorio(laboratorio));
        }

        public TabelaRegrasDMSViewModel ObterPorNomeQuimico(string nomeQuimico)
        {
            return Mapper.Map<TabelaRegrasDMSViewModel>(_TabelaRegrasDMSService.ObterPorNomeQuimico(nomeQuimico));
        }

        public PagedViewModel<TabelaRegrasDMSViewModel> ObterTodos(string descricao, int pageSize, int pageNumber)
        {
            return Mapper.Map<PagedViewModel<TabelaRegrasDMSViewModel>>(_TabelaRegrasDMSService.ObterTodos(descricao, pageSize, pageNumber));
        }

        public void ObterPorCodigo(string id)
        {
          
            _TabelaRegrasDMSService.ObterPorCodigo(id);
           
        }

        public void ExcluirExcel()
        {
            BeginTransaction();
            _TabelaRegrasDMSService.ExcluirExcel();
            Commit();
        }
        public void Remover(int id)
        {
            BeginTransaction();
            _TabelaRegrasDMSService.Remover(id);
            Commit();
        }

        //public void Dispose()
        //{
        //    _TabelaRegrasDMSService.Dispose();
        //    GC.SuppressFinalize(this);
        //}

        public TabelaRegrasDMSViewModel ObterPorIdTabela(int id)
        {
            return Mapper.Map<TabelaRegrasDMSViewModel>(_TabelaRegrasDMSService.ObterPorIdTabela(id));
        }

        public List<TabelaRegrasDMSViewModel> ObterTodos()
        {
            return Mapper.Map<List<TabelaRegrasDMSViewModel>>(_TabelaRegrasDMSService.ObterTodos());
        }
    }
}
