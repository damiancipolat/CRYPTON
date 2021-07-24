using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Permisos;

namespace BE.Permisos
{
    public class Patente2:Componente2
    {
        public override IList<Componente2> Hijos
        {
            get
            {
                return new List<Componente2>();
            }

        }

        public override void AgregarHijo(Componente2 c)
        {

        }

        public override void VaciarHijos()
        {

        }
    }
}