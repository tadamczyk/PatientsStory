using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace PatientsStory.Validation.Behaviors
{
    public class PatientNameValidationBehavior : BaseValidationBehavior
    {
        protected override void BindableOnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            var name = textChangedEventArgs.NewTextValue;

            if (sender is Entry entry)
            {
                entry.TextColor = Regex.IsMatch(name, PatternsConstants.PATIENT_NAME_PATTERN)
                    ? Color.Black
                    : Color.Red;
            }
        }
    }
}