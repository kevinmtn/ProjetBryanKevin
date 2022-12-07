using ProjetBryanKevin.Classes;
using ProjetBryanKevin.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;

namespace ProjetBryanKevin.Factory
{

    public enum DAOFactoryType
    {
        MS_SQL_FACTORY,
        XML_FACTORY
    }
    internal abstract class AbstractDAOFactory
    {

        public abstract DAO_User<Administrator> GetAdministratorDAO();
        public abstract DAO_User<Player> GetPlayerDAO();
        public static AbstractDAOFactory GetFactory(DAOFactoryType type)
        {
            switch (type)
            {
                case DAOFactoryType.MS_SQL_FACTORY: return new MSSQLFactory();

                case DAOFactoryType.XML_FACTORY: return null;

                default: return null;
            }
        }

        public abstract DAO<Booking> GetBookingDAO();
        public abstract DAO<Copy> getCopyDAO();
        public abstract DAO<Loan> getLoanDAO();
        public abstract DAO<VideoGame> getVideoGameDAO();

    }
}
