using SistemaIndexador.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.PortalOncoprod.Application.ViewModels
{
    public class DadosIndexadorViewModel
    {
        ITabelaRegrasDMSAppService _tabelaRegrasService;
        DadosIndexadorViewModel(ITabelaRegrasDMSAppService tabelaRegrasDMSAppService)
        {
            _tabelaRegrasService = tabelaRegrasDMSAppService;

            ListaRegras = _tabelaRegrasService.ObterListaDescricao();
        }

        public List<string> ListaRegras { get; set; }
    }
}
