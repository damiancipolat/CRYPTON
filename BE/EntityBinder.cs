using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;

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

        public static object bindOne(List<object> register,object target)
        {

            //Valida si la lista tiene un 1 registro, sino tiro error.
            if (!(register != null && register.Count() == 1))
                throw new Exception("Unable to bind with data source");

            //Traigo el elemento, manejo genericos.
            IList row = (IList)register[0];

            foreach (KeyValuePair<string, object> data in row)
            {
                string attributeName = data.Key;
                object value = data.Value;

                //Bind resulset with target object.
                Debug.WriteLine("BIND-->",attributeName);

                if (target.GetType().GetField(attributeName)!=null)
                    target.GetType().GetField(attributeName).SetValue(target,value);
            }

            return target;

        }
    }

}
