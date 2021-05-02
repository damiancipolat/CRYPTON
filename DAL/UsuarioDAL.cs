using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.DAO;

namespace DAL
{
    public class UsuarioDAL
    {
        public UsuarioBE findById(int id)
        {
            //Busco en la bd por id.
            QuerySelect builder = new QuerySelect();
            List<object> result = builder.selectById("usuario", "idusuario", id);

            if (!(result.Count > 0))
                return null;

            //Cargo el resultado en un mapa para traer los campos que no se pueden bindear directo.
            List<object> row = ((IEnumerable)result[0]).Cast<object>().ToList();
            Dictionary<string, object> mapa = builder.getAsDictionary(row);

            //Armo el usuario resultado.
            UsuarioBE userTarget = new UsuarioBE();
            
            //Bindeo campos
            EntityBinder.bindOne(result, userTarget);

            //Bindeo el tipo de usuario a enum.
            userTarget.tipoUsuario = (UsuarioTipo)mapa["tipo_usuario"];

            return userTarget;

        }
    }
}
