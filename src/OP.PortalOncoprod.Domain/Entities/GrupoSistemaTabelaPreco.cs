using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndexador.Domain.Entities
{
    [Table("KsGrupoSistemaTabelaPreco")]
    public class GrupoSistemaTabelaPreco
    {
        
        public int grupoId { get; set; }
        public string elemento { get; set; }
        public string nomeGrupo { get; set; }


    }
}
