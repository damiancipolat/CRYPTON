using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Permisos
{
    public abstract class Componente
    {
        public string Nombre { get; set; }
        public string Cod { get; set; }
        public Int64 UserId { get; set; }
        public bool esPatente { get; set; }

        public abstract IList<Componente> Hijos { get; }
        public abstract void AgregarHijo(Componente c);

    }    
}