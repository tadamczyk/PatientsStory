using System;
using System.IO;
using PatientsStory.DataAccess.Interfaces;
using PatientsStory.Droid.DataAccess;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalFileHelper))]

namespace PatientsStory.Droid.DataAccess
{
    public class LocalFileHelper : ILocalFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), filename);
        }
    }
}