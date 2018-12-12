using PatientsStory.Models;
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
                    var patient = new Patient(Id, FirstName, LastName, PESEL);
                    await App.DataController.SavePatientAsync(patient);
                    await Application.Current.MainPage.DisplayAlert("Zrobione!", "Dodano/zaktualizowano pacjenta!",
                        "Ok");
                    await Application.Current.MainPage.Navigation.PopToRootAsync();
                });
            }
        }
    }
}