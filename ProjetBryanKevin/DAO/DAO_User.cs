using ProjetBryanKevin.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBryanKevin.DAO
{ 
    public abstract class DAO_User<T> : DAO<T> 
    { 
        public abstract T VerificationConnection(string username, string password);
    }
}
