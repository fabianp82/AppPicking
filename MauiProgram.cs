namespace AppPicking;

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

        //Conectividad
        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);

        //Services
        builder.Services.AddSingleton<LoginServices>();
        builder.Services.AddTransient<RecepcionServices>();

        //ViewsModels
        builder.Services.AddSingleton<LoginPageViewModel>();
        builder.Services.AddSingleton<LoadingPageViewModel>();
        builder.Services.AddTransient<RecepcionPageViewModel>();
        builder.Services.AddTransient<RecepcionDetailsPageViewModel>();

        //Views
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<LoadingPage>();
        builder.Services.AddTransient<RecepcionPage>();
        builder.Services.AddTransient<RecepcionDetailsPage>();
        builder.Services.AddTransient<EgresoPage>();
        
        return builder.Build();
	}
}
