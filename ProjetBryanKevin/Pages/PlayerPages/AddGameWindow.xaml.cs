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
using System.Windows.Shapes;

namespace ProjetBryanKevin.Pages.PlayerPages
{
    /// <summary>
    /// Logique d'interaction pour AddGameWindow.xaml
    /// </summary>
    public partial class AddGameWindow : Window
    {
        public AddGameWindow()
        {
            InitializeComponent();
        }

        
        private void ButtonValidate(object sender, RoutedEventArgs e)
        {
            String gameName = GameName.Text;
            String console = ConsoleType.Text;

            if (gameName == "" || console == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            VideoGame videoGame = new VideoGame(0, gameName, 0, console);
            string message = "";
            switch (videoGame.CheckDuplicate())
            {
                case 0:
                    message = "Jeux ajouté\nIl apparaitra dans la liste quand un admin l'aura vérifier!";
                    videoGame.Insert();
                    break;
                case 1:
                    message = "Ce jeu a déjà été ajouté mais n'a pas encore été vérifié par un admin";
                    break;
                case 2:
                    message = "Ce jeu existe déjà!";
                    break;
            }
                MessageBox.Show(message, "Validation", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
        }
    }   
}
