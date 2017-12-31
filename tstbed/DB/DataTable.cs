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
            LoadFromDB();
            UpdateToDB();
            Find();
            AddEditDelete();
            Changes();
            //DataRowVersion, see changes
        }

        private static void Changes()
        {
            DataTable dt = new DataTable();
            void AcceptChanges()
            {
                using (var da = new SqlDataAdapter("SELECT * FROM movie", connStr))
                {
                    da.Fill(dt);
                    DataRow[] dr = dt.Select("Title='Star Wars 10'");
                    if (dr.Length == 0)
                    {
                        return;
                    }
                    var orig = dr[0]["Title"];

                    dr[0]["Title"] = "Star Wars AccptChng";
                    da.UpdateCommand = new SqlCommand("update movie set Title = @newTitle where ID = @oldID") //ctor
                    {
                        Connection = da.SelectCommand.Connection  //object initializer, fixes: object initialization can be simplified
                    };
                    SqlParameter sp0 = da.UpdateCommand.Parameters.Add("@newTitle", SqlDbType.NVarChar);
                    sp0.SourceColumn = "Title";
                    sp0.SourceVersion = DataRowVersion.Current;
                    SqlParameter sp = da.UpdateCommand.Parameters.Add("@oldID", SqlDbType.Int, 0, "ID");
                    sp.SourceVersion = DataRowVersion.Original;
                    dt.AcceptChanges(); //this cancels the change from going to the DB. why? becuase now the RowState is Unmodified (no reason to update)
                                        //note: RowVersion should change too, todo
                                        //Current value is copied to Original value
                    if (orig == dr[0]["Title", DataRowVersion.Original])
                    {
                        Utils.WriteDetailLine("should not be");
                    }
                    int n = da.Update(dr);
                }
            }

            void RejectChanges()
            {
                //after RejectChanges, the Original value is copied to the Current value. The RowState = Unmodified
                //  no, db update/access on dt.Update, because it is now unchaged/Unmodified
            }

            //applies to DataSet, DataTable and DataRow

            //HasChanges
            //AcceptChanges
            AcceptChanges();  //if a change is made, and then AcceptChanges is called on the DT, 
                              //the DB i snot be updated. Because now the rows are marked as Unmodified
                              //Note: when Update is called it will internally call AcceptChanges (Row.State = Unmodified)
                              //      but, after saving/updating to the DB
            RejectChanges();

        }

        private static void AddEditDelete()
        {
            DataTable dt = new DataTable();
            LoadTbl(dt);

            void Add()
            {
                Utils.WriteSubTopic("Add Rows");

                /*
                 DataRow newCustomersRow = dataSet1.Tables["Customers"].NewRow();
                 newCustomersRow["CustomerID"] = "ALFKI";
                 newCustomersRow["CompanyName"] = "Alfreds Futterkiste";
                 dataSet1.Tables["Customers"].Rows.Add(newCustomersRow);
                */

                Utils.WriteDetailLine($"before add, number rows {dt.Rows.Count}");

                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                Utils.WriteDetailLine($"after add, number rows {dt.Rows.Count}");
            }

            void Delete()
            {
                Utils.WriteSubTopic("DeleteRows");

                Utils.WriteDetailLine($"before delete, number rows {dt.Rows.Count}");
                int n = dt.Rows.Count;
                dt.Rows[n - 1].Delete();
                Utils.WriteDetailLine($"after delete, number rows {dt.Rows.Count}");
                //dataSet1.Tables["Customers"].Rows[0].Delete();
            }

            void Edit()
            {
                Utils.WriteSubTopic("Edit Rows");

                DataRow[] drs = dt.Select("ID=4");
                if (drs.Length == 0)
                {
                    return;
                }
                Utils.WriteDetailLine($"before edit, row state {drs[0].RowState}");
                drs[0]["Title"] = "test edit";
                Utils.WriteDetailLine($"after edit, row state {drs[0].RowState}");

                //undo change
                drs[0].RejectChanges();
                Utils.WriteDetailLine($"after RejectChanges, row state {drs[0].RowState}");

                /*
                DataRow[] customerRow = dataSet1.Tables["Customers"].Select("CustomerID = 'ALFKI'");
                customerRow[0]["CompanyName"] = "Updated Company Name";
                customerRow[0]["City"] = "Seattle";

                or, if the row index is known:

                northwindDataSet1.Customers[4].CompanyName = "Updated Company Name";
                northwindDataSet1.Customers[4].City = "Seattle";
                */
            }

            Utils.WriteTopic("DataTable Rows");
            Add();
            Delete();
            Edit();
            //see changes
        }

        private static void UpdateToDB()
        {
            DataTable dt = new DataTable();
            using (var da = new SqlDataAdapter("SELECT * FROM movie", connStr))
            {

                da.Fill(dt);
                DataRow[] dr = dt.Select("Title='Stars Wars 10'");
                if (dr.Length == 0)
                {
                    return;
                }
                dr[0]["Title"] = "Star Wars 10";
                da.UpdateCommand = new SqlCommand("update movie set Title = @newTitle where ID = @oldID") //ctor
                {
                    Connection = da.SelectCommand.Connection  //object initializer, fixes: object initialization can be simplified
                };
                SqlParameter sp0 = da.UpdateCommand.Parameters.Add("@newTitle", SqlDbType.NVarChar);
                sp0.SourceColumn = "Title";
                sp0.SourceVersion = DataRowVersion.Current;
                SqlParameter sp = da.UpdateCommand.Parameters.Add("@oldID", SqlDbType.Int, 0, "ID");
                sp.SourceVersion = DataRowVersion.Original;
                int n = da.Update(dr);
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

        private static void LoadFromDB()
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
