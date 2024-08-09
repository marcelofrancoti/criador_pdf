using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndexador.Application.ViewModels
{
    public class GrupoSistemaViewModel
    {
        [Key]

        public int Id { get; set; }

        [DisplayName("grupoId")]
        public int grupoId { get; set; }

        [DisplayName("Elemento")]
        public string elemento { get; set; }

        [DisplayName("Nome do Grupo")]
        public string nomeGrupo { get; set; }

    }
}
