using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VlastniKontrol
{
  public class MujProtokol : ListBox
  {
    bool _addToTop = false;
    [Description("Určuje, zda se má přidávat na začátek")]
    [DefaultValue(false)]
    [Category("Nastavení")]
    public bool AddToTop
    {
      get { return _addToTop; }
      set { _addToTop = value; }
    }

    int _pocetRadku = 20;
    [Description("Určuje počet řádků ve výpisu")]
    [DefaultValue(20)]
    [Category("Nastavení")]
    public int PocetRadku
    {
      get { return _pocetRadku; }
      set { _pocetRadku = value; }
    }

    public void Add(Object o)
    {
      String s = String.Format(
        "{0:HH:mm:ss.fff} {1}", DateTime.Now, o);

      if (_addToTop)
      {
        while (this.Items.Count >= _pocetRadku)
          Items.RemoveAt(Items.Count - 1);

        Items.Insert(0, s);
        SelectedIndex = 0;
      }
      else
      {
        while (Items.Count >= _pocetRadku)
          Items.RemoveAt(0);

        Items.Add(s);
        SelectedIndex = Items.Count - 1; // posledni
      }

      SelectedIndex = -1;   // odvybrat
    }
  }
}
