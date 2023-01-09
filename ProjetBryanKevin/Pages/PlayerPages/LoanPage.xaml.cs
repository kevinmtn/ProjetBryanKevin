using ProjetBryanKevin.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace ProjetBryanKevin.Pages.PlayerPages
{
    /// <summary>
    /// Logique d'interaction pour LoanPage.xaml
    /// </summary>
    public partial class LoanPage : Page
    {
        Classes.Player player;

        public LoanPage(Classes.Player player)
        {
            InitializeComponent();
            List<Copy> allCopiesExceptUser = Copy.GetCopyExceptUser(player);
            var availableCopies = from copy in allCopiesExceptUser where Copy.IsAvailable(copy) select copy;
            dataGridVideoGame.ItemsSource = availableCopies;
            this.player = player;
            int creditLeft = Classes.Player.GetCreditPlayer(player);
            CreditLeft.Text = creditLeft.ToString();
        }
        private void ButtonBorrow(object sender, RoutedEventArgs e)
        {
            Copy copy = (Copy)dataGridVideoGame.SelectedItem;

            if (!Copy.IsAvailable(copy))
            {
                MessageBox.Show("Le jeu n'est pas disponible pour le moment", "Jeu déja loué", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (!Classes.Player.LoanAllowed(player))
            {
                MessageBox.Show("Votre nombre de crédit n'est pas suffisant !", "Emprunt impossible", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Etes vous certain de vouloir emprunter ce jeu ?", "Validation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    BorrowWindow borrow = new BorrowWindow(copy, player);
                    borrow.Show();
                    break;
                default:
                    break;
            }  
        }
    }
}

