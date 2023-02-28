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

		string directory = "C:\\Database";

		if(!Directory.Exists(directory))
		{
			System.IO.Directory.CreateDirectory(directory);
		}
        

		// TODO: Add statements for adding PersonRepository as a singleton
		string dbPath = FileAccessHelper.GetLocalFilePath("C:\\Database\\people.db3");
		
		
		//builder for creating the PersonTable
		builder.Services.AddSingleton<PersonRepository>(s => ActivatorUtilities.CreateInstance<PersonRepository>(s, dbPath));
		
		//builder for creating the CarsTable
		builder.Services.AddSingleton<CarRepository>(s => ActivatorUtilities.CreateInstance<CarRepository>(s, dbPath));
			
        return builder.Build();

		//comment
		//comment too
	}
}
