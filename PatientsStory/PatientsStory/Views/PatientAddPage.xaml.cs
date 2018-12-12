using PatientsStory.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatientsStory.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PatientAddPage : ContentPage
    {
        public PatientAddPage(PatientAddViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}