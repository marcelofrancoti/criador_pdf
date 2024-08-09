using AutoMapper;
using SistemaIndexador.Application.ViewModels;
using SistemaIndexador.Domain.Entities;

namespace SistemaIndexador.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<UsuarioTabelaRegrasDMSViewModel,UsuarioTabelaRegrasDMS>();
            CreateMap<GrupoSistemaViewModel, GrupoSistemaTabelaPreco>();
            CreateMap<TabelaRegrasDMSViewModel, TabelaRegrasDMS>();
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<PerfilAcessoViewModel, PerfilAcesso>();
        }
    }
}