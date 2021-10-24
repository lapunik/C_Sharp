using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VlakyTT
{
    class Engine // třída reprezentující každou jednu lokomotivu kterou chci právě ovládat nebo kterou ovládá jízdní řád
    {
        public List<string> listOfEngines = new List<string>() // kažná nová lokomotiva okamžitě obsahuje seznam možných názvů lokomotiv
        {
            "Taurus EVB",
            "Taurus DHL",
            "Ragulin",
            "Desiero DB642 133-3",
            "Brejlovec",
            "ICE",
            "Taurus Railion",
            "Herkules Priessnitz",
            "Para 555",
            "Desiero (Kamera)",
            "DB204 274-5",
            "ES363",
            "T334 Rosnicka"
        };

        private string name; 
        public string Name // vlastnost jméno vlaku ani netřeba blíže opisovat
        {
            set
            {
                name = value; // při změněn se nastaví nová hodnota
                AssignID(); // a zároveň se zavolám metoda na přiřazení příslušného ID
                Message = SetMessage(); // a velice důležitá věc, vlastnost lokomotivy "Message" se přenastaví podle ID
            }
            get
            {
                return name; // pouze vrací jméno vlaku
            }
        }
        private int direction;
        public int Direction // vlastnost reprezentující směr vlaku
        {
            set
            {
                direction = value; 
                Message = SetMessage(); // opět okamžitě jak se hodnota směru změní, měním také zprávu reprezentující nastavené hodnoty vlaku
            }
            get
            {
                return direction;
            }
        }
        private int speed;
        public int Speed // vlastnost reprezentující rychlost vlaku
        {
            set
            {
                speed = value;
                Message = SetMessage(); // stejně jako u zbytku vlastností se ze zeměnou rychlosti, mění také zpráva 
            }
            get
            {
                return speed;
            }
        }
        private string id;
        public string ID //vlastnost reprezentující ID vlaku
        {
            set
            {
                id = value;
                Message = SetMessage(); // přenastavuje zprávu podle nově zadaného ID
            }
            get
            {
                return id;
            }
        }
        public string Message { set; get; } // zpráva se mění se změnou kteréhokoliv parametru, reprezentuje zprávu v byte která se má poslat do desky pokud cheme aby lokomotiva vykonávala námi nastavené vlastnosti
                       
        public Engine(string name) // konstruktor třídy
        {
            Name = name; // přiřadí vlastnost jména polde vstupního argumentu konstruktoru
            Speed = 0; // nastaví vlastnost rychlosti do 0
            Direction = 0; // nastaví vlastnost směru do 0
            AssignID(); // zavolá metodu která podle názvu vlaku přiřadí příslušné ID
        }

        private void AssignID() // Metoda která podle názvu vlaku přiřadí příslušné ID
        {
            switch (Name) // podle jména, se vybere jedna z možností
            {
                case "Taurus EVB":
                    ID = "10"; // a je mu přiřazena ID (pevně daná v lokomotivě)
                    break;
                case "ICE":
                    ID = "0A";
                    break;
                case "Taurus Railion":
                    ID = "06";
                    break;
                case "Brejlovec":
                    ID = "03";
                    break;
                case "Desiero (Kamera)":
                    ID = "05";
                    break;
                case "Desiero DB642 133-3":
                    ID = "0F";
                    break;
                case "DB204 274-5":
                    ID = "07";
                    break;
                case "Ragulin":
                    ID = "09";
                    break;
                case "ES363":
                    ID = "11";
                    break;
                case "Taurus DHL":
                    ID = "0B";
                    break;
                case "Herkules Priessnitz":
                    ID = "0C";
                    break;
                case "Para 555":
                    ID = "0D";
                    break;
                case "T3334 Rosnicka":
                    ID = "0E";
                    break;
                default: // pokud se nenajde žádný název shodný s názvy vlaků (bude k tomu docházet zavolámeli tuto třídu a v comboboxu pro výběr vlaku bude položka "Select engine")
                    break; // metoda ID nepřiřadí a ukončí se
            }
        }

        private string SetMessage() // funkce která se stará o akuálnost vlastnosti "Message"
        {           
            string secondDataByte = "01"; // "second data byte" reprezentuje druhý datový byte v bitech (pro řízení lokomotiv jsou vždy první dva bity 01)
            secondDataByte += Direction.ToString(); // další bit je 1 nebo 0 podle směru
            string speed = Convert.ToString(Speed, 2); // hodnotu rychlosti musím převést do binární podoby

            while (speed.Length < 5) // a doplnit ze shora nulami
            {
                speed = "0" + speed;
            }

            secondDataByte += speed; // teprve takto připravený tvar mohu přilepit k současnému byte 
            secondDataByte = String.Format("{0:X}", (Convert.ToInt32(secondDataByte, 2))); // nakonec celý vyrobený byte je potřeba převést z binární soustavy do hexadecimální
            return (String.Format("08 10 20 " + ID + " " + secondDataByte + " 00 00 00 00 00 00 FF")); // až v tuto chvíli můžeme napsat hlavičku která má ustálený tvar "08", dále adresu pro řízení lokomotiv "10 20", potom ID lokomotivy a náš vytvořený datový byte s informacemi o rychlosti a směru, zbytek paketu doplníme nulovými byte a zakončíme byte FF (prozatimně, dokud se nepředělá systém na kotrolu CRC při přijmání i odesílání zpráv)
        } // takže v tuhle chvíli máme nastavenou zprávu pro lokomotivu ID s danou rychlostí a směrem a můžeme si ji kdykoliv vyzvednout
    }
}
