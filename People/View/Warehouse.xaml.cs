using People.Models;
namespace People;

public partial class Warehouse : ContentPage
{

	public Warehouse()
	{
		InitializeComponent();

	}

    public void OnNewButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        App.PersonRepo.AddNewPerson(newPerson.Text);
        statusMessage.Text = App.PersonRepo.StatusMessage;
    }

    public void OnGetButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        List<Person> people = App.PersonRepo.GetAllPeople();
        peopleList.ItemsSource = people;
    }

    public void OnNewButtonCarClicked(object sender, EventArgs args) 
    {
        CarMessage.Text = "";

        App.CarRepo.AddNewCar(newModel.Text);
        CarMessage.Text = App.CarRepo.CarMessage;
    }

    public void OnGetButtonCarClicked(object sender, EventArgs args)
    {
        CarMessage.Text = "";

        List<Cars> cars = App.CarRepo.GetAllCars();
        carsList.ItemsSource = cars;
    }


}

