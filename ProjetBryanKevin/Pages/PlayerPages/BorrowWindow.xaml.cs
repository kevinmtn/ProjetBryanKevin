using ProjetBryanKevin.Classes;
using ProjetBryanKevin.DAO;
using ProjetBryanKevin.Factory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private Copy copy;
        private Classes.Player borrower;
        private int loanCost;

        public BorrowWindow(Copy copy, Classes.Player borrower)
        {
            InitializeComponent();
            this.copy = copy;
            this.borrower = borrower;
            NameGame.Text = copy.VideoGame.Name;
            ConsoleName.Text = copy.VideoGame.Console;
            CreditCost.Text = copy.VideoGame.CreditCost.ToString();
            StartDate.Text = DateTime.Now.ToString();
        }



        private void Validation_Click(object sender, RoutedEventArgs e)
        {
            //TODO fix 
            //DAO_Loan dao_loan = (DAO_Loan)adf.getLoanDAO();
            //if (dao_loan.Create(new Loan(0, startDate, endDate, true,  player, player, cop)))
            //{
            //    MessageBox.Show("Votre emprunt est confirmé");
            //}

        }

        private void EndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = EndDate.SelectedDate.Value;
            TimeSpan duration = endDate.Subtract(startDate);
            loanCost = (copy.VideoGame.CreditCost * (duration.Days/7 + 1));
            LoanCost.Text = loanCost.ToString();

        }
    }
}
