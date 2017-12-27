using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed.DB
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
            Find();
            UpdateTst();
        }

        private static void UpdateTst()
        {
            DataTable dt = new DataTable();
            using (var da = new SqlDataAdapter("SELECT * FROM movie", connStr))
            {
                da.Fill(dt);
                DataRow[] dr = dt.Select("Title='Star Wars'");
                if (dr.Length == 0)
                {
                    return;
                }
                dr[0]["Title"] = "Stars Wars 9";
                da.UpdateCommand = new SqlCommand("update movie set Title = @newTitle where ID = @oldID");
                da.UpdateCommand.Connection = da.SelectCommand.Connection;
                SqlParameter sp0 = da.UpdateCommand.Parameters.Add("@newTitle", SqlDbType.NVarChar);
                sp0.SourceColumn = "Title";
                sp0.SourceVersion = DataRowVersion.Current;
                SqlParameter sp = da.UpdateCommand.Parameters.Add("@oldID", SqlDbType.Int, 0, "ID");
                sp.SourceVersion = DataRowVersion.Original;
                da.Update(dr);
            }
        }

        private static void Find()
        {
            DataTable dt = new DataTable();

            void Select()
            {
                LoadTbl(dt);               //col = 'value'
                DataRow[] rows = dt.Select("Genre='Comedy'");
            }

            void LINQ()
            {
                var result = from row in dt.AsEnumerable()  //IEnumerable, must be for linq
                             where row.Field<string>("Genre") == "Comedy"
                             select row;
            }

            Select();
            LINQ();
        }

        private static void LoadTbl(DataTable dt)
        {
            //DataTable load from query
            using (var da = new SqlDataAdapter("SELECT * FROM movie", connStr))
            {
                da.Fill(dt);
            }
        }

        private static void Load()
        {
            void FromReader()
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
            }

            void FromAdapter()
            {
                //DataTable load from query
                var table = new DataTable();
                using (var da = new SqlDataAdapter("SELECT * FROM movie", connStr))
                {
                    da.Fill(table);
                }
            }

            FromReader();
            FromAdapter();
        }
}
}
