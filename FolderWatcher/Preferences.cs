using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FolderWatcher
{
    public static class Preferences
    {
        private static readonly string _configFolder;
        private static readonly string _configFile;
        private static XDocument _docPreferences = null;

        static Preferences()
        {
            _configFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FolderWatcher");
            _configFile = Path.Combine(_configFolder, "Preferences.config");

            if (!Directory.Exists(_configFolder))
                Directory.CreateDirectory(_configFolder);

            if (!File.Exists(_configFile))
            {
                _docPreferences = new XDocument(XElement.Parse("<Preferencias></Preferencias>"));
                _docPreferences.Root.Add(XElement.Parse(string.Concat("<Folder>", "", "</Folder>")));
                Save();
            }
            else
            {
                _docPreferences = XDocument.Parse(File.ReadAllText(_configFile));
            }
        }

        public static string GetPreference(string tag)
        {
            return _docPreferences.Root.Element(tag).Value.ToString();
        }


        public static void SetPreference(string tag, string value)
        {
            _docPreferences.Root.Element(tag).SetValue(value);
            Save();
        }

        private static void Save()
        {
            _docPreferences.Save(_configFile);
        }
    }
}
