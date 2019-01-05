using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace PatientsStory.Validation.Behaviors
{
    public class VisitPriceValidationBehavior : BaseValidationBehavior
    {
        protected override void BindableOnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            var price = textChangedEventArgs.NewTextValue;

            if (sender is Entry entry)
            {
                entry.TextColor = Regex.IsMatch(price, PatternsConstants.VISIT_PRICE_PATTERN)
                    ? Color.Black
                    : Color.Red;
            }
        }
    }
}