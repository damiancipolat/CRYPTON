using System;
using System.Collections.Generic;
using System.Text;

namespace IO.Responses
{
    /* Json de referencia.
        {
            "status": "success",
            "data": {
                "network": "BTCTEST",
                "blockio_fee": "0.00000000",
                "estimated_network_fee": "0.00003090",
                "estimated_tx_size": 206,
                "estimated_min_custom_network_fee": "0.00001030",
                "estimated_max_custom_network_fee": "0.00154500"
            }
        } 
     */
    public class FeeData
    {
        public string network { get; set; }
        public string blockio_fee { get; set; }
        public string estimated_network_fee { get; set; }
        public int estimated_tx_size { get; set; }
        public string estimated_min_custom_network_fee { get; set; }
        public string estimated_max_custom_network_fee { get; set; }
    }

    public class Fee
    {
        public string status { get; set; }
        public FeeData data { get; set; }
    }
}
