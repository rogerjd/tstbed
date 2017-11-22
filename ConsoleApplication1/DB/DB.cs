using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DB
{
    static class DataReaderTst
    {
        static string connStr = "Server=(localdb)\\mssqllocaldb;Database=aspnet5-MVCMovie-6ee74982-4ec3-47e0-b632-1729502aab6a;Trusted_Connection=True;MultipleActiveResultSets=true";

        static public void Test()
        {
            SqlDataReaderTst();
        }

        private static void SqlDataReaderTst()
        {
            using (
                SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("select * from movie", con);
                //default: cmd.CommandType = CommandType.Text; cam be also, StoredProcedure
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Console.WriteLine(" {0} {1} - {2}", rdr[0], rdr[1], rdr[4]);
                    }
                    //rdr is at end, Load returns 0 rows
                    //The *DataReader classes are forward-only iterators. (store results in list or table for example)
                    //The only way to restart/reset it is to grab a new reader with ExecuteReader().
                    //DataTable tbl = new DataTable();
                    //tbl.Load(rdr);
                }
            }
        }

        static public void StoredProcedure()
        {

            /*
            Where is your problem ??

            For the stored procedure, just create:

            CREATE PROCEDURE dbo.ReadEmployees @EmpID INT
            AS
               SELECT * --I would* strongly*recommend specifying the columns EXPLICITLY
               FROM dbo.Emp
               WHERE ID = @EmpID
            That's all there is.

            From your ASP.NET application, just create a SqlConnection and a SqlCommand(don't forget to set the CommandType = CommandType.StoredProcedure)

            DataTable tblEmployees = new DataTable();

                        using (SqlConnection _con = new SqlConnection("your-connection-string-here"))
                        using (SqlCommand _cmd = new SqlCommand("ReadEmployees", _con))
                        {
                            _cmd.CommandType = CommandType.StoredProcedure;

                            _cmd.Parameters.Add(new SqlParameter("@EmpID", SqlDbType.Int));
                            _cmd.Parameters["@EmpID"].Value = 42;

                            SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                            _dap.Fill(tblEmployees);
                        }

                        YourGridView.DataSource = tblEmployees;
                        YourGridView.DataBind();

                    }
            */
        }
    }
}
