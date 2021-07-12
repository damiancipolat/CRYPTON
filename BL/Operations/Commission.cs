using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using SL;
using BL;

namespace BL.Operations
{
    public class Commission
    {
        //Creacion / calculo de comision para venta.
        private ComisionBE getForSell(OrdenVentaBE order)
        {
            //Traigo las billeteras del cliente.
            Dictionary<string, BilleteraBE> clientWallets = new CuentaBL().traerBilleterasCliente(order.vendedor);

            //Obtengo la billetera puntual de esta operacion.
            BilleteraBE wallet = clientWallets[order.ofrece.cod];

            if (wallet == null)
                throw new Exception("Wallet not found for this money");

            //Armo el dto de comision.
            ComisionBE comx = new ComisionBE();
            comx.idwallet = wallet.idwallet;
            comx.moneda = order.ofrece;
            comx.referencia = order.idorden;
            comx.tipo_operacion = Operaciones.VENTA;

            //Obtengo el valor de la comision.
            ComisionValorBL comVL = new ComisionValorBL();            
            comx.valor = comVL.calcTaxForPrice(order.cantidad, comVL.getSellCost());

            //Registro como no procesado.
            comx.processed = 0;

            return comx;
        }

        //Creacion / calculo de comision para compra.
        private ComisionBE getForBuy(OrdenCompraBE order)
        {
            //Traigo las billeteras del cliente.
            Dictionary<string, BilleteraBE> clientWallets = new CuentaBL().traerBilleterasCliente(order.comprador);

            //Obtengo la billetera puntual de esta operacion.
            BilleteraBE wallet = clientWallets[order.moneda.cod];

            if (wallet == null)
                throw new Exception("Wallet not found for this money");

            //Armo el dto de comision.
            ComisionBE comx = new ComisionBE();
            comx.idwallet = wallet.idwallet;
            comx.moneda = order.moneda;
            comx.referencia = order.idcompra;
            comx.tipo_operacion = Operaciones.COMPRA;

            //Obtengo el valor de la comision.
            ComisionValorBL comVL = new ComisionValorBL();
            comx.valor = comVL.calcTaxForPrice(order.precio, comVL.getBuyCost());

            //Registro como no procesado.
            comx.processed = 0;

            return comx;
        }

        //Creo las comisiones para una compra.
        public Dictionary<ComisionBE, ComisionBE> commisionate(OrdenCompraBE orden)
        {
            //Creo comision para la venta.
            ComisionBE comSell = this.getForSell(orden.ordenVenta);

            //Creo comision para la compra.
            ComisionBE comBuy = this.getForBuy(orden);

            //Registro las comisiones para la venta.
            new ComisionBL().save(comSell);

            //Registro las comisiones para la compra.
            new ComisionBL().save(comBuy);

            Dictionary<ComisionBE, ComisionBE> comDictionary = new Dictionary<ComisionBE, ComisionBE>();
            comDictionary.Add(comSell,comBuy);

            return comDictionary;
        }
    }
}
