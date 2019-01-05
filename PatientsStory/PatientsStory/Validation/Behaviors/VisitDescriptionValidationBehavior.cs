using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace PatientsStory.Validation.Behaviors
{
    public class VisitDescriptionValidationBehavior : BaseValidationBehavior
    {
        protected override void BindableOnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            var description = textChangedEventArgs.NewTextValue;

            if (sender is Entry entry)
            {
                entry.TextColor = Regex.IsMatch(description, PatternsConstants.VISIT_DESCRIPTION_PATTERN)
                    ? Color.Black
                    : Color.Red;
            }
        }
    }
}