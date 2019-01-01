using System.ComponentModel;
using PatientsStory.Constants;

namespace PatientsStory.Enums
{
    public enum GenderEnum
    {
        [Description(LabelsConstants.FEMALE)] FEMALE,
        [Description(LabelsConstants.MALE)] MALE
    }
}