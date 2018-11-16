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
    public class EspacoFotoRepository : BaseRepository<EspacoFoto>, IEspacoFotoRepository
    {
        public List<EspacoFoto> ListarFotosPorEspaco(int idEspaco)
        {
            using(DataContext d = new DataContext())
            {
                return d.EspacoFoto
                        .Where(ef => ef.IdEspaco == idEspaco)
                        .ToList();
            }
        }
    }
}
