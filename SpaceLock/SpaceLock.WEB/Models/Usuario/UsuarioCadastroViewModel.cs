using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpaceLock.WEB.Models.Usuario
{
    public class UsuarioCadastroViewModel
    {
        [Required(ErrorMessage = "Informe o nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o Login.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a senha.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Senhas não conferem.")]
        [Required(ErrorMessage = "Informe a Confirmação da senha.")]
        [DataType(DataType.Password)]
        public string ConfirmSenha { get; set; }

        //[Required(ErrorMessage = "Envie a foto.")]
        public HttpPostedFileBase Foto { get; set; }
    }
}