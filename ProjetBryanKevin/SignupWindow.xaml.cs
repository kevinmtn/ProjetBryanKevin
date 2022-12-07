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
        AbstractDAOFactory adf = AbstractDAOFactory.GetFactory(DAOFactoryType.MS_SQL_FACTORY);
        public SignupWindow()
        {
            InitializeComponent();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            String username = Login.Text;
            String pseudo = Pseudo.Text;
            String password = Password.Password.ToString();
            DateTime birthDate = BirthDate.SelectedDate!.Value;
            DateTime registrationDate = DateTime.Now;
            int credit = 0;
            if(birthDate == null || username== null || pseudo == null || password == null) 
            {
                MessageBox.Show("Veuillez compléter tous les champs");
                return;
            }
            DAO_Player dao_player = (DAO_Player) adf.GetPlayerDAO();
            if (dao_player.IsLoginDuplicate(username))
            {
                MessageBox.Show("Ce login est déjà utilisé...");
                return;
            }
            if (dao_player.Create(new Classes.Player(username, password, pseudo, registrationDate, birthDate)))
            {
                MessageBox.Show("Vous êtes maintenant inscrit!");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }

            


        }
    }
}
