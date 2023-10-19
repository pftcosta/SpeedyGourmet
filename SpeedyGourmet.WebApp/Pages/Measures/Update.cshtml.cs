using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Measures
{
    public class UpdateModel : PageModel
    {
        private readonly IService<Measure, int> _measureService;

        public UpdateModel(IService<Measure, int> measureService)
        {
            _measureService = measureService;
        }

        public Measure measure = new();

        public void OnGet(int id)
        {
            measure = _measureService.GetById(id);
        }

        public IActionResult OnPost()
        {
            measure.Id = Convert.ToInt32(Request.Form["id"]);
            measure.Name = Convert.ToString(Request.Form["name"]);
            _measureService.Update(measure);
            return Redirect("/Measures/GetAll");
        }
    }
}
