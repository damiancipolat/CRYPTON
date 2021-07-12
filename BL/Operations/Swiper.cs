using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
using BL;
using BE;
using IO;
using IO.Responses;
using SL;
using DAL;

namespace BL.Operations
{
    public class Swiper
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

        //Hago las transferencias cruzadas A->B.
        private string swipePart1(OrdenVentaBE orden, ClienteBE buyer)
        {
            //Preparo el primer lado de la transferencia A----->B
            ClienteBE seller = orden.vendedor;
            string originMoney = orden.ofrece.cod;

            BilleteraBE sellerWallet = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(seller))[originMoney].idwallet, true);
            BilleteraBE buyerWallet = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(buyer))[originMoney].idwallet, true);

            string originKey = this.getKeys(this.getEnvironment(), originMoney);

            Debug.WriteLine("operacion>" + sellerWallet.direccion + "->" + buyerWallet.direccion + orden.cantidad.ToString() + " " + originMoney);

            //Casteo
            string moneyFormatedA = orden.cantidad.ToString("0.000000000").Replace(",", ".");

            //Hago el request.
            Transference result = new BlockIo(originKey).makeTransference(sellerWallet.direccion, buyerWallet.direccion, moneyFormatedA);
            Debug.WriteLine("Transference" + result.block_io_transference.data.network + "   " + result.block_io_transference.data.txid);

            return result.block_io_transference.data.txid;
        }

        //Hago las transferencias cruzadas B->A.
        private string swipePart2(OrdenVentaBE orden, ClienteBE buyer)
        {
            //Preparo el primer lado de la transferencia B--->A
            ClienteBE seller = orden.vendedor;
            string originMoney = orden.pide.cod;

            BilleteraBE sellerWallet = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(seller))[originMoney].idwallet, true);
            BilleteraBE buyerWallet = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(buyer))[originMoney].idwallet, true);

            string originKey = this.getKeys(this.getEnvironment(), originMoney);
            Debug.WriteLine("operacion>" + buyerWallet.direccion + "->" + sellerWallet.direccion + orden.precio.ToString() + " " + originMoney);

            //Casteo
            string moneyFormatedA = orden.precio.ToString("0.000000000").Replace(",", ".");

            //Hago el request.
            Transference result = new BlockIo(originKey).makeTransference(buyerWallet.direccion, sellerWallet.direccion, moneyFormatedA);
            Debug.WriteLine("Transference" + result.block_io_transference.data.network + "   " + result.block_io_transference.data.txid);

            return result.block_io_transference.data.txid;
        }
        
        //Intercambio saldos entre 2 clientes en base a una orden de venta.
        public List<string> swipe(OrdenVentaBE orden, ClienteBE buyer)
        {
            //Hago A->B
            string tx1 = this.swipePart1(orden, buyer);

            //Hago A<-B
            string tx2 = this.swipePart2(orden, buyer);

            //Retorno los id de transacciones.
            List<string> result = new List<string>();
            result.Add(tx1);
            result.Add(tx2);

            return result;
        }

    }
}
