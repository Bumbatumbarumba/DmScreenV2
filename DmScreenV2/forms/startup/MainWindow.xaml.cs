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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using DmScreenV2.forms.startup;
using DmScreenV2.services;

namespace DmScreenV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DirectoryManagerService.InitializeAllDirectories();
        }


        public void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnViewList_Click(object sender, RoutedEventArgs e)
        {
            ListOfCampaignsScreen listOfCampaigns = new ListOfCampaignsScreen();
            listOfCampaigns.IsEnabled = true;
            listOfCampaigns.Visibility = Visibility.Visible;
            this.Close();
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
