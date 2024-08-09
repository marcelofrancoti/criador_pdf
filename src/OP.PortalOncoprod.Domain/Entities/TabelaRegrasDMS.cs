// Decompiled with JetBrains decompiler
// Type: SistemaIndexador.Domain.Entities.TabelaPrecoOncoprod
// Assembly: SistemaIndexador.Domain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8A0EB73C-6866-409A-822D-92B0E4911B88
// Assembly location: C:\Users\redbu\OneDrive\Área de Trabalho\PortalConsultas\bin\SistemaIndexador.Domain.dll

using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaIndexador.Domain.Entities
{
    [Table("TabelaRegrasDMS")]
    public class TabelaRegrasDMS
    {
        public int id { get; set; }

        public string Infotipo { get; set; }
        public string Subinfotipo { get; set; }
        public string FormularioKitAdmissao { get; set; }
        public string OutrosDocumentosControlados { get; set; }
        public string Obrigatorio { get; set; }
        public string Regra { get; set; }
        public string DescricaoOutrosDocs { get; set; }
        public string NomeFuncao { get; set; }
        public string CampoDoCtg { get; set; }
        public string TipoMedida { get; set; }
        public string NomeUsuario { get; set; }
        public string Data { get; set; }
        public string CampoDaCtg { get; set; }
        public string GrupoAutorizacoes { get; set; }
        public string CodGrupo { get; set; }


    }
}
