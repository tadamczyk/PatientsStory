using Xamarin.Forms;

namespace PatientsStory.ViewModels
{
    public class PatientDetailsViewModel : BaseViewModel
    {
        private string _age;

        private string _fullName;

        private string _gender;

        private int _id;

        private string _pesel;

        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        public string Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged("Gender");
            }
        }

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
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

        public string Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }

        public Command EditPatient
        {
            get { return new Command(async () => { }); }
        }

        public Command DeletePatient
        {
            get { return new Command(async () => { }); }
        }

        public Command ShowHistory
        {
            get { return new Command(async () => { }); }
        }

        public Command AddVisit
        {
            get { return new Command(async () => { }); }
        }
    }
}