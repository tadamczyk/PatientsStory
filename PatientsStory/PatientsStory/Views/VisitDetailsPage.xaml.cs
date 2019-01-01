using PatientsStory.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatientsStory.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VisitDetailsPage : ContentPage
    {
        public VisitDetailsPage(VisitDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}