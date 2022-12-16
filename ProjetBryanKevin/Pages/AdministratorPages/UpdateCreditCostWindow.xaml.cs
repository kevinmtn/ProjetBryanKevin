using ProjetBryanKevin.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjetBryanKevin.Pages.AdministratorPages
{
    /// <summary>
    /// Logique d'interaction pour UpdateCreditCostWindow.xaml
    /// </summary>
    public partial class UpdateCreditCostWindow : Window
    {
        private VideoGame videoGame;

        public UpdateCreditCostWindow(VideoGame videoGame)
        {
            InitializeComponent();
            this.videoGame = videoGame;
            GameName.Text = videoGame.Name;
            ConsoleType.Text = videoGame.Console;
            CreditCost.Text = videoGame.CreditCost.ToString();
        }

        private void UpdateCredit_Click(object sender, RoutedEventArgs e)
        {
            if(CreditCost.Text == "")
            {
                return;
            }
            int newCreditCost = Int32.Parse(CreditCost.Text);
            VideoGame updatedVideoGame = new VideoGame(videoGame.IdVideoGame, videoGame.Name, newCreditCost, videoGame.Console);
            updatedVideoGame.Update();
            MessageBox.Show("Changement effectué!");
            this.Close();

        }

        private void ValidateInputCost(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
