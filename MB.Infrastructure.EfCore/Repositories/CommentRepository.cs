using MB.Domain.CommentAgg;
using MB.Infrastructure.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure.EfCore.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MasterBloggerContext _context;
        public CommentRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public void Add(Comment entity)
        {
            _context.Add(entity);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
