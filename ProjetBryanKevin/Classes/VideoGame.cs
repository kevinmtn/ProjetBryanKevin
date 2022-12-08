using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProjetBryanKevin.DAO;

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

        public bool Insert()
        {
            DAO_VideoGame db = new DAO_VideoGame();
            return db.Create(this);
        }
        public static List<VideoGame> GetVideoGame()
        {
            DAO_VideoGame db = new DAO_VideoGame();
            return db.DisplayAll();
        }

        public static List<VideoGame> GetApprovedVideoGame()
        {
            DAO_VideoGame db = new DAO_VideoGame();
            List<VideoGame> allVideoGames = db.DisplayAll();
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

        public static List<VideoGame> GetAVideoGame(int idVideoGame)
        {
            DAO_VideoGame dao_videoGame = new DAO_VideoGame();
            return dao_videoGame.FindVideoGameById(idVideoGame);
        }
      
        public void SelectBooking()
        {

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
    }
}
