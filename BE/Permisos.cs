using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Componente
    {
        public string Nombre { get; set; }
        public int Id { get; set; }

        public abstract IList<Componente> Hijos { get; }
        public abstract void AgregarHijo(Componente c);

    }

    public class Patente : Componente
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

    public class Familia : Componente
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
