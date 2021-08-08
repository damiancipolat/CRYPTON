using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using SL;
using BE;
using BE.ValueObject;
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
        public long comprar(OrdenVentaBE2 orden, ClienteBE buyer, Money total)
        {
            //Valido los montos.
            new ValidateSwipe().validate(orden, buyer);
            Debug.WriteLine("La operacion "+orden.idorden.ToString()+" se puede realizar!");

            //Armo la orden de compra.
            OrdenCompraBE buyOrder = new OrdenCompraBE();
            buyOrder.comprador = buyer;
            buyOrder.cantidad = orden.cantidad;
            buyOrder.moneda = orden.pide;
            buyOrder.ordenVenta = orden;
            buyOrder.fecOperacion = DateTime.Now;

            //Grabo la entidad.
            long orderId = new OrdenCompraDAL().save(buyOrder);
            buyOrder.idcompra = orderId;

            //Registro las comisiones.
            new Commission().commisionate(buyOrder, orden, buyer);
            /*
                                                      //Hago el intercambio
            this.swipe(orden,buyer);

            //cargo las notificaciones.
            new NotificateBuySuccess().notificate(buyOrder);

            return orderId;*/
            return 1;
        }
    }
}
