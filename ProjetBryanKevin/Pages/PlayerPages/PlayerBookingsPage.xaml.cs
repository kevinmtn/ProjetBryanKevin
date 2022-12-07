using ProjetBryanKevin.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Logique d'interaction pour PlayerBookingsPage.xaml
    /// </summary>
    public partial class PlayerBookingsPage : Page
    {
        public PlayerBookingsPage(int idPlayer)
        {
            InitializeComponent();
            List<Booking> bookings = Booking.GetPlayerBookings(idPlayer);
            dataGridBooking.ItemsSource = bookings;
        }

        private void delBooking(Object sender, RoutedEventArgs e) 
        { 
            Booking? selectedBooking = (sender as Button).DataContext as Booking;
            selectedBooking?.Delete();
            Debug.Print("Reservation supprimée");
        }
    }
}
