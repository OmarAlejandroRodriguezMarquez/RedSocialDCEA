using Microsoft.Extensions.Logging;
using RedSocial.Services;

namespace RedSocial;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        
        builder.Services.AddSingleton<HttpClient>(sp =>
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://redsocialomar.azurewebsites.net/api/");
            return httpClient;
        });
        
        builder.Services.AddScoped<IHttpService, HttpService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}