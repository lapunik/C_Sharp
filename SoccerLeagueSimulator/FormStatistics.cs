using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoccerLeagueSimulator
{
    public partial class FormStatistics : Form
    {

        public Team team;
        public List<Match> matches;

        public FormStatistics()
        {
            InitializeComponent();
        }

        private void BestMatch()
        {
            Match bestMatch = matches[0];
            Match worstMatch = matches[0];

            foreach (Match match in matches)
            {
                if (match.end)
                {
                    int best;
                    int worst;

                    if (bestMatch.Home == team.Name)
                    {
                        best = bestMatch.scoreHome - bestMatch.scoreAway;
                    }
                    else
                    {
                        best = bestMatch.scoreAway - bestMatch.scoreHome;
                    }
                    if (worstMatch.Home == team.Name)
                    {
                        worst = worstMatch.scoreHome - worstMatch.scoreAway;
                    }
                    else
                    {
                        worst = worstMatch.scoreAway - worstMatch.scoreHome;
                    }

                    if (match.Home == team.Name)
                    {

                        if (best < (match.scoreHome - match.scoreAway))
                        {


                            bestMatch = match;

                        }
                        if (worst > (match.scoreHome - match.scoreAway))
                        {

                            worstMatch = match;

                        }



                    }
                    if (match.Away == team.Name)
                    {
                        if (best < (match.scoreAway - match.scoreHome))
                        {

                            bestMatch = match;

                        }
                        if (worst > (match.scoreAway - match.scoreHome))
                        {

                            worstMatch = match;

                        }
                    }

                }

            }

            if (matches[0].end)
            {

                if (bestMatch.Home == team.Name)
                {
                    if (bestMatch.scoreHome > bestMatch.scoreAway)
                    {
                        labelBestMatch.Text = String.Format("win ");
                    }
                    else if (bestMatch.scoreAway > bestMatch.scoreHome)
                    {
                        labelBestMatch.Text = String.Format("lost ");
                    }
                    else
                    {
                        labelBestMatch.Text = String.Format("draw ");
                    }

                    labelBestMatch.Text += String.Format("{0}:{1} against {2} in {3}. round", bestMatch.scoreHome, bestMatch.scoreAway, bestMatch.Away, bestMatch.Round);
                }
                else
                {
                    if (bestMatch.scoreHome < bestMatch.scoreAway)
                    {
                        labelBestMatch.Text = String.Format("win ");
                    }
                    else if (bestMatch.scoreAway < bestMatch.scoreHome)
                    {
                        labelBestMatch.Text = String.Format("lost ");
                    }
                    else
                    {
                        labelBestMatch.Text = String.Format("draw ");
                    }

                    labelBestMatch.Text += String.Format("{0}:{1} against {2} in {3}. round", bestMatch.scoreAway, bestMatch.scoreHome, bestMatch.Home, bestMatch.Round);
                }

                if (worstMatch.Home == team.Name)
                {
                    if (worstMatch.scoreHome > worstMatch.scoreAway)
                    {
                        labelWorstMatch.Text = String.Format("win ");
                    }
                    else if (worstMatch.scoreAway > worstMatch.scoreHome)
                    {
                        labelWorstMatch.Text = String.Format("lost ");
                    }
                    else
                    {
                        labelWorstMatch.Text = String.Format("draw ");
                    }

                    labelWorstMatch.Text += String.Format("{0}:{1} against {2} in {3}. round", worstMatch.scoreHome, worstMatch.scoreAway, worstMatch.Away, worstMatch.Round);
                }
                else
                {
                    if (worstMatch.scoreHome < worstMatch.scoreAway)
                    {
                        labelWorstMatch.Text = String.Format("win ");
                    }
                    else if (worstMatch.scoreAway < worstMatch.scoreHome)
                    {
                        labelWorstMatch.Text = String.Format("lost ");
                    }
                    else
                    {
                        labelWorstMatch.Text = String.Format("draw ");
                    }

                    labelWorstMatch.Text += String.Format("{0}:{1} against {2} in {3}. round", worstMatch.scoreAway, worstMatch.scoreHome, worstMatch.Home, worstMatch.Round);
                }
            }
            else
            {


                labelBestMatch.Text = "---";
                labelWorstMatch.Text = "---";
            }
            
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {
            List<Player> players = new List<Player>();

            foreach (Player player in team.players)
            {
                players.Add(player);
            }

            labelName.Text = team.Name;
            labelPoints.Text = team.Points.ToString();
            labelWins.Text = team.Wins.ToString();
            labelDraws.Text = team.Draws.ToString();
            labelLosts.Text = team.Losts.ToString();
            labelFor.Text = team.For.ToString();
            labelAgainst.Text = team.Against.ToString();

            jerseyHome.MainJerseyColor = team.homeJersey;
            jerseyHome.PlayerName = "Home";
            jerseyHome.Number = 1;
            jerseyAway.MainJerseyColor = team.awayJersey;
            jerseyAway.PlayerName = "Away";
            jerseyAway.Number = 1;

            BestMatch();
            
            for (int i = 0; i < players.Count - 1; i++)
            {

                for (int j = 0; j < players.Count - i - 1; j++)
                {

                    if (players[j + 1].Goals > players[j].Goals)
                    {

                        Player bubbleSort = players[j + 1];

                        players[j + 1] = players[j];

                        players[j] = bubbleSort;

                    }
                }
            }


            dataGridView1.DataSource = players;
                       
        }
    }
}
