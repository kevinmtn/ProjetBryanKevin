using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBryanKevin.Classes
{
    public abstract class User
    {
        private int id;
        private string userName;
        private string password;


        public User(int id, string userName, string password)
        {
            this.id = id;
            this.userName = userName;
            this.password = password;   
        }

        public int Id { 
            get {  return id; } 
            set { id = value; }
        }

        public string UserName
        {
            get{ return userName;}
            set {userName = value;}
        }

        public string Password
        {
            get{return password;}
            set{password = value;}
        }
    }
}
