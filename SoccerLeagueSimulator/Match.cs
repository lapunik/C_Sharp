using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerLeagueSimulator
{
    public class Match
    {

        private Random random;
        public Team teamHome;
        public Team teamAway;

        public int Round {set;get;}
        public string Home { set; get;}
        public int scoreHome { set; get;}
        public int scoreAway { set; get; }
        public string Away { set; get; }

        public bool end;

        public Match(string line)
        {
            if (String.IsNullOrEmpty(line))
            {
                return;
            }

            String[] data = line.Split(';');

            Round = int.Parse(data[0]);
            Home = data[1];
            Away = data[2];
            scoreHome = 0;
            scoreAway = 0;
            end = false;

        }

        public Match(string line,Team teamHome,Team teamAway)
        {
         
            if (String.IsNullOrEmpty(line))
            {
                return;
            }
            

            this.teamHome = teamHome;
            this.teamAway = teamAway;

            Round = int.Parse(line);
            Home = teamHome.Name;
            Away = teamAway.Name;
            scoreHome = 0;
            scoreAway = 0;

        }

        public void AssingTeams(Team teamHome, Team teamAway)
        {
            this.teamHome = teamHome;
            this.teamAway = teamAway;
        }

        public string Play()
        {

            string goalAuthor = "";

            random = new Random();

            System.Threading.Thread.Sleep(5);

            int i = random.Next(0, 2);
            
            if (i == 0)
            {
                
                if (random.Next(1, (teamHome.attackingAbility + teamAway.defendingAbility - 40) / 2) == 1)
                {
                    scoreHome++;
                    if (teamHome.players.Count == 0)
                    {
                        goalAuthor = "nikdo";
                    }
                    else
                    {
                        while (goalAuthor == "")
                        {

                            int k = random.Next(0,teamHome.numberOfPlayer); // Kdo dal gol, tlacitko tabulka strelcu/ golmanu a kompletni


                            if (random.Next(0, teamHome.players[k].scoredAbility) == 0)
                            {
                                goalAuthor = String.Format("{0} {1} {2}", teamHome.players[k].Number, teamHome.players[k].FirstName, teamHome.players[k].SecondName);
                                teamHome.players[k].Goals++;
                            }

                        }
                    }

                }
            }
            else if (i == 1)
            {
                if (random.Next(1, (teamAway.attackingAbility + teamHome.defendingAbility- 40) / 2) == 1)
                {
                    scoreAway++;
                    if (teamAway.players.Count == 0)
                    {
                        goalAuthor = "nikdo";
                    }
                    else
                    {
                        while (goalAuthor == "")
                        {
                            int k = random.Next(0, teamAway.numberOfPlayer);
                            if (random.Next(0, teamAway.players[k].scoredAbility) == 0)
                            {
                                goalAuthor = String.Format("{0} {1} {2}", teamAway.players[k].Number, teamAway.players[k].FirstName, teamAway.players[k].SecondName);
                                teamAway.players[k].Goals++;
                            }
                        }
                    }
                }
            }

            return goalAuthor;
        }

        public int VyhodnotZapas()
        {
            if (scoreHome > scoreAway)
            {
                return 1;
            }
            else if (scoreHome < scoreAway)
            {
                return 2;
            }
            else
            {
                return 0;
            }

        }

    }

}
