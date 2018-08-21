using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace tstbed.Net.Http
{
    static class WebRequestTst
    {
        public static void Test()
        {

            //HttpClient is preferred over HttpWebRequest due to async methods available out of the box and you would not have to worry about writing begin/end methods.
            void HttpClientTst()
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://www.nytimes.com");
                var str = client.GetStringAsync(""); //it is relative//("https://www.nytimes.com");
                Utils.WriteDetailLine(str.Result);
            }

            Utils.WriteTopic("Web Request");
            WebRequest req = WebRequest.Create("http://www.contoso.com");
            WebResponse resp = req.GetResponse();
            Utils.WriteDetailLine(((HttpWebResponse)resp).StatusDescription);
            Stream strm = resp.GetResponseStream();
            StreamReader sr = new StreamReader(strm);
            string respFromServer = sr.ReadToEnd();
            Utils.WriteDetailLine(respFromServer);

            resp.Close(); //must close either resp or resp.stream (no harm in closing both)

            HttpClientTst();
        }
    }
}
