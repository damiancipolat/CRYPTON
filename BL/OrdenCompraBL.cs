using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;
using SL;
using BE;
using IO;
using IO.Responses;
using DAL;

namespace BL
{
    public class OrdenCompraBL
    {
        //Obtengo las claves en base a la configuración.
        private ApiKeysBE getEnvironment()
        {
            //Traigo el ambiente desde la configuración.
            string envConfig = ConfigurationManager.AppSettings["Environment"];

            //Consulto desde la bd.
            return new ApiKeysDAL().findByCode(envConfig);

        }

        //Extraigo la clave en base a la moneda.
        private string getKeys(ApiKeysBE keys, string money)
        {
            switch (money)
            {
                case "BTC":
                    return keys.btc;
                case "LTC":
                    return keys.ltc;
                case "DOG":
                    return keys.dog;
                default:
                    return "";
            }
        }

        //Calcula el costo de hacer la transferencia de la cuenta del vendedor al comprador.
        public string calcTransferenceCost(OrdenVentaBE orden,ClienteBE comprador)
        {
            //Traigo la wallet destino del comprador.
            Dictionary<string, BilleteraBE> walletCluster = new CuentaBL().traerBilleterasCliente(comprador);

            //Obtengo la billetera segun la moneda.
            BilleteraBE destiny = walletCluster[orden.pide.cod];

            //Obtengo las claves de la red que corresponde la moneda.
            string networkKey = this.getKeys(this.getEnvironment(), orden.pide.cod);
            
            //Creo la wallet en block.io            
            Fee fees = new BlockIo(networkKey).estimateTransaction(destiny.direccion,orden.precio.ToString());

            //Llamo a la capa de io para consultar el precio de transferencia.
            return fees.data.estimated_network_fee;
        }

        public List<(string, string,string)> getTaxesToBuy(OrdenVentaBE orden,ClienteBE buyer)
        {
            List<(string, string, string)> taxList = new List<(string, string, string)>();

            //Calculo el impuesto de la plataforma.
            double platFormTax = ((new ComisionValorBL().getBuyCost() * orden.precio) / 100);

            //Casteo a formato de string con ".".
            string formatedValue = platFormTax.ToString("0.000000").Replace(",", ".");
            taxList.Add((formatedValue, orden.pide.cod,"TAX_PLATFORM_FOR_BUY"));

            //Si es una compra de una moneda cripto, se agregan costos de la red de cripto.
            if (orden.pide.cod != "ARS")
            {
                string networkFee = this.calcTransferenceCost(orden, buyer);
                taxList.Add((networkFee, orden.pide.cod, "TAX_NETWORK_FEE"));
            }

            return taxList;
        }
    }
}
