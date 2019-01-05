using System.Text.RegularExpressions;

namespace PatientsStory.Validation
{
    public class Validator
    {
        public static bool IsValid(string value, string pattern)
        {
            return value != null && Regex.IsMatch(value, pattern);
        }
    }
}