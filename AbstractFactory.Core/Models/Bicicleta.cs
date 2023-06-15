namespace AbstractFactory.Core;

public class Bicicleta
{
    public Bicicleta(string marca, string modelo, string gama)
    {
        Marca = marca;
        Modelo = modelo;
        Gama = gama;
    }

    public Bicicleta() { }

    public int Id { get; set; }
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public string Gama { get; set; } = string.Empty;

    public string ObtenerDetalles()
    {
        return $"Bicicleta {Marca} - Modelo: {Modelo} - {Gama}";
    }
}
