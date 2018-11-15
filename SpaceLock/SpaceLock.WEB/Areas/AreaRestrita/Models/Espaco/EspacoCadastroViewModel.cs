using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpaceLock.WEB.Areas.AreaRestrita.Models.Espaco
{
    public class EspacoCadastroViewModel
    {
        [Required(ErrorMessage = "Informe o nome do espaço.")]
        public string NomeEspaco { get; set; }

        [Required(ErrorMessage = "Informe a capacidade do espaço.")]
        public int Capacidade { get; set; }

        [Required(ErrorMessage = "Informe o tamanho do espaço.")]
        public int Tamanho { get; set; }

        [Required(ErrorMessage = "Informe a unidade de medida.")]
        public string UnidadeMedida { get; set; }

        [Required(ErrorMessage = "Informe o Endereço.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Informe o Número.")]
        public int Numero { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "Informe o Bairro.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe a Cidade.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe a UF.")]
        public string Uf { get; set; }

        [Required(ErrorMessage = "Informe o CEP.")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Informe o id do usuário.")]
        public int IdUsuario { get; set; }
    }
}