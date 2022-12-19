using ProjetBryanKevin.Classes;
using ProjetBryanKevin.Pages.PlayerPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace ProjetBryanKevin.Pages.Player
{
    /// <summary>
    /// Logique d'interaction pour VideoGameAvailable.xaml
    /// </summary>
    public partial class VideoGameAvailable : Page
    {

        Classes.Player player;
        public VideoGameAvailable(Classes.Player player)
        {
            InitializeComponent();
            List<Copy> copies = Copy.GetCopy(player);
            dataGridVideoGame.ItemsSource = copies;
            this.player = player;
            CreditLeft.Text = player.Credit.ToString();
        }

        private void ButtonBooking(object sender, RoutedEventArgs e)
        {
            Copy copy = (Copy)dataGridVideoGame.SelectedItem;
            
            if (Classes.Player.LoanAllowed(player))
            {
                MessageBoxResult result = MessageBox.Show("Etes vous certain de vouloir reserver ce jeux ?", "Validation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        BorrowWindow borrow = new BorrowWindow(copy, player);
                        borrow.Show();
                        break;

                    case MessageBoxResult.No:
                        break;

                    default:
                        break;
                }
            }
            else 
            {
                MessageBox.Show("Votre nombre de crédit n'est pas suffisant !", "Reservation impossible", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void ButtonBorrow(object sender, RoutedEventArgs e)
        {
            Copy copy = (Copy)dataGridVideoGame.SelectedItem;

            if (!copy.IsAvailable(copy))
            {
                if (Classes.Player.LoanAllowed(player))
                {
                    MessageBoxResult result = MessageBox.Show("Etes vous certain de vouloir emprunter ce jeux ?", "Validation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            BorrowWindow borrow = new BorrowWindow(copy, player);
                            borrow.Show();
                            break;

                        case MessageBoxResult.No:
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Votre nombre de crédit n'est pas suffisant !", "Emprunt impossible", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Le jeux n'est pas disponible pour le moment", "Jeux déja loué", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
