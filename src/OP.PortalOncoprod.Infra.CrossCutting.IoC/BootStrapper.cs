using SistemaIndexador.Application;
using SistemaIndexador.Application.Interfaces;
using SistemaIndexador.Domain.Interfaces.Repository;
using SistemaIndexador.Domain.Interfaces.Service;
using SistemaIndexador.Domain.Services;
using SistemaIndexador.Infra.CrossCutting.Logging.Data;
using SistemaIndexador.Infra.CrossCutting.Logging.Helpers;
using SistemaIndexador.Infra.Data.Context;
using SistemaIndexador.Infra.Data.Interfaces;
using SistemaIndexador.Infra.Data.Repository;
using SistemaIndexador.Infra.Data.UoW;
using SimpleInjector;

namespace SistemaIndexador.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request

            // App
            container.Register<ITabelaRegrasDMSAppService, TabelaRegrasDMSAppService>(Lifestyle.Scoped);
            container.Register<IUsuarioTabelaRegrasDMSAppService, UsuarioTabelaAppService>(Lifestyle.Scoped);
            container.Register<IUsuarioAppService, UsuarioAppService>(Lifestyle.Scoped);
            container.Register<IGrupoSistemaAppService, GrupoSistemaAppService>(Lifestyle.Scoped);

            // Domain
            container.Register<IUsuarioTabelaPrecoService, UsuarioTabelaPrecoService>(Lifestyle.Scoped);
            container.Register<ITabelaRegrasDMSService, TabelaRegrasDMSService>(Lifestyle.Scoped);
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
            container.Register<IGrupoSistemaTabelaPrecoService, GrupoSistemaTabelaPrecoService>(Lifestyle.Scoped);

            // Infra Dados
            container.Register<ITabelaPrecoOncoprodRepository, TabelaRegrasDMSRepository>(Lifestyle.Scoped);
            container.Register<IUsuarioTabelaPrecoRepository, UsuarioTabelaPrecoRepository>(Lifestyle.Scoped);
            container.Register<IGrupoSistemaTabelaPrecoRepository, GrupoSistemaTabelaPrecoRepository>(Lifestyle.Scoped);
            container.Register<IUsuarioRepository, UsuariosRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<PortalOncoprodContext>(Lifestyle.Scoped);

            // Logging
            container.Register<ILogAuditoria, LogAuditoriaHelper>(Lifestyle.Scoped);
            container.Register<LogginContext>(Lifestyle.Scoped);
        }
    }
}