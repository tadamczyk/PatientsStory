using PatientsStory.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatientsStory.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VisitsListPage : ContentPage
    {
        public VisitsListPage(VisitsListViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}