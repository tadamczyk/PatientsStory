using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PatientsStory.Validation
{
    public class Validator : Behavior<Entry>
    {
        public string Pattern { get; set; }

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
            var input = textChangedEventArgs.NewTextValue;

            if (sender is Entry entry)
            {
                entry.TextColor = Regex.IsMatch(input, Pattern)
                    ? Color.Black
                    : Color.Red;
            }
        }

        public static bool IsValid(string value, string pattern)
        {
            return value != null && Regex.IsMatch(value, pattern);
        }

        public static async Task<bool> IsPeselExistsAsync(int id, string pesel)
        {
            var patients = await App.DataController.GetPatientsAsync();
            if (id != 0)
            {
                patients.RemoveAll(p => p.PESEL == patients.Where(patient => patient.Id == id)
                                            .Select(patient => patient.PESEL).First());
            }

            return patients.Exists(p => p.PESEL == pesel);
        }
    }
}