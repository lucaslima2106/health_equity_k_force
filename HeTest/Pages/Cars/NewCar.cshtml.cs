using HeTest.Models;
using HeTest.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeTest.Pages.Cars
{
    [BindProperties(SupportsGet = true)]
    public class NewCarModel : PageModel
    {
        private CarsRepository _repository;

        public NewCarModel(CarsRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public Car? car { get; set; }

        public void OnPost()
        {
            if (car != null)
                car = _repository.Create(car);
        }
    }
}
