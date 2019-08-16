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

namespace DmScreenV2.forms.tools
{
    /// <summary>
    /// Interaction logic for Dice.xaml
    /// </summary>
    public partial class Dice : Window
    {
        /// <summary>
        /// Quantity of dice.
        /// </summary>
        private int NumberOfDice = 1;
        /// <summary>
        /// Which faced dice was selected.
        /// </summary>
        private int SelectedDice = 4;
        /// <summary>
        /// Stores the results of the dice rolls.
        /// </summary>
        private int[] DiceResults;
        private int SumOfResult = 0;


        public Dice()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Event occurs when the user makes a selection; takes the dice number from the
        /// content of the radio button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Selection_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton selection = sender as RadioButton;
            SelectedDice = Convert.ToInt16(selection.Content.ToString().Substring(1));
            Console.WriteLine(SelectedDice);
        }


        private void BtnRoll_Click(object sender, RoutedEventArgs e)
        {
            ParseTextbox();
            GenerateRandomNumbers();
            lblDiceResult.Content = "Result: " + SumOfResult;
        }


        /// <summary>
        /// If the textbox for dice quantity is empty, set it to 1.
        /// </summary>
        private void ParseTextbox()
        {
            if (txtDiceQuantity.Text == null || txtDiceQuantity.Text == "")
            {
                txtDiceQuantity.Text = "1";
            }

            NumberOfDice = Convert.ToInt16(txtDiceQuantity.Text);            
        }


        /// <summary>
        /// Creates the results array and the fills it with random numbers between
        /// one and the selected dice type (inclusively).
        /// </summary>
        private void GenerateRandomNumbers()
        {
            DiceResults = new int[NumberOfDice];
            Random rand = new Random();
            SumOfResult = 0;

            for (int i = 0; i < NumberOfDice; i++)
            {
                DiceResults[i] = rand.Next(1, SelectedDice + 1);
                SumOfResult += DiceResults[i];

                Console.WriteLine(DiceResults[i]);
            }
        }


        /// <summary>
        /// Draws the dice in the dice box.
        /// </summary>
        private void DrawDiceRolls()
        {
            //have the dice fit within the boundries of the dice box and at random rotation amounts.
        }
    }
}
