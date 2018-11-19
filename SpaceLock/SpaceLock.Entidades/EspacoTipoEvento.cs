using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLock.Entidades
{
    public class EspacoTipoEvento
    {
        public int IdEspacoTipoEvento { get; set; }
        public int IdEspaco { get; set; }
        public int IdTipoEvento { get; set; }
        public DateTime DataCriacao { get; set; }

        public Espaco Espaco { get; set; }
        public TipoEvento TipoEvento { get; set; }

        public EspacoTipoEvento()
        {

        }

        public EspacoTipoEvento(int idEspacoTipoEvento, int idEspaco, int idTipoEvento, DateTime dataCriacao)
        {
            IdEspacoTipoEvento = idEspacoTipoEvento;
            IdEspaco = idEspaco;
            IdTipoEvento = idTipoEvento;
            DataCriacao = dataCriacao;
        }

        public override string ToString()
        {
            return $"Id do Espaço: {IdEspaco}, Id do Evento: {IdTipoEvento}";
        }
    }
}
