using ProjetBryanKevin.Classes;
using ProjetBryanKevin.Pages.Administrator;
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
using System.Windows.Shapes;

namespace ProjetBryanKevin
{
    /// <summary>
    /// Logique d'interaction pour AdministratorWindow.xaml
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        Administrator admin;
        VideoGame video;

        public AdministratorWindow(Administrator administrator)
        {
            InitializeComponent();
            admin = administrator;
            Main.Content = new AdministratorHome(admin);
        }

        private void menuDisconnect(Object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Vous vous êtes déconnecté", "Deconnection", MessageBoxButton.OK, MessageBoxImage.Information);

            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void menuHome(Object sender, RoutedEventArgs e)
        {
            Main.Content = new AdministratorHome(admin);
        }

        private void menuVideoGame(Object sender, RoutedEventArgs e)
        {
            Main.Content = new UpdateVideoGameCredit(video);
        }
    }
}
