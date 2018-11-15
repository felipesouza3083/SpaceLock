using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLock.Entidades
{
    public class Espaco
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
        public DateTime DataCadastro { get; set; }
        public int IdUsuario { get; set; }

        public List<TipoEvento> TipoEventos { get; set; }
        public List<Manutencao> Manutencoes { get; set; }
        public List<Aluguel> Alugueis { get; set; }
        public List<EspacoFoto> EspacoFotos { get; set; }
        public Usuario Usuario { get; set; }

        public Espaco()
        {

        }

        public Espaco(int idEspaco, string nomeEspaco, int capacidade, int tamanho, string unidadeMedida, string endereco, int numero, string complemento, string bairro, string cidade, string uf, string cep, DateTime dataCadastro)
        {
            IdEspaco = idEspaco;
            NomeEspaco = nomeEspaco;
            Capacidade = capacidade;
            Tamanho = tamanho;
            UnidadeMedida = unidadeMedida;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
            Cep = cep;
            DataCadastro = dataCadastro;
        }

        public override string ToString()
        {
            return $"Id do espaço: {IdEspaco}, Nome: {NomeEspaco}";
        }
    }
}
