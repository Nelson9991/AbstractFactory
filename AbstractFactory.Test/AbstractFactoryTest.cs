using AbstractFactory.Core;
using AbstractFactory.Core.Factories;
using AbstractFactory.Core.Interfaces;

namespace AbstractFactory.Test;

public class AbstractFactoryTestData : AbstractFactoryBaseTestData
{
    public AbstractFactoryTestData()
    {
        AddTestData<VehiculosGamaBajaFactory>("Gama Baja");
        AddTestData<VehiculosGamaMediaFactory>("Gama Media");
        AddTestData<VehiculosGamaAltaFactory>("Gama Alta");
    }
}

public class AbstractFactoryTest
{
    [Theory]
    [ClassData(typeof(AbstractFactoryTestData))]
    public void Debe_crear_un_Carro_de_la_gama_esperada(
        IVehiculoFactory vehiculoFactory,
        string gamaEsperada
    )
    {
        // Act
        ICarro result = vehiculoFactory.CrearCarro("Chevrolet", "Aveo");

        // Assert
        Assert.IsType<Carro>(result);
        Assert.Equal(gamaEsperada, result.Gama);
    }

    [Theory]
    [ClassData(typeof(AbstractFactoryTestData))]
    public void Debe_crear_una_Bici_de_la_gama_esperada(
        IVehiculoFactory vehiculoFactory,
        string gamaEsperada
    )
    {
        // Act
        IBicicleta result = vehiculoFactory.CrearBicicleta("Cannondale", "XP20");
        // Assert
        Assert.IsType<Bicicleta>(result);
        Assert.Equal(gamaEsperada, result.Gama);
    }
}
