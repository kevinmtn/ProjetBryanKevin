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

        public Copy(int idCopy, VideoGame videoGame)
        {
            this.idCopy = idCopy;
            this.videoGame = videoGame;
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


    }
}
