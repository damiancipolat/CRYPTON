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
    public class BlockIo
    {
        private string host;
        private string env;

        //todo
        public BlockIo()
        {
            //Cargo config.
            this.host= ConfigurationManager.AppSettings["ApiHost"];
            this.env = ConfigurationManager.AppSettings["Environment"];

            //Seteo mock host.
            if (this.env == "DEVELOP")
                this.host = this.host + "/mock";

            Debug.WriteLine("!!!!!!!!!"+this.host);
        }

        public NewWallet createWallet(string money)
        {
            //Armo la url.
            string url = this.host+"/"+money.ToUpper()+"/wallet";

            //Preparo el body.
            var data = new StringContent("", Encoding.UTF8, "application/json");

            //Hago el request.
            var result = new Request().POST(url, data);

            //Si es erroneo lanzo excepcion.
            if (!result.IsSuccessStatusCode)
                throw new Exception("Request not success," + result.StatusCode);

            //Extraigo en forma de json.
            string jsonResponse = result.Content.ReadAsStringAsync().Result;

            //Descerializo y convierto al tipo de retorno.
            return JsonConvert.DeserializeObject<NewWallet>(jsonResponse);
        }

        public Balance getBalance(string money, string address)
        {
            //Armo la url.
            string url = this.host+"/"+money.ToUpper()+"/wallet/"+address+"/balance";

            //Hago el request.
            var result = new Request().GET(url);

            //Si es erroneo lanzo excepcion.
            if (!result.IsSuccessStatusCode)
                throw new Exception("Request not success," + result.StatusCode);

            //Extraigo en forma de json.
            string json = result.Content.ReadAsStringAsync().Result;

            //Descerializo y convierto al tipo de retorno.
            return JsonConvert.DeserializeObject<Balance>(json);
        }

        public Transference makeTransference(string money, string from, string to, string ammount)
        {
            //Armo la url.
            string url = this.host+"/"+money.ToUpper()+"/wallet/transfer";

            //Armo el objeto body.
            TransferenceReq request = new TransferenceReq();
            request.ammount = ammount;
            request.origin = from;
            request.destination = to;

            //Preparo el body.
            var json = JsonConvert.SerializeObject(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            //Hago el request.
            var result = new Request().POST(url, data);

            //Si es erroneo lanzo excepcion.
            if (!result.IsSuccessStatusCode)
                throw new Exception("Request not success," + result.StatusCode);

            //Extraigo en forma de json.
            string jsonResponse = result.Content.ReadAsStringAsync().Result;

            //Descerializo y convierto al tipo de retorno.
            return JsonConvert.DeserializeObject<Transference>(jsonResponse);
        }

        //Obtiene el costo estimado de la transferencia.
        public Fee estimateTransaction(string money, string to, string ammount)
        {
            //Armo la url.
            string url = this.host+"/"+money.ToUpper()+"/wallet/fee";

            //Armo el objeto body.
            BalanceReq request = new BalanceReq();
            request.ammount = ammount;
            request.destination = to;

            //Preparo el body.
            var json = JsonConvert.SerializeObject(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            //Hago el request.
            var result = new Request().POST(url, data);

            //Extraigo en forma de json.
            string jsonResponse = result.Content.ReadAsStringAsync().Result;

            //Si es erroneo lanzo excepcion.
            if (!result.IsSuccessStatusCode)
                throw new Exception(jsonResponse);

            //Descerializo y convierto al tipo de retorno.
            return JsonConvert.DeserializeObject<Fee>(jsonResponse);
        }
    }
}
