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
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository , IArticleCategoryValidationService articleCategoryValidationService )
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidationService = articleCategoryValidationService;
        }

        public void Create(CreateArticleCategory command)
        {
            var articlecategory = new ArticleCategory(command.Title,_articleCategoryValidationService);
            _articleCategoryRepository.Create(articlecategory);     
        }

        public void Edit(EditArticleCategory command)
        {
            var article = _articleCategoryRepository.GetById(command.Id);
            article.Edit(command.Title);
           //_articleCategoryRepository.Save();
        }

        public void Active(long id)
        {
            var article = _articleCategoryRepository.GetById(id);
            article.Active();
            //_articleCategoryRepository.Save();
        }
        public void Remove(long id)
        {
            var article = _articleCategoryRepository.GetById(id);
            article.Remove();
            //_articleCategoryRepository.Save();
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
 