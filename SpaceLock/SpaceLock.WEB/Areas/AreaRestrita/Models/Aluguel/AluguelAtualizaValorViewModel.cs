using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpaceLock.WEB.Areas.AreaRestrita.Models.Aluguel
{
    public class AluguelAtualizaValorViewModel
    {
        [Required(ErrorMessage = "Informe o Aluguel")]
        public int IdAluguel { get; set; }

        [Required(ErrorMessage = "Informe o valor do Aluguel")]
        public string ValorAluguel { get; set; }
    }
}