using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace PatientsStory.Validation.Behaviors
{
    public class PatientPeselValidationBehavior : BaseValidationBehavior
    {
        protected override void BindableOnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            var pesel = textChangedEventArgs.NewTextValue;

            if (sender is Entry entry)
            {
                entry.TextColor = Regex.IsMatch(pesel, PatternsConstants.PATIENT_PESEL_PATTERN)
                    ? Color.Black
                    : Color.Red;
            }
        }
    }
}