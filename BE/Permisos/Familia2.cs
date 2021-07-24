using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Permisos
{
    public class Familia2 : Componente2
    {
        private IList<Componente2> _hijos;
        public Familia2()
        {
            _hijos = new List<Componente2>();
        }

        public override IList<Componente2> Hijos
        {
            get
            {
                return _hijos.ToArray();
            }

        }

        public override void VaciarHijos()
        {
            _hijos = new List<Componente2>();
        }
        public override void AgregarHijo(Componente2 c)
        {
            _hijos.Add(c);
        }
    }
}
