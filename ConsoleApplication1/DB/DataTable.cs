using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DB
{
    static class DataTableTst
    {
        //rdr is at end, Load returns 0 rows
        //The *DataReader classes are forward-only iterators. (store results in list or table for example)
        //The only way to restart/reset it is to grab a new reader with ExecuteReader().

        static string connStr = "Server=(localdb)\\mssqllocaldb;Database=aspnet5-MVCMovie-6ee74982-4ec3-47e0-b632-1729502aab6a;Trusted_Connection=True;MultipleActiveResultSets=true";

        public static void Test()
        {
            Load();
        }

        private static void Load()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("select * from movie", con);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    DataTable tbl = new DataTable();
                    tbl.Load(rdr);
                }
            }

            //DataTable load from query
            var table = new DataTable();
            using (var da = new SqlDataAdapter("SELECT * FROM movie", connStr))
            {
                da.Fill(table);
            }
        }
    }
}
