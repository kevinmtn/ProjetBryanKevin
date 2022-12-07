using ProjetBryanKevin.Classes;
using ProjetBryanKevin.Pages.Player;
using ProjetBryanKevin.Pages.PlayerPages;
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

namespace ProjetBryanKevin
{
    /// <summary>
    /// Logique d'interaction pour PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {

        Player player;
    
        public PlayerWindow(Player player)
        {
            InitializeComponent();
            this.player = player;
            WelcomeText.Text = "Bienvenue " + this.player.UserName;
        }

        private void menuDisconnect(Object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Vous vous êtes déconnecté","Deconnection",MessageBoxButton.OK, MessageBoxImage.Information);
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void menuHome(Object sender, RoutedEventArgs e)
        {
            Main.Content = new PlayerHome(player);
        }

        private void seeVideoGames(Object sender, RoutedEventArgs e)
        {
            Main.Content = new VideoGameAvailable();
        }

        private void loanVideoGame(Object sender, RoutedEventArgs e)
        {
            Main.Content = new LoanPage();
        }

        private void seePlayerBookingsPage(Object sender, RoutedEventArgs e)
        {
            Main.Content = new PlayerBookingsPage(player.Id);
        }
    }
}
