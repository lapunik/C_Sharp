using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainTTLibrary;

namespace TimetableControlTrainTT
{
    public partial class ChangeTrainData : Form
    {
        public BindingList<NoteInTimetable> timetable = new BindingList<NoteInTimetable>();

        public List<DataForTimetable> dataForTimetable = new List<DataForTimetable>();

        public String fileName;

        public ChangeTrainData()
        {
            InitializeComponent();
        }

        private void ChangeTrainData_Load(object sender, EventArgs e)
        {
            while (tableLayoutPanelName.RowStyles.Count <= dataForTimetable.Count)
            {

                int index = tableLayoutPanelName.RowStyles.Count - 1;

                this.Height += 40;

                tableLayoutPanelName.RowStyles.Add(new RowStyle());
                tableLayoutPanelName.RowCount = tableLayoutPanelName.RowStyles.Count;
                tableLayoutPanelTrain.RowStyles.Add(new RowStyle());
                tableLayoutPanelTrain.RowCount = tableLayoutPanelTrain.RowStyles.Count;
                tableLayoutPanelStation1.RowStyles.Add(new RowStyle());
                tableLayoutPanelStation1.RowCount = tableLayoutPanelStation1.RowStyles.Count;
                tableLayoutPanelStation2.RowStyles.Add(new RowStyle());
                tableLayoutPanelStation2.RowCount = tableLayoutPanelStation2.RowStyles.Count;
                tableLayoutPanelWaitTime1.RowStyles.Add(new RowStyle());
                tableLayoutPanelWaitTime1.RowCount = tableLayoutPanelWaitTime1.RowStyles.Count;
                tableLayoutPanelWaitTime2.RowStyles.Add(new RowStyle());
                tableLayoutPanelWaitTime2.RowCount = tableLayoutPanelWaitTime2.RowStyles.Count;
                tableLayoutPanelSpeed.RowStyles.Add(new RowStyle());
                tableLayoutPanelSpeed.RowCount = tableLayoutPanelSpeed.RowStyles.Count;
                tableLayoutPanelPercent.RowStyles.Add(new RowStyle());
                tableLayoutPanelPercent.RowCount = tableLayoutPanelPercent.RowStyles.Count;
                tableLayoutPanelms.RowStyles.Add(new RowStyle());
                tableLayoutPanelms.RowCount = tableLayoutPanelms.RowStyles.Count;
                tableLayoutPanelms2.RowStyles.Add(new RowStyle());
                tableLayoutPanelms2.RowCount = tableLayoutPanelms2.RowStyles.Count;

                foreach (RowStyle rs in tableLayoutPanelName.RowStyles)
                {
                    rs.SizeType = SizeType.Absolute;
                    rs.Height = 40;
                }
                foreach (RowStyle rs in tableLayoutPanelTrain.RowStyles)
                {
                    rs.SizeType = SizeType.Absolute;
                    rs.Height = 40;
                }
                foreach (RowStyle rs in tableLayoutPanelStation1.RowStyles)
                {
                    rs.SizeType = SizeType.Absolute;
                    rs.Height = 40;
                }
                foreach (RowStyle rs in tableLayoutPanelStation2.RowStyles)
                {
                    rs.SizeType = SizeType.Absolute;
                    rs.Height = 40;
                }
                foreach (RowStyle rs in tableLayoutPanelWaitTime1.RowStyles)
                {
                    rs.SizeType = SizeType.Absolute;
                    rs.Height = 40;
                }
                foreach (RowStyle rs in tableLayoutPanelWaitTime2.RowStyles)
                {
                    rs.SizeType = SizeType.Absolute;
                    rs.Height = 40;
                }
                foreach (RowStyle rs in tableLayoutPanelSpeed.RowStyles)
                {
                    rs.SizeType = SizeType.Absolute;
                    rs.Height = 40;
                }
                foreach (RowStyle rs in tableLayoutPanelPercent.RowStyles)
                {
                    rs.SizeType = SizeType.Absolute;
                    rs.Height = 40;
                }
                foreach (RowStyle rs in tableLayoutPanelms.RowStyles)
                {
                    rs.SizeType = SizeType.Absolute;
                    rs.Height = 40;
                }
                foreach (RowStyle rs in tableLayoutPanelms2.RowStyles)
                {
                    rs.SizeType = SizeType.Absolute;
                    rs.Height = 40;
                }

                ComboBox comboBox = new ComboBox()
                {
                    Tag = String.Format("{0}", index),
                    Font = new Font("Microsoft Sans Serif", 10),
                    Dock = DockStyle.Fill,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                };

                for (int i = 0; i < LocomotiveInfo.listOfLocomotives.Count; i++)
                {
                    comboBox.Items.Add(LocomotiveInfo.listOfLocomotives[i].Name);
                }

                comboBox.SelectedItem = dataForTimetable[index].Locomotive.Name;

                comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;

                tableLayoutPanelTrain.Controls.Add(comboBox);

                TextBox textBox = new TextBox()
                {
                    Tag = String.Format("{0}", index),
                    Font = new Font("Microsoft Sans Serif", 10),
                    Text = dataForTimetable[index].Type,
                    Dock = DockStyle.Top,
                };

                textBox.TextChanged += textBox_TextChanged;

                tableLayoutPanelName.Controls.Add(textBox);

                NumericUpDown numericUpDown = new NumericUpDown()
                {
                    Tag = String.Format("{0}", index),
                    Font = new Font("Microsoft Sans Serif", 10),
                    Dock = DockStyle.Top,
                    Increment = 10,
                    Minimum = 10,
                    Maximum = 100,
                    Value = ((decimal)dataForTimetable[index].Speed) * 100,
                };

                tableLayoutPanelSpeed.Controls.Add(numericUpDown);
                /*
                TextBox textBoxS1 = new TextBox()
                {
                    Tag = String.Format("{0}", index),
                    Font = new Font("Microsoft Sans Serif", 10),
                    Text = dataForTimetable[index].Station1.Name,
                    Dock = DockStyle.Top,
                };

                tableLayoutPanelStation1.Controls.Add(textBoxS1);

                
                TextBox textBoxS2 = new TextBox()
                {
                    Tag = String.Format("{0}", index),
                    Font = new Font("Microsoft Sans Serif", 10),
                    Text = dataForTimetable[index].Station2.Name,
                    Dock = DockStyle.Top,
                };

                tableLayoutPanelStation2.Controls.Add(textBoxS2);
               */

                ComboBox comboBoxS1 = new ComboBox()
                {
                    Tag = String.Format("{0}", index),
                    Font = new Font("Microsoft Sans Serif", 10),
                    Dock = DockStyle.Fill,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                };

                for (int i = 0; i < SectionInfo.listOfSection.Count; i++)
                {
                    comboBoxS1.Items.Add(SectionInfo.listOfSection[i].Name);
                }

                comboBoxS1.SelectedItem = dataForTimetable[index].Station1.Name;

                comboBoxS1.SelectedIndexChanged += comboBox_SelectedIndexChanged;

                tableLayoutPanelStation1.Controls.Add(comboBoxS1);

                ComboBox comboBoxS2 = new ComboBox()
                {
                    Tag = String.Format("{0}", index),
                    Font = new Font("Microsoft Sans Serif", 10),
                    Dock = DockStyle.Fill,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                };

                for (int i = 0; i < SectionInfo.listOfSection.Count; i++)
                {
                    comboBoxS2.Items.Add(SectionInfo.listOfSection[i].Name);
                }

                comboBoxS2.SelectedItem = dataForTimetable[index].Station2.Name;

                comboBoxS2.SelectedIndexChanged += comboBox_SelectedIndexChanged;

                tableLayoutPanelStation2.Controls.Add(comboBoxS2);


                NumericUpDown numericUpDownW1 = new NumericUpDown()
                {
                    Tag = String.Format("{0}", index),
                    Font = new Font("Microsoft Sans Serif", 10),
                    Dock = DockStyle.Top,
                    Increment = 100,
                    Minimum = 0,
                    Maximum = 10000,
                    Value = dataForTimetable[index].WaitTime1,
                };

                tableLayoutPanelWaitTime1.Controls.Add(numericUpDownW1);

                NumericUpDown numericUpDownW2 = new NumericUpDown()
                {
                    Tag = String.Format("{0}", index),
                    Font = new Font("Microsoft Sans Serif", 10),
                    Dock = DockStyle.Top,
                    Increment = 100,
                    Minimum = 0,
                    Maximum = 10000,
                    Value = dataForTimetable[index].WaitTime2,
                };

                tableLayoutPanelWaitTime2.Controls.Add(numericUpDownW2);

                Label label = new Label()
                {
                    Tag = String.Format("{0}", index),
                    Font = new Font("Microsoft Sans Serif", 10),
                    Dock = DockStyle.Top,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = "[%]",
                };

                tableLayoutPanelPercent.Controls.Add(label);

                Label labelms = new Label()
                {
                    Tag = String.Format("{0}", index),
                    Font = new Font("Microsoft Sans Serif", 10),
                    Dock = DockStyle.Top,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = "[ms]",
                };

                tableLayoutPanelms.Controls.Add(labelms);

                Label labelms2 = new Label()
                {
                    Tag = String.Format("{0}", index),
                    Font = new Font("Microsoft Sans Serif", 10),
                    Dock = DockStyle.Top,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = "[ms]",
                };

                tableLayoutPanelms2.Controls.Add(labelms2);

            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox == null)
            {
                return;
            }

            foreach (Control control in tableLayoutPanelTrain.Controls)
            {
                if ((control.Tag != comboBox.Tag) && (control.Text == comboBox.Text))
                {
                    comboBox.SelectedIndex++;
                }
            }

        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox == null)
            {
                return;
            }

            foreach (Control control in tableLayoutPanelName.Controls)
            {
                if ((control.Tag != textBox.Tag) && (control.Text == textBox.Text))
                {
                    textBox.Text += "X";
                }
            }

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // nejdřív data v jizdnim radu

            for (int i = 0; i < timetable.Count; i++)
            {
                for (int j = 0; j < dataForTimetable.Count; j++)
                {
                    if (timetable[i].Type == dataForTimetable[j].Type)
                    {
                        if (Packet.GapToUnderLine(timetable[i].StartStation.Name) == dataForTimetable[j].Station1.Name)
                        {
                            timetable[i].StartStation = new Section(tableLayoutPanelStation1.Controls[j].Text);
                            timetable[i].FinalStation = new Section(tableLayoutPanelStation2.Controls[j].Text);
                        }
                        else
                        {
                            timetable[i].StartStation = new Section(tableLayoutPanelStation2.Controls[j].Text);
                            timetable[i].FinalStation = new Section(tableLayoutPanelStation1.Controls[j].Text);
                        }


                        timetable[i].Type = tableLayoutPanelName.Controls[j].Text;
                    }
                }
            }

            // potom teprve data pro jízdní řád

            for (int i = 0; i < dataForTimetable.Count; i++)
            {

                dataForTimetable[i].Locomotive = (new Locomotive(tableLayoutPanelTrain.Controls[i].Text));
                dataForTimetable[i].Type = tableLayoutPanelName.Controls[i].Text;
                dataForTimetable[i].Station1 = (new Section(tableLayoutPanelStation1.Controls[i].Text));
                dataForTimetable[i].Station2 = (new Section(tableLayoutPanelStation2.Controls[i].Text));
                dataForTimetable[i].Speed = (double)((tableLayoutPanelSpeed.Controls[i] as NumericUpDown).Value / 100);
                dataForTimetable[i].WaitTime1 = (uint)(tableLayoutPanelWaitTime1.Controls[i] as NumericUpDown).Value;
                dataForTimetable[i].WaitTime2 = (uint)(tableLayoutPanelWaitTime2.Controls[i] as NumericUpDown).Value;


            }

            if (checkBoxInFile.CheckState == CheckState.Checked)
            {
                ChangeDataInFile();
            }
        }

        private void ChangeDataInFile()
        {
            if (!String.IsNullOrEmpty(fileName))
            {
                try
                {
                    String[] lines = new String[(dataForTimetable.Count + timetable.Count)];

                    for (int i = 0; i < dataForTimetable.Count; i++)
                    {
                        DataForTimetable d = new DataForTimetable(dataForTimetable[i].Locomotive, dataForTimetable[i].Type, dataForTimetable[i].Station1, dataForTimetable[i].Station2, dataForTimetable[i].Speed, dataForTimetable[i].Reverse1, dataForTimetable[i].Reverse2, dataForTimetable[i].WaitTime1, dataForTimetable[i].WaitTime2);

                        lines[i] = d.Line;
                    }

                    for (int i = 0; i < timetable.Count; i++)
                    {
                        NoteInTimetable n = new NoteInTimetable(timetable[i].Type, timetable[i].StartStation, timetable[i].FinalStation, timetable[i].Departure);

                        lines[i + 3] = n.Line;
                    }

                    File.WriteAllLines(fileName, lines,Encoding.GetEncoding("Windows-1250"));

                }
                catch (IOException e)
                {
                    MessageBox.Show("An I/O error occurred while opening the file...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}