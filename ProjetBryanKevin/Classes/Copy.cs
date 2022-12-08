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
        private Player player;

        public Copy(int idCopy, VideoGame videoGame, Player player)
        {
            this.idCopy = idCopy;
            this.videoGame = videoGame;
            this.player = player;
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

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        public bool Insert()
        {
            DAO_Copy db = new DAO_Copy();
            return db.Create(this);
        }
        public static List<Copy> GetCopy()
        {
            DAO_Copy db = new DAO_Copy();
            return db.FindAll();
        }

        public static Copy GetCopyFromIdVideoGame(int idVideoGame)
        {
            DAO_Copy db = new DAO_Copy();
            return db.GetCopyFromVideoGameId(idVideoGame);
        }
    }
}
