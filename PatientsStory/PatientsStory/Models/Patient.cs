using System.Collections.Generic;
using PatientsStory.Helpers;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace PatientsStory.Models
{
    [Table("PATIENT")]
    public class Patient
    {
        public Patient(int id, string firstName, string lastName, string pesel)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PESEL = pesel;
            FullName = PatientHelper.GetFullName(firstName, lastName);
            Visits = new List<Visit>();
        }

        public Patient()
        {
        }

        [PrimaryKey] [AutoIncrement] public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PESEL { get; set; }

        public string FullName { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Visit> Visits { get; set; }
    }
}