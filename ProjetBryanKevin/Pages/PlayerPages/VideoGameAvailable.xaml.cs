using ProjetBryanKevin.Classes;
using ProjetBryanKevin.DAO;
using ProjetBryanKevin.Factory;
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

namespace ProjetBryanKevin.Pages.Player
{
    /// <summary>
    /// Logique d'interaction pour VideoGameAvailable.xaml
    /// </summary>
    public partial class VideoGameAvailable : Page
    {
     
        public VideoGameAvailable(Classes.Player play)
        {
            InitializeComponent();
            List<VideoGame> videoGames = VideoGame.GetVideoGame();
            dataGridVideoGame.ItemsSource = videoGames;

            Credit.Text = play.Credit.ToString();
        }

        private void ButtonLoan(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Etes vous certain de vouloir reserver ce jeux ?", "Validation", MessageBoxButton.YesNo, MessageBoxImage.Question);

        }
    }
}
