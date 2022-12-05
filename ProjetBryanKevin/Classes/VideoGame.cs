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

        public void SelectBooking()
        {

        }
    }
}
