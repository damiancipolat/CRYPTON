using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.ValueObject;

namespace BE
{
    public enum SolicEstados
    {
        APROBADA =1,
        RECHAZADA=2,
        PENDIENTES = 3
    }

    public enum TipoSolicOperacion
    {
        INGRESO_SALDO=1,
        RETIRO_SALDO=2
    }

    public class SolicOperacionBE : EntityBE
    {
        public Int64 idoperacion;
        public UsuarioBE usuario;
        public TipoSolicOperacion tipoOperacion;
        public BilleteraBE billetera;
        public Money valor;
        public string cbu;
        public UsuarioBE operador;
        public SolicEstados estadoSolic;
        public DateTime fecRegistro;
        public DateTime fecProceso;
    }
}
