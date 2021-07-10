using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;
using System.Diagnostics;
using DAL.DAO;
using BE;

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
                Debug.WriteLine(
                    "BIND -->"+attributeName+
                    " type:" + (target.GetType().GetField(attributeName)!=null? target.GetType().GetField(attributeName).ToString():"null")+
                    " value:"+value.ToString()
                );

                if (target.GetType().GetField(attributeName)!=null)
                {
                    //Check is null to make convertion.
                    value = (value != System.DBNull.Value) ? value : null;

                    //Check if the value is not a entity.                    
                    bool isEntity = new TypeComparer().isEntity(target.GetType().GetField(attributeName).FieldType);

                    //Bind values.
                    if (!isEntity)
                         target.GetType().GetField(attributeName).SetValue(target, value);
                }
            }

            return target;
        }

    }

}
