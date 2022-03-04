using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IO
{    
    public class Request
    {
        private HttpClient client;

        public Request()
        {
            this.client = new HttpClient();
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpResponseMessage GET(string url)
        {
            Debug.WriteLine("GET:"+url);

            //Prepare the request.
            this.client.BaseAddress = new Uri(url);

            //Make the request.
            var responseTask = client.GetAsync("");
            responseTask.Wait();

            //Return the response.
            return responseTask.Result;
        }

        public HttpResponseMessage POST(string url,HttpContent body)
        {
            Debug.WriteLine("POST:" + url);

            //Prepare the request.
            this.client.BaseAddress = new Uri(url);

            //Make the request.
            var responseTask = this.client.PostAsync(url,body);
            responseTask.Wait();

            //Return the response.
            return responseTask.Result;
        }

        public HttpResponseMessage POSTWithAuth(string url, HttpContent body,string token)
        {
            Debug.WriteLine("POST:" + url);

            //Prepare the request.
            this.client.BaseAddress = new Uri(url);
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //Make the request.
            var responseTask = this.client.PostAsync(url, body);
            responseTask.Wait();

            //Return the response.
            return responseTask.Result;
        }
    }
}