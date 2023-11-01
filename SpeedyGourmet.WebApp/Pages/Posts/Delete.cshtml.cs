using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Posts
{
    public class DeleteModel : PageModel
    {
        private readonly IILPostService<Post, int> _iLPostService;

        public DeleteModel(IILPostService<Post, int> iLPostService)
        {
            _iLPostService = iLPostService;
        }

        public IActionResult OnGet(int id)
        {
            _iLPostService.Delete(id);
            return Redirect("/Posts/GetAll");
        }
    }
}
