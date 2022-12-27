using ProjetBryanKevin.Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace ProjetBryanKevin.Pages.PlayerPages
{
    /// <summary>
    /// Logique d'interaction pour PlayerBookingsPage.xaml
    /// </summary>
    public partial class PlayerBookingsPage : Page
    {
        public PlayerBookingsPage(Classes.Player play)
        {
           InitializeComponent();
           List<Booking> bookings = Booking.GetPlayerBookings(play);
           dataGridBooking.ItemsSource = bookings;
           if(bookings.Count==0)
            {
                MessageBox.Show("Vous ne posséder aucune reservation", "Pas de réservation", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }
        private void DelBooking(Object sender, RoutedEventArgs e) 
        { 
          
            MessageBoxResult result = MessageBox.Show("Etes vous certain de vouloir supprimer cette reservation ?", "Validation", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Booking? selectedBooking = (sender as Button).DataContext as Booking;
                    bool verif = (bool)(selectedBooking?.Delete());

                    if (verif)
                    {
                        MessageBox.Show("Réservation supprimée", "Validation", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Une erreur est survenue lors de la suppression", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
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
