using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databaze_Konzole
{
    class Program
    {
        static void Main(string[] args)
        {

            // connectionstring.com prost mrda connection stringů

            Console.WriteLine("Start test");

            using(SqlConnection connection = new SqlConnection("Data Source=147.228.90.71;Initial Catalog=ase;Persist Security Info=True;User ID=ase;Password=ase")) // using blok abych nemusel dělat na konci dispose
            {                                                                                                                                                                // connection string jsem ukradl v properties na serveru kae-virtual bla bla.. (heslo je ase)
                connection.Open();

                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
                    /*
                    sqlCommand.CommandText = "SELECT SUM(ipsc) FROM psc"; // velke pismena jen pro přehlednost

                    object o = sqlCommand.ExecuteScalar(); // Execute fuknce (podívat se v přednášce)

                    Console.WriteLine("{0}, {1}", o, o.GetType());
                    */
                    
                     
                    /* 
                    sqlCommand.CommandText = "SELECT COUNT(*) FROM teploty";

                    object o = sqlCommand.ExecuteScalar(); // Execute fuknce (podívat se v přednášce)
                    if (o == DBNull.Value)
                    {
                        Console.WriteLine("NULL");
                    }
                    else
                    {
                        Console.WriteLine("Pocet teplot: {0}", o);
                    }
                    
                    */

                    DataTable table = new DataTable();

                    sqlCommand.CommandText = "SELECT TOP(10) * FROM teploty ORDER BY cas DESC"; // DESC značí sestupně, "WHERE cas > 0"

                    //sqlCommand.Parameters.AddWithValue("@casDnes",/*Proměná Data Time*/DateTime.Now);

                    //sqlCommand.CommandText = "SELECT TOP(10) * FROM teploty WHERE cas=@casDnes"; // DESC značí sestupně, "WHERE cas > 0"

                    //sqlCommand.CommandText = "SELECT TOP(10) * FROM teploty WHERE cas >= @casOd AND cas<=@casDo "; // DESC značí sestupně, "WHERE cas > 0"

                    using (SqlDataAdapter da = new SqlDataAdapter(sqlCommand)) // adapter je narocnejsi na vykon, zbira vic pameti ale dava tu tabulku jak je, reader pouze ukazuje a kje to nějaký blbý ještě no
                    {
                        da.Fill(table);

                        Console.WriteLine("Vysledek - radku: {0}, sloupcu: {1}", table.Rows.Count, table.Columns.Count);

                    }

                    foreach (DataColumn dataColumn in table.Columns)
                    {
                        Console.Write("{0} {1}\t", dataColumn.ColumnName, dataColumn.DataType);
                    }

                    Console.WriteLine("\n*********************************************************");

                    foreach (DataRow dataRow in table.Rows)
                    {
                        Console.WriteLine(String.Join("\t",dataRow.ItemArray));
                    }

                    Console.WriteLine("\n*********************************************************");
                    

                    using (SqlDataReader rdr = sqlCommand.ExecuteReader()) // nejaký postupný vyčítání řádků, mohu přerušit načítání, zato fill buď zobrzí vše nebo spdne
                    {
                                                        

                        if (!rdr.HasRows)
                        {
                            Console.WriteLine("Nejsou data");
                        }
                        else
                        { // takhle to mužu jenom přečíst , ale je to rychlý
                            while (rdr.Read()) // supr ´mechanismus, vrati false až tam nic nebude
                            {
                                Console.WriteLine("{0}\t{1}\t{2}\t{3}", rdr.GetDouble(0), rdr.GetDateTime(1), rdr.GetInt32(2), rdr.GetString(3));
                            }
                            
                        }

                    }

                    
                }

                connection.Close();
            }

            Console.WriteLine("End test");

        }
    }
}
