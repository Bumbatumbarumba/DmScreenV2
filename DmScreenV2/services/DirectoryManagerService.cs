using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmScreenV2.services
{
    class DirectoryManagerService
    {
        private static string WorkingDirectory { get; set; }


        //
        //Creates the directories needed for the program to run; called on startup.
        //
        public static void InitializeAllDirectories()
        {
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings.Get("IsFirstTimeStartUp")))
            {
                WorkingDirectory = ConfigurationSettings.AppSettings.Get("DefaultSaveLocation");
                Directory.CreateDirectory(WorkingDirectory);
                Directory.CreateDirectory(WorkingDirectory + "campaigns\\");
                Directory.CreateDirectory(WorkingDirectory + "resources\\");
                Directory.CreateDirectory(WorkingDirectory + "resources\\" + "music\\");
                Directory.CreateDirectory(WorkingDirectory + "resources\\" + "images\\");
                Directory.CreateDirectory(WorkingDirectory + "resources\\" + "images\\" + "dice\\");

                ConfigurationSettings.AppSettings.Set("IsFirstTimeStartUp", "false");
                Console.WriteLine("all directories created successfully");
            }
            else
            {
                Console.WriteLine("checking for missing directories");
                CheckForMissingDirectories();
            }
        }

        private static void CheckForMissingDirectories()
        {
            if(!Directory.Exists(WorkingDirectory))
                Directory.CreateDirectory(WorkingDirectory);
            if (!Directory.Exists(WorkingDirectory + "campaigns\\"))
                Directory.CreateDirectory(WorkingDirectory + "campaigns\\");
            if (!Directory.Exists(WorkingDirectory + "resources\\"))
                Directory.CreateDirectory(WorkingDirectory + "resources\\");
            if (!Directory.Exists(WorkingDirectory + "resources\\" + "music\\"))
                Directory.CreateDirectory(WorkingDirectory + "resources\\" + "music\\");
            if (!Directory.Exists(WorkingDirectory + "resources\\" + "images\\"))
                Directory.CreateDirectory(WorkingDirectory + "resources\\" + "images\\");
            if (!Directory.Exists(WorkingDirectory + "resources\\" + "images\\" + "dice\\"))
                Directory.CreateDirectory(WorkingDirectory + "resources\\" + "images\\" + "dice\\");
        }
    }
}
