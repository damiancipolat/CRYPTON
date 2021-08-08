using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
using BL;
using BE;
using IO;
using IO.Responses;
using SL;
using DAL;

namespace BL.Operations
{
    public class Swiper
    {
        private int swipePart1(OrdenVentaBE2 orden, ClienteBE buyer)
        {
            string moneda = orden.ofrece.cod;

            //Traigo las billetersa de esta parte.
            BilleteraBE2 origin = new BilleteraBL2().getById((new CuentaBL2().traerBilleterasCliente(orden.vendedor, false))[moneda].idwallet, false);
            BilleteraBE2 destiny = new BilleteraBL2().getById((new CuentaBL2().traerBilleterasCliente(buyer, false))[moneda].idwallet, false);

            return new BilleteraBL2().transferir(orden.idorden, origin, destiny, orden.cantidad);
        }

        private int swipePart2(OrdenVentaBE2 orden, ClienteBE buyer)
        {
            string moneda = orden.pide.cod;

            //Traigo las billetersa de esta parte.
            BilleteraBE2 origin = new BilleteraBL2().getById((new CuentaBL2().traerBilleterasCliente(orden.vendedor, false))[moneda].idwallet, false);
            BilleteraBE2 destiny = new BilleteraBL2().getById((new CuentaBL2().traerBilleterasCliente(buyer, false))[moneda].idwallet, false);

            return new BilleteraBL2().transferir(orden.idorden, origin, destiny, orden.precio);
        }

        //Intercambio saldos entre 2 clientes en base a una orden de venta.
        public void swipe(OrdenVentaBE2 orden, ClienteBE buyer)
        {
            BilleteraBL2 biz = new BilleteraBL2();

            //Transfiero de ORIGEN->DESTINO la 1ra moneda.
            this.swipePart1(orden,buyer);

            //Transfiero de ORIGEN<-DESTINO la 2da moneda.
            this.swipePart2(orden, buyer);
        }

    }
}
