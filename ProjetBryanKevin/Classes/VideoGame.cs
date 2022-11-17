using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBryanKevin.Classes
{
    public class VideoGame
    {
        private string name;
        private int creditCost;
        private string console;

        public VideoGame(string name, int creditCost, string console)
        {
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
    }
}
