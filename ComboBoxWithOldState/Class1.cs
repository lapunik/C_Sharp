using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComboBoxWithOldState
{
    class Class1 : ComboBox
    {
        string comboBoxOldState;
        public string ComboBoxOldState
        {
            set
            {

                comboBoxOldState = value;


            }
            get
            {

                return comboBoxOldState;

            }
        }

    }
}
