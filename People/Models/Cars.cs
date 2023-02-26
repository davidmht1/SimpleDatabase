using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.Models
{

    //labeling a table of cars
    [Table("cars")]
    public class Cars
    {
        //sets a unique CardId for each car added
        //key will auto increment
        [PrimaryKey, AutoIncrement]
        public int CarId { get; set; }

        //sets max string length, has to be a unique entry
        [MaxLength(50), Unique]
        public string Car { get; set; }


    }
}
