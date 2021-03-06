﻿using System.Collections.ObjectModel;
using PatientsStory.Constants;
using PatientsStory.Helpers;
using PatientsStory.Models;
using PatientsStory.Views;
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
            get
            {
                return new Command(async () =>
                {
                    var patientAddViewModel = new PatientAddViewModel
                    {
                        Id = Id,
                        FirstName = PatientHelper.GetFirstName(FullName),
                        LastName = PatientHelper.GetLastName(FullName),
                        PESEL = PESEL
                    };
                    var patientAddPage = new PatientAddPage(patientAddViewModel);
                    await Application.Current.MainPage.Navigation.PushAsync(patientAddPage);
                });
            }
        }

        public Command DeletePatient
        {
            get
            {
                return new Command(async () =>
                {
                    var answer =
                        await Application.Current.MainPage.DisplayAlert(AlertsLabelsConstants.DELETE_TITLE,
                                                                        AlertsLabelsConstants.DELETE_MESSAGE,
                                                                        AlertsLabelsConstants.YES_ANSWER,
                                                                        AlertsLabelsConstants.NO_ANSWER);
                    if (answer)
                    {
                        var patient = await App.DataController.GetPatientAsync(Id);
                        await App.DataController.DeletePatientAsync(patient);
                        Application.Current.MainPage =
                            new NavigationPage(new PatientsListPage(new PatientsListViewModel()));
                    }
                });
            }
        }

        public Command ShowHistory
        {
            get
            {
                return new Command(async () =>
                {
                    var visits = await App.DataController.GetVisitsAsync(Id);
                    var visitsListViewModel = new VisitsListViewModel
                    {
                        VisitsList = new ObservableCollection<Visit>(visits),
                        PatientId = Id,
                        PatientFullName = FullName
                    };
                    var visitsListPage = new VisitsListPage(visitsListViewModel);
                    await Application.Current.MainPage.Navigation.PushAsync(visitsListPage);
                });
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
                        PatientId = Id,
                        PatientFullName = FullName
                    };
                    var visitAddPage = new VisitAddPage(visitAddViewModel);
                    await Application.Current.MainPage.Navigation.PushAsync(visitAddPage);
                });
            }
        }
    }
}