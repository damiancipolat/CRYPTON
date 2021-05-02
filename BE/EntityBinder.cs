using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BE
{
    public static class EntityBinder
    {
        /*
            Este metodo setea las propiedades de un objeto usando una lista clave valor.
            var monedaBinding = new ArrayList(){
                new KeyValuePair<string, object>("cod", "aa"),
                new KeyValuePair<string, object>("descripcion", "sadsadasdsa")
            };         
        */
        public static object applyBindingList(ArrayList bindingList, object target)
        {
            foreach (KeyValuePair<string, object> objBinding in bindingList)
                target.GetType().GetField(objBinding.Key).SetValue(target, objBinding.Value);                

            return target;

        }
    }

}
