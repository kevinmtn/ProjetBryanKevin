using ProjetBryanKevin.DAO;
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
                case "Membre":
                    DAO<Member> memberDAO = adf.GetMemberDAO();
                    Member memb = memberDAO.VerificationConnection(login, password);

                    if (memb == null)
                    {
                        ErrorMessageForLogin();
                    }
                    else
                    {
                        WindowForMember wfm = new WindowForMember(memb);
                        wfm.Show();
                        this.Close();
                    }

                    break;

                case "Trésorier":
                    DAO<Treasurer> treasurerDAO = adf.GetTreasurerDAO();
                    Treasurer tres = treasurerDAO.VerificationConnection(login, password);

                    if (tres == null)
                    {
                        ErrorMessageForLogin();
                    }

                    else
                    {
                        WindowForTreasurer wft = new WindowForTreasurer(tres);
                        wft.Show();
                        this.Close();
                    }

                    break;

                case "Responsable":
                    DAO<Responsible> responsibleDAO = adf.GetResponsibleDAO();
                    Responsible resp = responsibleDAO.VerificationConnection(login, password);

                    if (resp == null)
                    {
                        ErrorMessageForLogin();
                    }
                    else
                    {
                        WindowForResponsible wfr = new WindowForResponsible(resp);
                        wfr.Show();
                        this.Close();
                    }

                    break;
            }

        }
    }
}
