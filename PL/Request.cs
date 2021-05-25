using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace PL
{    
    public class Request
    {
        private HttpClient client;

        public Request()
        {
            //url: https://zetcode.com/csharp/httpclient/
            this.client = new HttpClient();
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public HttpResponseMessage GET(string url)
        {
            return this.client.GetAsync(url).Result;
        }

        public HttpResponseMessage POST(string url,HttpContent body)
        {
            return this.client.PostAsync(url,body).Result;
        }
    }
}
