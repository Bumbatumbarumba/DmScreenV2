using DmScreenV2.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DmScreenV2.forms;
using DmScreenV2.forms.startup;
using DmScreenV2.forms.tools;
using DmScreenV2.forms.characters;
using System.Timers;

namespace DmScreenV2.forms
{
    /// <summary>
    /// Interaction logic for MainInterface.xaml
    /// </summary>
    public partial class MainInterface : Window
    {
        private bool clickedExit = false;
        private Timer timer = new Timer();

        public MainInterface()
        {
            InitializeComponent();
            InitDmScreen();
            InitEvents();
            //CampaignDataService.SaveCampaignData(); //saves the last accessed date in case app closes without saving.
        }


        /// <summary>
        /// Changes the appearance based on the campaign the user selected.
        /// </summary>
        public void InitDmScreen()
        {
            frmMainInterface.Title = CampaignDataService.SelectedCampaign.Title;
        }


        /// <summary>
        /// Initializes all custom events.
        /// </summary>
        public void InitEvents()
        {
            CampaignDataService.DataSaved += this.OnDataSaved;

            timer.Elapsed += (object sender, ElapsedEventArgs eventArgs) => { timer.Stop(); };
        }


        //=========================GENERAL=========================
        private void ListOfSkills_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BattleMap_Click(object sender, RoutedEventArgs e)
        {
            BattleMap battleMap = new BattleMap
            {
                Visibility = Visibility.Visible,
                IsEnabled = true
            };
        }

        private void MusicPlayer_Click(object sender, RoutedEventArgs e)
        {
            MusicPlayer musicPlayer = new MusicPlayer
            {
                Visibility = Visibility.Visible,
                IsEnabled = true
            };
        }

        private void Dice_Click(object sender, RoutedEventArgs e)
        {
            Dice dice = new Dice
            {
                Visibility = Visibility.Visible,
                IsEnabled = true
            };
        }

        private void ImageGallery_Click(object sender, RoutedEventArgs e)
        {

        }


        //=========================MAP=========================
        private void CreateMap_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditMap_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ViewMap_Click(object sender, RoutedEventArgs e)
        {

        }


        //=========================FILL LAND=========================
        private void CreateTowns_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditTowns_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ViewTowns_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateShops_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditShops_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ViewShops_Click(object sender, RoutedEventArgs e)
        {

        }


        //=========================CHARACTERS=========================
        private void CreateNpc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreatePlayers_Click(object sender, RoutedEventArgs e)
        {
            CreatePlayer cp = new CreatePlayer()
            {
                Visibility = Visibility.Visible,
                IsEnabled = true
            };

        }

        private void ViewCharacters_Click(object sender, RoutedEventArgs e)
        {

        }


        //=========================SETTINGS=========================
        private void PlayMode_Clicked(object sender, RoutedEventArgs e)
        {

        }


        private void EditMode_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void Help_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Clicked(object sender, RoutedEventArgs e)
        {
            CampaignDataService.SaveCampaignData();
            if (CampaignDataService.SelectedCampaign.WasFileSaveSuccessful)
                MessageBox.Show("Save Successful.");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Clicked(object sender, RoutedEventArgs e)
        {
            clickedExit = true;
            CampaignDataService.SaveCampaignData();
            ListOfCampaignsScreen exiting = new ListOfCampaignsScreen();
            exiting.Visibility = Visibility.Visible;
            exiting.IsEnabled = true;
            this.Close();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMainInterface_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ExitMessage(clickedExit))
            {
                e.Cancel = true;
            }
            CampaignDataService.SaveCampaignData();
        }

        private bool ExitMessage(bool clickedExit)
        {   
            if (clickedExit)
            {
                return clickedExit;
            }
            else
            {
                return (MessageBox.Show("Are you sure you would like to exit?", "Close DM Screen?",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes);
            }
        }


        //=========================CUSTOM EVENTS=========================
        /// <summary>
        /// Event handler for when data gets saved; creates a little icon that indicates if a data save was successful.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void OnDataSaved(object source, EventArgs e)
        {
            imgSaveStatus.Source = new BitmapImage(new Uri(DirectoryManagerService.WorkingDirectory + @"resources\images\dataSaved.png"));
            imgSaveStatus.InvalidateVisual();
            timer.Interval = 5000;
            timer.Start();
            imgSaveStatus.Source = new BitmapImage(new Uri(DirectoryManagerService.WorkingDirectory + @"resources\images\dataNotSaved.png"));
            imgSaveStatus.InvalidateVisual();
        }

    }
}
