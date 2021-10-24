using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int score = 0;

        int throws = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            button2_Click(null, null);
        }

        int time = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval += 50;

            Play();

            if (time == 6)
            {
                Evaluate();
                time = 0;
                timer1.Interval = 50;
                timer1.Enabled = false;
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            foreach (Label label in tableLayoutPanel2.Controls)
            {
                label.Text = "";
            }
            time = 0;
            timer1.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = false;


        }
        public void Play()
        {

            for (int i = 0; i < tableLayoutPanelDice.Controls.Count; i++)
            {

                Dice.Dice dice = tableLayoutPanelDice.Controls[i] as Dice.Dice;

                Label label = tableLayoutPanel2.Controls[i] as Label;

                Random randomNumber = new Random();

                System.Threading.Thread.Sleep(randomNumber.Next(5, 10));

                if (time == 0)
                {
                    dice.Throw();
                }

                if (label.Text == "")
                {
                    if (randomNumber.Next(1, 5) == 1)
                    {
                        label.Text = dice.Number.ToString();
                        time++;
                    }
                    else
                    {
                        dice.Throw();
                    }
                }

            }

        }
        public void Evaluate()
        {
            int now = 0;

            for (int i = 0;i<tableLayoutPanelDice.Controls.Count;i++)
            {

                Dice.Dice dice = tableLayoutPanelDice.Controls[i] as Dice.Dice;
                Label label = tableLayoutPanel2.Controls[i] as Label;

                label.Text = dice.Number.ToString();

                now += dice.Number; 
            }

            label7.Text = "Throw : " + now;

            score += now;

            throws++;

            label8.Text = "Total : " + score + "  (" + (throws) + " throws)";

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            score = 0;
            throws = 0;
            label8.Text = "Total : ";
            label7.Text = "Throw : ";


            Random randomNumber = new Random();

            for (int i = 0; i < tableLayoutPanelDice.Controls.Count; i++)
            {

                Dice.Dice dice = tableLayoutPanelDice.Controls[i] as Dice.Dice;
                Label label = tableLayoutPanel2.Controls[i] as Label;

                dice.Number = i+1;
                dice.Invalidate();
                label.Text = "";
                
            }

        }


    }
}
