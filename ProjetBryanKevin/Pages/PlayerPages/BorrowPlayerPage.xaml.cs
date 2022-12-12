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
            
        }

        private void GiveBackGame(object sender, RoutedEventArgs e)
        {
            Loan loan = (Loan)dataGridLoan.SelectedItem;
            int days = loan.EndDate.DayOfYear - DateTime.Now.DayOfYear;

            MessageBoxResult res= MessageBox.Show("Etes vous certain de vouloir rendre ce jeux ?", "Fin de l'emprunt", MessageBoxButton.YesNo, MessageBoxImage.Question);
            
            switch (res)
            {
                case MessageBoxResult.Yes:
                    if(loan.EndDate.DayOfYear > DateTime.Now.DayOfYear)
                    {
                        MessageBox.Show($"Votre emprunt finira dans {days} jours");
                    }
                    else if (loan.EndDate.DayOfYear < DateTime.Now.DayOfYear)
                    {
                        MessageBox.Show($"Votre emprunt est fini depuis {days} jours", "Retard de l'échéance");
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
