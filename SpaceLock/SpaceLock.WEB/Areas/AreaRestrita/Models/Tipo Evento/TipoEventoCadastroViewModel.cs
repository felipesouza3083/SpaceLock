using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpaceLock.WEB.Areas.AreaRestrita.Models.Tipo_Evento
{
    public class TipoEventoCadastroViewModel
    {
        [Required(ErrorMessage = "Informe a descrição do Tipo de Evento.")]
        public string Descricao { get; set; }
    }
}