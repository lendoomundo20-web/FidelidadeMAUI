namespace AdrianaApp.core;

public static class VendaService
{
    public static void RegistrarVenda()
    {
        Console.Clear();
        Console.WriteLine("=== REGISTRAR VENDA ===");

        Cliente? cliente = Util.SelecionarCliente();

        if (cliente == null)
            return;

        Console.WriteLine($"Cliente: {cliente.NomeCompleto}");

        double valorCompra = Util.LerDouble("Valor da compra (€): ");

        bool ganhouTicket =
        SistemaFidelidade.RegistrarVenda(cliente, valorCompra);

        Console.WriteLine();
        Console.WriteLine("Venda registrada com sucesso!");

        if (valorCompra >= 13)
            Console.WriteLine("+1 ponto concedido.");
        else
            Console.WriteLine("Compra inferior a 13 €. Nenhum ponto concedido.");

        if (ganhouTicket)
            Console.WriteLine("🎉 O cliente ganhou 1 ticket!");

        Console.WriteLine($"Pontos: {cliente.Pontos}");
        Console.WriteLine($"Tickets: {cliente.Tickets}");
    }

    public static void ResgatarTicket()
    {
        Console.Clear();

        Console.WriteLine("=== RESGATAR TICKET ===");

        Cliente? cliente = Util.SelecionarCliente();

        if (cliente == null)
            return;

        Console.WriteLine($"\nCliente: {cliente.NomeCompleto}");
        Console.WriteLine($"Tickets disponíveis: {cliente.Tickets}");

        if (cliente.Tickets == 0)
        {
            Console.WriteLine("\nEste cliente não possui tickets.");
            return;
        }

        Console.Write("\nConfirmar resgate? (S/N): ");
        string resposta = (Console.ReadLine() ?? "").Trim().ToUpper();

        if (resposta != "S")
        {
            Console.WriteLine("Resgate cancelado.");
            return;
        }

        SistemaFidelidade.ResgatarTicket(cliente);
    }
}