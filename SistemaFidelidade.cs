namespace AdrianaApp.core;

public static class SistemaFidelidade
{
    // ---------- CLIENTES ----------

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

    public static Cliente? BuscarClientePorId(int id)
    {
        return Banco.BuscarPorId(id);
    }

    public static List<Cliente> BuscarClientePorNome(string texto)
    {
        return Banco.BuscarPorNome(texto);
    }

    public static List<Cliente> ListarClientes()
    {
        return Banco.ListarClientes().ToList();
    }

    // ---------- VENDAS ----------

    public static bool RegistrarVenda(Cliente cliente, double valorCompra)
    {
        Compra compra = new Compra
        {
            ClienteId = cliente.Id,
            ValorCompra = valorCompra
        };

        Banco.AdicionarCompra(compra);

        return cliente.RegistrarCompra(valorCompra);
    }

    // ---------- TICKETS ----------

    public static bool ResgatarTicket(Cliente cliente)
    {
        return cliente.ResgatarTicket();
    }
}