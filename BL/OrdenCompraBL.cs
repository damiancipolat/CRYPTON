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


        //TAX ------------------------------------------------------------------------

        //Valido los montos de ambas cuentas comprador y vendedor.
        public void validateSwipeAmmount(OrdenVentaBE orden, ClienteBE buyer, ClienteBE seller)
        {/*
            //Traigo billeteras de cada parte.
            Dictionary<string, BilleteraBE> buyerWallets = new CuentaBL().traerBilleterasCliente(buyer);
            Dictionary<string, BilleteraBE> sellerWallets = new CuentaBL().traerBilleterasCliente(seller);

            //Traigo billetera de origen de ambas partes.
            originBuyerWallet 

            //Traigo billetera de cada una de las partes en base a la moneda.
            BilleteraBE buyerWallet = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(buyer))[orden.ofrece.cod].idwallet,true);
            BilleteraBE sellerWallet = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(seller))[orden.pide.cod].idwallet,true);

            //Obtengo los saldos de ambas cuentas.
            double sellerBalance = sellerWallet.saldo;
            double buyerBalance = buyerWallet.saldo;

            //Traigo el impuesto que debera pagar el vendedor.
            double sellerPlatformFee = ((new ComisionValorBL().getSellCost() * orden.cantidad) / 100);
            double buyerPlatformFee = ((new ComisionValorBL().getBuyCost() * orden.precio) / 100);*/


        }


        //Obtengo en forma de lista todos los impuestos para hacer la compra.
        public List<(string, string,string)> getTaxesToBuy(OrdenVentaBE orden,ClienteBE buyer)
        {
            List<(string, string, string)> taxList = new List<(string, string, string)>();

            //Traigo la lista de impuestos para esta operacion.
            List <(double, string)> buyerTaxList = new TaxManager().getBuyerTaxes(orden,buyer,orden.vendedor);

            //Adapto el formato para una ui.
            foreach ((double, string) tmpValue in buyerTaxList)
            {
                //Casteo a formato de string con ".".
                string formatedValue = tmpValue.Item1.ToString("0.000000").Replace(",", ".");
                taxList.Add((formatedValue,orden.pide.cod,tmpValue.Item2));
            }

            return taxList;
        }
    }
}
