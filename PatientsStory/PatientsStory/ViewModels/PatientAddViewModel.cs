using PatientsStory.Constants;
using PatientsStory.Models;
using PatientsStory.Validation;
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
                    if (Validator.IsValid(FirstName, PatternsConstants.PATIENT_NAME_PATTERN) &&
                        Validator.IsValid(LastName, PatternsConstants.PATIENT_NAME_PATTERN) &&
                        Validator.IsValid(PESEL, PatternsConstants.PATIENT_PESEL_PATTERN))
                    {
                        var patient = new Patient(Id, FirstName, LastName, PESEL);
                        await App.DataController.SavePatientAsync(patient);
                        await Application.Current.MainPage.DisplayAlert(AlertsLabelsConstants.SAVE_TITLE,
                                                                        AlertsLabelsConstants.PATIENT_SAVE_MESSAGE,
                                                                        AlertsLabelsConstants.OK_ANSWER);
                        await Application.Current.MainPage.Navigation.PopToRootAsync();
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