using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;

namespace BL.Operations
{
    public class EstimateTaxesForBuy
    {
        //Obtengo en forma de lista todos los impuestos para hacer la compra.
        public List<(string, string, string)> getTaxesToBuy(OrdenVentaBE orden, ClienteBE buyer)
        {
            List<(string, string, string)> taxList = new List<(string, string, string)>();

            //Traigo la lista de impuestos para esta operacion.
            List<(double, string)> buyerTaxList = new TaxManager().getBuyerTaxes(orden, buyer, orden.vendedor);

            //Adapto el formato para una ui.
            foreach ((double, string) tmpValue in buyerTaxList)
            {
                //Casteo a formato de string con ".".
                string formatedValue = tmpValue.Item1.ToString("0.000000").Replace(",", ".");
                taxList.Add((formatedValue, orden.pide.cod, tmpValue.Item2));
            }

            return taxList;
        }
    }
}
