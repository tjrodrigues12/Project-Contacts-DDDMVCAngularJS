using System.Collections.Generic;

using System.Linq;
using System.Data.Entity;
using System.Configuration;
using Project.Domain.Entities;
using Project.Domain.Interfaces;
using Project.Infra.Data.Context;

namespace Project.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private DataContext context = new DataContext(ConfigurationManager.ConnectionStrings["connString"].ConnectionString.ToString());

        public void Insert(T obj)
        {
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }

        public void Update(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Set<T>().Remove(this.Select(id));
            context.SaveChanges();
        }

        public IList<T> Select()
        {
            return context.Set<T>().ToList();
        }

        public T Select(int id)
        {
            return context.Set<T>().Find(id);
        }

    }
}
