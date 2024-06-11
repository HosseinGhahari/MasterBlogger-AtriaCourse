using MB.Domain.CommentAgg;
using MB.Infrastructure.EfCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBloggerContext _context;
        public ArticleQuery(MasterBloggerContext context)
        {
            _context = context;
        }

        public List<ArticleQueryView> GetArticles()
        {
            return _context.Articles
                .Include(x => x.ArticleCategory)
                .Include(x => x.Comments)
                .Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                Image = x.Image,
                ShortDescription = x.ShortDescription,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture), 
                CommentCount = x.Comments.Count(x => x.Status == Statuses.Confirmed),

            }).ToList();
        }

        public ArticleQueryView GetArticleDetaile(long id)
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                Image = x.Image,
                ShortDescription = x.ShortDescription,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Content = x.Content,
                CommentCount = x.Comments.Count(x => x.Status == Statuses.Confirmed),
                Comments = MapComment(x.Comments.Where(z => z.Status == Statuses.Confirmed))

            }).FirstOrDefault(x => x.Id == id);
        }

        private static List<CommentQueryView> MapComment(IEnumerable<Comment> comments)
        {
            return comments.Select(x => new CommentQueryView
            {
                Name = x.Name,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Message = x.Message,

            }).ToList();
        }
    }
}
