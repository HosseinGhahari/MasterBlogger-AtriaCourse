using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Service;
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
        private readonly IArticleValidationService _articleValidationService;

        public ArticleApplication(IArticleRepository articleRepository , IArticleValidationService articleValidationService )
        {
            _articleRepository = articleRepository;
            _articleValidationService = articleValidationService;
        }


        public void Create(CreateArticle command)
        {
            var article = new Article(command.Title,command.ShortDescription,command.Image
                ,command.Content,command.ArticleCategoryId , _articleValidationService);

            _articleRepository.Create(article);
        }

        public void Edit(EditArticle command)
        {
            var article = _articleRepository.GetById(command.Id);
            article.Edit(command.Title,command.ShortDescription,command.Image,
                command.Content,command.ArticleCategoryId , _articleValidationService);
            //_articleRepository.Save();
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

        public void Remove(long id)
        {
            var article = _articleRepository.GetById(id);
            article.Remove();
            //_articleRepository.Save();
        }

        public void Active(long id)
        {
            var article = _articleRepository.GetById(id);
            article.Active();
            //_articleRepository.Save();
        }

    }
}
