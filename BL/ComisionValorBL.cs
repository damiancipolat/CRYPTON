using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;
using DAL;

namespace BL
{
    public class ComisionValorBL
    {
        //Retorno porcentaje de comision en venta.
        public double getSellCost()
        {
            ComisionValorBE data = new ComisionValorDAL().findById((int)Operaciones.VENTA);
            return data.valor;
        }


        //Retorno porcentaje de comision en compra.
        public double getBuyCost()
        {
            ComisionValorBE data = new ComisionValorDAL().findById((int)Operaciones.COMPRA);
            return data.valor;
        }

        //Retorno porcentaje de comision en extracción.
        public double getExtractionCost()
        {
            ComisionValorBE data = new ComisionValorDAL().findById((int)Operaciones.EXTRACT);
            return data.valor;
        }
    }
}