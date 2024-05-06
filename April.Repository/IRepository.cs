using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace April.Repository
{
    public interface IRepository <TEntity> where TEntity : class
    {

        void Add(TEntity entity);

        bool Delete (TEntity entity);

        List<TEntity> GetAll ();

        TEntity GetById (int id);

    }
}
