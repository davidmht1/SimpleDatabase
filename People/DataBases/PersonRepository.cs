using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using People.Models;


namespace People.DataBases
{
    public class PersonRepository
    {
        //declare a string that will store database path
        string _dbPath;
        
        //used to display messages
        public string StatusMessage { get; set; }


        // TODO: Add variable for the SQLite connection
        private SQLiteConnection conn;


        //method used to ensure a connection exists with the database
        //if there doesnt then a new connection is initiatec
        private void InitPerson()
        {
            // TODO: Add code to initialize the repository         
            if (conn != null)
            {
                return;
            }

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Person>();
        }

        //Constructor used to set string as the database path
        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }


        //method to add new person to database
        public void AddNewPerson(string name)
        {

            int result = 0;

            try
            {
                // TODO: Call Init()
                InitPerson();

                // basic validation to ensure a name was entered
                 if (string.IsNullOrWhiteSpace(name))
                {
                    new Exception("Valid name required");
                }


                // enter this line
                result = conn.Insert(new Person { Name = name });

                StatusMessage = string.Format("{0} record(s) added (Name: {1}", result, name);

                // TODO: Insert the new person into the database
                result = 0;


                
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }

        }

        public List<Person> GetAllPeople()
        {
            // TODO: Init then retrieve a list of Person objects from the database into a list
            try
            {
                InitPerson();
                return conn.Table<Person>().ToList();

            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Person>();
        }



        
    }
}
