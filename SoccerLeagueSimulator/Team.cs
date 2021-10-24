using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SoccerLeagueSimulator
{
    public class Team
    {
        public int Order { set; get; }
        public string Name { set; get; }
        public int Round { set; get; }
        public int Wins { set; get; }
        public int Draws { set; get; }
        public int Losts { set; get; }
        public int For { set; get; }
        private int against;
        public int Against
        {
            get
            {
                return against;
            }
            set
            {
                against = value;

                GoalDifference = For - against;
            }
        }
        public int GoalDifference { set; get; }
        public int Points { set; get; }
        public int attackingAbility; //kolik minut prumnerne potřebuje na gol 
        public int defendingAbility; //za kolik minut dostane prumerne gol
        public int numberOfPlayer;
        public Color homeJersey;
        public Color awayJersey;
        public Color gkJersey;

        public List<Player> players = new List<Player>();

        public Team(string line)
        {
            if (String.IsNullOrEmpty(line))
            {
                return;
            }

            String[] data = line.Split(';');

            List<string> list = new List<string>();

            foreach (String dat in data)
            {
                if (dat != "")
                {

                    list.Add(dat);

                }
            }

            Name = list[0];
            if (list.Count > 1)
            {
                attackingAbility = int.Parse(list[1]);
                defendingAbility = int.Parse(list[2]);
            }
            else
            {
                attackingAbility = 35; // pokud nahraji soubor bez schopnosti
                defendingAbility = 35;
            }
            if (list.Count > 3)
            {
                homeJersey = Color.FromName(list[3]); 
                awayJersey = Color.FromName(list[4]);
                gkJersey = Color.FromName(list[5]);
                
            }
            else
            {
                homeJersey = Color.White;
                awayJersey = Color.White;
                gkJersey = Color.White;
            }
            Round = 0;
            Points = 0;
            Wins = 0;
            Losts = 0;
            Draws = 0;
            For = 0;
            Against = 0;
            
            if(list.Count > 6) // pokud soubor obsahuje informace o hracich
            {
                for (int i = 0; i < list.Count - 6; i++)
                {
                    players.Add(new Player(list[6+i],Name));
                }
            }

            numberOfPlayer = players.Count; 

        }

    }
}
