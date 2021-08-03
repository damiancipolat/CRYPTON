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
        public List<(string, string, string)> getTaxesToBuy(OrdenVentaBE2 orden, ClienteBE buyer)
        {
            return new EstimateTaxesForBuy().getTaxesToBuy(orden,buyer);
        }                

        //Hago swipe.
        public List<string> swipe(OrdenVentaBE orden, ClienteBE buyer)
        {
            return new Swiper().swipe(orden,buyer);
        }

        //Hago la operacion de comprar.
        public long comprar(OrdenVentaBE orden, ClienteBE buyer)
        {
            //Valido los montos.
            new ValidateSwipe().validate(orden, buyer);

            //Armo la orden de compra.
            OrdenCompraBE buyOrder = new OrdenCompraBE();
            buyOrder.comprador = buyer;
            buyOrder.cantidad = (float)orden.cantidad;
            buyOrder.moneda = orden.pide;
            buyOrder.ordenVenta = orden;
            buyOrder.precio = (float)orden.precio;
            buyOrder.fecOperacion = DateTime.Now;

            long orderId = new OrdenCompraDAL().save(buyOrder);
            buyOrder.idcompra = orderId;

            //Registro las comisiones.
            new Commission().commisionate(buyOrder);

            //Hago el intercambio
            this.swipe(orden,buyer);

            //cargo las notificaciones.
            new NotificateBuySuccess().notificate(buyOrder);

            return orderId;
        }
    }
}
