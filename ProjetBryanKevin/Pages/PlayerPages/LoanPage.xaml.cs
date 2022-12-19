using ProjetBryanKevin.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            CreditLeft.Text = player.Credit.ToString();
        }
        private void ButtonBorrow(object sender, RoutedEventArgs e)
        {
            Copy copy = (Copy)dataGridVideoGame.SelectedItem;

            if (!Copy.IsAvailable(copy))
            {
                MessageBox.Show("Le jeux n'est pas disponible pour le moment", "Jeux déja loué", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (!Classes.Player.LoanAllowed(player))
            {
                MessageBox.Show("Votre nombre de crédit n'est pas suffisant !", "Emprunt impossible", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Etes vous certain de vouloir emprunter ce jeux ?", "Validation", MessageBoxButton.YesNo, MessageBoxImage.Question);
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

