namespace AbstractFactory.Core.Factories;

public class VehiculosGamaAltaFactory : IVehiculoFactory
{
    public Bicicleta CrearBicicleta(string marca, string modelo)
    {
        return new Bicicleta(marca, modelo, "Gama Alta");
    }

    public Carro CrearCarro(string marca, string modelo)
    {
        return new Carro(marca, modelo, "Gama Alta");
    }
}
