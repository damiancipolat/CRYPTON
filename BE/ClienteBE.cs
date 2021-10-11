using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ClienteBE:UsuarioBE
    {
        public Int64 idcliente;
        public UsuarioBE usuario;
        public string tipoDoc;
        public string numero;
        public DateTime fec_nac;
        public string num_tramite;
        public string domicilio;
        public string email;
        public string telefono;
        public string valido;
        public string cbu;

        public ClienteBE() { }

        public ClienteBE(UsuarioBE user, string tdoc, string num,string numTramite, DateTime fecNac, string domic, string email, string tel)
        {
            this.usuario = user;
            this.tipoDoc = tdoc;
            this.numero = num;            
            this.num_tramite = numTramite;
            this.fec_nac = fecNac;
            this.domicilio = domic;
            this.email = email;
            this.telefono = tel;
        }
    }
}