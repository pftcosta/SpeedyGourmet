using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedyGourmet.Model;
using SpeedyGourmet.Service;

namespace SpeedyGourmet.WebApp.Pages.Measures
{
    public class GetByIdModel : PageModel
    {
        private readonly IService<Measure, int> _measureService;

        public GetByIdModel(IService<Measure, int> measureService)
        {
            _measureService = measureService;
        }

        public Measure Measure { get; private set; }

        public void OnGet(int measureId)
        {
            Measure = _measureService.GetById(measureId);
        }
    }
}
