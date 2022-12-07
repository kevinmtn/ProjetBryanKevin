using ProjetBryanKevin.Classes;
using ProjetBryanKevin.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBryanKevin.Factory
{

    class MSSQLFactory : AbstractDAOFactory
    {
        public override DAO_User<Player> GetPlayerDAO()
        {
            return new DAO_Player();
        }
        public override DAO_User<Administrator> GetAdministratorDAO()
        {
            return new DAO_Administrator();
        }

        public override DAO<Booking> GetBookingDAO()
        {
            return new DAO_Booking();
        }

        public override DAO<Copy> getCopyDAO()
        {
            return new DAO_Copy();
        }

        public override DAO<Loan> getLoanDAO()
        {
            return new DAO_Loan();
        }


        public override DAO<VideoGame> getVideoGameDAO()
        {
            return new DAO_VideoGame();
        }
    }
}
