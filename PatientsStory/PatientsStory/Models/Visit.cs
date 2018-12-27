using System;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace PatientsStory.Models
{
    [Table("VISIT")]
    public class Visit
    {
        public Visit(int id, int patientId, DateTime dateOfVisit, string diagnose, string indications, decimal price)
        {
            Id = id;
            PatientId = patientId;
            DateOfVisit = dateOfVisit;
            Diagnose = diagnose;
            Indications = indications;
            Price = price;
        }

        public Visit()
        {
        }

        [PrimaryKey] [AutoIncrement] public int Id { get; set; }

        [ForeignKey(typeof(Patient))] public int PatientId { get; set; }

        public DateTime DateOfVisit { get; set; }

        public string Diagnose { get; set; }

        public string Indications { get; set; }

        public decimal Price { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public Patient Patient { get; set; }
    }
}