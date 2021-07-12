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

        //Transferencia de cripto usando blockio
        private string cryptoTransfer(string origen, string destino, string money, double ammount)
        {
            //Traigo las claves.
            string originKey = this.getKeys(this.getEnvironment(), money);

            //Casteo el formato de la moneda.
            string moneyFormatedA = ammount.ToString("0.000000000").Replace(",", ".");

            //Hago el request.
            Transference result = new BlockIo(originKey).makeTransference(origen, destino, moneyFormatedA);
            Debug.WriteLine("Transference" + result.block_io_transference.data.network + "   " + result.block_io_transference.data.txid);

            return result.block_io_transference.data.txid;
        }

        //Transferencia desde una cuenta en ars a la otra.
        private int arsTransfer(BilleteraBE origen, BilleteraBE destino, double ammount, long idoperacion)
        {
            //Armo la nueva transferencia.
            TransferenciasBE transfer = new TransferenciasBE();

            transfer.moneda = origen.moneda;
            transfer.cliente = origen.cliente;
            transfer.origen = origen;
            transfer.destino = destino;
            transfer.valor = ammount;
            //transfer.idorden = idoperacion;

            //Guardo.
            int transfId = new TransferenciaDAL().save(transfer);

            //Actualizo saldos.
            BilleteraBL walletBiz = new BilleteraBL();

            //Extraigo la cantidad de $ del origen.
            walletBiz.extraer(origen, ammount);

            //La agrego en el despinto.
            walletBiz.depositar(destino,ammount);

            return transfId;
        }

        //Hago las transferencias cruzadas A->B.
        private void swipePart1(OrdenVentaBE orden, ClienteBE buyer)
        {
            //Preparo el primer lado de la transferencia A----->B
            ClienteBE seller = orden.vendedor;
            string originMoney = orden.ofrece.cod;

            BilleteraBE sellerWallet = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(seller))[originMoney].idwallet, true);
            BilleteraBE buyerWallet = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(buyer))[originMoney].idwallet, true);

            if (orden.ofrece.cod != "ARS")
                this.cryptoTransfer(sellerWallet.direccion, buyerWallet.direccion, originMoney, orden.cantidad);
            else
                this.arsTransfer(sellerWallet,buyerWallet, orden.cantidad, orden.idorden);
        }

        //Hago las transferencias cruzadas B->A.
        private void swipePart2(OrdenVentaBE orden, ClienteBE buyer)
        {
            //Preparo el primer lado de la transferencia B--->A
            ClienteBE seller = orden.vendedor;
            string originMoney = orden.pide.cod;

            BilleteraBE sellerWallet = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(seller))[originMoney].idwallet, true);
            BilleteraBE buyerWallet = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(buyer))[originMoney].idwallet, true);
            
            if (orden.ofrece.cod != "ARS")
                this.cryptoTransfer(buyerWallet.direccion, sellerWallet.direccion, originMoney, orden.precio);
            else
                this.arsTransfer(sellerWallet, buyerWallet, orden.cantidad, orden.idorden);
        }

        //Intercambio saldos entre 2 clientes en base a una orden de venta.
        public List<string> swipe(OrdenVentaBE orden, ClienteBE buyer)
        {
            //Hago A->B
            this.swipePart1(orden, buyer);

            //Hago A<-B
            this.swipePart2(orden, buyer);

            //Retorno los id de transacciones.
            List<string> result = new List<string>();
            result.Add("a");
            result.Add("b");

            return result;
        }

    }
}
