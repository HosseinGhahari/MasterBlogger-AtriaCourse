using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleAgg.Service
{
    public class ArticleValidationService : IArticleValidationService
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleValidationService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void TitleExistCheck(string title)
        {
            if(_articleRepository.Exist(x =>x.Title == title)) 
                throw new DuplicateWaitObjectException();
        }
    }
}
