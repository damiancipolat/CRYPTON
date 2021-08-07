using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BE;
using BL;

namespace BL.Operations
{
    public class ValidateSwipe
    {
        //Traigo el costo para el comprador.
        private decimal getBuyerCost(OrdenVentaBE2 orden,ClienteBE seller)
        {
            //Traigo la lista de impuestos.
            List<(decimal, string)> buyerTaxes = new TaxManager().getBuyerTaxes(orden, seller);

            //Sumarizo los impuestos del comprador.
            decimal finalBuyerTotal = 0;

            foreach ((decimal, string) tmpBuyer in buyerTaxes)
                finalBuyerTotal = +finalBuyerTotal + tmpBuyer.Item1;

            //Contabilizo impuestos mas costo fijo.
            return finalBuyerTotal + orden.precio.getValue();
        }

        //Traigo el costo para el vendedor.
        private decimal getSellerCost(OrdenVentaBE2 orden, ClienteBE buyer)
        {
            //Traigo la lista de impuestos.
            List<(decimal, string)> sellerTaxes = new TaxManager().getSellerTaxes(orden, buyer);

            //Sumarizo los impuestos del comprador.
            decimal finalSellerTotal = 0;

            foreach ((decimal, string) tmpSeller in sellerTaxes)
                finalSellerTotal = +finalSellerTotal + tmpSeller.Item1;

            //Contabilizo impuestos mas costo fijo.
            return finalSellerTotal + orden.cantidad.getValue();
        }

        //Valido los montos de ambas cuentas comprador y vendedor.
        public bool validate(OrdenVentaBE2 orden, ClienteBE buyer)
        {
            //Traigo costos de ambas partes.
            decimal buyerCost = this.getBuyerCost(orden,orden.vendedor);
            decimal sellerCost = this.getSellerCost(orden,buyer);

            //Traigo las wallets de ambas partes.
            BilleteraBE2 sellerWallet = new BilleteraBL2().getById((new CuentaBL2().traerBilleterasCliente(orden.vendedor, false))[orden.ofrece.cod].idwallet, true);
            BilleteraBE2 buyerWallet = new BilleteraBL2().getById((new CuentaBL2().traerBilleterasCliente(buyer, false))[orden.pide.cod].idwallet, true);

            Debug.WriteLine("buyer>"+buyerCost.ToString()+" -- "+buyerWallet.saldo.ToString());
            Debug.WriteLine("seller>" + sellerCost.ToString() + " -- " + sellerWallet.saldo.ToString());

            //Valido el saldo del vendedor para afrontar la operacion.
            if (!(sellerWallet.saldo.getValue()>=sellerCost))
                throw new Exception("El saldo de la cuenta del vendedor no puede cubrir la operacion");

            //Valido el saldo del comprador para afrontar la operacion.
            if (!(buyerWallet.saldo.getValue() >= buyerCost))
                throw new Exception("El saldo de la cuenta del comprador no puede cubrir la operacion");

            return true;
        }
    }
}
