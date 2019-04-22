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
using DmScreenV2.forms.tools;
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
            //DELETE THIS
            TestingStuff();
        }


        //THIS IS ONLY FOR TESTING STUFF
        //DELETE THIS EVENTUALLY
        public void TestingStuff()
        {
            //BattleMap test = new BattleMap();
            //test.Visibility = Visibility.Visible;
            //test.IsEnabled = true;

            //CampaignDataService.CreateCampaignFile("test2", "bartosz");
            //CampaignDataService.CreateCampaignFile("joachim smells", "bartosz");
            //CampaignDataService.GetCampaignData("test");
            //CampaignDataService.SelectedCampaign.Title = "eeeee";
            //CampaignDataService.SaveCampaignData();
            //DirectoryManagerService.InitializeAllDirectories();
            //CampaignDataService.GetAllCampaigns();

            foreach (var camp in CampaignDataService.GetAllCampaigns())
            {
                Console.WriteLine(camp.Title);
            }
        }
    }
}
