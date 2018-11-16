using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpaceLock.WEB.Areas.AreaRestrita.Models.EspacoFoto
{
    public class EspacoFotoCadastroViewModel
    {
        [Required(ErrorMessage = "Informe o nome da foto")]
        public string Foto { get; set; }

        [Required(ErrorMessage = "Informe o espaço")]
        public int IdEspaco { get; set; }
    }
}