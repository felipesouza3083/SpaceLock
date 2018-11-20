using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpaceLock.WEB.Areas.AreaRestrita.Models.Aluguel
{
    public class AluguelAtualizaSolicitacaoViewModel
    {
        [Required(ErrorMessage = "Informe o Aluguel")]
        public int IdAluguel { get; set; }

        [Required(ErrorMessage = "Informe a Data do Aluguel.")]
        public DateTime DataAluguel { get; set; }

        [Required(ErrorMessage = "Informe a Hora Inicial do Aluguel.")]
        public TimeSpan HorInicio { get; set; }

        [Required(ErrorMessage = "Informe a Hora Final do Aluguel.")]
        public TimeSpan HoraFim { get; set; }

        [Required(ErrorMessage = "Informe a Descrição do Evento.")]
        public string DescricaoEvento { get; set; }

        [Required(ErrorMessage = "Informe o Espaço a ser Alugado.")]
        public int IdEspaco { get; set; }

        [Required(ErrorMessage = "Informe o Usuário solicitante.")]
        public int IdUsuario { get; set; }


    }
}