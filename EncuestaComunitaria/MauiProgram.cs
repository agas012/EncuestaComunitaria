using EncuestaComunitaria.Data;
using EncuestaComunitaria.Services;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace EncuestaComunitaria
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                // Initialize the .NET MAUI Community Toolkit by adding the below line of code
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddMauiBlazorWebView();

    #if DEBUG
		    builder.Services.AddBlazorWebViewDeveloperTools();
		    builder.Logging.AddDebug();
    #endif
            builder.Services.AddSingleton<IPatientService, PatientService>();
            builder.Services.AddSingleton<WeatherForecastService>();

            return builder.Build();
        }
    }
}