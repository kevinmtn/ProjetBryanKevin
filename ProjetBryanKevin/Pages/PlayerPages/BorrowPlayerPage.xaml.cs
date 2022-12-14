﻿using ProjetBryanKevin.Classes;
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
        private Classes.Player borrower;
        public BorrowPlayerPage(int idBorrower, Classes.Player borrower)
        {
            InitializeComponent();
            List<Loan> loans = Loan.GetPlayerLoan(idBorrower);
            dataGridLoan.ItemsSource = loans;

            if (loans.Count == 0)
            {
                MessageBox.Show("Vous ne posséder aucune location", "Pas de location", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            this.borrower = borrower;
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
                        MessageBox.Show($"Votre emprunt finira dans {days.Days} jours", "Retour impossible");
                    }
                    else if (days.Days<0)
                    {
                        int penalty = 5 * Math.Abs(days.Days) + (loan.Copy.VideoGame.CreditCost * (days.Days / 7 + 1));
                        int newCreditBorrower = borrower.Credit - penalty;
                        bool verifUpdate = Classes.Player.UpdateValueCredit(borrower, newCreditBorrower);
                        bool desactivateLoan = Loan.UpdatePlayerLoan(loan);

                        if (verifUpdate && desactivateLoan)
                        {
                            MessageBox.Show($"Votre emprunt est fini depuis {Math.Abs(days.Days)} jours \nUne penalité de {penalty} crédits vous sera appliqué", "Retard de l'échéance");
                        }
                    }
                    else
                    {
                        bool desactivateLoan = Loan.UpdatePlayerLoan(loan);

                        if(desactivateLoan)
                        {
                            MessageBox.Show("Votre emprunt est terminé", "Validation");
                        } 
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
