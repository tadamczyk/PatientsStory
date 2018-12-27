using PatientsStory.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatientsStory.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VisitAddPage : ContentPage
    {
        public VisitAddPage(VisitAddViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}