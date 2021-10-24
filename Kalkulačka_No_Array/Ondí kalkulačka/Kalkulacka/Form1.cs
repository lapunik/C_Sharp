using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulacka
{
    public partial class Form1 : Form
    {
        Double result = 0;  //proměnná pro uložení výsledku
        Double inter_result=0;//proměnná pro mezivýsledek,to, co se zobrazuje v lblDisp, zadávaná hodnota
        String operation = "";  //proměnná pro znamínko +-*/
        bool equatorPressed = false;    //příznak, že se zmáčklo rovnítko(kvůli opakovanému mačkání rovnítka, aby se vypsala historie správně)
        bool dispzero = true;//proměnná, že je na displeji zobrazena 0
        bool deleninulou = false; //proměnná že se dělilo nulou
        bool vypocitat = false;//aby se mohlo provest =
        bool operationPerformed = false;//příznak, že se provedla operace +-/*
        bool vymaz = false;

        public Form1()
        {
            InitializeComponent();
            lblDisp.Text = "0";

            lblHistory.Text = String.Empty;
            /*lblDisp.Text = "0";
            dispzero = true;*/
        }


        private void button_number(object sender, EventArgs e)//akce v případě kliknutí na tlačítko s číslem
        {
            if (vymaz)
            {
                buttonC.PerformClick();
            }

            if (dispzero||deleninulou)
            {
                lblDisp.Text = "";
            }
            Button pressed_button = (Button)sender;
            inter_result = (10 * inter_result) + Double.Parse(pressed_button.Text);
            lblDisp.Text = inter_result.ToString();
            equatorPressed = false;
            //vypocitat = true;
            
           

        }

        private void button_operator(object sender, EventArgs e)//akce když se zmáčkne +-*/
        {

            //buttonRovno.PerformClick();
            //lblDisp.Text = "";//maze label

            if (deleninulou)
            {
                lblDisp.Text = inter_result.ToString();
                //lblHistory.Text = "0";
                deleninulou = false;
            }

            //equatorPressed = false;
            vypocitat = true;

            if (operationPerformed)
            {
                if (!equatorPressed)
                {
                    buttonRovno.PerformClick();
                    vymaz = false;

                }
                Button pressed_button = (Button)sender;
                lblDisp.Text = "";
                operation = pressed_button.Text;
                lblHistory.Text = result.ToString() + pressed_button.Text;
                inter_result = 0;
                vymaz = false;
            }
            else
            {


                
                if (result == 0)
                {
                    Button pressed_button = (Button)sender;
                    lblDisp.Text = "";
                    operation = pressed_button.Text;
                    result = inter_result;
                    lblHistory.Text = result.ToString() + pressed_button.Text;
                    inter_result = 0;
                }
                else
                {
                    Button pressed_button = (Button)sender;
                    operation = pressed_button.Text;
                    inter_result = 0;
                    lblHistory.Text = result.ToString() + pressed_button.Text;
                    lblDisp.Text = "";

                }
                operationPerformed = true;
            }
        }

        private void buttonC_Click(object sender, EventArgs e) //akce v případě kliku na C - vymazat
        {
            lblDisp.Text = "0";
            dispzero = true;
            result = 0;
            inter_result = 0;
            lblHistory.Text = String.Empty;
            operation = "";
            equatorPressed = false;
            deleninulou = false;
            vypocitat = false;
            operationPerformed = false;
            vymaz = false;
           
        }

        private void buttonRovno_Click(object sender, EventArgs e) //akce v případě kliku na rovnítko
        {

            if (vypocitat)
            {

                lblHistory.Text = lblHistory.Text + inter_result.ToString() + "=";
                if (equatorPressed)
                {
                    lblHistory.Text = result.ToString() + operation + inter_result.ToString() + "=";
                }

                equatorPressed = true;

                switch (operation)
                {
                    case "+":
                        //lblDisp.Text = (result + Double.Parse(lblDisp.Text)).ToString();
                        result = (result + inter_result);
                        lblDisp.Text = result.ToString();
                        break;

                    case "-":
                        //lblDisp.Text = (result - Double.Parse(lblDisp.Text)).ToString();
                        result = (result - inter_result);
                        lblDisp.Text = result.ToString();
                        break;

                    case "*":
                        //lblDisp.Text = (result * Double.Parse(lblDisp.Text)).ToString();
                        result = (result * inter_result);
                        lblDisp.Text = result.ToString();
                        break;

                    case "/":
                        //lblDisp.Text = (result / Double.Parse(lblDisp.Text)).ToString();
                        if (inter_result == 0)
                        {

                            buttonC.PerformClick();
                            dispzero = false;
                            deleninulou = true;
                            lblDisp.Text = "Nulou nelze dělit!";
                            
                            break;
                        }
                        result = (result / inter_result);
                        lblDisp.Text = result.ToString();
                        break;
                    default:
                        break;

                }

                vymaz = true;

                //result = Double.Parse(lblDisp.Text);

            }

        }
    }
}
