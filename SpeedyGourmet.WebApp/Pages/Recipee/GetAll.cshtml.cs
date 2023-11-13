using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class GetAllModel : PageModel
    {
        private readonly IRecipeService<Recipe, int> _recipeService;
        private readonly IService<User, int> _userService;

        [BindProperty]
        public int UserId { get; set; }

        public List<Recipe> Recipes { get; set; }
        public List<User> Users { get; set; }

        public GetAllModel(IRecipeService<Recipe, int> recipeService, IService<User, int> userService)
        {
            _recipeService = recipeService;
            _userService = userService;
        }

        public void OnGet()
        {
            Recipes = _recipeService.GetAll();
            Users = _userService.GetAll();
        }

    }
}
