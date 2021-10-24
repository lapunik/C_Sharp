using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKEY
{
    public partial class ReadLog : Form
    {
        public ReadLog()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Browse Log Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_file.Text = openFileDialog1.FileName;
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            //fp = fopen(filename, "r");
            //if (fp == NULL)
            //{
            //    printf("Could not open file %s", filename);
            //    return 1;
            //}
            //while (fgets(str, MAXCHAR, fp) != NULL)
            //    printf("%s", str);
            //fclose(fp);
            //return 0;
        }
    }
}
