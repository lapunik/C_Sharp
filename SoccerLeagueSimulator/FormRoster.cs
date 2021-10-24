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
    public partial class Roster : Form
    {

        public Team team;

        public Roster()
        {
            InitializeComponent();

        }

        private void FormRoster_Load(object sender, EventArgs e)
        {
            jerseyCMl.BackColor = Color.Transparent;
            jerseyRB.BackColor = Color.Transparent;
            jerseyLB.BackColor = Color.Transparent;
            jerseyCBl.BackColor = Color.Transparent;
            jerseyCBr.BackColor = Color.Transparent;
            jerseyGK.BackColor = Color.Transparent;
            jerseyCMr.BackColor = Color.Transparent;
            jerseyST.BackColor = Color.Transparent;
            jerseyCAM.BackColor = Color.Transparent;
            jerseyLM.BackColor = Color.Transparent;
            jerseyRM.BackColor = Color.Transparent;
            jerseyCMl.MainJerseyColor = team.homeJersey;
            jerseyRB.MainJerseyColor = team.homeJersey;
            jerseyLB.MainJerseyColor = team.homeJersey;
            jerseyCBl.MainJerseyColor = team.homeJersey;
            jerseyCBr.MainJerseyColor = team.homeJersey;
            jerseyCMr.MainJerseyColor = team.homeJersey;
            jerseyGK.MainJerseyColor = team.gkJersey;
            jerseyRM.MainJerseyColor = team.homeJersey;
            jerseyLM.MainJerseyColor = team.homeJersey;
            jerseyST.MainJerseyColor = team.homeJersey;
            jerseyCAM.MainJerseyColor = team.homeJersey;


            foreach (Player player in team.players)
            {
                if (player.Position == "GK")
                {
                    jerseyGK.PlayerName = player.SecondName;
                    jerseyGK.Number = player.Number;
                }
                if (player.Position == "CB")
                {
                    if (jerseyCBr.Number == 0)
                    {
                        jerseyCBr.PlayerName = player.SecondName;
                        jerseyCBr.Number = player.Number;
                    }
                    else
                    {
                        jerseyCBl.PlayerName = player.SecondName;
                        jerseyCBl.Number = player.Number;
                    }

                }
                if (player.Position == "RB")
                {
                    jerseyRB.PlayerName = player.SecondName;
                    jerseyRB.Number = player.Number;
                }
                if (player.Position == "LB")
                {
                    jerseyLB.PlayerName = player.SecondName;
                    jerseyLB.Number = player.Number;
                }
                if (player.Position == "CM")
                {
                    if (jerseyCMr.Number == 0)
                    {
                        jerseyCMr.PlayerName = player.SecondName;
                        jerseyCMr.Number = player.Number;
                    }
                    else
                    {
                        jerseyCMl.PlayerName = player.SecondName;
                        jerseyCMl.Number = player.Number;
                    }

                }
                if (player.Position == "RM")
                {
                    jerseyRM.PlayerName = player.SecondName;
                    jerseyRM.Number = player.Number;
                }
                if (player.Position == "LM")
                {
                    jerseyLM.PlayerName = player.SecondName;
                    jerseyLM.Number = player.Number;
                }
                if (player.Position == "CAM")
                {
                    jerseyCAM.PlayerName = player.SecondName;
                    jerseyCAM.Number = player.Number;
                }
                if (player.Position == "ST")
                {
                    jerseyST.PlayerName = player.SecondName;
                    jerseyST.Number = player.Number;
                }
            }
        }

    }
}