using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.ValueObject;
using BL;
using IO;
using IO.Responses;

namespace BL
{
    public class TransferenciaBL
    {

        public string estimate(MonedaBE moneda, string destiny, string ammount) 
        {
            Money monedaValue = new Money(ammount);
            Fee response = new BlockIo().estimateTransaction(moneda.cod, destiny, monedaValue.getValue().ToString());

            return response.data.estimated_network_fee;
        }

        public void transfer(MonedaBE moneda,string ammount, string origen, string destino) 
        {
            Money monedaValue = new Money(ammount);
            new BlockIo().makeTransference(moneda.cod, origen, destino, monedaValue.getValue().ToString());
        }
    }
}
