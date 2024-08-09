using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaIndexador.Domain.Entities
{
    [Table("Usuario")]
    public class Usuario
    {
        public string usuarioId { get; set; }
        public string usuarioNome { get; set; }
        public string dominioId { get; set; }
        public string usuarioLogin { get; set; }
        public string usuarioEmail { get; set; }
        public string usuarioSenha { get; set; }


    }
}
