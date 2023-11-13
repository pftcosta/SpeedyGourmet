using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Posts
{
    public class DeleteAllByRecipeModel : PageModel
    {
        private readonly IIIngredientLineService<Post, int> _iLPostService;

        public DeleteAllByRecipeModel(IIIngredientLineService<Post, int> iLPostService)
        {
            _iLPostService = iLPostService;
        }

        public IActionResult OnGet(int id)
        {
            _iLPostService.DeleteAllByRecipeId(id);
            return Redirect("/Posts/GetAllByRecipe");
        }
    }
}
