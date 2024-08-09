using SistemaIndexador.Application.ViewModels;

using System;
using System.Collections.Generic;

namespace SistemaIndexador.Application.Interfaces
{
    public interface IUsuarioTabelaRegrasDMSAppService : IDisposable
    {
        UsuarioTabelaRegrasDMSViewModel ObterPorUsuarioId(string usuarioId);
    }
}
