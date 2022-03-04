using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BE;

namespace DAL.DAO
{
    public class TypeComparer
    {
        //Dice si es un numero.
        public bool IsNumber(object value)
        {
            return value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is float
                    || value is double
                    || value is decimal;
        }

        //Dice si es un string.
        public bool isString(object value)
        {
            return value is String;
        }

        //Dice si es un date time.
        public bool isDate(object value)
        {
            return value is DateTime;
        }

        //Dice si es una clase.
        public bool isClass(object value)
        {
            return value != null ? value.GetType().IsClass : false;
        }

        //Dice si es una entidad.
        public bool isEntity(Type value)
        {
            return value!=null?value.IsSubclassOf(typeof(EntityBE)):false;
        }

        public bool isBindeable(object value)
        {
            return this.isDate(value) || this.isString(value) || this.IsNumber(value);
        }
    }
}
