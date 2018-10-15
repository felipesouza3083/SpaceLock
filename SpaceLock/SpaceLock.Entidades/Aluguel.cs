using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLock.Entidades
{
    public class Aluguel
    {
        public int IdAluguel { get; set; }
        public DateTime DataAlguel { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public string Descricao { get; set; }
        public double ValorAluguel { get; set; }
        public int IdUsuario { get; set; }
        public int IdEspaco { get; set; }

        public Espaco Espaco { get; set; }
        public Usuario Usuario { get; set; }

        public Aluguel()
        {

        }

        public Aluguel(int idAluguel, DateTime dataAlguel, TimeSpan horaInicio, TimeSpan horaFim, string descricao, double valorAluguel)
        {
            IdAluguel = idAluguel;
            DataAlguel = dataAlguel;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
            Descricao = descricao;
            ValorAluguel = valorAluguel;
        }

        public override string ToString()
        {
            return $"Id do aluguel: {IdAluguel}, Descrição: {Descricao}";
        }
    }
}
