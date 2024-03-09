using FragataAssist.Data;
using FragataAssist.Services.AlumnoService;
using FragataAssist.Services.AsistenciaService;
using FragataAssist.Services.ProductService;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace FragataAssist
{
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
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"ProductDB.db3");

            //FileInfo fi = new FileInfo(dbPath);
            //if (fi.Exists)
            //{
            //    fi.Delete();
            //}

            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddSingleton<IMediaPicker>(MediaPicker.Default);
            //builder.Services.AddTransient<>
            builder.Services.AddSingleton<IProductRepository, ProductService>(p => ActivatorUtilities.CreateInstance<ProductService>(p, dbPath));
            builder.Services.AddSingleton<IAlumnoRepository, AlumnoService>(p => ActivatorUtilities.CreateInstance<AlumnoService>(p, dbPath));
            builder.Services.AddSingleton<IAsistenciaRepository, AsistenciaService>(p => ActivatorUtilities.CreateInstance<AsistenciaService>(p, dbPath));



            return builder.Build();
        }
    }
}