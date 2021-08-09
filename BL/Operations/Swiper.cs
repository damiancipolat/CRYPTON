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
        private int swipePart1(OrdenVentaBE orden, ClienteBE buyer)
        {
            string moneda = orden.ofrece.cod;

            //Traigo las billetersa de esta parte.
            BilleteraBE origin = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(orden.vendedor, false))[moneda].idwallet, false);
            BilleteraBE destiny = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(buyer, false))[moneda].idwallet, false);

            return new BilleteraBL().transferir(orden.idorden, origin, destiny, orden.cantidad);
        }

        private int swipePart2(OrdenVentaBE orden, ClienteBE buyer)
        {
            string moneda = orden.pide.cod;

            //Traigo las billetersa de esta parte.
            BilleteraBE origin = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(orden.vendedor, false))[moneda].idwallet, false);
            BilleteraBE destiny = new BilleteraBL().getById((new CuentaBL().traerBilleterasCliente(buyer, false))[moneda].idwallet, false);

            return new BilleteraBL().transferir(orden.idorden, origin, destiny, orden.precio);
        }

        //Intercambio saldos entre 2 clientes en base a una orden de venta.
        public void swipe(OrdenVentaBE orden, ClienteBE buyer)
        {
            BilleteraBL biz = new BilleteraBL();

            //Transfiero de ORIGEN->DESTINO la 1ra moneda.
            this.swipePart1(orden,buyer);

            //Transfiero de ORIGEN<-DESTINO la 2da moneda.
            this.swipePart2(orden, buyer);
        }

    }
}
