using System;
using System.IO;
using RestSharp;
using RestSharp.Authenticators;
using System.Globalization;
using System.Configuration;
using System.Diagnostics;

namespace IO
{
    public class Mailer
    {
        private string emailKey;
        private string emailHost;

        //todo
        public Mailer()
        {
            //Cargo config.
            this.emailKey = ConfigurationManager.AppSettings["EmailKey"];
            this.emailHost = ConfigurationManager.AppSettings["EmailHost"];
        }

        public void send(string origin, string destiny,string subject, string payload)
        {
            Debug.WriteLine("<EMAIL>" + origin+","+destiny+","+subject+","+payload);

            //Prepate the client.
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator=new HttpBasicAuthenticator("api", this.emailKey);

            //Create the request.
            RestRequest request = new RestRequest();
            request.AddParameter("domain", this.emailHost, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", origin);
            request.AddParameter("to",destiny);
            request.AddParameter("subject", subject);
            request.AddParameter("text", payload);
            request.Method = Method.POST;

            //Send email.
            client.Execute(request);

        }
    }
}
