using PatientsStory.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatientsStory.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PatientDetailsPage : ContentPage
    {
        public PatientDetailsPage(PatientDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}