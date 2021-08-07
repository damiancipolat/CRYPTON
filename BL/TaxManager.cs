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
                //double networkFee = Convert.ToDouble(this.fetchNetworkFee(orden.ofrece.cod, destinyWallet.direccion, orden.cantidad.ToString()));

                //Agrego.
                //taxList.Add((networkFee, "TAX_NETWORK_FEE"));
            }

            return taxList;
        }

        //Traigo los costos de operacion para el vendedor.
        public List<(decimal, string)> getBuyerTaxes(OrdenVentaBE2 orden, ClienteBE buyer, ClienteBE seller)
        {
            List<(decimal, string)> taxList = new List<(decimal, string)>();

            //Traigo la billetera del vendedor y del cliente de la misma moneda.            
            BilleteraBE destinyWallet = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(seller,false))[orden.pide.cod].idwallet, false);

            //Traigo la comision de la plataforma por la venta.
            decimal buyCost = Convert.ToDecimal(new ComisionValorBL().getBuyCost());
            decimal orderPrice = orden.precio.getValue();

            //Calculo usando regla de 3.
            decimal buyerPlatformFee = (buyCost * orderPrice)/100;

            //Agrego costos de plataforma.
            taxList.Add((buyerPlatformFee, "TAX_PLATFORM_FOR_BUY"));

            //Traigo el costo la red.
            if (orden.pide.cod != "ARS")
            {
                try
                {
                    //Casteo valores.
                    Money valueFee = this.fetchNetworkFee(orden.pide.cod, destinyWallet.direccion, orden.precio.ToString());

                    //Agrego el impuesto.
                    taxList.Add((valueFee.getValue(), "TAX_NETWORK_FEE"));
                }
                catch(Exception error)
                {
                    taxList.Add((0, "TAX_NETWORK_FEE_ERROR"));
                }

            }

            return taxList;
        }
    }
}