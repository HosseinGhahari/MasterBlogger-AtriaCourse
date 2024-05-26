using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.Presentation.MVC.Areas.Administrator.Pages.ArticleManagement
{
    public class EditModel : PageModel
    {
        [BindProperty] public EditArticle Article { get; set; }
        public List<SelectListItem> ArticleCategories { get; set; }

        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articlecategoryApplication;
        public EditModel(IArticleApplication articleApplication , IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articlecategoryApplication = articleCategoryApplication;
        }

        public void OnGet(long id)
        {
            Article = _articleApplication.GetEditDetailes(id);
            ArticleCategories = _articlecategoryApplication
                .GetArticleCategories()
                .Select(x => new SelectListItem ( x.Title , x.Id.ToString())).ToList();
        }

        public RedirectToPageResult OnPost()
        {
            _articleApplication.Edit(Article);
            return RedirectToPage("./List");
        }
    }
}
