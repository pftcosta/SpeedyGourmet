using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Measures
{
    public class GetByIdModel : PageModel
    {
        private readonly IService<Measure, int> _measureService;

        public GetByIdModel(IService<Measure, int> measureService, Measure measure)
        {
            _measureService = measureService;
            Measure = measure;
        }

        public Measure Measure { get; set; }

        public void OnGet(int id)
        {
            Measure = _measureService.GetById(id);
        }
    }
}
