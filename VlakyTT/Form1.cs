using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.IO.Ports;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Net.Mail;
using System.Net;

namespace VlakyTT
{
    public partial class Form1 : Form
    {


        private ConcurrentQueue<string> packet = new ConcurrentQueue<string>(); // fronta už plnohodnotných paketů ve správném formátu
        private List<byte> packetInCheck = new List<byte>(); // paket který se zkoumá v metodě "serialPort_DataReceived", ještě není jisté jestli je to plnohodnotný paket (jestli má správný formát a správné CRC)
        private List<byte> secondCheckPacket = new List<byte>(); // pokud se paket kontroluje a vyhodnotí se jako neplatný, je potřeba znovu zkontrolovat paket jestli se uvnitř něho neukrývá jiná hlavička značící začátek paketu 
        private bool chcekPacket = false; // "checkPaket" značí že probíhá kontrola paketu u kterého už bylo podezření že by paket mohl být ale nestalo se tak, tyto data jsou totiž potřeba zkontrolovat dříve než další příchozí 

        private List<Engine> listEngines = new List<Engine>(); // Seznam lokomotiv obsahující všechny lokomotivy + seznam s názvy všech lokomotiv

        private BindingList<NoteInTimetable> timetable = new BindingList<NoteInTimetable>(); // jízdní řád podle kterého se jede (pokud se tedy jede podle jízního řádu)
        private BindingList<NoteInTimetable> timetableRecovery = new BindingList<NoteInTimetable>(); // pokud jízdní řád nikdo nevypne, a on dorazí na svůj konec, je žádoucí aby se obnovil, k tomu slouží tento list
        private bool timetableOn = false; // indikace kzterá říká že program má brát v potaz jízdní řád a brát z něj data 

        private string mode; // mód ve kterém se Form1 vyskytuje 

        private Timer timer = new Timer(); // timer se spustí pouze v reřimu "timetable" ve chvíli kdy vlak vjede do zastávky, poté je potřeba počkat dobu kterou má nastavenou v jízdním řádu, aby před zastavením stihli dojet všechny vagony vlaku

        private string oldMessage = ""; // zpráva kterou jsme poslali v minulém okamžiku, slouží pro detekci jestli jsou zprávy stejné a vyhodnocení jestli je zprávu potřeba posílat stejnou znovu
        private int sendCounter = 0; // počítá, když se zpráva posílaná do kolejiště nemění, pošle ji pouze jednou za čas, tak aby se nepřehltil USB to CAN převodník, v případě že se zpráva mění, je stále na nule a zprávy se stále posílají

        private List<bool> oldCurrentState = new List<bool>(); // seznam informací o obsazenosti úseků v minulém okamžiku, slouží pro porovnání s obsazením v současném okamžiku a tím vyhodnocení jestli se vlaky fyzicky hýbou či nikoliv
        private int changeIndicator = 0; // pokud jsme v režimu "timetable" a vlaky dostanou příkaz k pohybu, načte se počet vlaků které by měli zmenit svou obsazenost do této proměné, pokud nezmění, vím že některé vlaky se fyzicky nepohnuly

        private Timer timerError = new Timer(); // za určitý čas (Interval tohoto timeru) pokud nedošlo ke změně obsazenosti úseků a "changeIndicator" není nula, to znamená že některý vlak měl svou pozici změnit, provede potřebaná opatření, viz. kód

        private List<DataForTimetable> dataForTimetables = new List<DataForTimetable>(); // List obsahující data pro jízní řád, jízdní řád obsahuje hlavičku která se načte do této proměnné a porgram jí který vlak má kam jet a jak dlouho tam čekat

        public Form1(string mode) // konstruktor s vstupním argumentem "mode", který rozhodne co se stane dál
        {
            InitializeComponent();
            // tady bylo: comboBoxSerialPort.SelectedIndex = comboBoxSerialPort.Items.Count - 1;
            EnablePorts(); // Metoda pro zpřístupnění a výběr portů 
            this.mode = mode; // mód který určuje jestli se program bude řídit jízním řádem, manuálně nebo před "debug" přímím odesílání paketů

            if (mode == "debug") // mód pro odlaďování, je zde vidět graficky obsazenost ústeků, zprávy které se příjmají i které se odesílají
            {
                return;
            }
            else if (mode == "timetable") // mód pro automatickou jízdu podle jízdního řádu nahraného v souboru .csv
            {
                buttonOpenPort_Click(null, null); // stiskni tlačítko pro otevření portu
                buttonFormTimetable_Click(null, null); // stisk tlačítka pro otevření formuláře jízdního řádu (možnost otevřít tento formulář je přes tlačítko i v řežimu "debug")
            }
            else if (mode == "manual") // mód pro manuální řízení vlaků, jednoduše tabulka s ovládacími prvkami pro každý vlak (směr, rychlost)
            {
                buttonOpenPort_Click(null, null); // stiskni tlačítko pro otevření portu
                ManualControl(null, null); // stisk tlačítka pro otevření formuláře manual (možnost otevřít tento formulář je přes tlačítko i v řežimu "debug")
            }

        }

        private void EnablePorts() // Zpřístupní porty pomocí comboboxu
        {
            comboBoxSerialPort.Items.AddRange(SerialPort.GetPortNames()); // načte všechny dostupné (připojené COM porty) a předá je do comboboxu
            comboBoxSerialPort.SelectedIndex = comboBoxSerialPort.Items.Count - 1; //Vybere nejvyšší možný COM port (zdálo se mi to jako vhodnější varianta než pouze natvrdo nastavit daný COM port)
        }

        private void buttonOpenPort_Click(object sender, EventArgs e) // tlačítko otevření vybraného portu v comboboxu
        {
            try
            {
                if ((comboBoxSerialPort.Text == "")) //kontrola jestli je v comoboxu port který lze používat
                {

                    textBoxstatus.Text = String.Format("These values are not entered"); // Pokud ne, vypíše hlášku

                }
                else 
                {
                    serialPort.PortName = comboBoxSerialPort.Text; // seriový port je vytvořen v "Návrhu" s požadovanou rychlostí 115200 Bd, přiřazení názvu COM portu z comboboxu
                    serialPort.Open(); // otevření portu
                    buttonOpenPort.Enabled = false; // následuje sekvence zpřístupnění nebo naopak odepření přístupu k vizuelním prvkům aplikace které mají co dočinění s portem
                    buttonClosePort.Enabled = true;
                    buttonAutoSend.Enabled = true;
                    buttonStopShowPackets.Enabled = true;
                    textBoxSend.Enabled = true;
                    buttonSend.Enabled = true;
                    buttonFormTimetable.Enabled = true;
                    buttonAddEngine.Enabled = true;
                    buttonRemoveEngine.Enabled = true;
                    textBoxstatus.Text = String.Format("Port {0} is open", serialPort.PortName); // vypíše hlášku o tom že port byl úspěšně otevřený
                    timerReadSerialPort.Enabled = true; // zapnutí časovače s intervalem 200ms, který sleduje co přichází po seriovém portu

                    if (tablePanelName.Controls.Count < 1) 
                    {
                        buttonAddEngine_Click(null, null); // přidání prvního bloku pro ovládání vlaku
                    }

                }

            }
            catch (UnauthorizedAccessException) //vyjímka pokud se nepodaří port otevřít
            {

                textBoxstatus.Text = String.Format("Unauthorized access"); 

            }

        }

        private void buttonClosePort_Click(object sender, EventArgs e) // inverzní tlačítko k tlačítku Open port
        {
            timerReadSerialPort.Enabled = false; // zastaví časovač přijmu dat a zakáže přístup k ovládacím prvkům pro které je stěžejní otevřený COM port
            serialPort.Close(); // zavření portu 
            buttonOpenPort.Enabled = true; 
            buttonClosePort.Enabled = false;
            buttonAutoSend.Enabled = false;
            buttonSend.Enabled = false;
            buttonStopShowPackets.Enabled = false;
            textBoxSend.Enabled = false;
            buttonAddEngine.Enabled = false;
            buttonFormTimetable.Enabled = false;
            buttonRemoveEngine.Enabled = false;
            textBoxstatus.Text = String.Format("Port {0} is close", serialPort.PortName);
            while (tablePanelName.Controls.Count > 0)
            {
                buttonRemoveEngine_Click(null, null); //odstranění bloků pro ovládání všech mašin
            }
            listBoxPackets.Items.Clear(); // vyšistí list box 

        }

        private void timerReadSerialPort_Tick(object sender, EventArgs e) // metoda pro sledování v intervalech, co ze seriového portu chodí za zprávy
        {
            while (packet.Count > 0)  // Pokud je ve frontě "packet" co číst
            {
                string p; 

                if (!packet.TryDequeue(out p)) // zkus uložit první data ve frontě do proměnné "p"
                {
                    return; // pokud se to nepovede, ukonči metodu
                }

                if (buttonStopShowPackets.Text == "Stop") // pokud není zastavené příjmání zpráv pomocí tlačítka "Stop" pod list boxem, tlačítko je zde pro vhodnější práci debug
                {
                    listBoxPackets.Items.Insert(0, p);  // naplň list box daty z proměnné p (nejnovější data řadím nahoru)

                    listBoxPackets.SelectedIndex = 0; // označ nejnovější data

                    string[] byteInPacketString = p.Split(' '); // rozděl data z proměné p oddělovačem mezera do stringového pole (na string pole lze použít metodu ".Split()")

                    List<int> byteInPacketInt = new List<int>(); // rozdělená data chceme převést do int listu pro lepší zpravocání, takže list vytvoříme

                    for (int i = 0; i < byteInPacketString.Length; i++) 
                    {
                        if (byteInPacketString[i] != "")
                        {
                            byteInPacketInt.Insert(0, Convert.ToInt32(byteInPacketString[i], 16)); // projedeme všechny data v stringovém poli a pokud nejsou prázdná (pro jistotu), uložíme je do listu
                        }
                    }

                    byteInPacketInt = ObtainCurrents(byteInPacketInt); // stále máme v paketu všechny data včetně hlavičky, adresy a CRC, fukce "ObtainCurrents" nám vytáhne pouze data o proudech v jednotlivých úsecích, pokud data nejsou informace o proudech (poznáme podle adresy 30 60) vrátí null

                    List<bool> currentStateNow = new List<bool>(); // založíme nový list, plný booleovských proměných, později nám dovolí porovnávat stav obsazenosti úseků teď ze stavem předešlým

                    if (byteInPacketInt != null) // pokud je co číst
                    {

                        foreach (int currentState in byteInPacketInt) // nahrajeme informace o obsazenosti úseků do listu "currentState"
                        {
                            if (currentState > 40) //hranici od kdy je úsek obsazený jsem zvolil 40 (na číslo jsem přišel metodou pokus omyl)
                            {
                                currentStateNow.Add(true); // přidávám do listu booleovských proměných informace true/false
                            }
                            else
                            {
                                currentStateNow.Add(false);
                            }
                        }

                        DrawGraphCurrent(byteInPacketInt); // metoda pro vykreslení grafu, který znázorňuje obsazenost úseků (pro jednodušší debug)

                        if (timetableOn) // jestliže je zapnutý režim jízdího řádu
                        {
                            Timetable(currentStateNow); // zavolej jízdní řád (prozkoumej instrukce v něm a podle toho srovnej vlaky na svá místa(ve zkratce))
                        }

                        if (changeIndicator != 0) // pokud se proměnná hlídající, jestli by se měla v dohledné době změnit obsazenost úseků nerovná nule(nula značí vše v pořádku), přičítání do této proměné v okamžik kdy by se obsazenost měla měnit lze nalézt na řádku: 398
                        {
                            for (int i = 0; i < oldCurrentState.Count; i++) // prozkoumám starou obsazenost úseků s tou kterou mám právě teď
                            {
                                if (oldCurrentState[i] != currentStateNow[i]) // pokud se nerovnají (tudíž vlaky opustili své úseky), odečti od indikátoru jedičku (aby se zaznamenalo že vlak změnil svou polohu), nepředpokládám že by vlaky změnili obsazenost v úplně stejný okamžik
                                {
                                    changeIndicator--;
                                }
                            }
                        }

                        oldCurrentState.Clear(); // odstraň starou obsazenost úseků 

                        oldCurrentState = currentStateNow; // a ulož novou 


                    }
                }
            }
        }

        private List<int> ObtainCurrents(List<int> list) // získej informace o proudech
        {
            if (list.Count > 11) // zpráva obsahující proudy z úseků má tvar: Hlavička, Adresa(30 60), data a CRC
            {
                if ((list[11] == 8) && (list[10] == 48) && (list[9] == 96)) // HEX: 08 30 60 => zprava proudu o obśazenosti, ale pozor, načítám pospátku protože useky jsou načtené pospátku
                {

                    list.RemoveAt(11); //  odstraňuji hlavičku 
                    list.RemoveAt(10);  // odstraňuji adresu
                    list.RemoveAt(9);  // odstraňuji adresu
                    list.RemoveAt(0);  // odstraňuji CRC // teď už zbyli pouze data o obsazenosti úseků

                    return list; // vrať list s daty

                }
                else
                {
                    return null; // vrať null
                }
            }
            else
            {

                return null; // vrať null

            }
        } 

        private void DrawGraphCurrent(List<int> current) // vykresli hodnoty proudů do bar grafu
        {
            barGraph.Series["Section"].Points.Clear(); //vyčisti bar graf

            for (int i = 0; i < current.Count; i++) // prozkoumej všechny proudy
            {
                barGraph.Series["Section"].Points.AddXY((i).ToString(), current[i]); // přidej do grafu sloupec s příslušnou hodnotou

                if (current[i] > 200)
                {
                    barGraph.Series["Section"].Points.ElementAt(i).Color = Color.ForestGreen; // obarvi sloupec na příslušnou barvu (pro jednodušší práci a debug)
                }
                else if (current[i] < 40)
                {
                    barGraph.Series["Section"].Points.ElementAt(i).Color = Color.Brown;
                }
                else
                {
                    barGraph.Series["Section"].Points.ElementAt(i).Color = Color.Gray;
                }
            }

        }

        private void Timetable(List<bool> current) // metoda zavolání akce podle jízdního řádu jednotlivým vlakovým spojením
        {
           // OnOffMonitor(); // metoda která pokud v dohledné době nepojede vlak, zhasne monitor(nebo jej rozsvítí pokud vlak v dohledné době pojede)

            TimetableRecovery(); // metoda pro obnovení jízdního řádu na další den

            foreach (DataForTimetable data in dataForTimetables) // v istu "dataForTimetables" jsou v jednotlivých položkách uloženy informace z hlavičky jízdního řádu (který vlak jezdí po kterých úsekách, jakou rychlostí, jak dlouho má čekat po přijetí do úseku než zastaví).. ten se projede a pro každou hlavičkovou položku se provede metoda "EvaluateCommandFromTimetable" 
            {
                EvaluateInstructionFromTimetable(data.Train, data.Section1, data.Section2, current, data.Type, data.Station1, data.Station2, data.Speed, data.Direction1, data.Direction2, data.WaitTime1, data.WaitTime2); // metoda která porovnává jízdní řád s dobou právě teď a dává vlakům říkazy do které zastávky mají jet
            }
        }

        private void OnOffMonitor() // metoda která pokud v dohledné době nepojede vlak, zhasne monitor(nebo jej rozsvítí pokud vlak v dohledné době pojede)
        {
            if (DateTime.Now.Second == 0) // každou minitu
            {
                if (timetable.Count != 0) // pokud není jízdní řád prázdný
                {
                    if (timetable[0].Departure.TimeOfDay - DateTime.Now.TimeOfDay > new TimeSpan(0, 30, 0)) // a jestliže rozdíl času v jízním řádu a času právě teď je větší než 30min
                    {
                        WinLowLevel.SetDisplayState(WinLowLevel.eMonitorState.Off); // Zavolej metodu z třídy WinLowLevel pro nastavení monitoru do režimu "Vypnuto"
                    }
                    else
                    {
                        WinLowLevel.SetDisplayState(WinLowLevel.eMonitorState.On); // Pokud podmínka není pravda, monitor zapni
                    }
                }
            }
        }

        private void TimetableRecovery() // metoda pro obnovení jízdního řádu na další den
        {
            if ((DateTime.Now.Hour == 0) && (DateTime.Now.Minute == 0) && (DateTime.Now.Second == 1)) // pokud je jízdní řád pro dnešek prázdný, další den v první sekundě dne se opět obnoví
            {
                if ((timetableOn) && (timetable.Count != timetableRecovery.Count)) // pokud se délky obou jízdních řádů nerovanjí a zároveň je spuštěn timetable (kdyby nebyl, tak bych se sem teoreticky vůbec neměl dostat, takže jen pro jistotu)
                {
                    foreach (NoteInTimetable note in timetableRecovery) //projeď uloženou kopii původně načteného jízdního řádu a nači ji opět do jízdního řádu
                    {
                        timetable.Add(note);
                    }
                }
            }
        }

        private void EvaluateInstructionFromTimetable(string train, int section1, int section2, List<bool> occupancyOfSections, string type, string station1, string station2, double speed, string direction1, string direction2, int waitTime1, int waitTime2)
        { // nejdříve tedy k vstupním argumentům: (název vlaku, prvni usek na kterém vlak může zastavit(reálné číslo úseku na jednotce), druhy usek na kterém vlak může zastavit,seznam obsazenosti úseků, pracovní název(typ) vlaku,pracovní název první zastávky(jmeno zvolim v souboru s jízdním řádem, je jedno jaké je, ale takové bude zobrazeno v jízdním řádu), pracovní název druhé zastávky, rychlost vlaku (0 až 1), směr ve kterém pojede vlak z prvního úseku do druhého, směr ve kterém pojede vlak z druhého úseku do prvního,čas od doby co vlak zaznamená první úsek až do doby než vlak dostane skutečne povel stůj(kvůli dojetí všech vagonů), stejně tak i pro druhý úsek)

            int numberOfTain = 0; // číslo se později přiřadí, je to vlastně číslo říkající v kolikátém comboboxu achází vlak s názevem, který chceme ovládat

            //Nejprve je potřeba přiřadit vlak do comboboxu
            foreach (ComboBox comboBox in tablePanelName.Controls)
            {
                if (comboBox.Text == "Select engine") // pokud je blok na ovládání vlaku volný
                {
                    for (int i = 0; i < comboBox.Items.Count; i++)
                    {

                        if (comboBox.Items[i].ToString() == train) // a zároveň se název vlaku v itemech comboboxu rovná názvu vlaku v hlavičce jízdního řádu
                        {
                            comboBox.SelectedIndex = i; //vyber v comboboxu právě tento item
                        }
                    }
                }

            }
 
            for (int i = 0; i < tablePanelName.Controls.Count; i++) // projedu všechny vlaky v comboboxu
            {
                ComboBox comboBox = tablePanelName.Controls[i] as ComboBox;

                if (comboBox.SelectedItem.ToString() == train) // a ptám se jestli název vlaku je shodný s názvem vybraným v comboboxu
                {
                    numberOfTain = i; //jestli ano, číslo vlaku je daná otočka cyklu for (toto číslo vlastně potřebujeme pro nalezení tagu pro blok ovládání vlaku)
                }
            }

            bool dataChanged = false; // založím proměnou která bude později indikovat jestli se mají některá data z jízdního řádu odstranit (už jsou stará, vlaky už odjely) 

            for (int i = 0; i < timetable.Count; i++) // projíždíme jízdní řád tak dlohuo dokud nenarazíme na nejbližší akci která se má vykonat pro danný vlak (nezapomeňme že tato funkce se volá pro každý vlak terý stojí na kolejích zvlášť) 
            { 
                if ((timetable[i].Departure.Second > DateTime.Now.Second) || (timetable[i].Departure.Minute > DateTime.Now.Minute) || (timetable[i].Departure.Hour > DateTime.Now.Hour)) // podmínka spíše pro jistotu, aby se nebrali v potaz záznamy v jízdním řádu které jsou staré (teoreticky by se tady už vůbec objevit neměly)
                {
                    if ((timetable[i].Type == type) && (timetable[i].StartStation == station1) && (timetable[i].FinalStation == station2)) // pokud se typ vlaku rovná se záznamem v jízdním řádu a pokud má startovat z pozice "station1", musí na ni dojet (takhle funguje celý princip jízdního řádu, ve chvíli kdy se má vykonat příkaz v jízdím řádu, tak tento příkaz algoritmus vlastně zahodí a najde si nejbližší další příkaz, kde má vlastně napsáno že za nějaký čas má stát někde jinde aby mohl jet zase někam.. a on tam nestojí aby mohl tento příkaz splnit, takže tam jede (zjednodušeně řečeno vlaky dostavají příkazy kde mají stát, místo toho aby dostávali příkazy kam mají jet) ) 
                    {
                        GoToTheStation(numberOfTain, section1, occupancyOfSections, speed, direction1, waitTime1); //(Jeď do stanice..) "section1" je usek kam prijizdim proto "waitTime1" je cas ktery ma pockat, po zaznamenání úsekem, nez zastavi v danem useku
                        break; // pokud se nalezne shoda a některý příkaz se nalezne, musím ukončit prohledávání jízdního řádu
                    }
                    if ((timetable[i].Type == type) && (timetable[i].StartStation == station2) && (timetable[i].FinalStation == station1)) // pokud u první podínky seděl typ vlaku ale neseděl od kud kam má jet, vykoná se tento druhý příkaz
                    {
                        GoToTheStation(numberOfTain, section2, occupancyOfSections, speed, direction2, waitTime2); // takže jak jsme řikali o pár řádků výš, tady vlaku vlastně říkám, máš stát v úsku 2
                        break; // pokud se nalezne shoda a některý příkaz se nalezne, musím ukončit prohledávání jízdního řádu
                    }
                }
            }


            for (int i = 0; i < timetable.Count; i++) // prozkoumám jízdní řád kvůli odstranění starých příkazů v něm
            {
                if (((timetable[i].Departure.Second < DateTime.Now.Second) && (timetable[i].Departure.Minute == DateTime.Now.Minute) && (timetable[i].Departure.Hour == DateTime.Now.Hour)) || (timetable[i].Departure.Hour < DateTime.Now.Hour) || ((timetable[i].Departure.Minute < DateTime.Now.Minute)&& (timetable[i].Departure.Hour == DateTime.Now.Hour))) //takhle šílená podmínka vlastně říká jen "je-li čas v jízdním řádu menší než čas právě teď"
                {
                    timetable.Remove(timetable[i]); //pokud se takový záznam najde, je potřeba ho z jízdního řádu vyhodit
                    i--; // tím že záznam vyhodíme, zmenšíme počet  záznamů v jízdím řádu, takže když chceme prověřit záznam hned za vyhozeným, má nyní stejný index jako měl právě vyhozený záznam, proto snížení počitadla i
                    dataChanged = true; // indikuje že některý ze záznamů v jízdním řádu byl odstraňen, tuto informaci budu potřebvat proto abych napočítal, kolik valků mělo v danný čas opustit svůj úsek a měl tím feedback o tom jestli vlaky jezdí jak mají
                }
            }
            
            if (dataChanged) // pokud došlo k odstranění záznamu v jízdním řádu
            {
                dataGridChanged(); // zavolej metodu která zjistí zda v tento okamžik mají některé vlaky opustit svůj úsek
            }


        }

        private void GoToTheStation(int numberOfTain, int usek, List<bool> current, double speed, string direction, int waitTime) // příkaz pro odjezd vlaku na daný úsek, pokud zde teda už nestojí (vlaku vlastně říkám, kde má právě teď stát)
        {

            if (!current[usek]) // pokud není úsek na kterém má vlak stát obsazený, proveď opatření..
            {

                if ((tablePanelStart.Controls[numberOfTain] as Button).Text == "Start") // Pokud je tlačítko v bloku pro ovládání vlaku "start" (to zanemná že vlak stojí)
                {
                    (tablePanelSpeed.Controls[numberOfTain] as TrackBar).Value = (Convert.ToInt16(((tablePanelSpeed.Controls[0] as TrackBar).Maximum) * speed)); // tak nastav rychlost pomocí track baru na poadovanou 

                    trackBarSpeed_Scroll((tablePanelSpeed.Controls[numberOfTain] as TrackBar), null); // aby track bar zaregistroval že jsem mu změnil hodnotu a překreslil se

                    buttonStart_Click(tablePanelStart.Controls[numberOfTain] as Button, null); // klikni na tlačítko start (aby se vlak rozjel)
                }
                if ((tablePanelDirection.Controls[numberOfTain] as Button).Text == direction) // pokud se směr napsaný na tlačítku rovná směru kterým chci jet, zmáčkni toto tlačítko (protože když je na tlačítku "Dopředu", znamená to že jedu dozadu)
                {
                    buttonDirection_Click((tablePanelDirection.Controls[numberOfTain] as Button), null);
                }
            }
            else if ((current[usek])) // pokud vlak stojí na úseku kde stát má
            {
                if ((tablePanelStart.Controls[numberOfTain] as Button).Text == "Stop") // a zároveň je na tlačítku nápis "Stop" (to zanamená že vlak je v pohybu)
                {

                    // tady by člověk očekával příkaz zastav vlak, ale já chci nejprve dojet do stanice tak aby např. všichni lidé v vagonů mohli vytoupit na nástupiště, takže místo příkazu "zastav", nechám vlak jet určenou dobu (z hlavičky v jízdním řádu) a pak ho teprve zastavím 

                    timer.Interval = waitTime; // "waitTime" obsahuje informaci jak dlouho má vlak ještě jet než zastaví, nastavíme tedy přesně tak dlouhý interval (čas čekání můe být pochopitelně i nulový)
                    timer.Tag = numberOfTain; // do tagu časovače uložíme index, který říká, ve kterém ovládacím bloku pro vlaky, se tento vlak nachází
                    timer.Enabled = true; // zapneme časovač
                    timer.Tick += timer_Tick; // a jako funcki "tick" mu dáme naší funkci "timer_Tick"
                    
                }
            }

        } 

        private void timer_Tick(object sender, EventArgs e) // časovač pro zastavení vlaku
        {
            int numberOfTrain = int.Parse(timer.Tag.ToString()); // které tlačítko "stop" mám zmáčknout mi říká tag, do kterého jsme právě tuhle informaci uložili
            (tablePanelSpeed.Controls[numberOfTrain] as TrackBar).Value = 0; // nastav daný track bar do nulové hodnoty (zastavení)
            trackBarSpeed_Scroll((tablePanelSpeed.Controls[numberOfTrain] as TrackBar), null); //zavolej metodu pro track bar aby se překreslil a změnu zaznamenal
            buttonStart_Click(tablePanelStart.Controls[numberOfTrain] as Button, null); // zmáčkni tlačítko "stop"
            timer.Enabled = false; //časovač pro zastavení vlaku vypni  
        } 

        private void dataGridChanged()// metoda pro prozkoumání, jestli v tento danný moment mají některé vlaky opustit svůj úsek
        {

            for (int i = 0; i < timetableRecovery.Count; i++) //prohledáme kopii jízdího řádu a zjistíme z ní, kolik vlaků se má v tento moment pohnout ze svého úseku
            {
                if ((timetableRecovery[i].Departure.Second == DateTime.Now.Second) && (timetableRecovery[i].Departure.Minute == DateTime.Now.Minute) && (timetableRecovery[i].Departure.Hour == DateTime.Now.Hour)) // které vlaky mají jet právě teď
                {
                    changeIndicator++; // inkrementuji proměnou, více vysvětlenou na řádku 42
                }
            }

            timerError.Interval = 15000; // nastav čas 15 vteřin do časovače 

            timerError.Enabled = true; // zapni časovač, čímž vlastně zavolej metodu "timerError_Tick" po nastaveném intervalu

            timerError.Tick += timerError_Tick; //metoda "timerError_Tick" zjistí zda všechny změny v obsazenosti proběhly jak měly

        }

        private void timerError_Tick(object sender, EventArgs e)
        {
            if (changeIndicator != 0) // jestliže indikátor který hlídá když se změní obsazenost úseků ani po patnácti vteřinách není nula
            {
                 SendMail("lapunik@students.zcu.cz", "Vlaky TT", "Některý z vlaků neopustil nádraží."); //zavolej metodu poslání emailu na daný email s předmětem a textem..
            }

            timerError.Enabled = false; // vypni časovač
            changeIndicator = 0; // hodnotu indikátoru nastav do nuly aby byl zase použitelný
        } // zjistí zda všechny změny v obsazenosti proběhly jak měly

        public static void SendMail(string to, string subject, string body)
        {

            MailAddress mailAddress = new MailAddress("lapunik@students.zcu.cz", "Kolejiště FEL"); // vytvoření proměné mailová adresa s konstruktorem emailu ze kterého se má zpráva posalt 

            using (MailMessage mailMassage = new MailMessage()) // vytvoření mailové zprávy
            {
                try
                {
                    mailMassage.To.Add(to); // příjemce
                    mailMassage.Sender = mailAddress; // odesílatel
                    mailMassage.From = mailAddress; // "od koho" 
                    mailMassage.Subject = subject; // předmět
                    mailMassage.Body = body; // zpráva
                }
                catch
                {

                }

                using (SmtpClient clnt = new SmtpClient("smtp.zcu.cz")) // klient SMTP 
                {
                    try
                    {
                        clnt.Send(mailMassage); //pošli mail přes klienta
                    }
                    catch
                    {

                    }
                }
            }

        } //metoda pro odeslání emailu
   
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e) // metoda která reaguje na přijmutá data po sériovém portu (vždy když se data dostaví a jsou smysluplná, uloží je do frony)
        {
            if (e.EventType == SerialData.Chars)
            {

                while ((serialPort.IsOpen) && (serialPort.BytesToRead > 0)) // dokud je co číst z portu a zároveň je pot otevřený tak prováděj cyklus
                {
                    byte data; // příprava proměnné do které budu ukládat data po dobu zpracování a zkoumání smysluplnosti

                    if (secondCheckPacket.Count > 1) //jestlize je co číst z paketu který jsem zkoumal a vyhodnotil jako paket falešný, musím jeho části opět prozkoumat, tentokrát bez prvního byte který se falešn tvářil jako hlavička
                    {
                        secondCheckPacket.RemoveAt(0); // tady provádím odstraňování byte z listu podruhé kontorolovaných byte
                        data = secondCheckPacket[0]; //uložím do "data" byte který je potřeba prozkoumat
                    }
                    else // pokud je "secondCheck" prázdný, bereme data normálně ze serial portu
                    {
                        if (!serialPort.IsOpen) //bezprostřední test jestli se port neodpojil respektive jestli je co číst
                        {
                            return;
                        }
                        data = (byte)serialPort.ReadByte(); // čti byte ze serial portu
                    }

                    if ((data > 0) && (data <= 8) && (!chcekPacket)) // jestliže je byte (HEX: 01 až 08), což jsou možné začátky datových paketů a zároveň se žádný paket právě teď neprozkoumává (to zančí proměnná chceckPacket)
                    {
                        packetInCheck.Add(data); // přidej do "packetInCheck" tento byte (přidá se na první místo, jak z kontextu vyplívá)
                        chcekPacket = true; // zapni signalizaci že se již zkoumá některý paket
                    }
                    else if (chcekPacket) // pokud první podmínka není splněna a zároveň je některý paket právě zkoumaný, provede se tento cyklus
                    {
                        if ((packetInCheck.Count) == ((packetInCheck[0]) + 3)) // hlavička paketu mi říká, kolik datových byte paket obsahuje, tudíž pokud je zkoumaný paket dlouhý jako hodnota této hlavičky + 3 (protože k datovým paketům je ještě jeden byte hlavička a dva byte asresa), tak by další byte měl být CRC, to se testuje níže
                        {
                            byte crc = VypocetCRC(packetInCheck); // vypočtu si kolik vychází CRC z dosavadního paketu, tato hodnota by se měla rovnat poslednímu byte který přijde

                            packetInCheck.Add(data); // doplním poslední byte který obsahuje informaci CRC

                            if (packetInCheck[packetInCheck.Count - 1] == crc) // pokud se tento poslední byte rovná s byte "crc" který jsme vypočítali, našli jsme plnohodnotný paket a máme vyhráno
                            {
                                string packetComplete = ""; // proměnná typu string kam data nahrajeme a pošleme je do string fronty

                                for (int i = 0; i < packetInCheck.Count; i++) // projedeme délku námi nalezeného paketu
                                {
                                    packetComplete += String.Format("{0:X2} ", packetInCheck[i]); // a každý jeho byte načteme do stringové proměnné s oddělovačem "mezera" 
                                }

                                packet.Enqueue(packetComplete); // do fronty přidáme paket zabalený ve string

                            }
                            else // pokud CRC nesedí, vyhodím z kontrolovaného paketu první byte
                            {
                                packetInCheck.RemoveAt(0);
                                secondCheckPacket.AddRange(packetInCheck);// a falešný paket, teď už bez prvního byte(faešné hlavičky) nahraji do listu a "prohledej ho znovu"                          
                            }

                            chcekPacket = false; // ať už paket dopadl jako plnohodnotný a odeslal se do fronty nebo falešný a odeslal se do listu byte které je potřeba znovu zkontrolovat, musím ukončit signalizaci že zrovna některý z paketů kontroluji, to značí proměná "chcekPacket"
                            packetInCheck.Clear(); // stejně tak, ať už paket byl nebo nebyl plnohodnotný, musíme tento paket smazat abychom mohli zkoumat paket nový 

                        }
                        else // pokud není prohledávaný paket u teoreticky svého posledního byte, prostě jenom načti další byte
                        {
                            packetInCheck.Add(data);
                        }
                    }
                }
            }
        }

        private byte VypocetCRC(List<byte> paket) // výpočet CRC
        {
            byte crc = 0;
            byte icrc, ucrc;

            byte CRC_POLYNOM = 0xd8;
            byte TOP_BIT = 0x80;

            for (ucrc = 0; ucrc < paket.Count; ucrc++)
            {
                crc ^= paket[ucrc];

                for (icrc = 8; icrc > 0; --icrc)
                {


                    if ((crc & TOP_BIT) != 0)
                    {
                        crc = (byte)(crc << 1);
                        crc = (byte)(crc ^ CRC_POLYNOM);
                    }
                    else
                    {
                        crc <<= 1;
                    }
                }
            }

            return (byte)crc;
        }

        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e) // metoda volaná vybráním v comboboxu v bloku pro ovládání vlaků
        {
            ComboBox comboBoxName = sender as ComboBox;    
            
            if (comboBoxName == null) // bezpečné přetypování senderu na combo box
            {
                return; 
            }

            foreach (Control control in tablePanelName.Controls)
            {
                if ((control.Tag != comboBoxName.Tag) && (control.Text != "Select engine") && (control.Text == comboBoxName.Text)) // projdi všechny comboboxy, pokud má některý z nich stejnou vybraný stejný vlak, který se pokouší uživatel vybrat teď i na tomto comboboxu, tak vyber na comboboxu item "Select Engine"...  podmínka "contorl.Tag != comboBoxName.Tag" zaručuje že při prohledávání comboboxů když narazí foreach na combobox který zrovna nastavuji, bude jeho hodnotu ignorovat a poslendí podmínka "control.Text != "Select engine"" zařizuje že text comboboxu "Select engine" není brát jako vybraný název vlaku 
                { 
                    comboBoxName.Text = "Select engine"; // pokud se tedy uživatel pokouší nastavit vlak na comboboxu který je již vybrán v jiném comboboxu, nenastaví se nic
                }
            }
            
            int tag = int.Parse(comboBoxName.Tag.ToString()); // přetypuj Tag na číslo a ulož jej do proměnné "tag"

            Button buttonDirection = tablePanelDirection.Controls[tag] as Button; // vytvořím si tlačítko směru, tlačítko "start" a trackbar rychlosti a vytvořím referenci na skutečná tlačítka a track bar v bloku pro ovládání vlaku na konkrétním tagu
            TrackBar trackBar = tablePanelSpeed.Controls[tag] as TrackBar;
            Button buttonStart = tablePanelStart.Controls[tag] as Button;

            listEngines[tag] = new Engine(comboBoxName.Text); // v listu lokomotiv vytvořím novou mašinu s názvem z comboboxu
            listEngines[tag].Speed = 0; // nastavím ji hodnotu rychlosti 0
            buttonStart.Text = String.Format("Start"); // nastavím tlačítko "start" do polohy lokomotiva stojí
            buttonStart.BackColor = Color.ForestGreen; // podbarvím tlačítko zeleně (pro efekt)
            buttonDirection.Text = String.Format("Backward"); // směr jízdy lokomotivy nastavím na "dopředu"
            trackBar.Value = 0; //její rychlost nastavím na nulu také na vizuelním trackbaru
        }

        private void buttonDirection_Click(object sender, EventArgs e) // metoda vyvolaná tlačítkem pro ovládání směru v bloku ovládání vlaků
        {
            Button button = sender as Button;
            if (button == null) // bezpečné přetypování
            {
                return;
            }

            int tag = int.Parse(button.Tag.ToString());

            if (listEngines[tag].Direction == 1) // jestliže byl směr vlkau nastaven na hodnotu jedna
            {
                button.Text = String.Format("Backward"); //přepiš nápis na tlačítku
                listEngines[tag].Direction = 0; // a nastav ho na hodntu nula 

            }
            else
            {
                button.Text = String.Format("Forward"); // v opačném případě udělej opak
                listEngines[tag].Direction = 1;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e) // metoda vyvolaná tlačítkem "start" v bloku ovládání vlaků
        {
            Button button = sender as Button;
            if (button == null) // Bezpečné přetypování
            {
                return;
            }
            if ((tablePanelName.Controls[int.Parse((button.Tag).ToString())] as ComboBox).Text == "Select engine") // pokud kliknu na talčítko v bloku pro ovládání vlaku, který ale nemá vybraný žádný vlak v comboboxu, ignoruj kliknutí
            {
                return;
            }

            if (button.Text == "Start") // pokud vlak stál
            {
                button.Text = String.Format("Stop"); // přepiš tlačítko na "zastav"
                button.BackColor = Color.Brown; // pro přehlednost ho přebarvi

                if (!timerSend.Enabled) // jestliže odesílání již neběží
                {
                    buttonAutoSend_Click(null, null); // nastav tlačítko centrálního zastavení do polohy "vypnout" kde se krom jiného také zapne časovač "timerSand"
                }
            }
            else
            {
                button.Text = String.Format("Start"); //v opačném případě prostě přeřiš a přebarvi tlačítko (odesílání zpráv do desky funguje tak, že se prochází všechny "start" tlačítka, jestli má některé tlačítko v poloze "stop"(tudíž je v pohybu), tak odesílá zprávu o pohybu)
                button.BackColor = Color.ForestGreen; 
            }
        }

        private void trackBarSpeed_Scroll(object sender, EventArgs e) // metoda vyvolaná scrollováním trackbaru v bloku ovládání vlaků
        {
            TrackBar trackBar = sender as TrackBar;
            if (trackBar == null) // bezpečné přetypování
            {
                return;
            }

            int tag = int.Parse(trackBar.Tag.ToString());

            listEngines[tag].Speed = trackBar.Value; //hodnota rychlosti vlaku v seznamu vlaků se rovná nastavené hodnotě na trackbaru 
        }

        private void timerSend_Tick(object sender, EventArgs e) // medota opakující se každých 25 ms která zkoumá jestli je co odeslat do desky 
        {
            textBoxSend.Text = ""; // vymaž text box kde se zobrazují právě posílaná data

            if (mode != "manual") // teď jsou ve směs dvě mořnosti, buď data dostávám z "debug" formuláře Form1, nebo třeba z jízdního řádu, a v tom případě se tvoří zpáva projížděním tlačítek "start" právě ve Form1 a hledá se které je aktivní a které ne, nebo duhá možnost viz. else
            {
                if ((mode == "timetable")||(mode == null)) // jestliže odesílání volá jízdní řád
                {
                    mode = sender as string;
                    if (mode == null)
                    {
                        return; // od jízdního řádu může přijít pokyn pauza nebo jeď, tento pokyn dostanu z senderu 
                    }
                }
                foreach (Control button in tablePanelStart.Controls) // procházím všechny tlačítka "start"
                {
                    int tag = int.Parse(button.Tag.ToString());

                    if (button.Text == "Stop") //pokud je tlačítko v poloze "stop" (to znamená že vlak by měl jet)
                    {
                        if (mode != "debug") // a zároveň se nacházíme v režimu timetable
                        {
                            if (mode != "pause") // a zároveň nám timetable nedává zprávu o pauze
                            {
                                textBoxSend.Text += " " + listEngines[tag].Message; // tak vlož do odesílacího text boxu zprávu od vlaku na stejném indexu v listu vlaků jako je indexu ovládacího bloku 
                            }
                            else
                            {
                                int speed = listEngines[tag].Speed; // uschovej inforaci o rychlosti vlaku 
                                listEngines[tag].Speed = 0; // ale nastav informaci o nulové rychlosti, aby vlak dostával pokyn k zastavení, je možné zastavit vlaky několika možnosti, dvě nejdůležitější jsou (0 - zastavení s brzdnými rampami, 3 - bez zastavovacích ramp
                                textBoxSend.Text += " " + listEngines[tag].Message; // informaci pošli vlaku
                                listEngines[tag].Speed = speed; //a zpět nastav vlaku jeho rychlost (která se tedy ve zprávě zachová a když budu chtít valk rozjet rychlostí kterou jel před tím než jsem klikl na tlačítko stop, stačí mi pouze kliknut na start, místo toho abych musel dát start a znovu vybírat rychlost)
                            }
                        }
                        else // pokud jsme v režimu debug, prostě zapiš pokin do textboxu
                        {
                            textBoxSend.Text += " " + listEngines[tag].Message; // tak vlož do odesílacího text boxu zprávu od vlaku na stejném indexu v listu vlaků jako je indexu ovládacího bloku 
                        }
                    }
                    else if ((tablePanelName.Controls[tag] as ComboBox).Text != "Select engine") // pokud nebyla první podmínka splněna a zároveň se nejedná o nevybraný vlak (nápis "Select engine")... tohle slouží k posílání pokynů o zastavení
                    {
                        int speed = listEngines[tag].Speed; // uschovej inforaci o rychlosti vlaku 
                        listEngines[tag].Speed = 0; // ale nastav informaci o nulové rychlosti, aby vlak dostával pokyn k zastavení, je možné zastavit vlaky několika možnosti, dvě nejdůležitější jsou (0 - zastavení s brzdnými rampami, 3 - bez zastavovacích ramp
                        textBoxSend.Text += " " + listEngines[tag].Message; // informaci pošli vlaku
                        listEngines[tag].Speed = speed; //a zpět nastav vlaku jeho rychlost (která se tedy ve zprávě zachová a když budu chtít valk rozjet rychlostí kterou jel před tím než jsem klikl na tlačítko stop, stačí mi pouze kliknut na start, místo toho abych musel dát start a znovu vybírat rychlost)
                    }
                }
                if (mode != "debug")
                {
                    mode = "timetable"; // jelikož jsme proměnou "mode" přepsali senderem, navrátíme ji její hodnotu "timetable"
                }
            }
            else // mode je nastaven na "manual" a tudíž zpráva kterou chci odeslat mi chodí v senderu od formuláře "manual"
            {
                string message = sender as string; // vytáhni zprávu ze senderu
                if (message == null) // bezpečné přetypování
                {
                    return;
                }
                textBoxSend.Text = message; // zprávu kterrou jsem dostal ze senderu nastav do místa odesílání zpráv do desky
            }

            if (oldMessage == textBoxSend.Text) // toto je systém který pomáhá USB/CAN převodníku aby se nezahltil, pokud je zpráva totožná s tou která se odeslala naposledy
            {
                sendCounter++; // počítadlo mi počítá, jak dlouho jsem již neodeslal zprávu která byla totožná ze správou v předešlém okamžiku 

                if (sendCounter >= 10) // pokud je počitadlo menší než deset, nic se neodesílá, ale pokud je rovno neb větší, pošle zprávu (to znamená že pokud se zpráva nemění, posílám ji do převodníku 10x pomaleji a to je čas který není znát na pohybu lokomotivy ale převodníku zabrání zahlcení)
                {
                    sendCounter = 0; // pokud je tedy zpráva po několikáté stejná, stejně ji musím odeslat a také vynulovat počitadlo, aby systém fungoval stále a ne jen na poprvé
                    sendMessage(textBoxSend.Text); // zavolej metodu pro odeslání informací do desky s textem uloženým v texboxu (to co chci odeslat) 
                }
            }
            else // pokud zpráva není totožná s tou která se odeslala před ní, odešlu ji normálně a taky nastavím počitadlo do polohy, že tato zpáva odešla uplně poprvé
            {
                sendCounter = 0;
                sendMessage(textBoxSend.Text);
            }
            oldMessage = textBoxSend.Text; // starou zprávu už nepotřebuji, takže ji přepíšu zprávou novou, která bude v dalším ticku této metody považována za zprávu starou
        }

        private void sendMessage(string message) // metoda odeslání zprávy zadané jako vstupní agrument string
        {

            List<string> stringByte = (message.Split(new char[] { ' ', '{', '}' }, StringSplitOptions.RemoveEmptyEntries)).ToList<string>(); // nejprve zprávu "roztrháme" do jednotlivých byte ve formátu string pomocí metody split s odděovačem mezery (nebo složených závore, teď už asi nevyužitelné)

            for (int i = 0; i < stringByte.Count; i++) // všechny byte projdeme
            {
                if (stringByte[i] == "FF") // jestliže se byte rovná FF (což je indikátor že se jedná o posledního byte, v budoucnu by tu měl být CRC i pro odesílání, ale ještě není), tak je jasné že všechny byte až do tohoto(respektive společně s tímto) je zpráva pro jednu lokomotivu
                {
                    byte[] byteArray = new byte[i + 1];// vytvořím pole byte o velikosti zprávy, protože mám zprávu stále ve string 

                    for (int j = 0; j < i + 1; j++) // projdu všechny pozice na kterých se zpráva v listu "stringByte" má nacházet
                    {
                        byteArray[j] = byte.Parse(stringByte[j], System.Globalization.NumberStyles.HexNumber, null as IFormatProvider); //a uložím každou z nich do pole byte jako HEX number
                    }
                    for (int j = 0; j < i + 1; j++)
                    {
                        stringByte.RemoveAt(0); // stejný cylkus projedu ještě jednou abych zprávu ze "stringByte" smazal
                    }

                    i = -1; // vynuluji i (respektive vynuluje se samo s další otočkou cyklu)

                    serialPort.Write(byteArray, 0, byteArray.Length); // a konečně odešlu pole byte do desky

                    System.Threading.Thread.Sleep(1); // když jsme koukali s osciloskopem na převodík, stávalo se že zprávy byli moc blízko u sebe a byli náročné na rozeznání pro USB/CAN převodík, proto zemi další zprávou 1ms počkáme
                }
            }
        }

        private void buttonAutoSend_Click(object sender, EventArgs e) // metoda pro zpracování zmáčknutí tlačítka Automatické odesílání
        {
            if (!timerSend.Enabled) // jestliže časovač odesílání neběží
            {
                timerSend.Enabled = true; // zapni ho
                buttonAutoSend.Text = String.Format("Off"); 
            }
            else
            {
                timerSend.Enabled = false; // pokud časovač bežel, vypni ho
                buttonAutoSend.Text = String.Format("Auto Send");

                foreach (Control button in tablePanelStart.Controls) // zároveň projdi všechny ovládací bloky pro lokomotivy a všem vypni tlačítka "start"
                {
                    button.Text = String.Format("Start");
                    button.BackColor = Color.ForestGreen;
                }

            }
        }
        
        private void buttonAddEngine_Click(object sender, EventArgs e) // tlačítko pro přidání nového ovládacího bloku pro lokomotivu
        {
            if (tablePanelName.RowStyles.Count < 14) // máme místo je pro 13 lokomotiv (více jich není k disozici)
            {

                listEngines.Add(new Engine(null)); // přidej do seznamu vlaků novou lokomotivu(zatím jen prázdnou a nenastavenou)

                tablePanelName.RowStyles.Add(new RowStyle()); // sekvence přidání místa pro ovladací prvky a nastavení jejich velikostí
                tablePanelName.RowCount = tablePanelName.RowStyles.Count;
                tablePanelDirection.RowStyles.Add(new RowStyle());
                tablePanelDirection.RowCount = tablePanelDirection.RowStyles.Count;
                tablePanelSpeed.RowStyles.Add(new RowStyle());
                tablePanelSpeed.RowCount = tablePanelSpeed.RowStyles.Count;
                tablePanelStart.RowStyles.Add(new RowStyle());
                tablePanelStart.RowCount = tablePanelStart.RowStyles.Count;

                foreach (RowStyle rs in tablePanelName.RowStyles)
                {
                    rs.SizeType = SizeType.Absolute;
                    rs.Height = 40;
                }
                foreach (RowStyle rs in tablePanelDirection.RowStyles)
                {
                    rs.SizeType = SizeType.Absolute;
                    rs.Height = 40;
                }
                foreach (RowStyle rs in tablePanelSpeed.RowStyles)
                {
                    rs.SizeType = SizeType.Absolute;
                    rs.Height = 40;
                }
                foreach (RowStyle rs in tablePanelStart.RowStyles)
                {
                    rs.SizeType = SizeType.Absolute;
                    rs.Height = 40;
                }

                ComboBox comboBox = new ComboBox() // vytvoření nového comboboxu
                {
                    Tag = String.Format("{0}", listEngines.Count - 1), // tag comboboxu je shodný s pořadím, kolikátý byl vlak přidán do listu lokomotiv
                };

                string[] engines = listEngines[listEngines.Count - 1].listOfEngines.ToArray(); // z listu lokomotiv si vytáhnu všechny možná jména lokomotiv

                comboBox.Items.Add("Select engine"); // přidám do comboboxu položku "nemít vybraný žádný z vlaků"

                comboBox.Items.AddRange(engines); // a následně přidám do položek všechny názvy možné vlaků

                comboBox.SelectedIndex = 0; // comboboxu vyberu defalutně položkou "Select engine" (žádný vlak není vybrán)

                comboBox.SelectedIndexChanged += comboBoxName_SelectedIndexChanged; // přiřadím comboboxu metodu pro změnu výběru položky, kterou již mám vytvořenou na řádku 591

                tablePanelName.Controls.Add(comboBox); // a takto připravený combobox přidám do ovládacího bloku vlkaů

                Button buttonDirection = new Button() // vytvořím také nové tlačítko pro ovládání směru
                {
                    Tag = String.Format("{0}", listEngines.Count - 1), // s tagem schodným s comboboxem
                    Text = "Backward", // nastavený směr je směr dopředu (to znamená že na tlačítku je možnost "jeď dozadu")
                    Dock = DockStyle.Top, //a zadokuji tlačítko nahoře
                };

                buttonDirection.Click += buttonDirection_Click; // přidám tlačítku metodu pro kliknutí na něj

                tablePanelDirection.Controls.Add(buttonDirection); // hotové tlačítko, stejně jako u comboboxu, umístím do bloku pro ovládání vlaku

                TrackBar trackBar = new TrackBar() // stejný pricip následuje i s track barem a následně s tlačítkem "start"
                {
                    Tag = String.Format("{0}", listEngines.Count - 1),
                    Minimum = 0, //minimální hodnota rychlosti je 0´, maximální je 31
                    Maximum = 31,
                    Dock = DockStyle.Top,
                };

                trackBar.Scroll += trackBarSpeed_Scroll;

                tablePanelSpeed.Controls.Add(trackBar);

                Button buttonStart = new Button()
                {
                    Tag = String.Format("{0}", listEngines.Count - 1),
                    Text = "Start",
                    Dock = DockStyle.Top,
                    BackColor = Color.ForestGreen,
                };

                buttonStart.Click += buttonStart_Click;

                tablePanelStart.Controls.Add(buttonStart);

                listEngines[listEngines.Count - 1] = new Engine(comboBox.Text); // v listu lokomotiv na poslední pozici(vytvořili jsme jí na začátku této metody) zavolám konstruktor třídy s názvem vlaku, o tom jak to funguje více ve třídě "Engine"
            }
        }

        private void buttonRemoveEngine_Click(object sender, EventArgs e) // tlačítko pro odebrání posledního ovládacího bloku pro lokomotivu
        {
            if (tablePanelName.RowStyles.Count > 1)
            {

                listEngines.RemoveAt(listEngines.Count - 1); // odstraním poslední lokomotivu ze seznamu lokomotiv

                tablePanelName.Controls.RemoveAt(tablePanelName.Controls.Count - 1); // odstraním všechny ovládací prvky v bloku pro ovládání vlaku a zároveň protor ve kterém byli
                tablePanelName.RowStyles.RemoveAt(tablePanelName.RowStyles.Count - 1);
                tablePanelName.RowCount = tablePanelName.RowStyles.Count;
                tablePanelDirection.Controls.RemoveAt(tablePanelDirection.Controls.Count - 1);
                tablePanelDirection.RowStyles.RemoveAt(tablePanelDirection.RowStyles.Count - 1);
                tablePanelDirection.RowCount = tablePanelDirection.RowStyles.Count;
                tablePanelSpeed.Controls.RemoveAt(tablePanelSpeed.Controls.Count - 1);
                tablePanelSpeed.RowStyles.RemoveAt(tablePanelSpeed.RowStyles.Count - 1);
                tablePanelSpeed.RowCount = tablePanelSpeed.RowStyles.Count;
                tablePanelStart.Controls.RemoveAt(tablePanelStart.Controls.Count - 1);
                tablePanelStart.RowStyles.RemoveAt(tablePanelStart.RowStyles.Count - 1);
                tablePanelStart.RowCount = tablePanelStart.RowStyles.Count;
            }
        }

        private void ButtonStopShowPackets_Click(object sender, EventArgs e) // tlčítko pro zastavení zobrazování paketů, hodí se když chceme podrobě zkoumat příchozí pakety, jejich přesnou hodnotu
        {
            if (buttonStopShowPackets.Text == "Stop") // jestliže bylo spuštěno zobrazování paketů
            {
                buttonStopShowPackets.Text = String.Format("Start"); // nastav tlačítko do opačné polohy 
            }
            else
            {
                buttonStopShowPackets.Text = String.Format("Stop"); // a když ne, tak naopak
            }
        }

        private void buttonSend_Click(object sender, EventArgs e) // tlačítko pro odesílání jednotlivé zprávy, nikolik intervalu odesílaní, hodí se pro odlaďování
        {

            sendMessage(textBoxSend.Text);

           /* string[] znaky = textBoxSend.Text.Split(' ', '{', '}'); 

            for (int i = 0; i < znaky.Length; i++)
            {
                byte[] znak = new byte[1];


                if (byte.TryParse(znaky[i], System.Globalization.NumberStyles.HexNumber, null as IFormatProvider, out znak[0]))
                {
                    serialPort.Write(znak, 0, 1);
                }


            }*/
        }
        
        private void buttonFormTimetable_Click(object sender, EventArgs e)
        {
            LoadTimeTable(); // zavolej metodu pro načtení jízdního řádu ze souboru csv

            using (Timetable form = new Timetable(timetable, timetableRecovery, timerSend_Tick, timerReadSerialPort_Tick)) // vytvoř formulář jízdního řádu a jako vstupní argumenty mu předej jízdní řád a jeho kopii a také metody co probíhají při tiknutí časovače odesílání a časovače přijmání 
            {
                form.ShowDialog(); // zobraz formulář jízdního řádu                
            }

            if (mode == "debug") // jestliže byl mód zvolený jako "debug" zviditelni formulář Form1, (to je rozdíl mezi tím když voláme formulář z menu nebo z Form1)
            {
                Visible = true;
            }

            for (int i = 0; i < 14; i++)
            {
                buttonRemoveEngine_Click(null, null); // odstranění ovládacích bloků teré se používaly pro jízdní řád
            }

            buttonAddEngine_Click(null, null); // přidání jednoho ovládacího bloku lokomotivy
            
            timetable.Clear(); // vymaž jízdní řád
            timetableRecovery.Clear(); // taky jeho kopii            
            timetableOn = false; // a zakaž proměnou která indikuje že program běží jako jízdní řád
        }

        private void LoadTimeTable() // načtení jízdího řádu
        {
            if (!timetableOn) // pokud ještě nemám žádný jízdní řád, musím ho načíst 
            {                
                String fileName = String.Empty; // vytvořím nový string file

                using (OpenFileDialog openFileDialog = new OpenFileDialog()) // otevřu formulář pro výber souboru a najdu příslušný csv soubor
                {
                    openFileDialog.Filter = "Soubory dat (*.csv)|*.csv|Vsechny|*.*"; // s filtrem na csv soubory

                    if (DialogResult.OK == openFileDialog.ShowDialog()) // pokud vyberu soubor a kliknu na "OK"
                    {
                        fileName = openFileDialog.FileName; // do mého string file se načte tento soubor
                    }
                    else
                    {
                        return; // pokud jsem vybral špatný, metoda končí
                    }
                }

                if (!String.IsNullOrEmpty(fileName)) // zkontroluji jestli není soubor prázdný
                {
                    String[] lines = File.ReadAllLines(fileName); // pokud ne, přečtu z něj všechny řádky textu
                    timetable.Clear(); // pro jistotu smažu celý dosavadní jízdní řád
                    timetableRecovery.Clear(); // a taky jeho kopii

                    foreach (String line in lines) // prozkoumám všechny načtené řádky
                    {
                        if (line.Contains("***")) // pokud obsahují indikátor hlavičky v podobě "***", jsou to informace o vlacích a ukládám je do dat pro jízdní řád
                        {
                            DataForTimetable data = new DataForTimetable(line); //založím no´vou položku dat pro jízdní řád (co se dějě uvnitř je popsáno v třídě "DataForTimetable")
                            dataForTimetables.Add(data); // přidám data o vlaku k ostatním datům z jízdního řádu
                        }
                        else
                        {
                            NoteInTimetable note = new NoteInTimetable(line); // pokud neobsahuje tři hvězdičky, je to obyčený záznam v jízdím řádu
                            timetable.Add(note); // proto ho přidám jako záznam v jízdním řádu do listu jízdní řád
                        }
                    }

                    foreach (NoteInTimetable note in timetable)
                    {
                        timetableRecovery.Add(note); // celý jízdní řád nakopíruji také do kopie jízdího řádu, ale nesmím přiřadit refernci, pouze obsahují na začátku stejná data
                    }

                    dataGridTimetable.DataSource = timetable; // jako zdroj pro zobrazení v dataGrid použiji list jízdní řád

                    while (tablePanelName.Controls.Count != 0)
                    {
                        buttonRemoveEngine_Click(null, null); // promažu všechny vlaky aby žádný z nich neměl nastavenou nežádoucí hodnotu
                    }
                    Engine engine = new Engine(""); // založím prádnou mašinu abych z ní dostal seznam všech možných lomkomotiv

                    for (int i = 0; i < engine.listOfEngines.Count; i++)
                    {
                        buttonAddEngine_Click(null, null); /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    }
                }
                timetableOn = true; // zapni signalizaci že je některý jízdní řád nahraný
            }
            else
            {
                timetable.Clear();
                timetableRecovery.Clear(); // a taky jeho kopii
            }
        }

        private void ManualControl(object sender, EventArgs e) // tlačítko pro zobrazení manuálního módu
        {
            using (Manual form = new Manual(timerSend_Tick))
            {
                form.ShowDialog(); // pouze zavolá formulář pro manuální ovládání
            }
        }

    }
}
