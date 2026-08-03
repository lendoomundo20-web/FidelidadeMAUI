namespace Fidelidade.App;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void CadastrarCliente(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroClientePage());
    }

    private async void RegistrarVenda(object sender, EventArgs e)
    {
        await DisplayAlert("Venda", "Tela em construção.", "OK");
    }

    private async void ConsultarCliente(object sender, EventArgs e)
    {
        await DisplayAlert("Consulta", "Tela em construção.", "OK");
    }

    private async void ResgatarTicket(object sender, EventArgs e)
    {
        await DisplayAlert("Ticket", "Tela em construção.", "OK");
    }

    private async void ListarClientes(object sender, EventArgs e)
    {
        await DisplayAlert("Clientes", "Tela em construção.", "OK");
    }
}