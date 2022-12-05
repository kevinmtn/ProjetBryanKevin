using ProjetBryanKevin.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjetBryanKevin.Classes
{
    public class Administrator : User
    {
        public Administrator(int id, string userName, string password) : base(id, userName, password)
        {
            base.Id = id;
            base.UserName = userName;
            base.Password = password;
        }


        public static List<Administrator> GetAdministrator()
        {
            DAO_Administrator dao_Admin = new DAO_Administrator;
            return dao_Admin.DisplayAll();
        }

     
    }
}
