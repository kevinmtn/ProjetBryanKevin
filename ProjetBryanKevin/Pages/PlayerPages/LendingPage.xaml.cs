using ProjetBryanKevin.Classes;
using ProjetBryanKevin.DAO;
using ProjetBryanKevin.Factory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace ProjetBryanKevin.Pages.PlayerPages
{
    /// <summary>
    /// Logique d'interaction pour LoanPage.xaml
    /// </summary>
    public partial class LendingPage : Page
    {
        Classes.Player lender;
        public LendingPage(Classes.Player lender)
        {
            InitializeComponent();
            this.lender = lender;
            List<VideoGame> approvedVideoGames = VideoGame.GetApprovedVideoGames();
            GameNames.ItemsSource = approvedVideoGames;
        }

        private void Validate_Click(object sender, RoutedEventArgs e)
        {
            if (GameNames.SelectedItem == null)
            {
                return;
            }
            Copy newCopy = new Copy((VideoGame)GameNames.SelectedItem, lender);
            newCopy = newCopy.Insert();
            if (newCopy == null)
            {
                return;
            }
            var bookings = newCopy.GetBookingsForCopy();
          
            bookings = bookings.Where(booking => booking.Booker.Id != newCopy.Owner.Id).ToList();

            if (bookings.Count == 0)
            {
                MessageBox.Show("Votre copie du jeu " + newCopy.VideoGame.Name + " sur " + newCopy.VideoGame.Console + " a bien été ajouté!");
                return;
            }
            Loan newPendingLoan = null;
            if (bookings.Count > 1)
            {
                Booking priorBooking = bookings[0];
                for (int x = 1; x < bookings.Count(); x++)
                {
                    priorBooking = priorBooking.GetPriorityBooking(bookings[x]);
                }
                newPendingLoan = new Loan(newCopy.Owner, priorBooking.Booker, newCopy);
                
            }
            else if (bookings.Count == 1)
            {
                newPendingLoan = new Loan(newCopy.Owner, bookings[0].Booker, newCopy);   
            }
            
            newPendingLoan = newPendingLoan.InsertPendingLoan();
            
            if (newPendingLoan != null)
            {
                MessageBox.Show("Votre copie a été proposé à " + newPendingLoan.Borrower.Pseudo + " car il l'avait résérvé. En attente de confirmation de sa part!");
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
