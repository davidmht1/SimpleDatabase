using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace People.Models
{
    //sets table for people
    [Table("people")]
    public class Person
    {
        //key, with autoincrement
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        //max length and unique entry
        [MaxLength(50), Unique]
        public string Name { get; set; }


    }
}
