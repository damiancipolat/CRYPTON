using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SL;
using BE;
using BE.ValueObject;
using IO;
using IO.Responses;
using DAL;

namespace BL
{
    public class TaxManager
    {
        //Hago un pedido de estimacion.
        private Money fetchNetworkFee(string money, string direccion, string valor)
        {
            //Pido estimar la transferencia.
            Fee dataFee = new BlockIo().estimateTransaction(money, direccion, valor);

            //Casteo valores.
            return new Money(dataFee.data.estimated_network_fee);
        }

        //Traigo los costos de operacion para el vendedor.
        public List<(decimal, string)> getSellerTaxes(OrdenVentaBE orden, ClienteBE buyer)
        {
            List<(decimal, string)> taxList = new List<(decimal, string)>();

            //Traigo la moneda.
            string moneda = orden.ofrece.cod;

            //Traigo la billetera de ambas parte de la misma moneda.            
            BilleteraBE buyerWallet = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(buyer, false))[moneda].idwallet, false);

            //Traigo el costo fijo de la plataforma.
            decimal sellerPlatformFee = ((Convert.ToDecimal(new ComisionValorBL().getSellCost()) * orden.cantidad.getValue()) / 100);
            taxList.Add((sellerPlatformFee, "TAX_PLATFORM_FOR_SELL"));

            //Traigo el costo la red.
            if (orden.ofrece.cod != "ARS")
            {
               try
               {
                    //Obtengo el valor de la transferencia del comprador al vendedor.
                    Money value = this.fetchNetworkFee(moneda, buyerWallet.direccion, orden.cantidad.ToString());

                    //Agrego el impuesto.
                    taxList.Add((value.getValue(), "TAX_NETWORK_FEE"));
                }
               catch (Exception ex)
               {
                    taxList.Add((0, "TAX_NETWORK_FEE_ERROR"));
               }
            }

            return taxList;
        }

        //Traigo los costos de operacion para el vendedor.
        public List<(decimal, string)> getBuyerTaxes(OrdenVentaBE orden, ClienteBE seller)
        {
            List<(decimal, string)> taxList = new List<(decimal, string)>();

            //Traigo la moneda.
            string moneda = orden.ofrece.cod;

            //Traigo la billetera de ambas parte de la misma moneda.
            BilleteraBE sellerWallet = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(seller, false))[moneda].idwallet, false);

            //Traigo el costo fijo de la plataforma.
            decimal buyerPlatformFee = ((Convert.ToDecimal(new ComisionValorBL().getSellCost()) * orden.cantidad.getValue()) / 100);
            taxList.Add((buyerPlatformFee, "TAX_PLATFORM_FOR_BUY"));

            //Traigo el costo la red.
            if (orden.ofrece.cod != "ARS")
            {
                try
                {
                    //Obtengo el valor de la transferencia del comprador al vendedor.
                    Money value = this.fetchNetworkFee(moneda, sellerWallet.direccion, orden.pide.ToString());

                    //Agrego el impuesto.
                    taxList.Add((value.getValue(), "TAX_NETWORK_FEE"));
                }
                catch (Exception ex)
                {
                    taxList.Add((0, "TAX_NETWORK_FEE_ERROR"));
                }
            }

            return taxList;
        }
    }
}