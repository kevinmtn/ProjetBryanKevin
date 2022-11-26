using ProjetBryanKevin.Classes;
using ProjetBryanKevin.DAO;
using ProjetBryanKevin.Factory;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

namespace ProjetBryanKevin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow instance;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ButtonClicked(object sender, RoutedEventArgs e)
        {
            AbstractDAOFactory adf = AbstractDAOFactory.GetFactory(DAOFactoryType.MS_SQL_FACTORY);
            String login = Pseudo.Text;
            String password = Password.Password.ToString();

            switch (ConnexionChoice.Text)
            {
                case "Administrateur":
                    DAO<Administrator> daoAdministrator = adf.GetAdministratorDAO();
                    Administrator administrator= daoAdministrator.VerificationConnection(login, password);

                    if (administrator == null)
                    {
                        ErrorMessageForLogin();
                    }
                    else
                    {
                        AdministratorWindow wfm = new AdministratorWindow(administrator);
                        wfm.Show();
                        this.Close();
                    }

                    break;

                case "Utilisateur":
                    DAO<Player> daoPlayer = adf.GetPlayerDAO();
                    Player player= daoPlayer.VerificationConnection(login, password);

                    if (player == null)
                    {
                        ErrorMessageForLogin();
                    }

                    else
                    {
                        PlayerWindow wft = new PlayerWindow(player);
                        wft.Show();
                        this.Close();
                    }

                    break;

            }

        }

        private void ErrorMessageForLogin()
        {
            Pseudo.Text = "";
            Password.Clear();
            MessageBox.Show("Votre pseudo ou votre login est incorrect", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
