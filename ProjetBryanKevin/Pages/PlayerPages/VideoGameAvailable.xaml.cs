using ProjetBryanKevin.Classes;
using ProjetBryanKevin.Pages.PlayerPages;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace ProjetBryanKevin.Pages.Player
{
    /// <summary>
    /// Logique d'interaction pour VideoGameAvailable.xaml
    /// </summary>
    public partial class VideoGameAvailable : Page
    {

        bool verifCredit = true;
        Classes.Player player;
        public VideoGameAvailable(Classes.Player play)
        {
            InitializeComponent();
            List<Copy> copies = Copy.GetCopy();
            dataGridVideoGame.ItemsSource = copies;
            player = play;

            Credit.Text = play.Credit.ToString();

            //TODO credit not updated when the appli runs => do binding

            if (play.Credit <= 0)
            {
                verifCredit = false;
            }
        }

        private void ButtonBooking(object sender, RoutedEventArgs e)
        {
            Copy copy = (Copy)dataGridVideoGame.SelectedItem;
            if (verifCredit)
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
            else if (!verifCredit)
            {
                MessageBox.Show("Votre nombre de crédit n'est pas suffisant !", "Reservation impossible", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void ButtonBorrow(object sender, RoutedEventArgs e)
        {
            Copy copy = (Copy)dataGridVideoGame.SelectedItem;
            if (verifCredit)
            {
               MessageBoxResult result= MessageBox.Show("Etes vous certain de vouloir emprunter ce jeux ?", "Validation", MessageBoxButton.YesNo, MessageBoxImage.Question);
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
            else if(!verifCredit)
            {
                MessageBox.Show("Votre nombre de crédit n'est pas suffisant !", "Emprunt impossible", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
