using ProjetBryanKevin.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBryanKevin.DAO
{
    //to delete
    class DAO_User : DAO<User>
    {
        public DAO_User()
        {

        }
        public override bool Create(User obj)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(User obj)
        {
            throw new NotImplementedException();
        }

        public override List<User> DisplayAll()
        {
            throw new NotImplementedException();
        }

        public override User Find(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(User obj)
        {
            throw new NotImplementedException();
        }

        public override User VerificationConnection(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
