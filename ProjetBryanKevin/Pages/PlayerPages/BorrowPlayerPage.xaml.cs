using ProjetBryanKevin.Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace ProjetBryanKevin.Pages.PlayerPages
{
    /// <summary>
    /// Logique d'interaction pour BorrowPlayerPage.xaml
    /// </summary>
    public partial class BorrowPlayerPage : Page
    {
      
        public BorrowPlayerPage(int idBorrower)
        {
            InitializeComponent();
            List<Loan> loans = Loan.GetPlayerLoan(idBorrower);
            dataGridLoan.ItemsSource = loans;

            if (loans.Count == 0)
            {
                MessageBox.Show("Vous ne posséder aucune location", "Pas de location", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void GiveBackGame(object sender, RoutedEventArgs e)
        {
            Loan loan = (Loan)dataGridLoan.SelectedItem;
            TimeSpan days = loan.EndDate.Subtract(DateTime.Now);
            MessageBoxResult res= MessageBox.Show("Etes vous certain de vouloir rendre ce jeux ?", "Fin de l'emprunt", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (res)
            {

                case MessageBoxResult.Yes:
                    if(days.Days>0)
                    {
                        MessageBox.Show($"Votre emprunt finira dans {days.Days} jours", "");
                    }
                    else if (days.Days<0)
                    {
                        MessageBox.Show($"Votre emprunt est fini depuis {Math.Abs(days.Days)} jours", "Retard de l'échéance");
                    }
                    else
                    {
                        MessageBox.Show($"Votre emprunt est terminé","Validation");
                    }
                    break;

                case MessageBoxResult.No:
                    break;
                default:
                    break;
            }
        }
    }
}
