using AbstractFactory.Core;
using AbstractFactory.Core.Factories;
using AbstractFactory.MVC.Models;
using AbstractFactory.MVC.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace AbstractFactory.MVC.Repository;

public class CarroRepository : ICarroRepository
{
    private readonly AppDbContext context;

    public CarroRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task CrearCarroAsync(Carro carro)
    {
        carro.Gama = carro.Gama.Trim().ToLower();
        switch (carro.Gama)
        {
            case "baja":
                var vehiculoGamaBajaFactory = new VehiculosGamaBajaFactory();
                var carroGamaBaja = vehiculoGamaBajaFactory.CrearCarro(carro.Marca, carro.Modelo);
                context.Carros.Add(carroGamaBaja);
                break;
            case "media":
                var vehiculoGamaMediaFactory = new VehiculosGamaMediaFactory();
                var carroGamaMedia = vehiculoGamaMediaFactory.CrearCarro(carro.Marca, carro.Modelo);
                context.Carros.Add(carroGamaMedia);
                break;
            case "alta":
                var vehiculoGamaAltaFactory = new VehiculosGamaAltaFactory();
                var carroGamaAlta = vehiculoGamaAltaFactory.CrearCarro(carro.Marca, carro.Modelo);
                context.Carros.Add(carroGamaAlta);
                break;
            default:
                throw new Exception("Gama no valida");
        }
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
