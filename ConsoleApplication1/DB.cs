using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class DB
    {
        static string connStr = "Server=(localdb)\\mssqllocaldb;Database=aspnet5-MVCMovie-6ee74982-4ec3-47e0-b632-1729502aab6a;Trusted_Connection=True;MultipleActiveResultSets=true";

        static public void Test()
        {
            using (
                SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("select * from movie", con);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Console.WriteLine(" {0} {1} - {2}", rdr[0], rdr[1], rdr[4]);
                    }
                }
            }
        }
    }
}
