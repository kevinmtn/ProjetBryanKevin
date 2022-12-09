using ProjetBryanKevin.Classes;
using ProjetBryanKevin.DAO;
using ProjetBryanKevin.Factory;
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
        Classes.Player lender = null;
        public LendingPage(Classes.Player lender)
        {
            InitializeComponent();
            this.lender = lender;
            List<VideoGame> approvedVideoGames = VideoGame.GetApprovedVideoGames();
            GameNames.ItemsSource = approvedVideoGames;
        }

        private void Validate_Click(object sender, RoutedEventArgs e)
        {
            if(GameNames.SelectedItem == null) 
            {
                return; 
            }
            Copy newCopy = new Copy((VideoGame)GameNames.SelectedItem, lender);
            if (newCopy.Insert() != null)
            {
                MessageBox.Show("Votre copie du jeu " + newCopy.VideoGame.Name + " sur " + newCopy.VideoGame.Console + " a bien été ajouté!\n Un admin vérifiera votre ajout rapidement!");
            }


        }
        private void GameSelection_Changed(object sender, SelectionChangedEventArgs e)
        {
            VideoGame videoGame = (VideoGame)GameNames.SelectedItem;
            CreditCost.Text = videoGame.CreditCost.ToString();
            Validate.Visibility = Visibility.Visible;
        }

        private void AddGame_Click(object sender, RoutedEventArgs e)
        {
            AddGameWindow addGameWindow = new AddGameWindow(lender);
            addGameWindow.Show();
            InitializeComponent();
        }
    }
}
