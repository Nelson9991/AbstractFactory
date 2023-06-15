using AbstractFactory.Core;
using AbstractFactory.MVC.Models;

namespace AbstractFactory.MVC.Repository.IRepository;

public interface ICarroRepository
{
    Task<IEnumerable<Carro>> ObtenerCarrosAsync();
    Task<Carro> ObtenerCarroPorIdAsync(int id);
    Task CrearCarroAsync(Carro carro);
    Task EditarCarroAsync(Carro carro);
    Task EliminarCarroAsync(Carro carro);
}
