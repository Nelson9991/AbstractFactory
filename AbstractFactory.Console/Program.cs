using AbstractFactory.Core.Factories;

var vehiculosGamaBajaFactory = new VehiculosGamaBajaFactory();
var carroGamaBaja = vehiculosGamaBajaFactory.CrearCarro("Chevrolet", "Aveo");
var bicicletaGamaBaja = vehiculosGamaBajaFactory.CrearBicicleta("Cannondale", "XP20");

Console.WriteLine(carroGamaBaja.ObtenerDetalles());
Console.WriteLine(bicicletaGamaBaja.ObtenerDetalles());

Console.WriteLine("\n==========================================================================\n");

var vehiculosGamaAltaFactory = new VehiculosGamaAltaFactory();
var carroGamaAlta = vehiculosGamaAltaFactory.CrearCarro("BMW", "Serie 3");
var bicicletaGamaAlta = vehiculosGamaAltaFactory.CrearBicicleta("Specialized", "Epic");

Console.WriteLine(carroGamaAlta.ObtenerDetalles());
Console.WriteLine(bicicletaGamaAlta.ObtenerDetalles());