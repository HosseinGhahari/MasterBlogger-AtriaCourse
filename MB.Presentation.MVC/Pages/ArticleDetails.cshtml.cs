using MB.Application.Contracts.Comment;
using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVC.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleQueryView Article { get; set; }

        private readonly IArticleQuery _articleQuery;
        private readonly ICommentApplication _commentApplication;
        public ArticleDetailsModel(IArticleQuery articleQuery , ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(long id)
        {
            Article = _articleQuery.GetArticleDetaile(id);
        }

        public RedirectToPageResult OnPost(AddComment command)
        {
            _commentApplication.Add(command);
            return RedirectToPage("./ArticleDetails" , new {id = command.ArticleId});
        }
    }
}
