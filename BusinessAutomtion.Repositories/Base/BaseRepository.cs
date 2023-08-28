using BusinessAutomation.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAutomtion.Repositories.Base
{
    public abstract class BaseRepository<T> where T : class
    {
        protected DbContext _db;
        /*public BaseRepository(DbContext db)
        {
            _db = db;
        }*/
        private DbSet<T> Table
        {
            get
            {
                return _db.Set<T>();
            }
        }
        public bool Add(T entity)
        {
            Table.Add(entity);
            return _db.SaveChanges() > 0;
        }

        public ICollection<T> GetAll()
        {
            return Table.ToList();
        }

        public bool Update(T entity)
        {
           Table.Update(entity);
            return _db.SaveChanges() > 0;
        }
        public bool Remove(T entity)
        {
            Table.Remove(entity);
            return _db.SaveChanges() > 0;
        }
    }
}
