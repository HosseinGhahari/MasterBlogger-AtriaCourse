using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void Create(CreateArticle command)
        {
            var article = new Article(command.Title,command.ShortDescription,command.Image
                ,command.Content,command.ArticleCategoryId);

            _articleRepository.Create(article);
        }

        public void Edit(EditArticle command)
        {
            var article = _articleRepository.GetById(command.Id);
            article.Edit(command.Title,command.ShortDescription,command.Image,command.Content,command.ArticleCategoryId);
            _articleRepository.Save();
        }

        public List<ArticleViewModel> GetArticles()
        {
            return _articleRepository.GetArticles();
        }

        public EditArticle GetEditDetailes(long id)
        {
            var article = _articleRepository.GetById(id);
            return new EditArticle
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                ArticleCategoryId = article.ArticleCategoryId,
                Image = article.Image,
                ShortDescription = article.ShortDescription,
            };
        }
    }
}
