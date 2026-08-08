namespace AdrianaApp.core;
public class Cliente
{
    public int Id { get; init; }

    public required string Nome { get; set; }

    public required string Sobrenome { get; set; }

    public string NomeCompleto => $"{Nome} {Sobrenome}";

    public int Pontos { get; private set; }

    public int Tickets { get; private set; }

    public bool RegistrarCompra(double valorCompra)
    {
        if (valorCompra < 13)
        {
            return false;
        }

        Pontos++;

        if (Pontos >= 10)
        {
            Pontos -= 10;
            Tickets++;

            return true;
        }

        return false;
    }

    public bool ResgatarTicket()
    {
        if (Tickets == 0)
        {
            return false;
        }

        Tickets--;
        return true;
    }
}


