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

namespace DmScreenV2.forms
{
    /// <summary>
    /// Interaction logic for MainInterface.xaml
    /// </summary>
    public partial class MainInterface : Window
    {
        public MainInterface()
        {
            InitializeComponent();
            InitDmScreen();
            InitEvents();
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
            //prolly not needed? tbd
        }

        

        //=========================GENERAL=========================

        private void BattleMap_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MusicPlayer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Dice_Click(object sender, RoutedEventArgs e)
        {

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

        private void Exit_Clicked(object sender, RoutedEventArgs e)
        {
            ListOfCampaignsScreen exiting = new ListOfCampaignsScreen();
            exiting.Visibility = Visibility.Visible;
            exiting.IsEnabled = true;
            this.Close();
        }
    }
}
