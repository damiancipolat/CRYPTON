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

        public List<OrdenVentaBE> recomendar(ClienteBE cliente)
        {
            //Traigo la combinatoria de monedas buscada.
            List<(string, string)> moneyCombinations = new OrdenCompraDAL().getFavouriteMoneys(cliente);

            //Lista de resultados.
            List<OrdenVentaBE> result = new List<OrdenVentaBE>();

            //Loop
            foreach ((string, string) combination in moneyCombinations)
            {
                //Traigo las monedas.
                MonedaBE ofreceMoney = new MonedaBL().getByCode(combination.Item1);
                MonedaBE pideMoney = new MonedaBL().getByCode(combination.Item2);

                //Busco.
                List<OrdenVentaBE> founded = new OrdenVentaBL().buscar(ofreceMoney, pideMoney);

                if (founded.Count > 0)
                    result.AddRange(founded);
            }

            return result;

        }

        //todo
        public float cotizarOperacion(Operaciones operacion, BilleteraBE billetera) { return 0; }
    }
}

