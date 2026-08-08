namespace AdrianaApp.core;

public static class Banco
{
    private static readonly List<Cliente> clientes = [];

    private static readonly List<Compra> compras = [];

    public static int GerarNovoId()
    {
        int id;

        do
        {
            id = Random.Shared.Next(10000, 100000);
        }
        while (clientes.Any(c => c.Id == id));

        return id;
    }

    public static void AdicionarCompra(Compra compra)
    {
        compras.Add(compra);
    }

    public static IReadOnlyList<Compra> ListarCompras()
    {
        return compras;
    }

    public static void AdicionarCliente(Cliente cliente)
    {
        clientes.Add(cliente);
    }

    public static Cliente? BuscarPorId(int id)
    {
        return clientes.FirstOrDefault(c => c.Id == id);
    }

    public static List<Cliente> BuscarPorNome(string texto)
    {
        return clientes
            .Where(c => c.NomeCompleto.Contains(texto,
                StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public static IReadOnlyList<Cliente> ListarClientes()
    {
        return clientes;
    }

    public static List<Cliente> BuscarClientes(string texto)
    {
        texto = texto.Trim();

        if (string.IsNullOrEmpty(texto))
            return [];

        if (texto.All(char.IsDigit))
        {
            return clientes
                .Where(c => c.Id.ToString().StartsWith(texto))
                .OrderBy(c => c.Id)
                .ToList();
        }

        return clientes
            .Where(c => c.NomeCompleto.Contains(
                texto,
                StringComparison.OrdinalIgnoreCase))
            .OrderBy(c => c.NomeCompleto)
            .ToList();
    }
}

