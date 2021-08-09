using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DAL;
using BE;
using BE.ValueObject;

namespace BL
{
    public class MonedaBL
    {
        //Convierto de una moneda a usd.
        private decimal convertToUsd(MonedaBE moneda, decimal moneyValor)
        {
            //Traigo valores de la moneda la cual queremos convertir a usd.
            ConversionesBE conversion = new ConversionesDAL().findByCode(moneda.cod);

            //Convierto todo a decimal.
            decimal usdValor = Convert.ToDecimal(conversion.valorUSD);
            decimal cantCripto = Convert.ToDecimal(conversion.cantCripto);

            //Hago regla de 3, cantCripto=1.
            return (moneyValor * usdValor) / cantCripto;
        }

        //Convierto de usd a una moneda X.
        private decimal convertFromUSD(MonedaBE moneda, decimal usdValor)
        {
            //Traigo info de conversion.
            ConversionesBE conversion = new ConversionesDAL().findByCode(moneda.cod);

            //Convierto todo a decimal.
            decimal cantCripto = Convert.ToDecimal(conversion.cantCripto);
            decimal convUsd = Convert.ToDecimal(conversion.valorUSD);

            return (usdValor * cantCripto) / convUsd;
        }

        //Convierto un valor X a Y.
        public decimal convertMoney(MonedaBE origen, MonedaBE destino, decimal cantidad)
        {
            //Origen  ---> USD ---> Destino
            return this.convertFromUSD(destino, this.convertToUsd(origen, cantidad));
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
