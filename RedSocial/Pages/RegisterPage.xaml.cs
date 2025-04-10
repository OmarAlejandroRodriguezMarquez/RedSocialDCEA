using Newtonsoft.Json;
using RedSocial.Models;
using RedSocial.Services;

namespace RedSocial.Pages;

public partial class RegisterPage : ContentPage
{
    private readonly IHttpService _httpService;
    
    public RegisterPage(IHttpService httpService)
    {
        _httpService = httpService;
        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        List<CatGenero> generos = new List<CatGenero>();
        var respuesta = await _httpService.GetInfo("catalogo",generos);
        pckGenero.ItemsSource = respuesta;
    }

    private async void BtnRegistrar_OnClicked(object? sender, EventArgs e)
    {
        Profile profile = new Profile();
        profile.Nickname = txtNickName.Text;
        profile.Genero = (CatGenero)pckGenero.SelectedItem;
        profile.GeneroId = int.Parse(profile.Genero.Id.ToString());
        profile.FechaNacimiento = dpkFechaNacimiento.Date;
        await DisplayAlert("Registro", "Registro exitoso", "OK");
        var json = JsonConvert.SerializeObject(profile);
        await DisplayAlert("Registro", json, "OK");
    }
}