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
    public class AluguelRepository : BaseRepository<Aluguel>, IAluguelRepository
    {
        public List<Aluguel> ListaAlugueisPorEspaco(int idEspaco)
        {
            using(DataContext d = new DataContext())
            {
                return d.Aluguel
                        .Where(a => a.IdEspaco == idEspaco)
                        .ToList();
            }
        }

        public List<Aluguel> ListaAlugueisPorUsuario(int idUsuario)
        {
            using (DataContext d = new DataContext())
            {
                return d.Aluguel
                        .Where(a => a.IdUsuario == idUsuario)
                        .ToList();
            }
        }
    }
}
