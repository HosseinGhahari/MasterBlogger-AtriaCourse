﻿using _01_Framework.Infrastructure;
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
    
    public class ArticleRepository : BaseRepository<long,Article> , IArticleRepository
    {
        private readonly MasterBloggerContext _context;
        public ArticleRepository(MasterBloggerContext context) : base(context) 
        {
            _context = context;
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
    }
}
