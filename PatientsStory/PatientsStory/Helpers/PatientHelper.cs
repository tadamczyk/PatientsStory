using System;

namespace PatientsStory.Helpers
{
    public class PatientHelper
    {
        public static string GetFullName(string firstName, string lastName)
        {
            return string.Concat(lastName, " ", firstName);
        }

        public static int GetAgeFromPesel(string pesel)
        {
            var stringYear = int.Parse(pesel.Substring(0, 2)) <= 18
                ? "20" + pesel.Substring(0, 2)
                : "19" + pesel.Substring(0, 2);

            var year = int.Parse(stringYear);
            var month = int.Parse(pesel.Substring(2, 2));
            var day = int.Parse(pesel.Substring(4, 2));

            var birthday = new DateTime(year, month, day);
            var age = ((DateTime.Now.Year - birthday.Year) * 372 +
                       (DateTime.Now.Month - birthday.Month) * 31 +
                       (DateTime.Now.Day - birthday.Day)) / 372;

            return age;
        }

        public static string GetGenderFromPesel(string pesel)
        {
            var genderNumber = int.Parse(pesel.Substring(9, 1));

            return genderNumber % 2 == 0 ? "Kobieta" : "Mężczyzna";
        }
    }
}