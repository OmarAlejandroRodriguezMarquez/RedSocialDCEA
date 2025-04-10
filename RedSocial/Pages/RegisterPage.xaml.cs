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
}