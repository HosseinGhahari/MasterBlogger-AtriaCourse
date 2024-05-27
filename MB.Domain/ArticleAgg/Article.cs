using MB.Domain.ArticleAgg.Service;
using MB.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleAgg
{
    public class Article
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Image { get; private set; }
        public string Content { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }
        public long ArticleCategoryId { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }

        protected Article()
        {
            
        }

        public static void Validate(string title , long articleCategoryId)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("title is null");

            if (articleCategoryId == 0)
                throw new ArgumentNullException("id is zero");
        }

        public Article(string title, string shortDescription, string image, string content, long articleCategoryId , IArticleValidationService articleValidation)
        {
            Validate(title , articleCategoryId);
            articleValidation.TitleExistCheck(title);

            Title = title;
            ShortDescription = shortDescription;
            Image = image;
            Content = content;
            IsDeleted = false;
            CreationDate = DateTime.Now;
            ArticleCategoryId = articleCategoryId;
        }

        public void Edit(string title, string shortDescription, string image, string content, long articleCategoryId, IArticleValidationService articleValidation)
        {
            Validate(title, articleCategoryId);

            Title = title;
            ShortDescription = shortDescription;
            Image = image;
            Content = content;
            ArticleCategoryId = articleCategoryId;
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
