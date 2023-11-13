using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Measures
{
    public class Delete : PageModel
    {
        private readonly IService<Measure, int> _measuretService;

        public Delete(IService<Measure, int> measuretService)
        {
            _measuretService = measuretService;
        }

        public IActionResult OnGet(int id)
        {
            _measuretService.Delete(id);
            return Redirect("/Measures/GetAll");
        }
    }
}
