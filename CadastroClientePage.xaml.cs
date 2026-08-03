namespace Fidelidade.App;

public partial class CadastroClientePage : ContentPage
{
    public CadastroClientePage()
    {
        InitializeComponent();
    }
    private async void Cadastrar_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Cadastro", "Botão funcionando!", "OK");
    }
}