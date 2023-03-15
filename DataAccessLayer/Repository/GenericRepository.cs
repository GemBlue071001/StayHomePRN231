using DataAccessLayer.Interface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly AppDbContext Context;
        private DbSet<T> table = null;
        public GenericRepository(AppDbContext context)
        {
            Context = context;
            table = Context.Set<T>();
        }

        public virtual List<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            Context.Entry(obj).State = EntityState.Modified;

        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);

        }
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
