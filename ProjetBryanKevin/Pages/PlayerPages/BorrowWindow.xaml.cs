using ProjetBryanKevin.Classes;
using ProjetBryanKevin.DAO;
using ProjetBryanKevin.Factory;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;



namespace ProjetBryanKevin.Pages.PlayerPages
{
    /// <summary>
    /// Logique d'interaction pour BorrowWindow.xaml
    /// </summary>
    public partial class BorrowWindow : Window
    {
        private Copy copy;
        private Classes.Player borrower;
        private int loanCost;
       

        public BorrowWindow(Copy copy, Classes.Player borrower)
        {
            InitializeComponent();
            this.copy = copy;
            this.borrower = borrower;
            NameGame.Text = copy.VideoGame.Name;
            ConsoleName.Text = copy.VideoGame.Console;
            CreditCost.Text = copy.VideoGame.CreditCost.ToString();
            StartDate.Text = DateTime.Now.ToString();
            
        }

        private void Validation_Click(object sender, RoutedEventArgs e)
        {
            DateTime? endDate = EndDate.SelectedDate;

            if (endDate.HasValue)
            {
                Loan newLoan = new Loan(1, DateTime.Now, (DateTime)endDate, true, borrower, copy.Player, copy);
                if (newLoan.Insert != null)
                {
                    MessageBox.Show("Votre emprunt est confirmé", "Emprunt confirmé", MessageBoxButton.OK, MessageBoxImage.Information);
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
   
            //TODO substract credit for borrower and addition for lender
        }

        private void EndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = EndDate.SelectedDate.Value;
            int borrowCost = Loan.CalculateBalance(startDate, endDate, copy);
            LoanCost.Text = borrowCost.ToString();
        }
    }
}
