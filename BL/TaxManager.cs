using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SL;
using BE;
using IO;
using IO.Responses;
using DAL;

namespace BL
{
    public class TaxManager
    {
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

        //Traigo las comisiones de uso de la red.
        private string fetchNetworkFee(string moneyCode, string address, string value)
        {
            //Obtengo las claves de la red que corresponde la moneda.
            string networkKey = this.getKeys(this.getEnvironment(), moneyCode);

            //Creo la wallet en block.io            
            Fee dataFee = new BlockIo(networkKey).estimateTransaction(address, value);

            //Obtengo los campos.
            return dataFee.data.estimated_network_fee;
        }

        //Traigo los costos de operacion para el vendedor.
        public List<(double,string)> getSellerTaxes(OrdenVentaBE orden, ClienteBE buyer, ClienteBE seller)
        {
            List<(double, string)> taxList = new List<(double, string)>();

            //Traigo la billetera del vendedor y del cliente de la misma moneda.
            BilleteraBE originWallet = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(buyer))[orden.ofrece.cod].idwallet, true);
            BilleteraBE destinyWallet = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(seller))[orden.ofrece.cod].idwallet, true);

            //Traigo la comision de la plataforma por la venta.
            double sellerPlatformFee = ((new ComisionValorBL().getSellCost() * orden.cantidad) / 100);

            //Agrego costos de plataforma.
            taxList.Add((sellerPlatformFee, "TAX_PLATFORM_FOR_SELL"));

            //Traigo el costo la red.
            if (orden.ofrece.cod != "ARS")
            {
                //Calculo el fee de la red de cripto.
                double networkFee = Convert.ToDouble(this.fetchNetworkFee(orden.ofrece.cod, destinyWallet.direccion, orden.cantidad.ToString()));

                //Agrego.
                taxList.Add((networkFee, "TAX_NETWORK_FEE"));
            }

            return taxList;
        }

        //Traigo los costos de operacion para el vendedor.
        public List<(double, string)> getBuyerTaxes(OrdenVentaBE orden, ClienteBE buyer, ClienteBE seller)
        {
            List<(double, string)> taxList = new List<(double, string)>();

            //Traigo la billetera del vendedor y del cliente de la misma moneda.
            BilleteraBE originWallet = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(buyer))[orden.pide.cod].idwallet, true);
            BilleteraBE destinyWallet = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(seller))[orden.pide.cod].idwallet, true);

            //Traigo la comision de la plataforma por la venta.
            double buyerPlatformFee = ((new ComisionValorBL().getBuyCost() * orden.precio) / 100);

            //Agrego costos de plataforma.
            taxList.Add((buyerPlatformFee, "TAX_PLATFORM_FOR_BUY"));

            //Traigo el costo la red.
            if (orden.ofrece.cod != "ARS")
            {
                //Calculo el fee de la red de cripto.
                double networkFee = Convert.ToDouble(this.fetchNetworkFee(orden.pide.cod, destinyWallet.direccion, orden.precio.ToString()));

                //Agrego.
                taxList.Add((networkFee, "TAX_NETWORK_FEE"));
            }

            return taxList;
        }
    }
}