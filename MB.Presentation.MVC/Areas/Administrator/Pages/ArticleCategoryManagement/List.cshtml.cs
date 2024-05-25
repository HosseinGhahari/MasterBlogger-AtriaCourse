using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVC.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleCategoryViewModel> _articles;

        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public ListModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            _articles = _articleCategoryApplication.GetArticleCategories();
        }

        public RedirectToPageResult OnPostRemove(long id)
        {
            _articleCategoryApplication.Remove(id);
            return RedirectToPage("./list");
        }

        public RedirectToPageResult OnPostActive(long id)
        {
            _articleCategoryApplication.Active(id);
            return RedirectToPage("./list");
        }
    }
}
