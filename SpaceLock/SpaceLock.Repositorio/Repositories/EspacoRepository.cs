using SpaceLock.Entidades;
using SpaceLock.Repositorio.Context;
using SpaceLock.Repositorio.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLock.Repositorio.Repositories
{
    public class EspacoRepository : BaseRepository<Espaco>, IEspacoRepository
    {
        public List<Espaco> ListarPorUsuario(int idUsuario)
        {
            using (DataContext d = new DataContext())
            {
                return d.Espaco
                        .Where(e => e.IdUsuario == idUsuario)
                        .ToList();
            }
        }

        public List<Espaco> ListarPorTipoEvento(int idTipoEvento)
        {
            using (DataContext d = new DataContext())
            {
                /*return d.Espaco
                        .Join(d.EspacoTipoEvento, e => e.IdEspaco, et => et.IdEspaco, (e, et) => new { e, et })
                        .Where(espaco => espaco.et.IdTipoEvento == idTipoEvento)
                        .ToList();*/

                return (from e in d.Espaco
                        join et in d.EspacoTipoEvento
                        on e.IdEspaco equals et.IdEspaco
                        where et.IdTipoEvento == idTipoEvento
                        select e)
                         .ToList();

            }
        }

        public int InsertRetornandoChavePrimaria(Espaco obj)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(obj).State = EntityState.Added;
                d.SaveChanges();
                d.Entry(obj).GetDatabaseValues();

                return obj.IdEspaco; // Yes it's here

            }
        }
    }
}
