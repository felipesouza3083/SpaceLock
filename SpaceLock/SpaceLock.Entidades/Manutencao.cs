using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLock.Entidades
{
    public class Manutencao
    {
        public int IdManutencao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Motivo { get; set; }
        public int IdEspaco { get; set; }
        public int IdUsuario { get; set; }

        public Espaco Espaco { get; set; }
        public Usuario Usuario { get; set; }

        public Manutencao()
        {

        }

        public Manutencao(int idManutencao, DateTime dataInicio, DateTime dataFim, string motivo, int idEspaco)
        {
            IdManutencao = idManutencao;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Motivo = motivo;
            IdEspaco = idEspaco;
        }

        public override string ToString()
        {
            return $"Id da Manutenção: {IdManutencao}, Motivo: {Motivo}";
        }
    }
}
