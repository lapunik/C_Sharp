using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoccerLeagueSimulator
{
    public partial class Form1 : Form
    {

        BindingList<Match> matches = new BindingList<Match>();
        BindingList<Team> standings = new BindingList<Team>();
        List<Player> players = new List<Player>();


        public Form1()
        {
            InitializeComponent();
        }

        private void LaodMatchesFile(String fileName)
        {


            if (!String.IsNullOrEmpty(fileName))
            {
                String[] lines = File.ReadAllLines(fileName, Encoding.GetEncoding("Windows-1250")); ;

                matches.Clear();
                standings.Clear();

                foreach (String line in lines)
                {

                    Match score = new Match(line);
                    matches.Add(score);
                }

                dataGridViewScore.DataSource = matches;
                log.Add("Matches have been loaded");

            }

            foreach (Match match in matches)
            {
                bool isHere = false;

                foreach (Team team in standings)
                {

                    if (match.Home == team.Name)
                    {
                        isHere = true;
                    }

                }

                if (!isHere)
                {
                    standings.Add(new Team(match.Home));
                }

            }

            foreach (Match match in matches)
            {
                Team teamA = null;
                Team teamB = null;

                foreach (Team team in standings)
                {
                    if (match.Home == team.Name)
                    {
                        teamA = team;
                    }
                    if (match.Away == team.Name)
                    {
                        teamB = team;
                    }
                }

                match.AssingTeams(teamA, teamB);

            }

            dataGridViewStandings.DataSource = standings;
            log.Add("Teams have been loaded");
        }

        private void LoadTeamsFile(String fileName)
        {

            if (!String.IsNullOrEmpty(fileName))
            {
                String[] lines = File.ReadAllLines(fileName, Encoding.GetEncoding("Windows-1250"));

                standings.Clear();
                matches.Clear();

                foreach (String line in lines)
                {

                    Team team = new Team(line);
                    team.Order = standings.Count+1;
                    standings.Add(team);

                }

                dataGridViewStandings.DataSource = standings;

            }
            log.Add("Teams have been loaded");

            DrawLeague();

            dataGridViewScore.DataSource = matches;

            log.Add("Matches have been loaded");

        }

        private void DrawLeague()
        {
            for (int l = 0; l < 2; l++) // každý z každým dvakrát(doma/venku)
            {
                int n = 0;

                if (!((standings.Count) % 2 == 0)) //když je lichý počet týmů
                {
                    n = standings.Count + 1;
                }
                else
                {
                    n = standings.Count;
                }

                int k = n - 1;// počet kol

                int s = n / 2;// počet zápasů na kolo

                for (int i = 1; i <= k; i++)
                {

                    if (((standings.Count) % 2 == 0))
                    {
                        if (l == 0)
                        {
                            matches.Add((new Match(String.Format("{0}", i), standings[i - 1], standings[n - 1])));
                        }
                        else
                        {
                            matches.Add(new Match((String.Format("{0}", i + (standings.Count - 1))), standings[n - 1], standings[i - 1]));
                        }
                    }
                    for (int j = 1; j < s; j++)
                    {
                        int teamA = ((n - j + i - 2) % k) + 1;
                        int teamB = ((i + j - 1) % k) + 1;

                        if (l == 0)
                        {
                            matches.Add(new Match(String.Format("{0}", i), standings[teamA - 1], standings[teamB - 1]));
                        }
                        else
                        {

                            if (((standings.Count) % 2 == 0))
                            {
                                matches.Add(new Match(String.Format("{0}", i + (standings.Count - 1)), standings[teamB - 1], standings[teamA - 1]));
                            }
                            else
                            {
                                matches.Add(new Match(String.Format("{0}", i + (standings.Count)), standings[teamB - 1], standings[teamA - 1]));
                            } // Spatne pridava zapasy pro liche tabulky
                        }
                    }

                }
            }

        }
       
        private void buttonLoadData_Click(object sender, EventArgs e)
        {
            {
                players = new List<Player>();

                String fileName = String.Empty;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Soubory dat (*.csv)|*.csv|Vsechny|*.*";

                    if (DialogResult.OK == openFileDialog.ShowDialog())
                    {
                        fileName = openFileDialog.FileName;
                    }
                }

                if (!String.IsNullOrEmpty(fileName))
                {
                    String [] lines = File.ReadAllLines(fileName, Encoding.GetEncoding("Windows-1250"));

                    String[] line = lines[0].Split(';');

                    if (int.TryParse(line[0],out int trash)) // pokud jde naparsovat, jedná se o číslo (round) pokud nejde je to string (team)
                    {
                        LaodMatchesFile(fileName);
                    }
                    else
                    {
                        LoadTeamsFile(fileName);
                    }
                }
        
                buttonSimulate.Enabled = Enabled;

                if (standings[0].players.Count != 0)
                {

                    comboBoxTeams.Enabled = true;
                    if (standings[0].players.Count == 11)
                    {
                        buttonShowRoster.Enabled = true;
                    }
                    buttonPlayersTeamsTable.Enabled = true;
                    buttonStat.Enabled = true;
                    buttonFast.Enabled = true;
                    buttonSlow.Enabled = true;

                    comboBoxTeams.Items.Clear();

                    foreach (Team team in standings)
                    {
                        comboBoxTeams.Items.Add(team.Name);

                        foreach (Player player in team.players)
                        {
                            player.Order = players.Count + 1;
                            players.Add(player);
                            
                        }
                    }
                    comboBoxTeams.SelectedIndex = 0;


                }
                else
                {
                    comboBoxTeams.Enabled = false;
                    buttonShowRoster.Enabled = false;
                    buttonPlayersTeamsTable.Enabled = false;
                    buttonStat.Enabled = false;
                    buttonFast.Enabled = false;
                    buttonSlow.Enabled = false;
                }
                


                labelGameMin.Text = String.Format("Game: 1 min: 0");

            }
        }

        private void buttonSimulate_Click(object sender, EventArgs e)
        {
            String[] data = labelGameMin.Text.Split(' ');
            int minute = int.Parse(data[3]);
            int game = int.Parse(data[1]);

            if (timer.Enabled == false)
            {
                buttonSimulate.Text = String.Format("Stop Simulate");
                timer.Enabled = true;
                log.Add(String.Format("Timer have been started at {0} minutes {1} games",minute, game));

            }
            else
            {
                buttonSimulate.Text = String.Format("Simulate");
                timer.Enabled = false;
                log.Add(String.Format("Timer have been ended at {0} minutes {1} games", minute, game));
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            String[] data = labelGameMin.Text.Split(' ');
            int minute = int.Parse(data[3]);
            int round = int.Parse(data[1]);



            if (minute == 90)
            {

                foreach (Match match in matches)
                {
                    if (match.Round == round)
                    {

                       

                        foreach (Team team in standings)
                        {
                           
                            int vyhodnoceni = match.VyhodnotZapas();

                            if (match.Home == team.Name)
                            {
                                team.Round++;
                                team.For += match.scoreHome;
                                team.Against += match.scoreAway;
                                if (vyhodnoceni == 1)
                                {
                                    team.Wins++;
                                    team.Points += 3;
                                }
                                else if (vyhodnoceni == 0)
                                {
                                    team.Draws++;
                                    team.Points++;
                                }
                                else
                                {
                                    team.Losts++;
                                }
                            }

                            if (match.Away == team.Name)
                            {
                                team.Round++;
                                team.For += match.scoreAway;
                                team.Against += match.scoreHome;
                                if (vyhodnoceni == 2)
                                {
                                    team.Wins++;
                                    team.Points += 3;
                                }
                                else if (vyhodnoceni == 0)
                                {
                                    team.Points++;
                                    team.Draws++;
                                }
                                else
                                {
                                    team.Losts++;
                                }
                            }

                        }


                        match.end = true;

                    }
                    
                }

                RecalculateStandings();
                RecalculatePlayers();
                


                log.Add(String.Format("Konec {0}. kola", round));

                if (round < LeagueEnd()-1)
                {
                    log.Add(String.Format("Soutěž vede: {0}", standings[0].Name));
                }
                else
                {
                    log.Add(String.Format("Soutěž vyhrál tým: {0}", standings[0].Name));
                }
                dataGridViewStandings.Invalidate();
                dataGridViewScore.Invalidate();

                minute = 0;

                round++;

            }
            if (round < LeagueEnd())
            {

                minute++;

                labelGameMin.Text = String.Format("Round: {0} min: {1}", round, minute);


                foreach (Match match in matches)
                {

                    if ((match.Round == round))
                    {

                        string goalAuthor = match.Play();

                        if (goalAuthor != "")
                        {
                            log.Add(String.Format("Gól v zapase: {0} vs {1}", match.teamHome.Name, match.teamAway.Name));


                            if (goalAuthor != "nikdo")
                            {
                                log.Add(String.Format("Vstřelil hráč číslo {0}", goalAuthor));


                            }


                            log.Add(String.Format("minuta:{0} stav je: {1}:{2}", minute, match.scoreHome, match.scoreAway));
                        }
                    }

                }

                // dataGridViewScore.Invalidate();
                // dataGridViewScore.Refresh();
            }
            else
            {
                timer.Enabled = false;
                buttonSimulate.Text = "Simulate";
                buttonSimulate.Enabled = false;               
            }
        }

        private int LeagueEnd()
        {
            if (((standings.Count) % 2 == 0))
            {
                return (standings.Count * 2) - 1;
            }
            else
            {
                return (standings.Count * 2) + 1; 
            }
        }

        private void RecalculateStandings()
        {

            for (int i = 0; i < standings.Count - 1; i++)
            {

                for (int j = 0; j < standings.Count - i - 1; j++)
                {

                    if (standings[j + 1].Points > standings[j].Points)
                    {

                        Team bubbleSort = standings[j + 1];

                        standings[j + 1] = standings[j];

                        standings[j] = bubbleSort;

                    }
                    else if (standings[j + 1].Points == standings[j].Points)
                    {
                        if (standings[j + 1].GoalDifference > standings[j].GoalDifference)
                        {
                            Team bubbleSort = standings[j + 1];

                            standings[j + 1] = standings[j];

                            standings[j] = bubbleSort;
                        }
                        else if (standings[j + 1].GoalDifference == standings[j].GoalDifference)
                        {
                            if (standings[j + 1].For > standings[j].For)
                            {
                                Team bubbleSort = standings[j + 1];

                                standings[j + 1] = standings[j];

                                standings[j] = bubbleSort;
                            }
                            else if (standings[j + 1].For == standings[j].For)
                            {
                                Random random = new Random();
                                if (random.Next(1, 2) == 1)
                                {
                                    Team bubbleSort = standings[j + 1];

                                    standings[j + 1] = standings[j];

                                    standings[j] = bubbleSort;
                                }

                            }

                        }

                    }
                }
 
            }

            for(int i = 0;i < standings.Count;i++)
            {
                standings[i].Order = i+1;

            }

        }

        private void RecalculatePlayers()
        {
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

            for (int i = 0; i < players.Count; i++)
            {
                players[i].Order = i + 1;

            }

        }

        private void buttonShowRoster_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                buttonSimulate_Click(null, null);
            }

            using (Roster form = new Roster())
            {

                foreach (Team team in standings)
                {

                    if (team.Name == comboBoxTeams.Text)
                    {
                        form.team = team;
                    }

                }
              

                form.ShowDialog();
                
                
            }
        }

        private void buttonPlayersTeamsTable_Click(object sender, EventArgs e)
        {

            if (dataGridViewStandings.DataSource == standings)
            {
                buttonPlayersTeamsTable.Text = String.Format("Teams");
                                
                dataGridViewStandings.DataSource = players;

            }
            else
            {
                buttonPlayersTeamsTable.Text = String.Format("Players");

                dataGridViewStandings.DataSource = standings;
            }
        }

        private void buttonStat_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                buttonSimulate_Click(null, null);
            }
            using (FormStatistics form = new FormStatistics())
            {

                foreach (Team team in standings)
                {

                    if (team.Name == comboBoxTeams.Text)
                    {
                        form.team = team;
                    }

                }

                List<Match> teamMatches = new List<Match>();

                foreach (Match match in matches)
                {

                    if ((match.Home == form.team.Name) || (match.Away == form.team.Name))
                    {

                        teamMatches.Add(match);

                    }

                }

                form.matches = teamMatches;

                form.ShowDialog();


            }

        }

        private void buttonSlow_Click(object sender, EventArgs e)
        {
            timer.Interval = 200;
        }

        private void buttonFast_Click(object sender, EventArgs e)
        {
            timer.Interval = 1;
        }

    }
}
