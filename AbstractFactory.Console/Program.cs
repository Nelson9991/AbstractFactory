using AbstractFactory.Core.Factories;

IVehiculoFactory vehiculosFactory = new VehiculosGamaBajaFactory();
var carroGamaBaja = vehiculosFactory.CrearCarro("Chevrolet", "Aveo");
var bicicletaGamaBaja = vehiculosFactory.CrearBicicleta("Cannondale", "XP20");

Console.WriteLine(carroGamaBaja.ObtenerDetalles());
Console.WriteLine(bicicletaGamaBaja.ObtenerDetalles());

Console.WriteLine("\n==========================================================================\n");

IVehiculoFactory vehiculosFactory2 = new VehiculosGamaAltaFactory();
var carroGamaAlta = vehiculosFactory2.CrearCarro("BMW", "Serie 3");
var bicicletaGamaAlta = vehiculosFactory2.CrearBicicleta("Specialized", "Epic");

Console.WriteLine(carroGamaAlta.ObtenerDetalles());
Console.WriteLine(bicicletaGamaAlta.ObtenerDetalles());
