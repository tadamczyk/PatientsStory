using PatientsStory.Constants;
using PatientsStory.Models;
using PatientsStory.Validation;
using PatientsStory.Views;
using Xamarin.Forms;

namespace PatientsStory.ViewModels
{
    public class PatientAddViewModel : BaseViewModel
    {
        private string _firstName;

        private int _id;

        private string _lastName;

        private string _pesel;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string PESEL
        {
            get => _pesel;
            set
            {
                _pesel = value;
                OnPropertyChanged("PESEL");
            }
        }

        public Command SavePatient
        {
            get
            {
                return new Command(async () =>
                {
                    if (Validator.IsValid(FirstName, ValidationPatternsConstants.PATIENT_NAME_PATTERN) &&
                        Validator.IsValid(LastName, ValidationPatternsConstants.PATIENT_NAME_PATTERN) &&
                        Validator.IsValid(PESEL, ValidationPatternsConstants.PATIENT_PESEL_PATTERN) &&
                        !await Validator.IsPeselExistsAsync(Id, PESEL))
                    {
                        var patient = new Patient(Id, FirstName, LastName, PESEL);
                        await App.DataController.SavePatientAsync(patient);
                        await Application.Current.MainPage.DisplayAlert(AlertsLabelsConstants.SAVE_TITLE,
                                                                        AlertsLabelsConstants.PATIENT_SAVE_MESSAGE,
                                                                        AlertsLabelsConstants.OK_ANSWER);
                        Application.Current.MainPage =
                            new NavigationPage(new PatientsListPage(new PatientsListViewModel()));
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert(AlertsLabelsConstants.ERROR_TITLE,
                                                                        AlertsLabelsConstants.ERROR_MESSAGE,
                                                                        AlertsLabelsConstants.OK_ANSWER);
                    }
                });
            }
        }
    }
}