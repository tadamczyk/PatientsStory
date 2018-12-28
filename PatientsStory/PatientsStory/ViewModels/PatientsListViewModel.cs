using System.Collections.ObjectModel;
using PatientsStory.Helpers;
using PatientsStory.Models;
using PatientsStory.Views;
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
                if (_selectedPatient == null)
                {
                    return;
                }

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
            get
            {
                return new Command(async () =>
                {
                    var patientAddViewModel = new PatientAddViewModel();
                    var patientAddPage = new PatientAddPage(patientAddViewModel);
                    await Application.Current.MainPage.Navigation.PushAsync(patientAddPage);
                });
            }
        }

        public Command SelectPatient
        {
            get
            {
                return new Command(async () =>
                {
                    var patientDetailsViewModel = new PatientDetailsViewModel
                    {
                        Id = _selectedPatient.Id,
                        FullName = _selectedPatient.FullName,
                        PESEL = _selectedPatient.PESEL,
                        Age = PatientHelper.GetAgeFromPesel(_selectedPatient.PESEL).ToString(),
                        Gender = PatientHelper.GetGenderFromPesel(_selectedPatient.PESEL)
                    };
                    var patientDetailsPage = new PatientDetailsPage(patientDetailsViewModel);
                    await Application.Current.MainPage.Navigation.PushAsync(patientDetailsPage);
                });
            }
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