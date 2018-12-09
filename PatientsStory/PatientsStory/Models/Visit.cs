using System;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace PatientsStory.Models
{
    [Table("VISIT")]
    public class Visit
    {
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