using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBryanKevin.Classes
{
    public class Administrator : User
    {
        public Administrator(int id, string userName, string password) : base(id, userName, password)
        {
        }
    }
}
