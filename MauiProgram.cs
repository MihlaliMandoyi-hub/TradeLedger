using Microsoft.Extensions.Logging;
using FxLedger.Data;

namespace FxLedger;

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

        // Register DatabaseService as a singleton: one shared instance,
        // and therefore one shared SQLite connection, for the app's whole lifetime.
        builder.Services.AddSingleton<DatabaseService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
