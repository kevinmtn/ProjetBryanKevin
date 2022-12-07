using ProjetBryanKevin.Classes;
using ProjetBryanKevin.Pages.Player;
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
    /// Logique d'interaction pour InscriptionWindow.xaml
    /// </summary>
    public partial class InscriptionWindow : Window
    {
        public InscriptionWindow()
        {
            InitializeComponent();
        }

        private void InscValidation_Click(object sender, RoutedEventArgs e)
        {
            string userName = InscName.Text;
            string pseudo = InscPseudo.Text;
            DateTime dateOfBirth = InscBirthday.DisplayDate;
            string password = InscPassword.Text;

            //TODO verification with dateofbirth and registration date for bonus

            if (userName != "" && pseudo != "" && dateOfBirth != null && password != "")
            {
                Player play = new Player(0, userName, password, 10, pseudo, DateTime.Now, dateOfBirth);
                bool verif = play.Insert();

                if (verif)
                {
                    MessageBox.Show("Inscription validée", "Bienvenue", MessageBoxButton.OK, MessageBoxImage.Information);

                    PlayerWindow playerWindow = new PlayerWindow(play);
                    playerWindow.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Une erreur est survenue lors de votre inscription", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez compléter tous les champs", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
