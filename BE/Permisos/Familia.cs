using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Permisos;

namespace BE.Permisos
{
    public class Familia: Componente
    {
        private IList<Componente> _hijos;
        public Familia()
        {
            _hijos = new List<Componente>();
        }

        public override IList<Componente> Hijos
        {
            get
            {
                return _hijos.ToArray();
            }

        }

        public override void AgregarHijo(Componente c)
        {
            _hijos.Add(c);
        }
    }
}
