namespace AbstractFactory.Core;

public class Carro
{
    public Carro(string marca, string modelo, string gama)
    {
        Marca = marca;
        Modelo = modelo;
        Gama = gama;
    }

    public Carro() { }

    public int Id { get; set; }
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public string Gama { get; set; } = string.Empty;

    public string ObtenerDetalles()
    {
        return $"Carro {Marca} - Modelo: {Modelo} - {Gama}";
    }
}
