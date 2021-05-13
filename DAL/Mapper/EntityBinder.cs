using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DAL.Mapper
{
    public class EntityBinder
    {
        /*
            Este metodo setea las propiedades de un objeto usando una lista clave valor.
            var monedaBinding = new ArrayList(){
                new KeyValuePair<string, object>("cod", "aa"),
                new KeyValuePair<string, object>("descripcion", "sadsadasdsa")
            };         
        */
        public object applyBindingList(ArrayList bindingList, object target)
        {
            foreach (KeyValuePair<string, object> objBinding in bindingList)
                target.GetType().GetField(objBinding.Key).SetValue(target, objBinding.Value);                

            return target;

        }

        public object match(IList row, object target)
        {
            foreach (KeyValuePair<string, object> data in row)
            {
                string attributeName = data.Key;
                object value = data.Value;

                //Bind resulset with target object.
                Debug.WriteLine("BIND-->", attributeName);

                if (target.GetType().GetField(attributeName) != null)
                {
                    //Check is null to make convertion.
                    value = (value != System.DBNull.Value) ? value : null;

                    //Bind values.
                    target.GetType().GetField(attributeName).SetValue(target, value);
                }
            }

            return target;
        }

    }

}
