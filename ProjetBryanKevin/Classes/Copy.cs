using ProjetBryanKevin.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBryanKevin.Classes
{
    public class Copy
    {
        private int idCopy;
        private VideoGame videoGame;
        private Player owner;

        public Copy(VideoGame videoGame, Player player) { 
            this.videoGame = videoGame;
            this.owner = player;
            this.idCopy = 0;
        }
        public Copy(int idCopy, VideoGame videoGame, Player player)
        {
            this.idCopy = idCopy;
            this.videoGame = videoGame;
            this.owner = player;
        }

        public int IdCopy
        {
            get { return idCopy; }
            set { idCopy = value; }
        }

        public VideoGame VideoGame
        {
            get { return videoGame; }
            set { videoGame = value; }
        }

        public Player Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public Copy Insert()
        {
            DAO_Copy dao = new DAO_Copy();
            return dao.Create(this);
        }
        public static List<Copy> GetCopyExceptUser(Player play)
        {
            DAO_Copy dao = new DAO_Copy();
            return dao.FindAllCopyExceptFromUser(play);
        }

        public static Copy GetCopyFromIdVideoGame(int idVideoGame)
        {
            DAO_Copy dao = new DAO_Copy();
            return dao.GetCopyFromVideoGameId(idVideoGame);
        }

        public bool CheckDuplicate()
        {
            DAO_Copy dao = new DAO_Copy();
            return dao.FindDuplicate(this);
        }

        public static bool IsAvailable(Copy copy)
        {
            DAO_Loan dao = new DAO_Loan();
            return !dao.FindLoanByCopy(copy);
        }

        internal List<Booking> GetBookingsForCopy()
        {
            DAO_Copy dao = new DAO_Copy();
            return dao.FindBookingsForCopy(this);
        }
    }
}
