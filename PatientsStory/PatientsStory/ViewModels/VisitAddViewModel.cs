using System;
using PatientsStory.Constants;
using PatientsStory.Models;
using PatientsStory.Validation;
using Xamarin.Forms;

namespace PatientsStory.ViewModels
{
    public class VisitAddViewModel : BaseViewModel
    {
        private DateTime _dateOfVisit = DateTime.Today;

        private string _diagnose;

        private int _id;

        private string _indications;

        private DateTime _maxDateOfVisit;

        private string _patientFullName;

        private int _patientId;

        private decimal _price;

        public VisitAddViewModel()
        {
            MaxDateOfVisit = DateTime.Today;
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

        public DateTime MaxDateOfVisit
        {
            get => _maxDateOfVisit;
            set
            {
                _maxDateOfVisit = value;
                OnPropertyChanged("MaxDateOfVisit");
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

        public Command SaveVisit
        {
            get
            {
                return new Command(async () =>
                {
                    if (Validator.IsValid(Diagnose, PatternsConstants.VISIT_DESCRIPTION_PATTERN) &&
                        Validator.IsValid(Indications, PatternsConstants.VISIT_DESCRIPTION_PATTERN) &&
                        Validator.IsValid(Price.ToString(), PatternsConstants.VISIT_PRICE_PATTERN))
                    {
                        var visit = new Visit(Id, PatientId, DateOfVisit, Diagnose, Indications, Price);
                        await App.DataController.SaveVisitAsync(visit);
                        await Application.Current.MainPage.DisplayAlert(AlertsLabelsConstants.SAVE_TITLE,
                                                                        AlertsLabelsConstants.VISIT_SAVE_MESSAGE,
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