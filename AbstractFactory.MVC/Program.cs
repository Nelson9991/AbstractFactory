using AbstractFactory.Core.Factories;
using AbstractFactory.MVC;
using AbstractFactory.MVC.Repository;
using AbstractFactory.MVC.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//.Services.AddTransient<IVehiculoFactory, VehiculosGamaAltaFactory>();
//builder.Services.AddTransient<IVehiculoFactory, VehiculosGamaMediaFactory>();
builder.Services.AddTransient<IVehiculoFactory, VehiculosGamaBajaFactory>();
builder.Services.AddScoped<ICarroRepository, CarroRepository>();
builder.Services.AddScoped<IBicicletaRepository, BicicletaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
