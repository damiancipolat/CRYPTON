using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DAL;
using BE;

namespace BL
{
    public class MonedaBL
    {
        //Convierto de una moneda a usd.
        private double convertToUsd(MonedaBE moneda, double cantidad)
        {
            //Traigo info de conversion.
            ConversionesBE conversion = new ConversionesDAL().findByCode(moneda.cod);

            //Convierto a usd.
            return (cantidad * conversion.valorUSD / conversion.cantCripto);
        }

        //Convierto de usd a una moneda X.
        private double convertFromUSD(MonedaBE moneda, double usdAmmount)
        {
            //Traigo info de conversion.
            ConversionesBE conversion = new ConversionesDAL().findByCode(moneda.cod);            
            return  (conversion.cantCripto * usdAmmount) / conversion.valorUSD;
        }

        //Convierto un valor X a Y.
        public double convertMoney(MonedaBE origen, MonedaBE destino, double cantidad)
        {
            return this.convertFromUSD(destino,this.convertToUsd(origen, cantidad));
        }

        //Traigo la lista de monedas.
        public List<MonedaBE> getAll()
        {
            return new MonedaDAL().findAll();
        }

        //Traigo una moneda por su codigo
        public MonedaBE getByCode(string code)
        {
            return new MonedaDAL().findByCode(code);
        }
    }
}
