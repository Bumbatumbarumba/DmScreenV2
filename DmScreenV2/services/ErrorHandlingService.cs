using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace DmScreenV2.services
{
    public class ErrorHandlingService
    {
        private static string CurrentWorkingDirectory = ConfigurationSettings.AppSettings.Get("DefaultSaveLocation") + @"\resources\log.txt";


        //
        //Writes the specified error message to the error log.
        //
        public static void WriteToLog(string errorMsg)
        {
            using (StreamWriter stream = new StreamWriter(CurrentWorkingDirectory))
            {
                stream.Write(errorMsg);
            }
        }
    }
}
