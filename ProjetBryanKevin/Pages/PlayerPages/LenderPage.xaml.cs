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
    /// Logique d'interaction pour LoanPage.xaml
    /// </summary>
    public partial class LenderPage : Page
    {
        public LenderPage()
        {
            InitializeComponent();
        }

        private void ButtonValidate(object sender, RoutedEventArgs e)
        {
            String gameName = GameName.Text;
            String console = ConsoleType.Text;

            if(gameName =="" || console == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                VideoGame videoGame = new VideoGame(0, gameName, 0, console);
                videoGame.Insert();
                MessageBox.Show("Jeux ajouté", "Validation", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
