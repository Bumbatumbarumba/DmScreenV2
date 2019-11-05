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
    /// Interaction logic for CreateNewCampaignScreen.xaml
    /// </summary>
    public partial class CreateNewCampaignScreen : Window
    {
        private ListOfCampaignsScreen listScreen;
        private CampaignObject desiredCampaign;

        /// <summary>
        /// Creates an instance of the screen that will allow for the user to create a campaign.
        /// </summary>
        /// <param name="listScreen"> Passes the screen to get parameters from it.</param>
        /// <param name="isEditMode"> If isEditMode is true, then we pass the created campaign's parameters to the CreateNewCampaignScreen.</param>
        public CreateNewCampaignScreen(ListOfCampaignsScreen listScreen, bool isEditMode)
        {
            InitializeComponent();
            this.listScreen = listScreen;
            if (isEditMode)
            {
                txtAuthor.Text = CampaignDataService.SelectedCampaign.Author;
                txtTheme.Text = CampaignDataService.SelectedCampaign.Theme;
                txtTitle.Text = CampaignDataService.SelectedCampaign.Title;
                txtImageDir.Text = CampaignDataService.SelectedCampaign.CampaignImageFileLocation;
                btnEdit.Visibility = Visibility.Visible;
                btnEdit.Visibility = Visibility.Visible;
                btnEdit.IsEnabled = true;
                btnCreate.Visibility = Visibility.Hidden;
                btnCreate.IsEnabled = false;
            }
        }


        /// <summary>
        /// User chose to create a new campaign from scratch.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields())
            {
                try
                {
                    desiredCampaign = new CampaignObject();
                    desiredCampaign.FileTitle = txtTitle.Text.Replace(' ', '_');
                    desiredCampaign.Title = txtTitle.Text;
                    desiredCampaign.Author = txtAuthor.Text;
                    desiredCampaign.Theme = txtTheme.Text;
                    desiredCampaign.CampaignImageFileLocation = txtImageDir.Text;

                    CampaignDataService.CreateCampaignFile(desiredCampaign);
                    CloseForm("New file created and saved!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else
            {
                MessageBox.Show("Please ensure that the title, author, and theme fields are not empty!");
            }
        }


        /// <summary>
        /// User selected an existing campaign in the campaign list screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CampaignDataService.SelectedCampaign.Title = txtTitle.Text;
                CampaignDataService.SelectedCampaign.Author = txtAuthor.Text;
                CampaignDataService.SelectedCampaign.Theme = txtTheme.Text;
                CampaignDataService.SelectedCampaign.CampaignImageFileLocation = txtImageDir.Text;

                CampaignDataService.SaveCampaignData();
                CloseForm("Changes saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// Cancel button event handler; the user doesn't want to make a new campaign or edit the data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Shows a message then closes the form.
        /// </summary>
        /// <param name="message"></param>
        private void CloseForm(string message)
        {
            MessageBox.Show(message);
            this.listScreen.RefreshCampaignList();
            this.Close();
        }
        

        /// <summary>
        /// Checks if the title, author, and text field are empty or not.
        /// </summary>
        /// <returns>True if the title, author, and text field are not empty; otherwise false</returns>
        private bool ValidateFields()
        {
            bool isValid = false;

            if (txtTitle.Text != "" && txtAuthor.Text != "" && txtTheme.Text != "")
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
