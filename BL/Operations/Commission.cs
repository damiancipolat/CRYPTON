using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.ValueObject;
using SL;
using BL;
using DAL;

namespace BL.Operations
{
    public class Commission
    {
        //Traigo la comision del comprador.
        private ComisionBE fromBuy(OrdenVentaBE orden, ClienteBE buyer)
        {
            //Traigo las billeteras del cliente.
            Dictionary<string, BilleteraBE> clientWallets = new CuentaBL().traerBilleterasCliente(buyer);

            //Traigo la billetera.
            BilleteraBE wallet = clientWallets[orden.pide.cod];

            //Creo la comision.
            ComisionBE comision = new ComisionBE();
            comision.tipo_operacion = Operaciones.COMPRA;
            comision.referencia = orden.idorden;
            comision.moneda = orden.pide;
            comision.idwallet = wallet.idwallet;
            comision.fecCobro = DateTime.Now;
            comision.processed = 0;

            //Obtengo el valor de la comision.
            ComisionValorBL comVL = new ComisionValorBL();
            comision.valor = new Money((orden.precio.getValue() * Convert.ToDecimal(comVL.getBuyCost())) / 100);

            return comision;
        }

        //Traigo la comision del vendedor.
        private ComisionBE fromSell(OrdenVentaBE orden, ClienteBE seller)
        {
            //Traigo las billeteras del cliente.
            Dictionary<string, BilleteraBE> clientWallets = new CuentaBL().traerBilleterasCliente(seller);

            //Traigo la billetera.
            BilleteraBE wallet = clientWallets[orden.pide.cod];

            //Creo la comision.
            ComisionBE comision = new ComisionBE();
            comision.tipo_operacion = Operaciones.VENTA;
            comision.referencia = orden.idorden;
            comision.moneda = orden.ofrece;
            comision.idwallet = wallet.idwallet;
            comision.fecCobro = DateTime.Now;
            comision.processed = 0;

            //Obtengo el valor de la comision.
            ComisionValorBL comVL = new ComisionValorBL();
            comision.valor = new Money((orden.cantidad.getValue() * Convert.ToDecimal(comVL.getSellCost())) / 100);

            return comision;
        }

        //Creo las comisiones para una compra.
        public Dictionary<ComisionBE, ComisionBE> commisionate(OrdenCompraBE compra, OrdenVentaBE venta, ClienteBE buyer)
        {
            //Obtengo la comision del vendedor.
            ComisionBE comSell = this.fromSell(venta, venta.vendedor);
            new ComisionDAL().save(comSell);

            //Obtengo la comision del comprador.
            ComisionBE comBuy = this.fromBuy(venta,buyer);
            new ComisionDAL().save(comBuy);            

            //Retorno la lista de comisiones.
            Dictionary <ComisionBE, ComisionBE> comDictionary = new Dictionary<ComisionBE, ComisionBE>();
            comDictionary.Add(comSell, comBuy);

            return comDictionary;
        }
    }
}
