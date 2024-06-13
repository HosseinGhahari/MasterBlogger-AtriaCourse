using _01_Framework.Domain;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Serivce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory : BaseDomain<long>
    {
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public ICollection<Article> Articles { get; set; }

        protected ArticleCategory()
        {
            
        }
        public void TitleNullCheckValidation(string title)
        {
            if(string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("title is null");
        } 
        public ArticleCategory(string title , IArticleCategoryValidationService articleCategoryValidationService)
        {
            TitleNullCheckValidation(title);
            articleCategoryValidationService.TitleExistCheck(title);

            Title = title;
            IsDeleted = false;
            Articles = new List<Article>();
        }

        public void Edit(string title)
        {
            TitleNullCheckValidation(title);

            Title = title;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Active()
        {
            IsDeleted = false;
        }
    }
}
