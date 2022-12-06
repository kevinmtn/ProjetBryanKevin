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

namespace ProjetBryanKevin.Pages.Administrator
{
    /// <summary>
    /// Logique d'interaction pour UpdateVideoGameCredit.xaml
    /// </summary>
    public partial class UpdateVideoGameCredit : Page
    {
        VideoGame vid;
        public UpdateVideoGameCredit(VideoGame video)
        {
            InitializeComponent();
            List<VideoGame> videoGames = VideoGame.GetVideoGame();
            dataGridVideoGame.ItemsSource = videoGames;
        }

        private void ButtonModification(object sender, RoutedEventArgs e)
        {
           

        }
    }
}
