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
using DmScreenV2.classes;
using DmScreenV2.services;

namespace DmScreenV2.forms.characters
{
    /// <summary>
    /// Interaction logic for CreatePlayer.xaml
    /// </summary>
    public partial class CreatePlayer : Window
    {
        private Dictionary<string, string> textboxDescs = new Dictionary<string, string>();
        private CharacterObject newChar;
        private bool intentionallyClosed = false;

        public CreatePlayer()
        {
            InitializeComponent();
            InitFormEvents();
            HttpService.GetClasses();
        }


        /// <summary>
        /// Called when the user goes to edit an existing character; it populates
        /// the form with the data of the existing character instead of showing
        /// the default empty one.
        /// </summary>
        /// <param name="isEditMode"></param>
        public CreatePlayer(bool isEditMode)
        {
            InitializeComponent();
            InitFormEvents();
            HttpService.GetClasses();
        }


        /// <summary>
        /// Makes it so that when the user enters or exits the textbox, the
        /// desc disappears or appears (if it is empty).
        /// </summary>
        private void InitFormEvents()
        {
            string cname = "Character Name...";
            string pname = "Player Name...";
            string race = "Race...";
            string back = "Background...";
            string alig = "Alignment...";
            string ac = "AC...";
            string init = "Init...";
            string speed = "Speed...";
            string maxhp = "Max HP...";
            string insp = "Inspiration...";

            txtCharacterName.GotFocus += RemoveText;
            txtPlayerName.GotFocus += RemoveText;
            txtRace.GotFocus += RemoveText;
            txtBackground.GotFocus += RemoveText;
            txtAlignment.GotFocus += RemoveText;
            txtArmorClass.GotFocus += RemoveText;
            txtInitiativeBonus.GotFocus += RemoveText;
            txtSpeed.GotFocus += RemoveText;
            txtMaxHp.GotFocus += RemoveText;
            txtInspiration.GotFocus += RemoveText;

            txtCharacterName.LostFocus += (sender, e) => { AddDesc(sender, e, cname); };
            txtPlayerName.LostFocus += (sender, e) => { AddDesc(sender, e, pname); };
            txtRace.LostFocus += (sender, e) => { AddDesc(sender, e, race); };
            txtBackground.LostFocus += (sender, e) => { AddDesc(sender, e, back); };
            txtAlignment.LostFocus += (sender, e) => { AddDesc(sender, e, alig); };
            txtArmorClass.LostFocus += (sender, e) => { AddDesc(sender, e, ac); };
            txtInitiativeBonus.LostFocus += (sender, e) => { AddDesc(sender, e, init); };
            txtSpeed.LostFocus += (sender, e) => { AddDesc(sender, e, speed); };
            txtMaxHp.LostFocus += (sender, e) => { AddDesc(sender, e, maxhp); };
            txtInspiration.LostFocus += (sender, e) => { AddDesc(sender, e, insp); };
        }


        /// <summary>
        /// Clears the textbox when the user enters it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RemoveText(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;

            if (temp.Text.Contains("..."))
            {
                temp.Text = "";
            }
        }


        /// <summary>
        /// Re-adds a description to a textbox if the textbox is empty and a
        /// user enters it; pass a desc for it to populate the textbox with.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="desc"></param>
        public void AddDesc(object sender, EventArgs e, string desc)
        {
            TextBox temp = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(temp.Text))
            {
                temp.Text = desc;
            }
        }


        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
        /// <summary>
        /// First checks if there isn't a character with that name already saved;
        /// if there is, then it overwrites it, otherwise it saves a new instance.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            //Create a new instance of the character.
            newChar = new CharacterObject();
            newChar.CharacterName = txtCharacterName.Text;
            newChar.PlayerName = txtPlayerName.Text;
            newChar.Race = txtRace.Text;
            newChar.Background = txtBackground.Text;
            newChar.Alignment = txtAlignment.Text;
            newChar.ArmorClass = Convert.ToInt16(txtArmorClass.Text);
            newChar.InitiativeBonus = Convert.ToInt16(txtInitiativeBonus.Text);
            newChar.Speed = Convert.ToInt32(txtSpeed.Text);
            newChar.MaxHp = Convert.ToInt32(txtMaxHp.Text);
            newChar.Inspiration = Convert.ToInt32(txtInspiration.Text);

            var searchResult = CampaignDataService.SelectedCampaign.CharacterList.Find(character => character.CharacterName == newChar.CharacterName);
            if (searchResult == null)
            {
                //If they don't already exist, add them to the list.
                CampaignDataService.SelectedCampaign.CharacterList.Add(newChar);
            }
            else
            {
                //Otherwise overwrite the existing one.
                searchResult = newChar;
            }

            intentionallyClosed = true;
            this.Close();
        }


        /// <summary>
        /// If the form was not intentionally closed, then a message appears prompting the user
        /// to ensure that they meant to close it, then closes it if they did.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WinCreatePlayer_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!intentionallyClosed)
            {
                //If the user clicks "no" it cancels the closing.
                if (!(MessageBox.Show("Are you sure you would like to exit? Your character will not be saved!", "Close Player Creator?",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes))
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
