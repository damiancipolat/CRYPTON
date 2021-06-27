using System;
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
    public class EmpleadoBL
    {
        private int createUser(EmpleadoBE emp)
        {
            //Registro por separado.
            UsuarioBE newUser = new UsuarioBE();
            newUser.alias = emp.alias;
            newUser.nombre = emp.nombre;
            newUser.apellido = emp.apellido;
            newUser.email = emp.email;
            newUser.pwd = emp.pwd;
            newUser.tipoUsuario = UsuarioTipo.EMPLEADO;

            return new UsuarioBL().save(newUser);
        }

        public EmpleadoBE save(EmpleadoBE emple)
        {
            //Encripto el email para hacer busquedas.
            string cryptedEmail = Cripto.GetInstance().Encrypt(emple.email);

            //Valido si existe el email
            if (new ClienteDAL().findByEmail(cryptedEmail).Count > 0)
                throw new BusinessException("SIGNUP_EMAIL_REPEATED");

            //Registro el usuario obtengo el id.
            int insertedId = this.createUser(emple);

            //Seteo relacion cliente
            UsuarioBE tmpUser = new UsuarioBE();
            tmpUser.idusuario = insertedId;
            tmpUser.nombre = emple.nombre;
            tmpUser.apellido = emple.apellido;
            tmpUser.alias = emple.alias;
            tmpUser.email = emple.email;
            tmpUser.tipoUsuario = UsuarioTipo.EMPLEADO;

            //Agrego el usuario.
            emple.usuario = tmpUser;

            //Registro el empleado.
            int empleId = new EmpleadoDAL().insert(emple);
            emple.idempleado = empleId;

            return emple;
        }
    }
}