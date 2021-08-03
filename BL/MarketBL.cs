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

        public List<OrdenVentaBE2> recomendar(ClienteBE cliente)
        {
            //return new OrdenVentaDAL().getLastActivities();

            //Traigo la combinatoria de monedas buscada.
            List<(string, string)> moneyCombinations = new OrdenCompraDAL().getFavouriteMoneys(cliente);

            //Si no se pudo recuperar ninguna moneda "favorita", retorno las ultimas 10 ordenes de venta publicadas activas.
            if (moneyCombinations.Count == 0)
                return new OrdenVentaDAL2().getLastActivities();

            //Lista de resultados.
            List<OrdenVentaBE2> result = new List<OrdenVentaBE2>();

            //Loop
            foreach ((string, string) combination in moneyCombinations)
            {
                //Traigo las monedas.
                MonedaBE ofreceMoney = new MonedaBL2().getByCode(combination.Item1);
                MonedaBE pideMoney = new MonedaBL2().getByCode(combination.Item2);

                //Busco.
                List<OrdenVentaBE2> founded = new OrdenVentaBL2().buscar(ofreceMoney, pideMoney,cliente);

                if (founded.Count > 0)
                    result.AddRange(founded);
            }

            return result;

        }

        //todo
        public float cotizarOperacion(Operaciones operacion, BilleteraBE billetera) { return 0; }
    }
}

