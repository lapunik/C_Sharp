using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class form : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ltrInfo.Text = "Postback:" + this.IsPostBack;

        using (SqlConnection connection = new SqlConnection("Data Source=147.228.90.71;Initial Catalog=ase;Persist Security Info=True;User ID=ase;Password=ase")) // using blok abych nemusel dělat na konci dispose
        {                                                                                                                                                                // connection string jsem ukradl v properties na serveru kae-virtual bla bla.. (heslo je ase)
            connection.Open();

            using (SqlCommand sqlCommand = connection.CreateCommand())
            {
                
                DataTable table = new DataTable();

                sqlCommand.CommandText = "SELECT TOP(20) * FROM teploty ORDER BY cas DESC";
                
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                {
                    dataAdapter.Fill(table);
                   
                }
                
                gvMoje.DataSource = table;
                gvMoje.DataBind();
                
            }

            connection.Close();

        } 
    }

    protected void btnTest_Click(object sender, EventArgs e)
    {
        lblTest.Text = DateTime.Now.ToString();
    }

    protected void btnCalc_Click(object sender, EventArgs e)
    {
        
        int a, b;
        if (int.TryParse(txA.Text, out a) && int.TryParse(txA.Text, out b))
        {
            lblVysledek.Text = (a + b).ToString();
            lblVysledek.BackColor = System.Drawing.Color.LightGreen;
        }
        else
        {
            lblVysledek.Text = "Jsi hloupý";
            lblVysledek.BackColor = System.Drawing.Color.LightPink;
        }

       
    }
}