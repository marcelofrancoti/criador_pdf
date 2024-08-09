using AutoMapper;
using SistemaIndexador.Application.ViewModels;
using SistemaIndexador.Domain.DTO;
using SistemaIndexador.Domain.Entities;

namespace SistemaIndexador.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<UsuarioTabelaRegrasDMS, UsuarioTabelaRegrasDMSViewModel>();
            CreateMap<GrupoSistemaTabelaPreco, GrupoSistemaViewModel>();
            CreateMap<TabelaRegrasDMS, TabelaRegrasDMSViewModel>();
            CreateMap<Paged<TabelaRegrasDMS>, PagedViewModel<TabelaRegrasDMSViewModel>>();
            CreateMap<Paged<Usuario>, PagedViewModel<UsuarioViewModel>>();
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<PerfilAcesso, PerfilAcessoViewModel>();
        }
    }
}