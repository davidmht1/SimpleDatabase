using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using People.Models;

namespace People.DataBases
{
    public class CarRepository
    {
        //declare a string that will store database path
        string _dbPath;

        //status message to display actions taken
        public string CarMessage { get; set; }

        //declare variable that will be used to store SQL connection
        private SQLiteConnection conn;



        //Method checks for a connection to database
        //if there is no connection, one is created
        //and a new table of cars is initiated
        private void InitCar()
        {
            if (conn != null)
            {
                return;
            }

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Cars>();
        }

        //CarRepository constructor
        //the string argument that is passed to this constructor
        //will be assigned to the string _dbPath
        public CarRepository(string dbPath)
        {
            _dbPath = dbPath;
        }


        //method to add car to car table
        public void AddNewCar(string car)
        {
            //int to store the number of records added to the table
            int result = 0;

            try
            {
                //calls InitCar method
                InitCar();

                //if there is no imput in text box
                //throw exception
                if(string.IsNullOrWhiteSpace(car))
                {
                    new Exception("Valid name required");
                }

                //inserts new car into table
                result = conn.Insert(new Cars { Car = car });

                CarMessage = string.Format("{0} record(s) added (Model: {1}", result, car);

                result = 0;

                car = string.Empty;
            }

            //if any other error occurs, throw this exception
            catch(Exception ex) 
            {
                CarMessage = string.Format("Failed to add {0}. Error: {1}", car, ex.Message);
            }

        }


        //method to return all cars that have been added
        public List<Cars> GetAllCars()
        {
            try
            {
                InitCar();
                return conn.Table<Cars>().ToList();

            }
            catch (Exception ex) 
            {
               CarMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Cars>();
        }


    }
}
