using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DmScreenV2.services
{
    class UserSettingsService
    {
        public static string NewSaveLocation { get; set; }

        public static void ChangeDefaultSaveLocation()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = "c:\\";
            
            if (openFileDialog.ShowDialog() == true)
            {
                NewSaveLocation = openFileDialog.FileName;
            }

#pragma warning disable CS0618 // Type or member is obsolete
            ConfigurationSettings.AppSettings.Set("DefaultSaveLocation", NewSaveLocation);
#pragma warning restore CS0618 // Type or member is obsolete
        }

    }
}
