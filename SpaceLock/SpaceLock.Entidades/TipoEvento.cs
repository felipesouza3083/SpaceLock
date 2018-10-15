using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLock.Entidades
{
    public class TipoEvento
    {
        public int IdTipoEvento { get; set; }
        public string Descricao { get; set; }

        public List<Espaco> Espacos { get; set; }

        public TipoEvento()
        {

        }

        public TipoEvento(int idTipoEvento, string descricao)
        {
            IdTipoEvento = idTipoEvento;
            Descricao = descricao;
        }

        public override string ToString()
        {
            return $"Id Tipo de evento: {IdTipoEvento}, Descrição: {Descricao}";
        }
    }
}
