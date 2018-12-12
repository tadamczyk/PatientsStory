using System.Collections.Generic;
using System.Threading.Tasks;
using PatientsStory.Models;

namespace PatientsStory.DataAccess.Interfaces
{
    public interface IDataController
    {
        Task<List<Patient>> GetPatientsAsync();

        Task<Patient> GetPatientAsync(int id);

        Task<int> SavePatientAsync(Patient patient);

        Task<int> DeletePatientAsync(Patient patient);

        Task<List<Visit>> GetVisitsAsync(int patientId);

        Task<Visit> GetVisitAsync(int id);

        Task<int> SaveVisitAsync(Visit visit);
    }
}