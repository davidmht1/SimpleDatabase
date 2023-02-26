using People.DataBases;

namespace People;

public partial class App : Application
{
    // TODO: Add a public static PersonRepository property
    public static PersonRepository PersonRepo { get; set; }

    public static CarRepository CarRepo { get; set; }


    public App(PersonRepository repo, CarRepository repoCar)
	{
        InitializeComponent();

		MainPage = new AppShell();

        // TODO: Initialize the PersonRepository property with the PersonRespository singleton object
        PersonRepo = repo;
        CarRepo = repoCar;
    }
}
