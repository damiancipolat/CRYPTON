using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Diagnostics;
using System.Text;
using System.Net.Http;
using IO.Responses;
using IO.RequestFormat;
using Newtonsoft.Json;

namespace IO
{
    public class Mailer
    {
        private string emailKey;
        private string emailHost;
        private string emailSender;

        //todo
        public Mailer()
        {
            //Cargo config.
            this.emailKey = ConfigurationManager.AppSettings["EmailKey"];
            this.emailHost = ConfigurationManager.AppSettings["EmailHost"];
            this.emailSender = ConfigurationManager.AppSettings["EmailSender"];
        }

        public bool send(string destiny, string payload)
        {
            //Armo la url.
            string url = this.emailHost + "/mail/send";

            //Preparo el body.
            string json = "{\"personalizations\": [{\"to\": [{\"email\": \""+destiny+"\"}]}],\"from\": {\"email\": \""+this.emailSender+"\"},\"subject\": \"Sending with SendGrid is Fun\",\"content\": [{\"type\": \"text/plain\", \"value\": \""+payload+"\"}]}";            
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            //Muestro el body.
            Debug.WriteLine("Mailer send payload: "+json);

            //Hago el request.
            var result = new Request().POSTWithAuth(url, data,this.emailKey);

            //Si es erroneo lanzo excepcion.
            if (!result.IsSuccessStatusCode)
                throw new Exception("Request not success," + result.StatusCode);

            //Muestro el success.
            Debug.WriteLine("Mailer send ok to:" + destiny);

            return true;
        }
    }
}
