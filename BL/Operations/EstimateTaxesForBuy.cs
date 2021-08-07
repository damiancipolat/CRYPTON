using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.ValueObject;
using BL;

namespace BL.Operations
{
    public class EstimateTaxesForBuy
    {
        //Obtengo en forma de lista todos los impuestos para hacer la compra.
        public List<(string, string, string)> getTaxesToBuy(OrdenVentaBE2 orden, ClienteBE buyer)
        {
            List<(string, string, string)> taxList = new List<(string, string, string)>();

            //Traigo la lista de impuestos para esta operacion.
            List<(decimal, string)> buyerTaxList = new TaxManager().getBuyerTaxes(orden, buyer);

            //Adapto el formato para una ui.
            foreach ((decimal, string) tmpValue in buyerTaxList)
            {
                //Obtengo valores.
                Money valor = new Money(tmpValue.Item1);
                string detail = tmpValue.Item2;

                //Cargo la lista.
                taxList.Add((valor.ToString(), orden.pide.cod, detail));
            }

            return taxList;
        }
    }
}
