using _01_Framework.Infrastructure;
using MB.Domain.ArticleCategoryAgg;
using MB.Infrastructure.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure.EfCore.Repositories
{
    public class ArticleCategoryRepository : BaseRepository<long,ArticleCategory> , IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;
        public ArticleCategoryRepository(MasterBloggerContext context) : base(context)
        {
            _context = context;
        }

    }
}
