using HeTest.DatabaseContexts;
using HeTest.Models;
using Microsoft.EntityFrameworkCore;

namespace HeTest.Repositories
{
    public class CarsRepository
    {
        private readonly DataContext _context;

        public CarsRepository(DataContext context)
        {
            _context = context;
        }

        public Car Create(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();

            return car;
        }

        public Car Read(Car car)
        {
            return _context.Cars
                .Where(x =>
                (!string.IsNullOrEmpty(car.Make) && x.Make == car.Make) ||
                (!string.IsNullOrEmpty(car.Model) && x.Model == car.Model) ||
                (car.Year > 0 && x.Year == car.Year) ||
                (car.Doors > 0 && x.Doors == car.Doors) ||
                (!string.IsNullOrEmpty(car.Color) && x.Color == car.Color) ||
                (car.Price > 0 && x.Price == car.Price)
                )
                .FirstOrDefault();
        }

        public void Delete(int Id)
        {
            var car = _context.Cars.Single(x => x.Id.Equals(Id));
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }

        public void Update(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
