using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjetBryanKevin.Classes;

namespace ProjetBryanKevin.Pages.Administrator
{
    /// <summary>
    /// Logique d'interaction pour AdministratorHome.xaml
    /// </summary>
    public partial class AdministratorHome : Page
    {
        Classes.Administrator administrator;
        
        public AdministratorHome(Classes.Administrator admin)
        {
            InitializeComponent();
            administrator = admin;
            WelcomeText.Text = "Bienvenue " +admin.UserName;
        }
    }
}
