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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetBryanKevin.Pages.Administrator
{
    /// <summary>
    /// Logique d'interaction pour UpdateVideoGameCredit.xaml
    /// </summary>
    public partial class UpdateVideoGameCredit : Page
    {
        VideoGame vid;
        public UpdateVideoGameCredit(VideoGame video)
        {
            InitializeComponent();
            this.vid = video;

            AbstractDAOFactory adf = AbstractDAOFactory.GetFactory(DAOFactoryType.MS_SQL_FACTORY);
            DAO<VideoGame> videoDAO = adf.getVideoGameDAO();
            List<VideoGame> videoGames = videoDAO.DisplayAll();

            dataGridRide.ItemsSource = videoGames;
        }

   
    }
}
