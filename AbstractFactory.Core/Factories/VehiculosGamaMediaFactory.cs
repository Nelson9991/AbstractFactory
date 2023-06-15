namespace AbstractFactory.Core.Factories;

public class VehiculosGamaMediaFactory : IVehiculoFactory
{
    public Bicicleta CrearBicicleta(string marca, string modelo)
    {
        return new Bicicleta(marca, modelo, "Gama Media");
    }

    public Carro CrearCarro(string marca, string modelo)
    {
        return new Carro(marca, modelo, "Gama Media");
    }
}
