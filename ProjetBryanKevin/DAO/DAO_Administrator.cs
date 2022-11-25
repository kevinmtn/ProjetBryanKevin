using ProjetBryanKevin.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProjetBryanKevin.DAO
{
    class DAO_Administrator : DAO<Administrator>
    {
        public DAO_Administrator() { }

        public override bool Create (Administrator obj)
        {
            return false;
        }

        public override bool Delete (Administrator obj)
        {
            return false;
        }

        public override List<Administrator> DisplayAll()
        {
            throw new NotImplementedException();
        }

        public override Administrator Find(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Administrator obj)
        {
            throw new NotImplementedException();
        }
    }
}
