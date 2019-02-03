using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed.Lang
{
    static class UsingTest
    {
        class tst
        {

        }

        public static void Test(string[] args)
        {
/*
            using (tst t = new tst()) //err, must be IDisposable  CS1674
            {

            }
*/

            using (SqlConnection conn = new SqlConnection()) //ok, is IDisposable
            {

            }
        }
    }
}
