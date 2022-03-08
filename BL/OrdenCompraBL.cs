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
    public delegate void MyDelegate(string msg,int step);

    public class OrdenCompraBL
    {
        //Obtengo en forma de lista todos los impuestos para hacer la compra.
        public List<(string, string, string)> getTaxesToBuy(OrdenVentaBE orden, ClienteBE buyer)
        {
            return new EstimateTaxesForBuy().getTaxesToBuy(orden,buyer);
        }

        //Busco por cliente.
        public List<OrdenCompraBE> findByClient(ClienteBE cliente)
        {
            return new OrdenCompraDAL().findByClient(cliente);
        }

        //Hago la operacion de comprar.
        public long comprar(OrdenVentaBE orden, ClienteBE buyer, Money total, MyDelegate test)
        {
            //Valido los montos.
            test("Validando montos", 1);
            new ValidateSwipe().validate(orden, buyer);
            Debug.WriteLine("La operacion "+orden.idorden.ToString()+" se puede realizar!");

            //Armo la orden de compra.
            OrdenCompraBE buyOrder = new OrdenCompraBE();
            buyOrder.comprador = buyer;
            buyOrder.cantidad = total;
            buyOrder.moneda = orden.pide;
            buyOrder.ordenVenta = orden;
            buyOrder.fecOperacion = DateTime.Now;

            //Grabo la entidad.
            test("Grabando operacion", 2);
            long orderId = new OrdenCompraDAL().save(buyOrder);
            buyOrder.idcompra = orderId;

            //Registro las comisiones.
            test("Aplicando comisiones", 3);
            new Commission().commisionate(buyOrder, orden, buyer);

            //Hago el intercambio.
            test("Intercambiando monedas", 5);
            new Swiper().swipe(orden, buyer);

            //Marco como vendida la orden de venta.
            test("Cerrando orden", 6);
            new OrdenVentaBL().close(orden);

            //cargo las notificaciones.
            test("Notificando partes", 7);
            new NotificateBuySuccess().notificate(buyOrder);
            
            return orderId;
        }
    }
}
