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
    /// Logique d'interaction pour LoanPage.xaml
    /// </summary>
    public partial class BorrowerPage : Page
    {
        public BorrowerPage(Classes.Player play)
        {
            
            InitializeComponent();
            List<VideoGame> videoGames = VideoGame.GetVideoGame();
            dataGridVideoGame.ItemsSource = videoGames;

            Credit.Text = play.Credit.ToString();
        }

        private void ButtonLoan(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Etes vous certain de vouloir emprunter ce jeux ?", "Validation", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}
