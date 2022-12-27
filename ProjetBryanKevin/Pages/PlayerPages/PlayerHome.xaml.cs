using ProjetBryanKevin.Classes;
using System;
using System.Windows.Controls;
namespace ProjetBryanKevin.Pages.Player
{
    /// <summary>
    /// Logique d'interaction pour PlayerHome.xaml
    /// </summary>
    public partial class PlayerHome : Page
    {
        Classes.Player play;

        public PlayerHome(Classes.Player player)
        {
            InitializeComponent();
            play = player;
            WelcomeText.Text = "Bienvenue  " + play.UserName;
            InscriptionDate.Text = "Inscrit depuis le " + play.RegistrationDate.ToString("dd/MM/yy");
        }
    }
}
