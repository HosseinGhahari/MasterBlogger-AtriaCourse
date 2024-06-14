using _01_Framework;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Serivce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidationService _articleCategoryValidationService;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository 
            , IArticleCategoryValidationService articleCategoryValidationService
            , IUnitOfWork unitOfWork)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidationService = articleCategoryValidationService;
            _unitOfWork = unitOfWork;
        }

        public void Create(CreateArticleCategory command)
        {
            _unitOfWork.BeginTran();
            var articlecategory = new ArticleCategory(command.Title,_articleCategoryValidationService);
            _articleCategoryRepository.Create(articlecategory);   
            _unitOfWork.CommitTran();
        }

        public void Edit(EditArticleCategory command)
        {
            _unitOfWork.BeginTran();
            var article = _articleCategoryRepository.GetById(command.Id);
            article.Edit(command.Title);
            _unitOfWork.CommitTran();
        }

        public void Active(long id)
        {
            _unitOfWork.BeginTran();
            var article = _articleCategoryRepository.GetById(id);
            article.Active();
            _unitOfWork.CommitTran();
        }
        public void Remove(long id)
        {
            _unitOfWork.BeginTran();
            var article = _articleCategoryRepository.GetById(id);
            article.Remove();
            _unitOfWork.CommitTran();
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            var articleCategories = _articleCategoryRepository.GetAll();

            return articleCategories.Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                Title = x.Title,
                IsDeleted = x.IsDeleted,
                CreationDate = x.CreationDate.ToString()

            }).OrderByDescending(x => x.Id).ToList();
        }

        public EditArticleCategory GetEditDetailes(long id)
        {
            var article = _articleCategoryRepository.GetById(id);
            return new EditArticleCategory
            {
                Id = article.Id,
                Title = article.Title,
            };
        }


    }
}
 