using _01_Framework;
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
        private readonly IUnitOfWork _unitOfWork;
        public ArticleApplication(IArticleRepository articleRepository 
            , IArticleValidationService articleValidationService
            , IUnitOfWork unitOfWork)
        {
            _articleRepository = articleRepository;
            _articleValidationService = articleValidationService;
            _unitOfWork = unitOfWork;
        }


        public void Create(CreateArticle command)
        {
            _unitOfWork.BeginTran();
            var article = new Article(command.Title,command.ShortDescription,command.Image
                ,command.Content,command.ArticleCategoryId , _articleValidationService);

            _articleRepository.Create(article);
            _unitOfWork.CommitTran();
        }

        public void Edit(EditArticle command)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.GetById(command.Id);
            article.Edit(command.Title,command.ShortDescription,command.Image,
                command.Content,command.ArticleCategoryId , _articleValidationService);
            _unitOfWork.CommitTran();
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
            _unitOfWork.BeginTran();
            var article = _articleRepository.GetById(id);
            article.Remove();
            _unitOfWork.CommitTran();
        }

        public void Active(long id)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.GetById(id);
            article.Active();
            _unitOfWork.CommitTran();
        }

    }
}
