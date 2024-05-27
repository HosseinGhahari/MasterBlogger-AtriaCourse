using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleAgg.Service
{
    public interface IArticleValidationService
    {
        void TitleExistCheck(string title);
    }
}
