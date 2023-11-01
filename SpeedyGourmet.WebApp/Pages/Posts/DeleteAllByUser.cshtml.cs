using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Posts
{
    public class DeleteAllByUserModel : PageModel
    {
        private readonly IILPostService<Post, int> _iLPostService;

        public DeleteAllByUserModel(IILPostService<Post, int> iLPostService)
        {
            _iLPostService = iLPostService;
        }

        public IActionResult OnGet(int id)
        {
            _iLPostService.DeleteAllByUserId(id);
            return Redirect("/Posts/GetAllByUser");
        }
    }
}
