﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BE;
using BE.Permisos;
using DAL;
using DAL.Permiso;
using SL;
using SEC;
using BL.Exceptions;

namespace BL
{
    public class ClienteBL
    {
        public ClienteBL()
        {
            //..
        }

        private int createUser(ClienteBE cliente)
        {
            //Registro por separado.
            UsuarioBE newUser = new UsuarioBE();
            newUser.alias = cliente.alias;
            newUser.nombre = cliente.nombre;
            newUser.apellido = cliente.apellido;
            newUser.email = cliente.email;
            newUser.pwd = cliente.pwd;
            newUser.tipoUsuario = UsuarioTipo.CLIENTE;

            return new UsuarioBL().save(newUser);
        }

        public ClienteBE findById(long id)
        {
            return new ClienteDAL().findById(id);
        }

        public ClienteBE findByUser(UsuarioBE user)
        {
            return new ClienteDAL().findByUser(user);
        }

        public ClienteBE save(ClienteBE cliente)
        {
            //Encripto el email para hacer busquedas.
            string cryptedEmail = Cripto.GetInstance().Encrypt(cliente.email);

            //Valido si existe el email
            if (new ClienteDAL().findByEmail(cryptedEmail).Count > 0)
                throw new BusinessException("SIGNUP_EMAIL_REPEATED");

            //Valido si existe el dni.
            if (new ClienteDAL().findByDNI(cliente.numero).Count > 0)
                throw new BusinessException("SIGNUP_DNI_REPEATED");

            //Registro el usuario obtengo el id.
            int insertedId = this.createUser(cliente);

            //Seteo relacion cliente
            UsuarioBE tmpUser = new UsuarioBE();
            tmpUser.idusuario = insertedId;
            tmpUser.nombre = cliente.nombre;
            tmpUser.apellido = cliente.apellido;
            tmpUser.alias = cliente.alias;
            tmpUser.email = cliente.email;
            tmpUser.tipoUsuario = UsuarioTipo.CLIENTE;
            tmpUser.pwd = cliente.pwd;

            //Seteo campo de cliente autoseteados.
            cliente.valido = "N";
            cliente.usuario = tmpUser;
            
            //Registro el cliente por separado.
            int clientId = new ClienteDAL().insert(cliente);
            cliente.idcliente = clientId;

            //Registro el historial de cambios.
            new ClienteChangeDAL().insert(cliente);

            return cliente;
        }

        public int update(ClienteBE cliente)
        {
            //Actualizo los cambios.
            int result = new ClienteDAL().update(cliente);

            //Registro el cambio.
            new ClienteChangeDAL().insert(cliente);

            return result;
        }

        //Recupera el cambio en base a un id.
        public int recoverFromChange(long id)
        {
            //Recupero en base a un id.
            ClienteChangeBE change = new ClienteChangeDAL().findById(id);
            return 1;
        }
    }
}
