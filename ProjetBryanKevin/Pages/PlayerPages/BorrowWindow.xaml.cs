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
    /// Logique d'interaction pour BorrowWindow.xaml
    /// </summary>
    public partial class BorrowWindow : Window
    {
        AbstractDAOFactory adf = AbstractDAOFactory.GetFactory(DAOFactoryType.MS_SQL_FACTORY);

        VideoGame vg;
        Copy cop = null;
        Classes.Player player;
        string nameGame = "";
        string consoleName = "";
        string creditCost = "";
        public BorrowWindow(VideoGame videoGame, Classes.Player play)
        {
            InitializeComponent();
            vg = videoGame;

            List<VideoGame> videoGames = VideoGame.GetAVideoGame(videoGame.IdVideoGame);
           nameGame= NameGame.Text = videoGame.Name;
           consoleName= ConsoleName.Text = videoGame.Console;
           creditCost= CreditCost.Text = videoGame.CreditCost.ToString();
            player = play;
            cop = new Copy(0,videoGame, play);

        }

        private void Validation_Click(object sender, RoutedEventArgs e)
        {
            //TODO fix borrow method

            DateTime startDate = StartDate.DisplayDate;
            DateTime endDate = EndDate.DisplayDate;

            DAO_Loan dao_loan = (DAO_Loan)adf.getLoanDAO();
            if (dao_loan.Create(new Loan(0, startDate, endDate, true,  player, player, cop)))
            {
                MessageBox.Show("Votre emprunt est confirmé");
            }

        }
    }
}
