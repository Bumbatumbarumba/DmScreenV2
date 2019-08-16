using DmScreenV2.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DmScreenV2.services
{
    class MusicDataService
    {
        /// <summary>
        /// The most recently selected music.
        /// </summary>
        public static MusicObject SelectedMusic { get; set; }
        private static MediaPlayer mediaPlayer = new MediaPlayer();


        public static void CheckForSavedMusic()
        {

        }


        /// <summary>
        /// Adds music to the campaign data file
        /// http://web.archive.org/web/20100118163744/http://thoughtpad.net/alan-dean/cs-xml-documentation.html#param
        /// </summary>
        public static void AddMusicToList()
        {


        }


        /// <summary>
        /// Plays the selected track.
        /// </summary>
        public static void PlaySelected()
        {
            try
            {
                if (SelectedMusic.IsLocalFile)
                {
                    mediaPlayer.Open(new Uri(SelectedMusic.MusicLocation));
                    mediaPlayer.Play();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error playing audio file.");
                Console.WriteLine(e.Message);
            }
        }


        /// <summary>
        /// Pauses the selected track.
        /// </summary>
        public static void PauseSelected()
        {
            mediaPlayer.Pause();
        }


        /// <summary>
        /// Stops the selected track.
        /// </summary>
        public static void StopSelected()
        {

        }


        /// <summary>
        /// Goes to the next item in the music list that is saved in campaign 
        /// </summary>
        public static void NextTrack()
        {

        }


        public static void PreviousTrack()
        {

        }


        /// <summary>
        /// 
        /// </summary>
        private void ShowRedirectMessage()
        {

        }
    }
}
