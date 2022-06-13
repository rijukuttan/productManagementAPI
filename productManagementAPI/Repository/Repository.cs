
//using CoreCodeFirst.Repository.IRepository;

using Microsoft.EntityFrameworkCore;
using productManagementAPI.Data;
using productManagementAPI.Repository.IRepository;
using System.Linq.Expressions;

namespace productManagementAPI.Repository
{
    public class Repository<T>:IRepository<T> where T : class
    {
        private readonly DatabaseContext _db;
        internal DbSet<T> dbset;
        public Repository(DatabaseContext db)
        {
            _db = db;
            this.dbset = _db.Set<T>();  
        }

        public void Add(T item)
        {
            _db.Add(item);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter=null,string? includeProperties = null)
        {
            IQueryable<T> query = dbset;
            if(filter != null)
            {
                query = query.Where(filter);
            }
            if(includeProperties != null)
            {
                foreach(var property in includeProperties.Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries)){
                    query=query.Include(property);
                    
                }
            }
            //return query;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T>? query = dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            return query.FirstOrDefault();
        }

        public void Remove(T item)
        {
           _db.Remove(item);
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            _db.RemoveRange(items);
        }
    }
}
