using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLock.Entidades
{
    public class EspacoFoto
    {
        public int IdEspacoFoto { get; set; }
        public string Foto { get; set; }
        public DateTime DataInsercao { get; set; }
        public int IdEspaco { get; set; }

        public Espaco Espaco { get; set; }

        public EspacoFoto()
        {

        }

        public EspacoFoto(int idEspacoFoto, string foto, DateTime dataInsercao)
        {
            IdEspacoFoto = idEspacoFoto;
            Foto = foto;
            DataInsercao = dataInsercao;
        }

        public override string ToString()
        {
            return $"Id da foto: {IdEspacoFoto}, Foto: {Foto}";
        }
    }
}
