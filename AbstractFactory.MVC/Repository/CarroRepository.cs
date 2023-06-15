using AbstractFactory.Core;
using AbstractFactory.Core.Factories;
using AbstractFactory.MVC.Models;
using AbstractFactory.MVC.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace AbstractFactory.MVC.Repository;

public class CarroRepository : ICarroRepository
{
    private readonly AppDbContext context;
    private readonly IVehiculoFactory factory;

    public CarroRepository(AppDbContext context, IVehiculoFactory factory)
    {
        this.context = context;
        this.factory = factory;
    }

    public async Task CrearCarroAsync(Carro carroEntrante)
    {
        var carro = factory.CrearCarro(carroEntrante.Marca, carroEntrante.Modelo);
        context.Carros.Add(carro);
        await context.SaveChangesAsync();
    }

    public async Task EditarCarroAsync(Carro carro)
    {
        context.Carros.Update(carro);
        await context.SaveChangesAsync();
    }

    public async Task EliminarCarroAsync(Carro carro)
    {
        context.Carros.Remove(carro);
        await context.SaveChangesAsync();
    }

    public async Task<Carro> ObtenerCarroPorIdAsync(int id)
    {
        return await context.Carros.FindAsync(id);
    }

    public async Task<IEnumerable<Carro>> ObtenerCarrosAsync()
    {
        return await context.Carros.ToListAsync();
    }
}
