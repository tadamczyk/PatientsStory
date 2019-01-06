namespace PatientsStory.Constants
{
    public static class ValidationPatternsConstants
    {
        public const string PATIENT_NAME_PATTERN = "^[A-ZĆŁŚŹŻ][a-ząćęłńóśźżA-ZĄĆĘŁŃÓŚŹŻ-]{2,29}$";
        public const string PATIENT_PESEL_PATTERN = "^([0-9]{2})(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])([0-9]{5})$";

        public const string VISIT_DESCRIPTION_PATTERN = "^.{1,100}$";
        public const string VISIT_PRICE_PATTERN = "^([0-9]{1,5})([.]{0,1})([0-9]{0,2})$";
    }
}