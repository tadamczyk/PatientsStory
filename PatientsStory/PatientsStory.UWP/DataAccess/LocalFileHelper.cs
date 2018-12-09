using System.IO;
using Windows.Storage;
using PatientsStory.DataAccess.Interfaces;
using PatientsStory.UWP.DataAccess;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalFileHelper))]

namespace PatientsStory.UWP.DataAccess
{
    public class LocalFileHelper : ILocalFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}