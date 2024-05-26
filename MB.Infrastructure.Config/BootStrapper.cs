using MB.Application;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.Serivce;
using MB.Infrastructure.EfCore.Context;
using MB.Infrastructure.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Infrastructure.Config
{
    // here we created the MB.Infrastructure.Config layer and bootstrapper class
    // to remove the Dependency from presentation to inner layers that is not good 
    // for design and we define them here in a another layer.and we use this class
    // in our program.cs file in Presentation layer
    public class BootStrapper
    {
        public static void Config(IServiceCollection service, string connection)
        {
            service.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            service.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            service.AddTransient<IArticleCategoryValidationService, ArticleCategoryValidationService>();

            service.AddTransient<IArticleApplication, ArticleApplication>();
            service.AddTransient<IArticleRepository, ArticleRepository>();


            service.AddDbContext<MasterBloggerContext>(option => option.UseSqlServer(connection));
        }

    }
}