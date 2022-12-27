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
    /// Logique d'interaction pour BorrowPlayerPage.xaml
    /// </summary>
    public partial class BorrowPlayerPage : Page
    {
        Classes.Player player;

        public BorrowPlayerPage(Classes.Player play)
        {
            InitializeComponent();
            List<Loan> loans = Loan.GetPlayerLoans(play.Id);
            List<Loan> pendingLoans = Loan.GetPlayerPendingLoans(play.Id);
            player = play;

            if (loans.Count == 0)
            {
                LoansLabel.Visibility = Visibility.Collapsed;
                dataGridLoan.Visibility = Visibility.Collapsed;
            }
            if (pendingLoans.Count == 0)
            {
                PendingLoansLabel.Visibility = Visibility.Collapsed;
                dataGridPendingLoan.Visibility = Visibility.Collapsed;
            }
            if (pendingLoans.Count == 0 && loans.Count == 0){
                MessageBox.Show("Vous ne posséder aucune location", "Pas de location", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                LoansLabel.Visibility = Visibility.Collapsed;
                dataGridLoan.Visibility = Visibility.Collapsed;
                PendingLoansLabel.Visibility = Visibility.Collapsed;
                dataGridPendingLoan.Visibility = Visibility.Collapsed;
            }
            dataGridLoan.ItemsSource = loans;
            dataGridPendingLoan.ItemsSource = pendingLoans;    
        }

        private void GiveBackGame(object sender, RoutedEventArgs e)
        {
            Loan loan = (Loan)dataGridLoan.SelectedItem;
            DateTime endDate = (DateTime)loan.EndDate;
            TimeSpan days = endDate.Subtract(DateTime.Now);
            
            
            MessageBoxResult res= MessageBox.Show("Etes vous certain de vouloir rendre ce jeux ?", "Fin de l'emprunt", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (res)
            { 
                case MessageBoxResult.Yes:

                    if(days.Days>=0)
                    {
                        bool desactivateLoan = Loan.EndLoan(loan);
                        if (desactivateLoan)
                        {
                            MessageBox.Show("Votre emprunt est terminé", "Validation");
                        }
                        List<Booking> bookings = loan.Copy.GetBookingsForCopy();
                        if (bookings.Count == 0)
                        {
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
                            newPendingLoan = new Loan(loan.Copy.Owner, priorBooking.Booker, loan.Copy);

                        }
                        else if (bookings.Count == 1)
                        {
                            newPendingLoan = new Loan(loan.Copy.Owner, bookings[0].Booker, loan.Copy);
                        }
                        newPendingLoan = newPendingLoan.InsertPendingLoan();
                    }
                    else if (days.Days<0)
                    {
                        int penalty = 5 * Math.Abs(days.Days) + (loan.Copy.VideoGame.CreditCost * (Math.Abs(days.Days) / 7 + 1));
                        int newCreditBorrower = loan.Borrower.Credit - penalty;
                        int newCreditLender = loan.Lender.Credit + penalty;
                        bool verifUpdateBorrower = Classes.Player.UpdateValueCredit(loan.Borrower, newCreditBorrower);
                        bool verifUpdateLender = Classes.Player.UpdateValueCredit(loan.Lender, newCreditLender);
                        bool desactivateLoan = Loan.EndLoan(loan);

                        if (verifUpdateBorrower && verifUpdateLender && desactivateLoan)
                        {
                            MessageBox.Show($"Votre emprunt est fini depuis {Math.Abs(days.Days)} jours \nUne penalité de {penalty} crédits vous sera appliqué", "Retard de l'échéance");
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void ConfirmLoan_Click(object sender, RoutedEventArgs e)
        {
            Loan loan = (Loan)dataGridPendingLoan.SelectedItem;

            if(Classes.Player.LoanAllowed(player))
            {
                ConfirmLoanWindow confirmLoanWindow = new ConfirmLoanWindow(loan);
                confirmLoanWindow.Show();
            }
            else
            {
                MessageBox.Show("Votre nombre de crédit n'est pas suffisant !", "Emprunt impossible");
            }
           
        }

        private void RefuseLoan_Click(object sender, RoutedEventArgs e)
        {
            Loan loan = (Loan)dataGridPendingLoan.SelectedItem;
            if (loan == null)
            {
                return;
            }
            if (loan.Delete())
            {
                MessageBox.Show("Location refusé!");
            }
        }
    }
}
