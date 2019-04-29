using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;
using DmScreenV2.classes;

namespace DmScreenV2.services
{
    class CampaignDataService
    {
        private static string WorkingDirectory { get; set; }
        public static CampaignObject SelectedCampaign { get; set; }


        //
        //Goes through the campaigns directory, gets all of the json files, and then puts them
        //into a nice list for us to use.
        //NOTE TO SELF: we don't store this as a class variable because we only need to show the 
        //list one time, plus the data is dynamic and storing it would mean re-reading the files
        //every time.
        //
        public static List<CampaignObject> GetAllCampaigns()
        {
            List<CampaignObject> listOfCampaigns = new List<CampaignObject>(); ;

            WorkingDirectory = ConfigurationSettings.AppSettings.Get("DefaultSaveLocation") + "campaigns\\";
            foreach (var file in Directory.GetFiles(WorkingDirectory))
            {
                using (StreamReader streamReader = new StreamReader(file))
                {
                    string stringFileData = streamReader.ReadToEnd();
                    CampaignObject fileData = JsonConvert.DeserializeObject<CampaignObject>(stringFileData);
                    listOfCampaigns.Add(fileData);
                }
            }

            return listOfCampaigns;
        }


        //
        //Check if a specified campaign exists; if it does not then we create a new one, otherwise we throw an exception.
        //
        private static bool CheckIfCampaignExists(string campaignName)
        {
            //get the default directory for the project
            WorkingDirectory = ConfigurationSettings.AppSettings.Get("DefaultSaveLocation") + "campaigns\\" + campaignName + ".json";

            //
            //Check if there exists a campaign file with the same name as the one entered; if it does not then
            //we can just create the json file for it, otherwise we tell the user we cannot do that.
            //
            if (!File.Exists(WorkingDirectory))
                return false; //file does not exist
            else
                return true; //file does exist already

        }
        

        //
        //Creates a new campaign.json file using the campaign name and the author's name.
        //
        public static void CreateCampaignFile(CampaignObject desiredCampaign)
        {
            if (!CheckIfCampaignExists(desiredCampaign.FileTitle))
            {
                CampaignObject newCamp = new CampaignObject();
                newCamp.FileTitle = desiredCampaign.FileTitle;
                newCamp.Title = desiredCampaign.Title;
                newCamp.Author = desiredCampaign.Author;
                newCamp.Theme = desiredCampaign.Theme;
                newCamp.CreationDate = DateTime.Now;
                //newCamp.LastAccessed = DateTime.Parse("01/01/1001");
                newCamp.MusicFileLocations = new string[] { "" };
                newCamp.CharacterList = new CharacterObject[] { };

                //if there is a directory, we set it to be that; if it's empty, we set it to be default
                if (!(desiredCampaign.CampaignImageFileLocation == ""))
                    newCamp.CampaignImageFileLocation = desiredCampaign.CampaignImageFileLocation;
                else
                    newCamp.CampaignImageFileLocation = ConfigurationSettings.AppSettings.Get("DefaultSaveLocation") + @"\resources\images\DefaultCampaignIcon.png";

                string newCampJson = JsonConvert.SerializeObject(newCamp);
                using (StreamWriter streamWriter = new StreamWriter(WorkingDirectory))
                {
                    streamWriter.Write(newCampJson);
                }
            }
            else
            {
                throw new Exception(); //catch this exception in the menu that calls it and show the user a message
                //maybe write your own exception? find a concrete one
            }
        }
               
        
        //
        //Loads all the campaign json file into a CampaignObject for use where needed.
        //
        public static void GetCampaignData(string campaignName)
        {
            if (CheckIfCampaignExists(campaignName))
            {
                using (StreamReader streamReader = new StreamReader(WorkingDirectory))
                {
                    string stringSelectedCampaign = streamReader.ReadToEnd();
                    SelectedCampaign = JsonConvert.DeserializeObject<CampaignObject>(stringSelectedCampaign);
                }
            }
            else
            {
                throw new Exception(); //catch this exception in the menu that calls it and show the user a message
                //maybe write your own exception? find a concrete one
            }
        }


        //
        //Saves the selected campaign object back into a file
        //
        public static void SaveCampaignData()
        {
            WorkingDirectory = WorkingDirectory + @"\" + SelectedCampaign.FileTitle + ".json";
            using (StreamWriter streamWriter = new StreamWriter(WorkingDirectory))
            {
                string stringSelectedCampaign = JsonConvert.SerializeObject(SelectedCampaign);
                streamWriter.Write(stringSelectedCampaign);
            }
        }


        //
        //Deletes the selected file.
        //
        public static void DeleteCampaignData()
        {
            WorkingDirectory = WorkingDirectory + @"\" + SelectedCampaign.FileTitle + ".json";
            File.Delete(WorkingDirectory);
        }
    }
}
