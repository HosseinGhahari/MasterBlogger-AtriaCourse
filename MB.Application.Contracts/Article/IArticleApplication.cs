using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetArticles();
        void Create(CreateArticle command);
        void Edit(EditArticle command);
        EditArticle GetEditDetailes(long id);
    }
}
