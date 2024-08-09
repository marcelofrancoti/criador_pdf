using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SistemaIndexador.Application.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public string usuarioId { get; set; }
        [HiddenInput]
        public string UrlRetorno { get; set; }
      

        [Required(ErrorMessage = "Informe o login")]
        [MaxLength(20, ErrorMessage = "O login deve ter até 50 caracteres")]
        public string usuarioLogin { get; set; }
     

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        public string usuarioSenha { get; set; }
       

    }
}
