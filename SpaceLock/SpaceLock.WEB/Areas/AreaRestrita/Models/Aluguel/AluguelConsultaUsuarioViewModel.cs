using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceLock.WEB.Areas.AreaRestrita.Models.Aluguel
{
    public class AluguelConsultaUsuarioViewModel
    {
        public int IdAluguel { get; set; }
        public DateTime DataAluguel { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public string Descricao { get; set; }
        public int FlCancelado { get; set; }
        public int FlConfirmado { get; set; }
        public int IdEspaco { get; set; }
        public string NomeEspaco { get; set; }
    }
}