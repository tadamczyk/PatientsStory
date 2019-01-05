using Xamarin.Forms;

namespace PatientsStory.Validation.Behaviors
{
    public class BaseValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += BindableOnTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= BindableOnTextChanged;
        }

        protected virtual void BindableOnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
        }
    }
}