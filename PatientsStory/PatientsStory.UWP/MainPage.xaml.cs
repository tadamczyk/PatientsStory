namespace PatientsStory.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            LoadApplication(new PatientsStory.App());
        }
    }
}