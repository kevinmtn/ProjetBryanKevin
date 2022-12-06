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
    /// Logique d'interaction pour ReservationPage.xaml
    /// </summary>
    public partial class ReservationPage : Page
    {
        public ReservationPage(Classes.Player play)
        {
            InitializeComponent();
            List<Booking> booking = Booking.GetBooking(play);
            dataGridVideoGame.ItemsSource = booking;
        }

        private void ButtonCancel(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Etes vous certain de vouloir annuler cette réservation ?", "Validation", MessageBoxButton.YesNo, MessageBoxImage.Question);

        }
    }
}
