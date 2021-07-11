using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SL;
using BE;
using DAL;
using BL;

namespace BL
{
    public class ComisionBL
    {
        //Traigo el total de comisiones pendientes de una wallet.
        public double pendingAmmount(BilleteraBE wallet)
        {
            List<ComisionBE> comisiones = new ComisionDAL().pendingByWallet(wallet);
            double result = 0 ;

            foreach (ComisionBE comision in comisiones)
                result = result + comision.valor;

            return result;

        }

        //Registro comision para una venta.
        public int applyFromSell(OrdenVentaBE order, BilleteraBE wallet)
        {
            //Traigo el costo de la operacion.
            double tax = new ComisionValorBL().getSellCost();

            //Armo el dto de comision.
            ComisionBE comision = new ComisionBE();
            comision.tipo_operacion = Operaciones.VENTA;
            comision.referencia = order.idorden;
            comision.moneda = order.ofrece;
            comision.valor = tax;
            comision.fecCobro = DateTime.Now;
            comision.processed = 0;
            comision.idwallet = wallet.idwallet;

            return new ComisionDAL().save(comision);
        }

        //Registro comision para una compra.
        public int applyFromBuy(OrdenCompraBE order,BilleteraBE wallet)
        {
            //Traigo el costo de la operacion.
            double tax = new ComisionValorBL().getBuyCost();

            //Armo el dto de comision.
            ComisionBE comision = new ComisionBE();
            comision.tipo_operacion = Operaciones.COMPRA;
            comision.referencia = order.idcompra;
            comision.moneda = order.moneda;
            comision.valor = tax;
            comision.fecCobro = DateTime.Now;
            comision.processed = 0;
            comision.idwallet = wallet.idwallet;

            return new ComisionDAL().save(comision);
        }
    }
}
