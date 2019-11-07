using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DmScreenV2.services
{
    class HttpService
    {

        /*
         * NOTE TO SELF!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
         * 
         * HAVE ALL OF THE HTTP REQUESTS BE MADE AND STORED WHEN THE PROGRAM IS LAUNCHED INSTEAD
         * OF MAKING REDUNDANT CALLS!!!
         * 
         * PUT DATA INTO NEW STATIC CLASS FOR OTHER FORMS TO ACCESS
         *          -HttpDataService?
         * 
         */



        private const string API_BASE_URL = "http://dnd5eapi.co/api/";

        public static void GetAllMonsters()
        {
            try
            {
                WebRequest request = WebRequest.Create(API_BASE_URL + "monsters/");
                WebResponse response = request.GetResponse();
                //do other stuff lol
                //https://docs.microsoft.com/en-us/dotnet/framework/network-programming/how-to-request-data-using-the-webrequest-class
                //follow the above link
            }
            catch (Exception e)
            {
                //implement a specific request? figure out what error to catch?
                Console.WriteLine(e.ToString());
            }
        }

    
        //
        //Enter the keyword for monsters and it returns a list sorted in order of search results;
        //order is decreasing similarity to the searched word.
        //
        public static void SearchMonsterList(string searchWord)
        {
            //TO DO: change from void to something else, amongst other things.
        }


        /// <summary>
        /// Gets a list of classes and a url to get more info for a given class.
        /// </summary>
        /// <returns>A dict of strings containing "class":"url to class".></returns>
        public static Dictionary<string,string> GetClasses()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            try
            {
                WebRequest request = WebRequest.Create(API_BASE_URL + "classes/");
                WebResponse response = request.GetResponse();
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    JObject joResponse = JObject.Parse(reader.ReadToEnd());
                    JArray ojObject = (JArray)joResponse["results"];
                    
                    foreach (var item in ojObject)
                    {
                        result.Add(item[0].ToString(), item[1].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                //implement a specific request? figure out what error to catch?
                Console.WriteLine(e.ToString());
            }

            return result;
        }


    }
}
