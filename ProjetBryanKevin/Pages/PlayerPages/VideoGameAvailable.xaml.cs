using ProjetBryanKevin.Classes;
using ProjetBryanKevin.DAO;
using ProjetBryanKevin.Factory;
using ProjetBryanKevin.Pages.PlayerPages;
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

        bool verifCredit = true;
        Classes.Player player = null;
        public VideoGameAvailable(Classes.Player play)
        {
            InitializeComponent();
            List<VideoGame> videoGames = VideoGame.GetAllVideoGames();
            dataGridVideoGame.ItemsSource = videoGames;
            player = play;

            Credit.Text = play.Credit.ToString();

            if (play.Credit <= 0)
            {
                verifCredit = false;
            }
        }

        private void ButtonBooking(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Etes vous certain de vouloir reserver ce jeux ?", "Validation", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
        private void ButtonBorrow(object sender, RoutedEventArgs e)
        {
            VideoGame video = (VideoGame)dataGridVideoGame.SelectedItem;

            if (verifCredit)
            {
               MessageBoxResult result= MessageBox.Show("Etes vous certain de vouloir emprunter ce jeux ?", "Validation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        BorrowWindow borrow = new BorrowWindow(video, player);
                        borrow.Show();

                        break;
                    case MessageBoxResult.No:
                        break;
                    default:
                        break;
                }

            }
            else if(!verifCredit)
            {
                MessageBox.Show("Votre nombre de crédit n'est pas suffisant !", "Emprunt impossible", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
