using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProjetBryanKevin.DAO;
using System.Collections.ObjectModel;

namespace ProjetBryanKevin.Classes
{
    public class VideoGame
    {
        private int idVideoGame;
        private string name;
        private int creditCost;
        private string console;


        public VideoGame(int idVideoGame,string name, int creditCost, string console)
        {
            this.idVideoGame = idVideoGame;
            this.name = name;
            this.creditCost = creditCost;
            this.console = console;
        }

        public string Name { 
            get { return this.name; }
            set { this.name = value; }
        }
        public int CreditCost
        {
            get { return this.creditCost; }
            set { this.creditCost = value; }
        }
        
        public string Console
        {
            get { return this.console; }
            set { this.console = value; }
        }

        public int IdVideoGame
        {
            get { return this.idVideoGame; }
            set { this.idVideoGame = value; }
        }

        public VideoGame Insert()
        {
            DAO_VideoGame db = new DAO_VideoGame();
            return db.Create(this);
        }
        public static List<VideoGame> GetAllVideoGames()
        {
            DAO_VideoGame db = new DAO_VideoGame();
            return db.FindAll();
        }

        // credit != 0
        public static List<VideoGame> GetApprovedVideoGames()
        {
            DAO_VideoGame db = new DAO_VideoGame();
            List<VideoGame> allVideoGames = db.FindAll();
            List<VideoGame> approvedVideoGames = new List<VideoGame>();
            foreach(VideoGame videoGame in allVideoGames)
            {
                if(videoGame.creditCost != 0)
                {
                    approvedVideoGames.Add(videoGame);
                }
            }
            return approvedVideoGames;
        }

        public static VideoGame GetVideoGameById(int idVideoGame)
        {
            DAO_VideoGame dao_videoGame = new DAO_VideoGame();
            return dao_videoGame.FindVideoGameById(idVideoGame);
        }

        /* 
         return 0 if no duplicate
         return 1 if duplicate but creditcost = 0 (admin didn't not verified this game yet)
         return 2 if duplicate
         */
        internal int CheckDuplicate()
        {
            DAO_VideoGame dao = new DAO_VideoGame();
            return dao.CheckDuplicate(this);
        }

        internal bool Update()
        {
            DAO_VideoGame dao = new DAO_VideoGame();
            return dao.Update(this);
        }

        internal Copy CopyAvailable()
        {
            DAO_VideoGame dao = new DAO_VideoGame();
            return (Copy)dao.FindCopyAvailable(this);
        }

        internal Booking FindBookingByPlayerId(Player player)
        {
            DAO_VideoGame dao = new DAO_VideoGame();
            return dao.FindBookingByUserId(this, player);
        }

        internal static List<VideoGame> GetLoanedVideoGames(Player player)
        {
            DAO_VideoGame dao = new DAO_VideoGame();
            return dao.FindLoanedVideoGames(player);
        }
    }
}
