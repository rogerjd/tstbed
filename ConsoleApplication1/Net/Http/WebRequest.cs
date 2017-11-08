using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Net.Http
{
    static class WebRequestTst
    {
        public static void Test()
        {
            Utils.WriteTopic("Web Request");
            WebRequest req = WebRequest.Create("http://www.contoso.com");
            WebResponse resp = req.GetResponse();
            Utils.WriteDetailLine(((HttpWebResponse)resp).StatusDescription);
            Stream strm = resp.GetResponseStream();
            StreamReader sr = new StreamReader(strm);
            string respFromServer = sr.ReadToEnd();
            Utils.WriteDetailLine(respFromServer);

            resp.Close(); //must close either resp or resp.stream (no harm in closing both)
        }
    }
}
