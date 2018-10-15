using SpaceLock.Entidades;
using SpaceLock.Repositorio.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLock.Repositorio.Repositories
{
    public class EspacoRepository : BaseRepository<Espaco>, IEspacoRepository
    {
        public List<Espaco> ListarPorUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public List<Espaco> ListarPorTipoEvento(int idTipoEvento)
        {
            throw new NotImplementedException();
        }
    }
}
