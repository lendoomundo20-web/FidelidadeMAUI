namespace AdrianaApp.core;

public class Compra
{
    public int Id { get; init; }

    public int ClienteId { get; set; }

    public double ValorCompra { get; set; }

    public DateTime DataCompra { get; } = DateTime.Now;
}



