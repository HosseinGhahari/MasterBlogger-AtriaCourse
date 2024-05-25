using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> GetArticleCategories();
        void Create(CreateArticleCategory command);
        void Edit(EditArticleCategory command);
        void Remove(long id);
        void Active(long id);
        EditArticleCategory GetEditDetailes(long id);
    }
}
