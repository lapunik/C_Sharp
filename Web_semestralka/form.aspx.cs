using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Chart1_Load(object sender, EventArgs e)
    {

        chart.Series["Teplota"].Points.Clear(); //vyčisti bar graf

        using (SqlConnection connection = new SqlConnection("Data Source=147.228.90.71;Initial Catalog=ase;Persist Security Info=True;User ID=ase;Password=ase")) // using blok abych nemusel dělat na konci dispose
        {                                                                                                                                                                // connection string jsem ukradl v properties na serveru kae-virtual bla bla.. (heslo je ase)
            connection.Open();

            using (SqlCommand sqlCommand = connection.CreateCommand())
            {

                DateTime SelectedDate = calendar.SelectedDate;

                if ((SelectedDate.Year > 2050) || (SelectedDate.Year < 1990))
                {
                    SelectedDate = DateTime.Now;
                }

                // sqlCommand.CommandText = "SELECT TOP(100) * FROM teploty ORDER BY cas DESC"; // DESC značí sestupně,// "WHERE cas > 0"

                sqlCommand.Parameters.AddWithValue("@casOd", new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day, 0, 0, 0));

                sqlCommand.Parameters.AddWithValue("@casDo", new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day, 23, 59, 59));

                if (button.Text=="1907")
                {
                    sqlCommand.CommandText = "SELECT * FROM teploty WHERE cas >= @casOd AND cas <= @casDo AND stanice=1119";
                }
                else
                {
                    sqlCommand.CommandText = "SELECT * FROM teploty WHERE cas >= @casOd AND cas <= @casDo AND stanice=1908";
                }

                using (SqlDataReader sqlDataAdapter = sqlCommand.ExecuteReader()) // nejaký postupný vyčítání řádků, mohu přerušit načítání, zato fill buď zobrzí vše nebo spdne
                {

                    int i = 0;

                    if (!sqlDataAdapter.HasRows)
                    {
                       // Console.WriteLine("Nejsou data");
                    }
                    else
                    { // takhle to mužu jenom přečíst , ale je to rychlý
                        while (sqlDataAdapter.Read()) // supr ´mechanismus, vrati false až tam nic nebude
                        {
                            if (sqlDataAdapter.GetDateTime(1).Day == SelectedDate.Day)
                            {
                                chart.Series["Teplota"].Points.AddXY(sqlDataAdapter.GetDateTime(1).ToShortTimeString(), sqlDataAdapter.GetDouble(0)); // přidej do grafu sloupec s příslušnou hodnotou
                            }
                            i++;

                        }

                    }

                    

                }


            }

            connection.Close();
        }

    }

    protected void Button_Click(object sender, EventArgs e)
    {
        if (button.Text == "1907")
        {
            button.Text = "1119";
        }
        else
        {
            button.Text = "1907";
        }

        Chart1_Load(null,null);
    }

    protected void calendar_SelectionChanged(object sender, EventArgs e)
    {
        Chart1_Load(null, null);
    }
}