using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
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
    
    public class ArticleRepository : IArticleRepository
    {
        private readonly MasterBloggerContext _context;
        public ArticleRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public void Create(Article entity)
        {
            _context.Articles.Add(entity);
            Save();
        }

        public List<ArticleViewModel> GetArticles()
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                IsDeleted = x.IsDeleted,
            }).ToList();
        }

        public Article GetById(long id)
        {
            return _context.Articles.FirstOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
