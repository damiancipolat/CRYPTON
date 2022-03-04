using System;
using System.Collections.Generic;
using System.Text;

namespace IO.Responses
{
    /* Json de referencia.
        :{
          "status" : "success",
          "data" : {
            "network" : "LTCTEST",
            "user_id" : 2,
            "address" : "QQFDfrnLCLDcjFpZCaN2EtthFkxT9hEHuT",
            "label" : "hike86"
          }
        }     
     */

    public class NewWalletData
    {
        public string network { get; set; }
        public int user_id { get; set; }
        public string address { get; set; }
        public string label { get; set; }
    }

    public class NewWallet
    {
        public string status { get; set; }
        public NewWalletData data { get; set; }
    }
}
