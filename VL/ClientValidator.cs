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
    public class ClientValidator
    {
        //Singleton logic.
        private static ClientValidator _instance;

        public static ClientValidator GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ClientValidator();
            }

            return _instance;
        }
        
        //Valida si es un numero.
        public bool isNumber(string value)
        {
            return (Regex.IsMatch(value, @"^[0-9]+$"));
        } 

        //Valido la registracion de un cliente.
        public bool validateUpdate(
            string typeDoc,
            string documentNumber,
            string birthDate,
            string orderNumber,
            string address,
            string phoneNumber
        )
        {
            //Valido que los campos no sean vacios.
            string[] fields = {
                typeDoc,
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
