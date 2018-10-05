using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpaceLock.WEB.Models.Usuario
{
    public class UsuarioLoginViewModel
    {
        [Required(ErrorMessage = "Informe o login")]
        [Display(Name = "Login do Usuário:")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}