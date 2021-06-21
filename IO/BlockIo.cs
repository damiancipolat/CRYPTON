using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Diagnostics;
using System.Text;
using IO.Responses;
using Newtonsoft.Json;

namespace IO
{
    public class BlockIo
    {
        private string apiKey;
        private string host;

        //todo
        public BlockIo(string keyCode)
        {
            this.host = "https://block.io/api/v2/";
            this.apiKey = keyCode;
        }

        public NewWallet createWallet()
        {
            //Armo la url.
            string url = this.host + "get_new_address/?api_key=" + this.apiKey;

            //Hago el request.
            var result = new Request().GET(url);

            //Si es erroneo lanzo excepcion.
            if (!result.IsSuccessStatusCode)
                throw new Exception("Request not success," + result.StatusCode);

            //Extraigo en forma de json.
            string json = result.Content.ReadAsStringAsync().Result;

            //Descerializo y convierto al tipo de retorno.
            return JsonConvert.DeserializeObject<NewWallet>(json);

        }

        public Balance getBalance(string address)
        {
            //Armo la url.
            string url = this.host + "get_address_balance/?api_key=" + this.apiKey + "&addresses=" + address;

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

        public Balance test()
        {
            string tmp = "{\"status\":\"success\",\"data\":{\"network\":\"LTCTEST\",\"available_balance\":\"100.0\",\"pending_received_balance\":\"100.0\",\"balances\":[{\"user_id\":3,\"label\":\"thora48\",\"address\":\"Qfku2FMrND7qvh8M9Ftcgfe6PKcJqeEcvD\",\"available_balance\":\"0.00000000\",\"pending_received_balance\":\"0.00000000\"}]}}";
            return JsonConvert.DeserializeObject<Balance>(tmp);
        }

        public object getWalletBalance(string address)
        {
            return new object();
        }

        public object validateWallet(string address)
        {
            return new object();
        }

        public object getCotization()
        {
            return new object();
        }

        public object getCotizationBase(string money)
        {
            return new object();
        }

        public object makeTransference(string to, float ammount )
        {
            return new object();
        }

        public float estimateTransaction(string to, float ammount)
        {
            return 0;
        }

        public object decodeTransaction(string data)
        {
            return new object();
        }

        public float convertirMoneda(string monedaA, string monedaB) { return 0; }
    }
}
