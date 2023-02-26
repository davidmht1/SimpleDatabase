using Microsoft.Extensions.DependencyInjection;
using People.DataBases;
using People.Models;

namespace People;

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

		// TODO: Add statements for adding PersonRepository as a singleton
		string dbPath = FileAccessHelper.GetLocalFilePath("C:\\Users\\david\\OneDrive\\Desktop\\All\\Coding\\C#\\DataBase Practice\\People\\people.db3");
		
		//builder for creating the PersonTable
		builder.Services.AddSingleton<PersonRepository>(s => ActivatorUtilities.CreateInstance<PersonRepository>(s, dbPath));
		
		//builder for creating the CarsTable
		builder.Services.AddSingleton<CarRepository>(s => ActivatorUtilities.CreateInstance<CarRepository>(s, dbPath));
			
        return builder.Build();

		//comment
	}
}
