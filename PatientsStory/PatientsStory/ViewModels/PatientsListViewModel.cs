using System.Collections.ObjectModel;
using PatientsStory.Models;
using Xamarin.Forms;

namespace PatientsStory.ViewModels
{
    public class PatientsListViewModel : BaseViewModel
    {
        private bool _isRefreshing;

        private ObservableCollection<Patient> _patientsList;

        private Patient _selectedPatient;

        public PatientsListViewModel()
        {
            RefreshCommand.Execute(null);
        }

        public Patient SelectedPatient
        {
            get => _selectedPatient;
            set
            {
                _selectedPatient = value;
                if (_selectedPatient == null) return;
                SelectPatient.Execute(_selectedPatient);
                _selectedPatient = null;
                OnPropertyChanged("SelectedPatient");
            }
        }

        public ObservableCollection<Patient> PatientsList
        {
            get => _patientsList;
            set
            {
                _patientsList = value;
                OnPropertyChanged("PatientsList");
            }
        }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged("IsRefreshing");
            }
        }

        public Command AddPatient
        {
            get { return new Command(async () => { }); }
        }

        public Command SelectPatient
        {
            get { return new Command(async () => { }); }
        }

        public Command RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;
                    var patients = await App.DataController.GetPatientsAsync();
                    PatientsList = new ObservableCollection<Patient>(patients);
                    IsRefreshing = false;
                });
            }
        }
    }
}