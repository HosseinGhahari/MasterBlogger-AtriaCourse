using _01_Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Infrastructure
{
    public class BaseRepository<TKey, TValue> : IRepository<TKey, TValue> where TValue : BaseDomain<TKey>
    {
        private readonly DbContext _context;
        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(TValue entity)
        {
            _context.Add<TValue>(entity);
        }

        public bool Exist(Expression<Func<TValue, bool>> expression)
        {
           return _context.Set<TValue>().Any(expression);
        }

        public List<TValue> GetAll()
        {
            return _context.Set<TValue>().ToList();
        }

        public TValue GetById(TKey id)
        {
            return _context.Find<TValue>(id);
        }
    }
}
