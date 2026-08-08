using AdrianaApp.core;
namespace AdrianaApp.core;

public static class ClienteService
{
    public static Cliente CadastrarCliente(string nome, string sobrenome)
    {
        Cliente cliente = new Cliente
        {
            Id = Banco.GerarNovoId(),
            Nome = nome,
            Sobrenome = sobrenome
        };

        Banco.AdicionarCliente(cliente);

        return cliente;
    }
    public static void ConsultarCliente()
    {
        Console.Clear();

        Console.WriteLine("=========================");
        Console.WriteLine(" CONSULTAR CLIENTE");
        Console.WriteLine("=========================");
        Console.WriteLine("1 - Buscar por ID");
        Console.WriteLine("2 - Buscar por Nome");
        Console.WriteLine("3 - Buscar por QR Code");
        Console.WriteLine("0 - Voltar");

        int opcao = Util.LerInteiro("\nEscolha uma opção: ");

        switch (opcao)
        {
            case 1:

                int id = Util.LerInteiro("\nID: ");

                Cliente? cliente = SistemaFidelidade.BuscarClientePorId(id);

                if (cliente == null)
                {
                    Console.WriteLine("\nCliente não encontrado.");
                    return;
                }

                MostrarCliente(cliente);
                break;

            case 2:

                Console.Write("\nNome: ");
                string busca = Console.ReadLine() ?? "";

                List<Cliente> encontrados = SistemaFidelidade.BuscarClientePorNome(busca);

                if (encontrados.Count == 0)
                {
                    Console.WriteLine("\nNenhum cliente encontrado.");
                    return;
                }

                foreach (Cliente clienteEncontrado in encontrados)
                {
                    MostrarCliente(clienteEncontrado);
                    Console.WriteLine("----------------------------");
                }

                break;

            case 3:
                Console.WriteLine("\nFuncionalidade em desenvolvimento.");
                break;

            case 0:
                return;

            default:
                Console.WriteLine("\nOpção inválida.");
                break;
        }
    }

    public static void ListarClientes()
    {
        Console.Clear();

        if (Banco.ListarClientes().Count == 0)
        {
            Console.WriteLine("Nenhum cliente cadastrado.");
            return;
        }

        foreach (Cliente cliente in Banco.ListarClientes())
        {
            MostrarCliente(cliente);
            Console.WriteLine("----------------------------");
        }
    }

    private static void MostrarCliente(Cliente cliente)
    {
        Console.WriteLine();
        Console.WriteLine($"Nome: {cliente.NomeCompleto}");
        Console.WriteLine($"ID: {cliente.Id}");
        Console.WriteLine($"Pontos: {cliente.Pontos}");
        Console.WriteLine($"Tickets: {cliente.Tickets}");
    }
}