using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Recipee
{
    public class GetAll : PageModel
    {
        private readonly IRecipeService _recipeService;
        private readonly IUserService _userService;

        public GetAll(IRecipeService recipeService, IUserService userService, int userId, List<Recipe> recipes, List<User> users)
        {
            _recipeService = recipeService;
            _userService = userService;
            UserId = userId;
            Recipes = recipes;
            Users = users;
        }

        [BindProperty]
        public int UserId { get; set; }
        public List<Recipe> Recipes { get; set; }
        public List<User> Users { get; set; }

        public void OnGet()
        {
            Recipes = _recipeService.GetAll();
            Users = _userService.GetAll();
        }

    }
}
