using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum OrdenEstado
    {
        DISPONIBLE = 1,
        VENDIDA = 2,
        EXPIRADA = 3
    }

    public class OrdenVenta
    {
        public int idVenta;
        public UsuarioBE vendedor;
        public int cantidad;
        public Moneda moneda;
        public float precio;
        public OrdenEstado estado;
    }

    public class OrdenCompra
    {
        public int idCompra;
        public OrdenVenta venta;
        public DateTime fecOperacion;
        public Cliente comprador;
        public Moneda moneda;
        public int cantidad;
        public float precio;
    }
}
