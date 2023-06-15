namespace AbstractFactory.Core.Factories;

public interface IVehiculoFactory
{
    Carro CrearCarro(string marca, string modelo);
    Bicicleta CrearBicicleta(string marca, string modelo);
}
