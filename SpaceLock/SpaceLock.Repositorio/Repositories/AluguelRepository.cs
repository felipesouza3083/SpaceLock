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
    public class AluguelRepository : BaseRepository<Aluguel>, IAluguelRepository
    {
        public void AtualizaValorAluguel(int idAluguel, double valor)
        {
            var a = new Aluguel() { IdAluguel = idAluguel, ValorAluguel = valor, FlVerificado = 1 };
            using (DataContext d = new DataContext())
            {
                d.Aluguel.Attach(a);
                d.Entry(a).Property(al => al.ValorAluguel).IsModified = true;
                d.Entry(a).Property(al => al.FlVerificado).IsModified = true;
                d.SaveChanges();
            }
        }

        public void CancelaAluguel(int idAluguel)
        {
            var a = new Aluguel() { IdAluguel = idAluguel, FlCancelado = 1 };
            using (DataContext d = new DataContext())
            {
                d.Aluguel.Attach(a);
                d.Entry(a).Property(al => al.FlCancelado).IsModified = true;
                d.SaveChanges();
            }
        }

        public List<Aluguel> ListaAlugueisPorEspaco(int idEspaco)
        {
            using (DataContext d = new DataContext())
            {
                return d.Aluguel
                        .Include(a => a.Usuario)
                        .Where(a => a.IdEspaco == idEspaco)
                        .ToList();
            }
        }

        public List<Aluguel> ListaAlugueisPorUsuario(int idUsuario)
        {
            using (DataContext d = new DataContext())
            {
                return d.Aluguel
                        .Include(a => a.Espaco)
                        .Where(a => a.IdUsuario == idUsuario)
                        .ToList();
            }
        }

        public override Aluguel FindById(int id)
        {
            using (DataContext d = new DataContext())
            {
                return d.Set<Aluguel>()
                        .Include(a => a.Usuario)
                        .Include(a => a.Espaco)
                        .FirstOrDefault(a => a.IdAluguel == id);
            }
        }
    }
}
