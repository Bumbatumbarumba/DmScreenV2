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
using DmScreenV2.services;
using DmScreenV2.classes;

namespace DmScreenV2.forms.startup
{
    /// <summary>
    /// Interaction logic for ListOfCampaignsScreen.xaml
    /// </summary>
    public partial class ListOfCampaignsScreen : Window
    {
        public ListOfCampaignsScreen()
        {
            InitializeComponent();
            RefreshCampaignList();
        }


        //
        //Returns the user to the main start screen.
        //
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.IsEnabled = true;
            main.Visibility = Visibility.Visible;
            this.Close();
        }


        //
        //Creates the window for the user to add a new campaign.
        //
        private void BtnCreateNew_Click(object sender, RoutedEventArgs e)
        {
            CreateNewCampaignScreen newCamp = new CreateNewCampaignScreen(this, false);
            newCamp.ShowDialog();
        }


        //
        //Starts the selected campaign.
        private void BtnLaunchSelected_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(CampaignDataService.SelectedCampaign.Title);
        }


        //
        //Opens the CreateNewCampaignScreen, but to edit the existing campaign object
        //instead of creating a new one.
        //
        private void BtnEditSelected_Click(object sender, RoutedEventArgs e)
        {
            CreateNewCampaignScreen editCamp = new CreateNewCampaignScreen(this, true);
            editCamp.ShowDialog();
        }


        //
        //Deletes the selected campaign file and item from the list, then refreshes
        //the list.
        //
        private void BtnDeleteSelected_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you would like to delete this file? It cannot be undone!", 
                "Delete Campaign Entry?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CampaignDataService.DeleteCampaignData();
                RefreshCampaignList();
            }
        }


        //
        //Used to add the latest entry to the list of campaigns, when the user creates a new campaign.
        //
        public void RefreshCampaignList()
        {
            listboxListOfCampaigns.Items.Clear();
            foreach (var campaignEntry in CampaignDataService.GetAllCampaigns())
            {
                listboxListOfCampaigns.Items.Add(
                    ListItem(campaignEntry)
                    );
            }
            this.listboxListOfCampaigns.InvalidateVisual();
        }
        

        //
        //Creates a new canvas item to hold some pieces of data of all of the campaigns
        //in the campaigns directory.
        //
        private Canvas ListItem(CampaignObject newEntry)
        {
            Canvas campaignEntry = new Canvas {
                Width = 355,
                Height = 196,
                Visibility = Visibility.Visible,
                IsEnabled = true,
                Background = (Brush)new BrushConverter().ConvertFrom("#FFFFFF")
            };

            Label newEntryTitle = new Label
            {
                Visibility = Visibility.Visible,
                Content = newEntry.Title,
                FontSize = 16,
                Margin = new Thickness(10, 10, 0, 0),
                Width = 210,
                Height = 30
            };

            Label newEntryAuthor = new Label
            {
                Visibility = Visibility.Visible,
                Content = newEntry.Author,
                FontSize = 16,
                Margin = new Thickness(149, 46, 0, 0),
                Width = 210,
                Height = 30
            };

            Label newEntryTheme = new Label
            {
                Visibility = Visibility.Visible,
                Content = newEntry.Theme,
                FontSize = 16,
                Margin = new Thickness(149, 82, 0, 0),
                Width = 210,
                Height = 30
            };

            Label newEntryLastAccessedDate = new Label
            {
                Visibility = Visibility.Visible,
                Content = "Created On: " + newEntry.CreationDate.ToString("dd-MM-yyyy"),
                FontSize = 16,
                Margin = new Thickness(149, 118, 0, 0),
                Width = 210,
                Height = 30
            };

            Label newEntryCreationDate = new Label
            {
                Visibility = Visibility.Visible,
                Content = "Last Accessed: " + newEntry.LastAccessed.ToString("dd-MM-yyyy"),
                FontSize = 16,
                Margin = new Thickness(149, 154, 0, 0),
                Width = 210,
                Height = 30
            };

            //sets the image
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(newEntry.CampaignImageFileLocation);
            bi3.EndInit();

            Image selectionImage = new Image
            {
                Height = 128,
                Width = 128,
                Margin = new Thickness(10, 38, 0, 0),
                Source = bi3
            };

            campaignEntry.Children.Add(newEntryTitle);
            campaignEntry.Children.Add(newEntryAuthor);
            campaignEntry.Children.Add(newEntryTheme);
            campaignEntry.Children.Add(newEntryLastAccessedDate);
            campaignEntry.Children.Add(newEntryCreationDate);
            campaignEntry.Children.Add(selectionImage);


            campaignEntry.MouseDown += (sender, MouseButtonEventHandler) => { SelectedCampaignEntry(sender, MouseButtonEventHandler, newEntry); };


            return campaignEntry;
        }


        //
        //When the user clicks a selection from the list of campaigns, it enables some buttons and 
        //sets the selected campaign to be the one that will be loaded.
        //
        private void SelectedCampaignEntry(object sender, RoutedEventArgs e, CampaignObject selectedEntry)
        {
            btnLaunchSelected.IsEnabled = true;
            btnEditSelected.IsEnabled = true;
            btnDeleteSelected.IsEnabled = true;
            CampaignDataService.SelectedCampaign = selectedEntry;
        }
    }
}
