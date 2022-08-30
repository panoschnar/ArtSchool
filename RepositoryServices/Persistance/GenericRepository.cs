using DataAccessLayer;
using Entities.Models;
using RepositoryServices.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Persistance
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ArtSchoolEntity
    {
        public ApplicationDbContext db;
        public DbSet<T> table;
        public GenericRepository(ApplicationDbContext context)
        {
            db = context;
            table = db.Set<T>();
        }

        public IEnumerable<T> GetAll() => table.ToList();

        public T GetById(object id) => table.Find(id);

        public void Insert(T obj) => table.Add(obj);

        public void Update(T obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id) => table.Remove(table.Find(id));

        public void Save() => db.SaveChanges();

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression) => table.Where(expression).ToList();

        public T SingleOrDefault(Expression<Func<T, bool>> expression) => table.SingleOrDefault(expression);

    }
}
