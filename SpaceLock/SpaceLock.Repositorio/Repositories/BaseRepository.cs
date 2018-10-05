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
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        public void Insert(T obj)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(obj).State = EntityState.Added;
                d.SaveChanges();
            }
        }

        public void Update(T obj)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(obj).State = EntityState.Modified;
                d.SaveChanges();
            }
        }

        public void Delete(T obj)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(obj).State = EntityState.Deleted;
                d.SaveChanges();
            }
        }

        public List<T> FindAll()
        {
            using (DataContext d = new DataContext())
            {
                return d.Set<T>().ToList();
            }
        }

        public T FindById(int id)
        {
            using (DataContext d = new DataContext())
            {
                return d.Set<T>().Find(id);
            }
        }

    }
}
