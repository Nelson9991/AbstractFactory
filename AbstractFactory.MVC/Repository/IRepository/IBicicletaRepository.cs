using AbstractFactory.Core;
using AbstractFactory.MVC.Models;

namespace AbstractFactory.MVC.Repository.IRepository;

public interface IBicicletaRepository
{
    Task<IEnumerable<Bicicleta>> ObtenerBicicletasAsync();
    Task<Bicicleta> ObtenerBicicletaPorIdAsync(int id);
    Task CrearBicicletaAsync(Bicicleta bicicleta);
    Task EditarBicicletaAsync(Bicicleta bicicleta);
    Task EliminarBicicletaAsync(Bicicleta bicicleta);
}
