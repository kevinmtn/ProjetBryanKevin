using ProjetBryanKevin.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;



namespace ProjetBryanKevin.Pages.PlayerPages
{
    /// <summary>
    /// Logique d'interaction pour BookingPage.xaml
    /// </summary>
    public partial class BookingPage : Page
    {

        Classes.Player player;
        public BookingPage(Classes.Player player)
        {
            InitializeComponent();
            
            this.player = player;
            List<VideoGame> loanedGames = VideoGame.GetLoanedVideoGames(this.player);
            var bookableGames = from game in loanedGames where game.FindBookingByPlayerId(player) == null select game;
            
            bookableGames = bookableGames.GroupBy(game => new { game.Name, game.Console }).Select(g => g.First()).ToList();
            dataGridVideoGame.ItemsSource = bookableGames;
            int creditLeft = Classes.Player.GetCreditPlayer(player);
            CreditLeft.Text = creditLeft.ToString();
        }

        

        private void Reservation_Click(object sender, RoutedEventArgs e)
        {
            VideoGame selectedVideoGame = (VideoGame)dataGridVideoGame.SelectedItem;

            if (!Classes.Player.LoanAllowed(player))
            {
                MessageBox.Show("Votre nombre de crédit n'est pas suffisant !", "Reservation impossible", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            MessageBoxResult result = MessageBox.Show("Etes vous certain de vouloir reserver ce jeux ?", "Validation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Booking newBooking = new Booking(player, selectedVideoGame, DateTime.Now);
                    if(newBooking.Insert() != null)
                    {
                        MessageBox.Show("Votre réservation est confirmé");
                    }
                    else
                    {
                        MessageBox.Show("Un problème est survenu lors de votre réservation");
                    };
                    break;
                default:
                    break;
            }
            
        }
    }
}
