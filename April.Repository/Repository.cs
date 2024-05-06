using April.DomainEntites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace April.Repository
{
    public class Repository <TEntity>: IRepository <TEntity> where TEntity : class
    {
        private DbSet<TEntity> _dbset;
        private readonly AprilUsersContext _context;



        public void Add(TEntity entity)
        {
            if (entity == null) 

            {
                throw new ArgumentNullException("entity");
            }
        _dbset.Add(entity);
        _context.SaveChanges();
        }


        public bool Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new NotImplementedException("entity");
            }
        _dbset.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public List<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
