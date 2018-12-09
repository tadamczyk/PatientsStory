using System;
using PatientsStory.DataAccess;
using PatientsStory.DataAccess.Interfaces;
using PatientsStory.ViewModels;
using PatientsStory.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace PatientsStory
{
    public partial class App : Application
    {
        private static DataController _dataController;
        private static DateTime _sleepStart;
        private readonly TimeSpan _sleepLimit;

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new PatientsListPage(new PatientsListViewModel()));
            _sleepLimit = TimeSpan.FromMinutes(30);
        }

        public static DataController DataController => _dataController ?? (_dataController =
                                                           new DataController(DependencyService.Get<ILocalFileHelper>()
                                                               .GetLocalFilePath("database.db3")));

        protected override void OnSleep()
        {
            _sleepStart = DateTime.Now;
        }

        protected override void OnResume()
        {
            if (DateTime.Now - _sleepStart > _sleepLimit) MessagingCenter.Send(this, "The session has expired.");
        }
    }
}