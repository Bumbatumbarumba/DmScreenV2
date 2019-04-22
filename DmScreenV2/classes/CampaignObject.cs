using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmScreenV2.classes
{
    class CampaignObject
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastAccessed { get; set; }
        public string[] MusicFileLocations { get; set; }
        public CharacterObject[] CharacterList { get; set; }
        public string CampaignImageFileLocation { get; set; }
    }
}
