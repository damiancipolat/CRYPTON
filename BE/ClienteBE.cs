﻿using System;
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
    }
}