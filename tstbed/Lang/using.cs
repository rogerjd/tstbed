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
        public static void Test()
        {
            /*
                        using (tst t = new tst()) //must be IDisposable
                        {

                        }
            */
            using (SqlConnection conn = new SqlConnection()) //must be IDisposable
            {

            }

        }
    }
}
