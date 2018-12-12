using System.Collections.Generic;
using System.Threading.Tasks;
using PatientsStory.DataAccess.Interfaces;
using PatientsStory.Models;
using SQLite;

namespace PatientsStory.DataAccess
{
    public class DataController : IDataController
    {
        private readonly SQLiteAsyncConnection _database;

        public DataController(string databasePath)
        {
            _database = new SQLiteAsyncConnection(databasePath);
            _database.CreateTableAsync<Patient>().Wait();
            _database.CreateTableAsync<Visit>().Wait();
        }

        public Task<List<Patient>> GetPatientsAsync()
        {
            return _database.Table<Patient>()
                .OrderBy(t => t.LastName)
                .ThenBy(t => t.FirstName)
                .ThenBy(t => t.PESEL)
                .ToListAsync();
        }

        public Task<Patient> GetPatientAsync(int id)
        {
            return _database.Table<Patient>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SavePatientAsync(Patient patient)
        {
            return patient.Id != 0 ? _database.UpdateAsync(patient) : _database.InsertAsync(patient);
        }

        public Task<int> DeletePatientAsync(Patient patient)
        {
            return _database.DeleteAsync(patient);
        }

        public Task<List<Visit>> GetVisitsAsync(int patientId)
        {
            return _database.Table<Visit>()
                .Where(v => v.PatientId == patientId)
                .OrderByDescending(t => t.DateOfVisit)
                .ThenBy(t => t.Diagnose)
                .ToListAsync();
        }

        public Task<Visit> GetVisitAsync(int id)
        {
            return _database.Table<Visit>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveVisitAsync(Visit visit)
        {
            return visit.Id != 0 ? _database.UpdateAsync(visit) : _database.InsertAsync(visit);
        }
    }
}