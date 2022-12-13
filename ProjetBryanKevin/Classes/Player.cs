using ProjetBryanKevin.DAO;
using ProjetBryanKevin.Pages.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBryanKevin.Classes
{
    public class Player : User

    {
        private int credit;
        private string pseudo;
        private DateTime registrationDate;
        private DateTime dateOfBirth;

        public Player(string userName, string password, string pseudo, DateTime registrationDate, DateTime dateOfBirth, int credit): base(userName, password)
        {
            base.Id = 0;
            base.UserName = userName;
            base.Password = password;
            this.pseudo = pseudo;
            this.credit = credit;
            this.registrationDate = registrationDate;
            this.dateOfBirth = dateOfBirth;

        }
        public Player(int id, string userName, string password, int credit, string pseudo, DateTime registrationDate, DateTime dateOfBirth) : base(id, userName, password)
        {

            base.Id = id;
            base.UserName = userName;
            base.Password = password;
            this.credit = credit;
            this.pseudo = pseudo;
            this.registrationDate = registrationDate;
            this.dateOfBirth = dateOfBirth;
       
        }

        public int Credit
        {
            get { return credit; }
            set { credit = value; }
        }
        public string Pseudo
        {
            get { return pseudo; }
            set { pseudo = value; }
        }

        public DateTime RegistrationDate
        {
            get { return registrationDate; }
            set { registrationDate = value; }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set{ dateOfBirth = value;}
        }

        public Player Insert()
        {
            DAO_Player db = new DAO_Player();
            return db.Create(this);
        }
        public static List<Player> GetPlayer()
        {
            DAO_Player db = new DAO_Player();
            return db.FindAll();
        }

        public static int GetCreditPlayer(Player play)
        {
            DAO_Player db = new DAO_Player();
            return db.SelectCreditPlayer(play.Id);
        }
        public bool LoanAllowed()
        {
            if(credit>=0) return false;
            return true;
        }

        public static bool AddBirthdayBonus(DateTime birthday, DateTime endBorrow)
        {
            if(birthday.DayOfYear == endBorrow.DayOfYear)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckDuplicate()
        {
            DAO_Player db = new DAO_Player();
            return db.FindDuplicate(this.pseudo);
        }

        public static bool UpdateValueCredit(Player play, int newCredit)
        {
            DAO_Player db = new DAO_Player();
            return db.UpdateCredit(play, newCredit);
        }
    }
}
