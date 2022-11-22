using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Loan(DateTime startDate, DateTime endDate, bool onGoing, int idLoan,Player lender, Player borrower, Copy copy)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            this.onGoing = onGoing;
            this.idLoan = idLoan;
            this.copy = copy;
            this.borrower = borrower;
            this.lender = lender;
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

        public int IdLoan
        {
            get { return idLoan; }
            set { this.idLoan = value; }
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
    }
}
