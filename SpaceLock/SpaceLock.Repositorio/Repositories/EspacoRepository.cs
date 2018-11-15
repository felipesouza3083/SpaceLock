using SpaceLock.Entidades;
using SpaceLock.Repositorio.Context;
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
            using(DataContext d = new DataContext())
            {
                return d.Espaco
                        .Where(e => e.IdUsuario == idUsuario)
                        .ToList();
            }
        }

        public List<Espaco> ListarPorTipoEvento(int idTipoEvento)
        {
            throw new NotImplementedException();
        }
    }
}
