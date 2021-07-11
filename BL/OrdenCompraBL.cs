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
        {
            //Traigo los saldos actuales de cada una de las wallets partes del swipe.
            BilleteraBE buyerWallet = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(buyer))[orden.ofrece.cod].idwallet, true);
            BilleteraBE sellerWallet = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(seller))[orden.pide.cod].idwallet, true);

            //Traigo los impuestos de ambas partes.
            List<(double, string)> sellerTaxes = new TaxManager().getSellerTaxes(orden,buyer,seller);
            List<(double, string)> buyerTaxes = new TaxManager().getBuyerTaxes(orden, buyer, seller);

            Debug.WriteLine("buyer"+buyerWallet.saldo.ToString()+ buyerWallet.moneda.cod);
            foreach ((double, string) tmpBuyer in buyerTaxes)
                Debug.WriteLine("tax for buyer ->>"+tmpBuyer.Item1.ToString()+" "+tmpBuyer.Item2);

            Debug.WriteLine("seller" + sellerWallet.saldo.ToString() + sellerWallet.moneda.cod);
            foreach ((double, string) tmpSeller in sellerTaxes)
                Debug.WriteLine("tax for seller ->>" + tmpSeller.Item1.ToString() + " " + tmpSeller.Item2);

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
