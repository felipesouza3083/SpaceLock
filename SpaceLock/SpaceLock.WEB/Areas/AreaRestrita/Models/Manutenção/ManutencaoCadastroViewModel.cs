using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpaceLock.WEB.Areas.AreaRestrita.Models.Manutenção
{
    public class ManutencaoCadastroViewModel
    {
        [Required(ErrorMessage ="Informe a Data de Inicio")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Informe a Data Final")]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "Informe o motivo")]
        public string Motivo { get; set; }

        [Required(ErrorMessage = "Informe o Espaço")]
        public int IdEspaco { get; set; }

        [Required(ErrorMessage = "Informe o Usuário")]
        public int IdUsuario { get; set; }
    }
}