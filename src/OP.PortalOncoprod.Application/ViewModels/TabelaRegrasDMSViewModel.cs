// Decompiled with JetBrains decompiler
// Type: SistemaIndexador.Application.ViewModels.TabelaPrecoOncoprodViewModel
// Assembly: SistemaIndexador.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8ACDBE2E-618F-4D71-B415-7B62351E8B68
// Assembly location: C:\Users\redbu\OneDrive\Área de Trabalho\PortalConsultas\bin\SistemaIndexador.Application.dll

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaIndexador.Application.ViewModels
{
    public class TabelaRegrasDMSViewModel
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Infotipo")]
        public string Infotipo { get; set; }

        [DisplayName("Regra")]
        public string Regra { get; set; }
        [DisplayName("Subinfotipo")]
        public string Subinfotipo { get; set; }
        [DisplayName("FormularioKitAdmissao")]
        public string FormularioKitAdmissao { get; set; }
        [DisplayName("OutrosDocumentosControlados")]
        public string OutrosDocumentosControlados { get; set; }
        [DisplayName("Obrigatorio")]
        public string Obrigatorio { get; set; }
        [DisplayName("DescricaoOutrosDocs")]
        public string DescricaoOutrosDocs { get; set; }
        [DisplayName("NomeFuncao")]
        public string NomeFuncao { get; set; }
    
        [DisplayName("CampoDoCtg")]
        public string CampoDoCtg { get; set; }

        [DisplayName("TipoMedida")]
        public string TipoMedida { get; set; }
        [DisplayName("NomeUsuario")]
        public string NomeUsuario { get; set; }
        [DisplayName("Data")]
        public string Data { get; set; }
        [DisplayName("GrupoAutorizacoes")]
        public string GrupoAutorizacoes { get; set; }
        [DisplayName("CodGrupo")]
        public string CodGrupo { get; set; }





        public List<UsuarioTabelaRegrasDMSViewModel> PaginasAcessos { get; set; }
    }
}
