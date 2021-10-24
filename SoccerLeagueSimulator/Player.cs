using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerLeagueSimulator
{
    public class Player
    {
        public int Order { set; get; }
        public int Number { set; get; }
        public string SecondName { set; get; }
        public string FirstName { set; get; }
        public string Position { set; get; }
        public string Team { set; get; }
        public int Goals { set; get; }

        public int scoredAbility;


        public Player(string line,string team)
        {
            String[] data = line.Split(' ');

            Number = int.Parse(data[0]);
            FirstName = data[1];
            SecondName = data[2];
            Position = data[3];
            Goals = 0;
            Team = team;
            scoredAbility = AssingAbility();


        }

        private int AssingAbility()
        {

            if (Position == "ST")
            {
                return 1;
            }
            else if ((Position == "LM") || (Position == "RM") || (Position == "CAM"))
            {
                return 4;
            }
            else if ((Position == "CM") || (Position == "LB") || (Position == "RB"))
            {
                return 9;
            }
            else if (Position == "CB")
            {
                return 25;
            }
            else
            {
                return 100;
            }
        }
    }
}
