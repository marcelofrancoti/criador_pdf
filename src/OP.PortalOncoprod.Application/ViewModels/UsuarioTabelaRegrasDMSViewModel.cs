using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndexador.Application.ViewModels
{
    public class UsuarioTabelaRegrasDMSViewModel
    {
        [Key]

        public int Id { get; set; }

        [DisplayName("usuarioTabelaRegrasDMSId")]
        public int usuarioTabelaRegrasDMSId { get; set; }

        [DisplayName("usuarioId")]
        public string usuarioId { get; set; }

        [DisplayName("grupoId")]
        public string grupoId { get; set; }

        public List<UsuarioTabelaRegrasDMSViewModel> listaUsuarioTabela { get; set; }
        public List<GrupoSistemaViewModel> listaGrupo{ get; set; }
    }
}
