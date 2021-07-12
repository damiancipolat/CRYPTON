using System;
using System.Collections.Generic;
using System.Text;

namespace IO.Responses
{
    /* Json de referencia.
        {
            "block_io_transference": {
                "status": "success",
                "data": {
                    "network": "BTCTEST",
                    "txid": "30c11d0f0929d7e1d4fc63382f169e09fd821deb343a63369f679d16aea9ed26"
                }
            }
        }
     */

    public class TransferenceDataResult
    {
        public string network { get; set; }
        public string txid { get; set; }
    }

    public class TransferenceData
    {
        public string status { get; set; }
        public TransferenceDataResult data { get; set; }
    }

    public class Transference
    {
        public TransferenceData block_io_transference { get; set; }
    }
}
