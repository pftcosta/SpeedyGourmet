using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Posts
{
    public class GetByIdModel : PageModel
    {
        private readonly IIIngredientLineService<Post, int> _iLPostService;

        public GetByIdModel(IIIngredientLineService<Post, int> iLPostService)
        {
            _iLPostService = iLPostService;
        }

        public Post post = new();

        public void OnGet(int id)
        {
            post = _iLPostService.GetById(id);
        }
    }
}
