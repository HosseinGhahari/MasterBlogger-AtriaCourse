using MB.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategoryAgg.Serivce
{
    public class ArticleCategoryValidationService : IArticleCategoryValidationService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        public ArticleCategoryValidationService(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }
        public void TitleExistCheck(string title)
        {
            if (_articleCategoryRepository.Exist(x=>x.Title == title))
                throw new ArgumentNullException("Title Already Exists");
        }
    }
}
