using ProjetBryanKevin.Classes;
using System;
using System.Windows;
using System.Windows.Controls;


namespace ProjetBryanKevin.Pages.PlayerPages
{
    /// <summary>
    /// Logique d'interaction pour ConfirmLoanWindow.xaml
    /// </summary>
    public partial class ConfirmLoanWindow : Window
    {
        Loan loan;
        int borrowCost;
        public ConfirmLoanWindow(Loan loan)
        {
            InitializeComponent();
            this.loan = loan;
            NameGame.Text = loan.Copy.VideoGame.Name;
            ConsoleName.Text = loan.Copy.VideoGame.Console;
            CreditCost.Text = loan.Copy.VideoGame.CreditCost.ToString();
            StartDate.Text = DateTime.Now.ToString();
        }

        private void Validation_Click(object sender, RoutedEventArgs e)
        {
            DateTime? endDate = EndDate.SelectedDate;

            if (endDate.HasValue)
            {
                Loan newLoan = new Loan(loan.IdLoan, DateTime.Now, (DateTime)endDate, true, loan.Lender, loan.Borrower, loan.Copy);
                if (newLoan.Update())
                {
                    Booking oldBooking = new Booking(loan.Borrower, loan.Copy.VideoGame);
                    if(!oldBooking.Delete())
                    {
                        MessageBox.Show("Une erreur est survenue");
                        this.Close();
                        return;
                    }
                    int newCreditBorrower = loan.Borrower.Credit - borrowCost;
                    int newCreditLender = loan.Lender.Credit + borrowCost;
                    MessageBox.Show("Votre emprunt est confirmé", "Emprunt confirmé", MessageBoxButton.OK, MessageBoxImage.Information);
                    bool verifUpdate = Classes.Player.UpdateValueCredit(loan.Borrower, newCreditBorrower) && Classes.Player.UpdateValueCredit(loan.Lender, newCreditLender);
                    if (verifUpdate)
                    {
                        MessageBox.Show("Votre solde de crédit a été mis à jour");
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Une erreur est survenue lors de votre validation", "Erreur de validation", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez selectionner une date pour la fin de votre location !", "Date non séléctionnée", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void EndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = EndDate.SelectedDate.Value;
            TimeSpan duration = endDate.Subtract(startDate);
            borrowCost = Loan.CalculateBalance(startDate, endDate, loan.Copy);
            LoanCost.Text = borrowCost.ToString();
        }
    }
}
