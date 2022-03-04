using System;
using System.Collections.Generic;
using System.Text;

namespace IO.Responses
{
    /* Json de referencia.
         {
          "status" : "success",
          "data" : {
            "network" : "LTCTEST",
            "available_balance" : "0.0",
            "pending_received_balance" : "0.0",
            "balances" : [
              {
                "user_id" : 3,
                "label" : "thora48",
                "address" : "Qfku2FMrND7qvh8M9Ftcgfe6PKcJqeEcvD",
                "available_balance" : "0.00000000",
                "pending_received_balance" : "0.00000000"
              }
            ]
          }
        }  
     */

    public class BalanceSummary
    {
        public string user_id { get; set; }
        public string label { get; set; }
        public string address { get; set; }
        public string available_balance { get; set; }
        public string pending_received_balance { get; set; }
    }

    public class BalanceData
    {
        public string network { get; set; }
        public string available_balance { get; set; }
        public string pending_received_balance { get; set; }
        public List<BalanceSummary> balances { get; set; }
    }

    public class Balance
    {
        public string status { get; set; }
        public BalanceData data { get; set; }
    }
}
