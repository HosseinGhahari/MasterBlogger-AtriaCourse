using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EfCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public Comment GetById(long id)
        {
            return _context.Comments.FirstOrDefault(x => x.Id == id);
        }

        public List<CommentViewModel> GetCommentsList()
        {
            return _context.Comments.Include(x => x.Article).Select(x => new CommentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Message = x.Message,
                status = x.Status,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Article = x.Article.Title

            }).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
