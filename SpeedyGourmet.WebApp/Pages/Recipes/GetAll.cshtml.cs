using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Recipes
{
    public class GetAll : PageModel
    {
        private readonly IRecipeService _recipeService;
        private readonly IUserService _userService;
        private readonly IService<Category, int> _categoryService;

        public GetAll(IRecipeService recipeService, IUserService userService, IService<Category, int> categoryService)
        {
            _recipeService = recipeService;
            _userService = userService;
            _categoryService = categoryService;
        }

        public List<Recipe> Recipes { get; private set; }
        public User User { get; private set; }

        public void OnGet()
        {
            GetUser();
            Recipes = _recipeService.GetAll();
        }

        public IActionResult OnPost()
        {
            if (int.TryParse(Request.Form["id"], out int recipeId))
            {
                Recipe recipe = _recipeService.GetById(recipeId);
                bool? newIsApproved = null;
                if (bool.TryParse(Request.Form["is_approved"], out bool isApprovedValue))
                {
                    newIsApproved = isApprovedValue;
                }

                if (newIsApproved.HasValue)
                {
                    recipe.IsApproved = newIsApproved.Value;
                }

                _recipeService.Update(recipe);
            }
                return Redirect("/Recipes/GetAll");
        }

        private void GetUser()
        {
            string user = HttpContext.Session.GetString("user");
            if (user != null)
            {
                User = JsonSerializer.Deserialize<User>(user);
            }
        }
    }
}
