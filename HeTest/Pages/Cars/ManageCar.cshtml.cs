using HeTest.Models;
using HeTest.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeTest.Pages.Cars
{
    public enum Operation
    {
        Read,
        Update,
        Delete
    }

    [BindProperties(SupportsGet = true)]
    public class ManageCarModel : PageModel
    {
        private CarsRepository _repository;

        public ManageCarModel(CarsRepository repository)
        {
            operation = Operation.Read;
            _repository = repository;
        }

        [BindProperty]
        public Car car { get; set; }
        public string message { get; set; }
        public Operation operation { get; set; }

        public IActionResult OnPostFind()
        {
            operation = Operation.Read;

            car = _repository.Read(car);

            return Page();
        }

        public IActionResult OnPostUpdate(Car car)
        {
            operation = Operation.Update;

            _repository.Update(car);

            return Page();
        }

        public IActionResult OnPostDelete(int Id)
        {
            operation = Operation.Delete;

            _repository.Delete(Id);

            return Page();
        }
    }
}
