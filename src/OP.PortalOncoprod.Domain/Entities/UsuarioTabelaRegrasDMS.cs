
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaIndexador.Domain.Entities
{
    [Table("UsuarioTabelaRegrasDMS")]
    public class UsuarioTabelaRegrasDMS
    {
        public int usuarioTabelaRegrasDMSId { get; set; }
        public string usuarioId { get; set; }
        public int grupoId { get; set; }
        public List<UsuarioTabelaRegrasDMS> listaUsuarioTabela { get; set; }
    }
}
