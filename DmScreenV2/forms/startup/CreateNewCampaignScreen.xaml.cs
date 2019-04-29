﻿using System;
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


        //
        //User chose to create a new campaign from scratch.
        //
        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                desiredCampaign = new CampaignObject();
                desiredCampaign.FileTitle = txtTitle.Text;
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


        //
        //User selected an existing campaign in the campaign list screen.
        //
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


        //
        //The user doesn't want to make a new campaign.
        //
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            CloseForm("No campaign made!");
        }


        //
        //Shows a message then closes the form.
        //
        private void CloseForm(string message)
        {
            MessageBox.Show(message);
            this.listScreen.RefreshCampaignList();
            this.Close();
        }
    }
}