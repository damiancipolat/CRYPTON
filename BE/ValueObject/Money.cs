using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace BE.ValueObject
{
    public class Money : EntityBE
    {
        private decimal _inner;
        public Money(decimal value) {
            this._inner = value;
        }

        public Money(double value)
        {
            this._inner = Convert.ToDecimal(value);
        }

        public Money(object value)
        {
            this._inner = Convert.ToDecimal(value);
        }

        public Money(string value)
        {
            this._inner= Decimal.Parse(value, CultureInfo.InvariantCulture);
        }

        public decimal getValue()
        {
            return this._inner;
        }
        public override string ToString()
        {
            return this._inner.ToString(CultureInfo.InvariantCulture);
        }
    }
}
