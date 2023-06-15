namespace AbstractFactory.Core.Factories;

public class VehiculosGamaBajaFactory : IVehiculoFactory
{
    public Bicicleta CrearBicicleta(string marca, string modelo)
    {
        return new Bicicleta(marca, modelo, "Gama Baja");
    }

    public Carro CrearCarro(string marca, string modelo)
    {
        return new Carro(marca, modelo, "Gama Baja");
    }
}
