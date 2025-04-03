using RedSocial.Models;
using RedSocial.Pages;
using RedSocial.Services;

namespace RedSocial;

public partial class MainPage : ContentPage
{
    private readonly IHttpService _httpService;

    public MainPage(IHttpService httpService)
    {
        _httpService = httpService;
        InitializeComponent();
    }

    private async void BtnRegistro_OnClicked(object? sender, EventArgs e)
    {
        Character character = new Character();
        character = await _httpService.GetAsync<Character>();
        await Navigation.PushAsync(new RegisterPage());
    }
}