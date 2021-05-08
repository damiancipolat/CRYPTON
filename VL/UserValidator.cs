using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Text.RegularExpressions;
using VL.Exceptions;

namespace VL
{
    public class UserValidator
    {
        //Singleton logic.
        private static UserValidator _instance;

        public static UserValidator GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UserValidator();
            }

            return _instance;
        }

        //Valida el email con una regex.
        public bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        //Funciones de validación para usuarios.
        public bool validateLogin(string user, string pwd)
        {
            //Valido campos.
            bool valid = user != "" && pwd != "";

            //Si no cumplen, comunico el error con una excepcion custom,.
            if (!valid)
                throw new InputException("LOGIN_INPUT_ERROR");

            return true;
        }

        public bool validateRegister(string name, string surname, string alias, string email, string pwd)
        {
            //Valido campos.
            bool isText = name != "" &&surname != "" &&alias != "" &&email != "" &&pwd != "";

            if (!isText)
                throw new InputException("REGISTER_INPUT_ERROR");

            //Valido el email.
            if (!this.IsValidEmail(email))
                throw new InputException("REGISTER_INPUT_EMAIL_ERROR");

            return true;
        }

    }
}
