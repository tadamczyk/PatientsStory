using System;
using PatientsStory.Views;
using Xamarin.Forms;

namespace PatientsStory.ViewModels
{
    public class VisitDetailsViewModel : BaseViewModel
    {
        private DateTime _dateOfVisit;

        private string _diagnose;

        private int _id;

        private string _indications;

        private string _patientFullName;

        private int _patientId;

        private decimal _price;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public int PatientId
        {
            get => _patientId;
            set
            {
                _patientId = value;
                OnPropertyChanged("PatientId");
            }
        }

        public DateTime DateOfVisit
        {
            get => _dateOfVisit;
            set
            {
                _dateOfVisit = value;
                OnPropertyChanged("DateOfVisit");
            }
        }

        public string Diagnose
        {
            get => _diagnose;
            set
            {
                _diagnose = value;
                OnPropertyChanged("Diagnose");
            }
        }

        public string Indications
        {
            get => _indications;
            set
            {
                _indications = value;
                OnPropertyChanged("Indications");
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }

        public string PatientFullName
        {
            get => _patientFullName;
            set
            {
                _patientFullName = value;
                OnPropertyChanged("PatientFullName");
            }
        }

        public Command EditVisit
        {
            get
            {
                return new Command(async () =>
                {
                    var visitAddViewModel = new VisitAddViewModel
                    {
                        Id = Id,
                        PatientId = PatientId,
                        DateOfVisit = DateOfVisit,
                        Diagnose = Diagnose,
                        Indications = Indications,
                        Price = Price,
                        PatientFullName = PatientFullName
                    };
                    var visitAddPage = new VisitAddPage(visitAddViewModel);
                    await Application.Current.MainPage.Navigation.PushAsync(visitAddPage);
                });
            }
        }
    }
}