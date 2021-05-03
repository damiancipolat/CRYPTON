using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
