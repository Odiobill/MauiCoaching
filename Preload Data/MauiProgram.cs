using CommunityToolkit.Maui;
using Preload_Data.Services;
using Preload_Data.ViewModels;
using Preload_Data.Views;

namespace Preload_Data;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<DatabaseService>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<ExchangesPage>();
        builder.Services.AddTransient<ExchangesViewModel>();

        return builder.Build();
	}
}
