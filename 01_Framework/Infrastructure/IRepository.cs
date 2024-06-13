using _01_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Infrastructure
{
    public interface IRepository<TKey,TValue> 
    {
        List<TValue> GetAll();
        void Create(TValue entity);
        TValue GetById(TKey id);
        bool Exist(Expression<Func<TValue, bool>> expression);
    }
}
