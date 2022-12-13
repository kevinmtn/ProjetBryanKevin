using ProjetBryanKevin.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjetBryanKevin.Classes
{
    public class Loan
    {
        private int idLoan;
        private DateTime startDate;
        private DateTime endDate;
        private bool onGoing;
        private Player lender;
        private Player borrower;
        private Copy copy;

        public Loan(DateTime startDate, DateTime endDate, bool onGoing, Player lender, Player borrower, Copy copy)
        {
            this.idLoan = 0;
            this.startDate = startDate;
            this.endDate = endDate;
            this.onGoing = onGoing;
            this.copy = copy;
            this.borrower = borrower;
            this.lender = lender;
        }
        public Loan(int idLoan, DateTime startDate, DateTime endDate, bool onGoing, Player lender, Player borrower, Copy copy)
        {
            this.idLoan = idLoan;
            this.startDate = startDate;
            this.endDate = endDate;
            this.onGoing = onGoing;
            this.copy = copy;
            this.borrower = borrower;
            this.lender = lender;
        }

        public int IdLoan
        {
            get { return idLoan; }
            set { this.idLoan = value; }
        }

        public DateTime StartDate {
            get { return startDate;}
            set { startDate = value; }
        }

        public DateTime EndDate
        {
            get { return endDate;}
            set
            {
                endDate = value;
            }
        }
        public bool OnGoing { 
            get { return onGoing; } 
            set { onGoing= value; } 
        }

        public Player Lender
        {
            get { return lender; }
            set { lender = value; }
        }

        public Player Borrower
        {
            get { return borrower; }
            set { borrower = value; }
        }

        public Copy Copy
        {
            get { return copy; }
            set
            {
                copy = value;
            }
        }
        public Loan Insert()
        {
            DAO_Loan db = new DAO_Loan();
            if (checkDuplicate(this))
            { 
                return null;
            }
            return db.Create(this);
        }

        internal bool checkDuplicate(Loan loan)
        {
            DAO_Loan db = new DAO_Loan();
            return db.FindDuplicate(this);
        }

        public static List<Loan> GetLoan()
        {
            DAO_Loan dao_loan= new DAO_Loan();
            return dao_loan.FindAll();
        }

        public static List<Loan> GetPlayerLoan(int idBorrower)
        {
            DAO_Loan dao_loan = new DAO_Loan();
            return dao_loan.FindLoanByIdBorrower(idBorrower);
        }

        public static int CalculateBalance(DateTime startDate, DateTime endDate, Copy copy)
        {
            TimeSpan duration = endDate.Subtract(startDate);
            int loanCost = (copy.VideoGame.CreditCost * (duration.Days / 7 + 1));
            return loanCost;
        }
    }
}
