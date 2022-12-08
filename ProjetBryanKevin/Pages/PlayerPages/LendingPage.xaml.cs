using ProjetBryanKevin.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ProjetBryanKevin.Pages.PlayerPages
{
    /// <summary>
    /// Logique d'interaction pour LoanPage.xaml
    /// </summary>
    public partial class LendingPage : Page
    {
        public LendingPage()
        {
            InitializeComponent();
            List<VideoGame> approvedVideoGames= VideoGame.GetApprovedVideoGames();
            GameNames.ItemsSource = approvedVideoGames;
        }

        private void Validate_Click(object sender, RoutedEventArgs e)
        {
            if(GameNames.SelectedItem == null) { return; }

        }
        private void GameSelection_Changed(object sender, SelectionChangedEventArgs e)
        {
            VideoGame videoGame = (VideoGame)GameNames.SelectedItem;
            CreditCost.Text = videoGame.CreditCost.ToString();
            Validate.Visibility = Visibility.Visible;
        }

        private void AddGame_Click(object sender, RoutedEventArgs e)
        {
            AddGameWindow addGameWindow = new AddGameWindow();
            addGameWindow.Show();
            InitializeComponent();
        }
    }
}
