using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Permisos;

namespace BE.Permisos
{
    public class Patente: Componente
    {
        public override IList<Componente> Hijos
        {
            get
            {
                return null;
            }

        }

        public override void AgregarHijo(Componente c)
        {

        }
    }
}
