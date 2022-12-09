using ProjetBryanKevin.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
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

        }
    }
}
