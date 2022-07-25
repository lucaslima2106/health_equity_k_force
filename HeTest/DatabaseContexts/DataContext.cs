using HeTest.Models;
using Microsoft.EntityFrameworkCore;

namespace HeTest.DatabaseContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("cars").HasKey(x => x.Id).HasName("pk_cars");
            modelBuilder.Entity<Car>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<Car>().Property(x => x.Make).HasMaxLength(100).HasColumnType("varchar(100)").HasColumnName("make");
            modelBuilder.Entity<Car>().Property(x => x.Model).HasMaxLength(100).HasColumnType("varchar(100)").HasColumnName("model");
            modelBuilder.Entity<Car>().Property(x => x.Year).HasColumnName("year");
            modelBuilder.Entity<Car>().Property(x => x.Doors).HasColumnName("doors");
            modelBuilder.Entity<Car>().Property(x => x.Color).HasColumnName("color");
            modelBuilder.Entity<Car>().Property(x => x.Price).HasColumnName("price");

            modelBuilder.Entity<Car>().HasData(
                new Car() { Id = 1, Make = "Audi", Model = "R8", Year = 2018, Doors = 2, Color = "Red", Price = 79995 },
                new Car() { Id = 2, Make = "Tesla", Model = "3", Year = 2020, Doors = 4, Color = "Black", Price = 54995 },
                new Car() { Id = 3, Make = "Porsche", Model = "911", Year = 2021, Doors = 2, Color = "White", Price = 155000 },
                new Car() { Id = 4, Make = "Mercedes-Benz", Model = "GLE 63S", Year = 2018, Doors = 5, Color = "Blue", Price = 83995 },
                new Car() { Id = 5, Make = "BMW", Model = "R8X6 M", Year = 2020, Doors = 5, Color = "Silver", Price = 62995 }
                );
        }
    }
}
