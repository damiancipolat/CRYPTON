using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace PL
{    
    public class BlockIo
    {
        private string apiKey;
        private string host;

        public BlockIo(string key)
        {
            this.apiKey = key;
            this.host = "https://block.io/api/v2/";
        }

        public object createWallet()
        {
            return new object();
        }

        public object getBalance()
        {
            return new object();
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

        public object estimateTransaction(string to, float ammount)
        {
            return new object();
        }

        public object decodeTransaction(string data)
        {
            return new object();
        }
    }
}
