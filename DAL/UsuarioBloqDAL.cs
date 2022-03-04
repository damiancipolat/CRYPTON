using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.DAO;
using DAL;

namespace DAL
{
    public class UsuarioBloqDAL : AbstractDAL<UsuarioBloqBE>
    {
        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private UsuarioBloqBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count == 0)
                return null;

            UsuarioBloqBE userBloq = new UsuarioBloqBE();
            this.binder.match(fieldData, userBloq);

            return userBloq;

        }

        //Este metodo retorna una lista de usuarios.
        public List<UsuarioBloqBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAll("usuario_bloq");

            //Lista resultado.
            List<UsuarioBloqBE> lista = new List<UsuarioBloqBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Este metodo obtiene en base al ID el usuario.
        public UsuarioBloqBE findById(long id)
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectById("idbloq", "usuario_bloq", id);

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);
        }

        //Borra el usuario bloqueado.
        public int delete(int id)
        {
            return this.getDelete().deleteById("idbloq", id, "usuario_bloq");
        }

        //Actualizar el usuario bloqueado.
        public int update(UsuarioBloqBE userBloq)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"motivo",userBloq.motivo}
            };

            return this.getUpdate().updateSchemaById(schema, "usuario_bloq", "idbloq", userBloq.idBloq);
        }

        //Agrega un nuevo usuario bloquedo.
        public int save(UsuarioBloqBE userBloq)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                { "idusuario", userBloq.usuario.idusuario},
                { "motivo", userBloq.motivo},
                { "fecBloq",userBloq.fecBloq.ToString("yyyy-MM-dd HH:mm:ss.fff")},
            };

            return this.getInsert().insertSchema(schema, "usuario_bloq", true);
        }
    }
}
