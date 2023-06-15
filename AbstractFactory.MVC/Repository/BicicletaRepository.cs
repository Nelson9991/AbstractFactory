using AbstractFactory.Core;
using AbstractFactory.Core.Factories;
using AbstractFactory.MVC.Models;
using AbstractFactory.MVC.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace AbstractFactory.MVC.Repository;

public class BicicletaRepository : IBicicletaRepository
{
    private readonly AppDbContext context;

    public BicicletaRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task CrearBicicletaAsync(Bicicleta bicicleta)
    {
        bicicleta.Gama = bicicleta.Gama.Trim().ToLower();
        switch (bicicleta.Gama)
        {
            case "baja":
                var vehiculoGamaBajaFactory = new VehiculosGamaBajaFactory();
                var bicicletaGamaBaja = vehiculoGamaBajaFactory.CrearBicicleta(
                    bicicleta.Marca,
                    bicicleta.Modelo
                );
                context.Bicicletas.Add(bicicletaGamaBaja);
                break;
            case "media":
                var vehiculoGamaMediaFactory = new VehiculosGamaMediaFactory();
                var bicicletaGamaMedia = vehiculoGamaMediaFactory.CrearBicicleta(
                    bicicleta.Marca,
                    bicicleta.Modelo
                );
                context.Bicicletas.Add(bicicletaGamaMedia);
                break;
            case "alta":
                var vehiculoGamaAltaFactory = new VehiculosGamaAltaFactory();
                var bicicletaGamaAlta = vehiculoGamaAltaFactory.CrearBicicleta(
                    bicicleta.Marca,
                    bicicleta.Modelo
                );
                context.Bicicletas.Add(bicicletaGamaAlta);
                break;
            default:
                break;
        }
        await context.SaveChangesAsync();
    }

    public async Task EditarBicicletaAsync(Bicicleta bicicleta)
    {
        context.Bicicletas.Update(bicicleta);
        await context.SaveChangesAsync();
    }

    public async Task EliminarBicicletaAsync(Bicicleta bicicleta)
    {
        context.Bicicletas.Remove(bicicleta);
        await context.SaveChangesAsync();
    }

    public async Task<Bicicleta> ObtenerBicicletaPorIdAsync(int id)
    {
        return await context.Bicicletas.FindAsync(id);
    }

    public async Task<IEnumerable<Bicicleta>> ObtenerBicicletasAsync()
    {
        return await context.Bicicletas.ToListAsync();
    }
}
