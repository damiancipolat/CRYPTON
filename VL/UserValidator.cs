using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
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
        public bool isValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        //Valida si es un numero.
        public bool isNumber(string value)
        {
            return (Regex.IsMatch(value, @"^[0-9]+$"));
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

        //Valido la registracion de un empleado.
        public bool validateEmployee(
            string name,
            string surname,
            string alias,
            string email,
            string pwd,
            string legacy
        )
        {
            //Valido que los campos no sean vacios.
            string[] fields = {
                name,
                surname,
                alias,
                email,
                pwd,
                legacy
            };

            foreach (string value in fields)
            {
                if (value == "")
                    throw new InputException("REGISTER_INPUT_ERROR");
            }

            //Valido el email.
            if (!this.isValidEmail(email))
                throw new InputException("REGISTER_INPUT_EMAIL_ERROR");

            return true;
        }

        //Valido la registracion de un cliente.
        public bool validateRegister(
            string name, 
            string surname, 
            string alias, 
            string email, 
            string pwd,
            string documentNumber,
            string birthDate,
            string orderNumber,
            string address,
            string phoneNumber
        )
        {
            //Valido que los campos no sean vacios.
            string[] fields = {
                name,
                surname,
                alias,
                email,
                pwd,
                documentNumber,
                birthDate,
                orderNumber,
                address,
                phoneNumber
            };

            foreach (string value in fields)
            {
                if (value=="")
                    throw new InputException("REGISTER_INPUT_ERROR");
            }

            //Valido el email.
            if (!this.isValidEmail(email))
                throw new InputException("REGISTER_INPUT_EMAIL_ERROR");

            //Valido numero de documento.
            if (!this.isNumber(documentNumber))                
                throw new InputException("BAD_DNI");

            //Valido telefono.
            if (!this.isNumber(phoneNumber))
                throw new InputException("BAD_PHONE");

            //Numero de tramite.
            if (!this.isNumber(orderNumber))
                throw new InputException("BAD_TRAMITE");

            return true;
        }

    }
}
