using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBryanKevin.DAO
{
    public abstract class DAO<T>
    {
        protected String connectionString = null;

        public DAO()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["BD_Kevin_Bryan"].ConnectionString;
        }

        public abstract bool Create(T obj);
        public abstract bool Delete(T obj);
        public abstract T Find(int id);
        public abstract bool Update(T obj);
        public abstract List<T> DisplayAll();
        public abstract T VerificationConnection(string username, string password);


    }
}
