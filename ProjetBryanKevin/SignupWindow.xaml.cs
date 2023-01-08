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
using System.Windows.Shapes;

namespace ProjetBryanKevin
{
    /// <summary>
    /// Logique d'interaction pour SignupWindow.xaml
    /// </summary>
    public partial class SignupWindow : Window
    {

        public SignupWindow()
        {
            InitializeComponent();
            BirthDate.DisplayDateEnd = DateTime.Today.AddYears(-8);
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            Classes.Player newPlayer;
            String username = UserName.Text;
            String pseudo = Pseudo.Text;
            String password = Password.Password.ToString();
            DateTime? birthDate = BirthDate.SelectedDate;
            DateTime registrationDate = DateTime.Now;
   

            if( username== "" || pseudo == "" || password == "" || birthDate == null) 
            {
                MessageBox.Show("Veuillez compléter tous les champs", "Formulaire imcomplet",MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            bool verifBonus = Player.AddBirthdayBonus((DateTime)birthDate,registrationDate);
          

            if (verifBonus == true)
            {
                 MessageBox.Show("Bonus de 2 crédits accordés", "Joyeux anniversaire !", MessageBoxButton.OK, MessageBoxImage.Information);
                 newPlayer = new Classes.Player(username, password, pseudo, registrationDate, (DateTime)birthDate, 12);
            }
            else
            {
                newPlayer = new Classes.Player(username, password, pseudo, registrationDate, (DateTime)birthDate, 10);
            }
           

            if (newPlayer.CheckDuplicate())
            {
                MessageBox.Show("Ce login est déjà utilisé...","Erreur" ,MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }

            if (newPlayer.Insert() != null)
            {
                MessageBox.Show("Vous êtes maintenant inscrit!", "Inscription validée", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
