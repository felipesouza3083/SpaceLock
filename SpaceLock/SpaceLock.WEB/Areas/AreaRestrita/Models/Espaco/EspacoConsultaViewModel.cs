using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceLock.WEB.Areas.AreaRestrita.Models.Espaco
{
    public class EspacoConsultaViewModel
    {
        public int IdEspaco { get; set; }
        public string NomeEspaco { get; set; }
        public int Capacidade { get; set; }
        public int Tamanho { get; set; }
        public string UnidadeMedida { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public int IdUsuario { get; set; }
    }
}