using HeTest.DatabaseContexts;
using HeTest.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<CarsRepository, CarsRepository>();
builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("Database"));

builder.Services.AddCors(options => options.AddPolicy("AllowSpecificOrigin",
  abuilder => abuilder
  .AllowAnyOrigin()
  .AllowAnyMethod()
  .AllowAnyHeader()
  ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
