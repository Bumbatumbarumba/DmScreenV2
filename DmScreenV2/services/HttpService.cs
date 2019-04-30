using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DmScreenV2.services
{
    class HttpService
    {
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



    }
}
