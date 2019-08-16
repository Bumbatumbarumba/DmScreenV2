using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmScreenV2.classes
{
    public class MusicObject
    {
        /// <summary>
        /// The user can give the song a title to make it easier to choose when to play it (eg, Town 1).
        /// </summary>
        public string GivenTitle { get; set; }

        /// <summary>
        /// Where to access the song (url or directory on the disk).
        /// </summary>
        public string MusicLocation { get; set; }

        /// <summary>
        /// Whether the file is a web link or saved locally.
        /// </summary>
        public bool IsLocalFile { get; set; }

        /// <summary>
        /// Prolly not needed.
        /// </summary>
        public int SongID { get; set; }
    }
}
