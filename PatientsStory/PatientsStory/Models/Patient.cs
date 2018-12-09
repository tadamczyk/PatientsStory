using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace PatientsStory.Models
{
    [Table("PATIENT")]
    public class Patient
    {
        [PrimaryKey] [AutoIncrement] public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string PESEL { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Visit> Visits { get; set; }
    }
}