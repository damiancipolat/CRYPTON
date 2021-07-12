using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;


namespace BL.Operations
{
    public class ValidateSwipe
    {
        //Valido los montos de ambas cuentas comprador y vendedor.
        public bool validate(OrdenVentaBE orden, ClienteBE buyer)
        {
            //Cargo el vendedor.
            ClienteBE seller = orden.vendedor;

            //Traigo los saldos actuales de cada una de las wallets partes del swipe.
            BilleteraBE buyerWallet = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(buyer))[orden.ofrece.cod].idwallet, true);
            BilleteraBE sellerWallet = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(seller))[orden.pide.cod].idwallet, true);

            //Traigo los impuestos de ambas partes.
            List<(double, string)> sellerTaxes = new TaxManager().getSellerTaxes(orden, buyer, seller);
            List<(double, string)> buyerTaxes = new TaxManager().getBuyerTaxes(orden, buyer, seller);

            //Sumarizo los impuestos del vendedor.
            double finalSellerTotal = 0;
            foreach ((double, string) tmpSeller in sellerTaxes)
                finalSellerTotal = +finalSellerTotal + tmpSeller.Item1;

            //Sumarizo los impuestos del comprador.
            double finalBuyerTotal = 0;
            foreach ((double, string) tmpBuyer in buyerTaxes)
                finalBuyerTotal = +finalBuyerTotal + tmpBuyer.Item1;

            //Valido saldo del vendedor.
            if (!(sellerWallet.saldo >= (finalSellerTotal + orden.cantidad)))
                throw new Exception("El saldo de la cuenta del vendedor no puede cubrir la operacion");

            //Valido saldo comprador.
            if (!(buyerWallet.saldo >= (finalBuyerTotal + orden.precio)))
                throw new Exception("El saldo de la cuenta del comprador no puede cubrir la operacion");

            return true;
        }

    }
}
