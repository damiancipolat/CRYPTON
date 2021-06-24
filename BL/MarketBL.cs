using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BE;
using DAL;
using SL;
using SEC;

namespace BL
{
    public class MarketBL
    {
        public MarketBL()
        {
            //..
        }

        public object traerCotizacion() { return new object(); }
        public object buscar() { return new object(); }
        public object intercambiar() { return new object(); }

        //Convierte una moneda de una a otra.
        public MonedaBE convertir(MonedaBE origen, MonedaBE destino)
        {
            return new MonedaBE();
        }

        //todo
        public List<OrdenVentaBE> recomendar(ClienteBE cliente) { return new List<OrdenVentaBE>(); }

        //todo
        public float cotizarOperacion(Operaciones operacion, BilleteraBE billetera) { return 0; }
    }
}

