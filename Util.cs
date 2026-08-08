namespace AdrianaApp.core;

public static class Util
{
    public static int LerInteiro(string mensagem)
    {
        int valor;

        while (true)
        {
            Console.Write(mensagem);

            if (int.TryParse(Console.ReadLine(), out valor))
                return valor;

            Console.WriteLine("Digite um número inteiro válido.");
        }
    }

    public static double LerDouble(string mensagem)
    {
        double valor;

        while (true)
        {
            Console.Write(mensagem);

            if (double.TryParse(Console.ReadLine(), out valor))
                return valor;

            Console.WriteLine("Digite um valor numérico válido.");
        }
    }

    public static Cliente? SelecionarCliente()
    {
        Console.Write("Digite o ID ou o nome do cliente: ");

        string entrada = (Console.ReadLine() ?? "").Trim();

        if (int.TryParse(entrada, out int id))
        {
            return Banco.BuscarPorId(id);
        }

        List<Cliente> encontrados = Banco.BuscarPorNome(entrada);

        if (encontrados.Count == 0)
        {
            Console.WriteLine("Cliente não encontrado.");
            return null;
        }

        if (encontrados.Count == 1)
        {
            return encontrados[0];
        }

        Console.WriteLine("\nForam encontrados vários clientes:\n");

        foreach (Cliente cliente in encontrados)
        {
            Console.WriteLine($"{cliente.Id} - {cliente.NomeCompleto}");
        }

        int idEscolhido = LerInteiro("\nDigite o ID do cliente: ");

        return Banco.BuscarPorId(idEscolhido);
    }
}