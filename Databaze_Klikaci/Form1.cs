using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Databaze_Klikaci
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Load_Data_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=147.228.90.71;Initial Catalog=ase;Persist Security Info=True;User ID=ase;Password=ase")) // using blok abych nemusel dělat na konci dispose
            {                                                                                                                                                                // connection string jsem ukradl v properties na serveru kae-virtual bla bla.. (heslo je ase)
                connection.Open();

                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
                                                        
                    DataTable table = new DataTable();

                    sqlCommand.Parameters.AddWithValue("@pocet", (int)numericUpDown.Value); // numericUpDown hází "decimal" a nikoliv int, proto přetypování

                    sqlCommand.Parameters.AddWithValue("@casOd",new DateTime(2019,12,2));

                    sqlCommand.Parameters.AddWithValue("@casDo",/*Proměná Data Time*/DateTime.Now);

                    //sqlCommand.CommandText = "SELECT TOP(10) * FROM teploty WHERE cas=@casDnes"; // DESC značí sestupně, "WHERE cas > 0"

                    //sqlCommand.CommandText = "SELECT TOP(10) * FROM teploty WHERE cas >= @casOd AND cas<=@casDo "; // DESC značí sestupně, "WHERE cas > 0"

                    //sqlCommand.CommandText = "SELECT TOP(@pocet) * FROM teploty ORDER BY cas DESC";

                    sqlCommand.CommandText = "SELECT TOP(@pocet) * FROM teploty WHERE cas >= @casOd AND cas <= @casDo ";

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        dataAdapter.Fill(table);
                    }

                    grid.DataSource = table;

                }

                connection.Close();
            }
        }
    }
}
