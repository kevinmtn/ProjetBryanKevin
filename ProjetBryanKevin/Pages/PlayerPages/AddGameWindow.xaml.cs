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

namespace ProjetBryanKevin.Pages.PlayerPages
{
    /// <summary>
    /// Logique d'interaction pour AddGameWindow.xaml
    /// </summary>
    public partial class AddGameWindow : Window
    {
        AbstractDAOFactory adf = AbstractDAOFactory.GetFactory(DAOFactoryType.MS_SQL_FACTORY);
        Classes.Player lender;
        public AddGameWindow(Classes.Player lender)
        {
            InitializeComponent();
            this.lender = lender;
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
            
            VideoGame newVideoGame = new VideoGame(0, gameName, 0, console);
            string message = "";
            switch (newVideoGame.CheckDuplicate())
            {
                case 0:
                    if(newVideoGame.Insert() == null)
                    {
                        break;
                        
                    }
                    newVideoGame = newVideoGame.Insert();
                    Copy newCopy = new Copy(newVideoGame, lender);
                    if (newCopy.Insert() != null)
                    {
                        message = "Votre copie du jeu " + newCopy.VideoGame.Name + " sur " + newCopy.VideoGame.Console + " a bien été ajouté!\n Un admin vérifiera votre ajout rapidement!";
                    }
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
