using System.Collections.ObjectModel;
using PatientsStory.Models;
using PatientsStory.Views;
using Xamarin.Forms;

namespace PatientsStory.ViewModels
{
    public class VisitsListViewModel : BaseViewModel
    {
        private string _patientFullName;

        private int _patientId;

        private Visit _selectedVisit;

        private ObservableCollection<Visit> _visitsList;

        public int PatientId
        {
            get => _patientId;
            set
            {
                _patientId = value;
                OnPropertyChanged("PatientId");
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

        public Visit SelectedVisit
        {
            get => _selectedVisit;
            set
            {
                _selectedVisit = value;
                if (_selectedVisit == null)
                {
                    return;
                }

                //SelectVisit.Execute(_selectedVisit);
                _selectedVisit = null;
                OnPropertyChanged("SelectedVisit");
            }
        }

        public ObservableCollection<Visit> VisitsList
        {
            get => _visitsList;
            set
            {
                _visitsList = value;
                OnPropertyChanged("VisitsList");
            }
        }

        public Command AddVisit
        {
            get
            {
                return new Command(async () =>
                {
                    var visitAddViewModel = new VisitAddViewModel
                    {
                        PatientId = PatientId,
                        PatientFullName = PatientFullName
                    };
                    var visitAddPage = new VisitAddPage(visitAddViewModel);
                    await Application.Current.MainPage.Navigation.PushAsync(visitAddPage);
                });
            }
        }
    }
}