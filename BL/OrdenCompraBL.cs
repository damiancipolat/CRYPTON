using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using SL;
using BE;
using BL.Operations;
using IO;
using IO.Responses;
using DAL;

namespace BL
{
    public class OrdenCompraBL
    {
        //Obtengo en forma de lista todos los impuestos para hacer la compra.
        public List<(string, string, string)> getTaxesToBuy(OrdenVentaBE orden, ClienteBE buyer)
        {
            return new EstimateTaxesForBuy().getTaxesToBuy(orden,buyer);
        }                

        //Hago swipe.
        public List<string> swipe(OrdenVentaBE orden, ClienteBE buyer)
        {
            return new Swiper().swipe(orden,buyer);
        }

        //Hago la operacion de comprar.
        public void comprar(OrdenVentaBE orden, ClienteBE buyer)
        {
            //Valido los montos.
           // this.validateSwipeAmmount(orden,buyer,orden.vendedor);

            //Registro la comision de la venta.
            //this.registrarComisionVenta(orden,buyer,orden.vendedor);

            //Hago el intercambio
            //this.swipe(orden,buyer);

            //cargo las notificaciones.
            //new NotificacionBL().save(sellNes);

        }
    }
}
