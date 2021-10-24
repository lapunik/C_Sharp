using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cv5
{
    public class MujProtokol: ListBox
        
    {
         bool _addToTop = false;

        [Description("Is to add at beginning")]
        [Category("Setting")]  


        public bool AddToTop
        {
            get {return _addToTop; }
            set { _addToTop = value; }
        
        }

        int _pocetRadku = 20;
        [Description("Modifies the number of rows")]
        [Category("Setting")]

        public int PocetRadku
        {
            get { return _pocetRadku; }
            set { _pocetRadku = value; }
        }

        public void Add(Object o)
        {
            String s=String.Format("{0:HH:mm:ss.fff} {1}", DateTime.Now, o);
            if (_addToTop)
            {
                while (this.Items.Count >= _pocetRadku)
                    this.Items.RemoveAt(Items.Count - 1);

                Items.Insert(0, s);
                SelectedIndex = 0;
            }
            else
            {
                while (this.Items.Count >= _pocetRadku)
                    Items.RemoveAt(0);

                Items.Add(s);
                SelectedIndex = Items.Count - 1; // posledni vybranej prvek

            }
            SelectedIndex = -1;  //odvybrat
                
        }
    }
}
