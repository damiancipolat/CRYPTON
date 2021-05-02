using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{

    public enum TipoOperacion
    {
        INGRESO = 1,
        RETIRO = 2
    }

    public enum SolicEstado
    {
        APROBADA = 1,
        RECHAZAD = 2
    }

    public class SolicOperacion
    {
        public int idOperacion;
        public Usuario usuario;
        public Billetera billetera;
        public float valor;
        public DateTime fecRegistro;
        public string cbu;
        public TipoOperacion tipoSolicitud;
        public SolicEstado estadoSolic;        
        public Usuario operador;
        public DateTime fecProceso;
    }
}