using AbstractFactory.Core;
using Microsoft.EntityFrameworkCore;

namespace AbstractFactory.MVC;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options)
        : base(options) { }

    public DbSet<Carro> Carros { get; set; }
    public DbSet<Bicicleta> Bicicletas { get; set; }
}
