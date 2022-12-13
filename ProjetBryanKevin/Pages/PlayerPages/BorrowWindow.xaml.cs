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
        private Classes.Player lender;
        int borrowCost;

       
        public BorrowWindow(Copy copy, Classes.Player lender)
        {
            InitializeComponent();
            this.copy = copy;
            this.lender = lender;
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
                Loan newLoan = new Loan(DateTime.Now, (DateTime)endDate, true, lender, copy.Player, copy);
                if (newLoan.Insert() != null)
                {
                    int newCredit = copy.Player.Credit - borrowCost;
                    MessageBox.Show("Votre emprunt est confirmé", "Emprunt confirmé", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    bool verifUpdate =  Classes.Player.UpdateValueCredit(copy.Player, newCredit);
                    
                    if (verifUpdate==true)
                    {
                        MessageBox.Show("Votre solde de crédit a été mit à jour");
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
   
            //TODO addition for lender
        }

        private void EndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = EndDate.SelectedDate.Value;
            TimeSpan duration = endDate.Subtract(startDate);
            borrowCost = Loan.CalculateBalance(startDate, endDate, copy);
            LoanCost.Text = borrowCost.ToString();
        }
    }
}
