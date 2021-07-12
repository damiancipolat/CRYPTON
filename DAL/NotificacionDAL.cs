using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class NotificacionDAL : AbstractDAL<NotificacionBE>
    {

        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private NotificacionBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count == 0)
                return null;

            //Armo un usuario que sera el cual se actualizara los campos.
            NotificacionBE notifTarget = new NotificacionBE();

            //Bindeo campos con la lista de resultados.
            this.binder.match(fieldData, notifTarget);

            //Seteo el valor.
            Dictionary<string, object> mapa = this.getParser().rowToDictionary(fieldData);
            notifTarget.cliente = new ClienteDAL().findById((long)mapa["idcliente"]);

            return notifTarget;

        }

        //Este metodo obtiene en base al ID el usuario.
        public NotificacionBE findById(int id)
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectById("notificaciones", "idnotification", id);

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);

        }

        //Este metodo retorna una lista de usuarios.
        public List<NotificacionBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAll("notificaciones");

            //Lista resultado.
            List<NotificacionBE> lista = new List<NotificacionBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Traigo lista de comisiones pendientes de una walley.
        public List<NotificacionBE> pendingToRead(ClienteBE client)
        {
            //Busco en la bd por wallet y estado.
            List<Object> result = this.getSelect().selectAnd(new Dictionary<string, Object>{
                {"idcliente",client.idcliente},
                {"marked",0}
            }, "comisiones");

            //Lista resultado.
            List<NotificacionBE> lista = new List<NotificacionBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;

        }

        //Borro la notificacion.
        public int delete(int id)
        {
            return this.getDelete().deleteById("idnotification", id, "notificaciones");
        }

        //Actualizar el usuario.
        public int update(NotificacionBE notif)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"idcliente",notif.cliente.idcliente},
                { "payload",notif.payload},
                { "fecRegistro",(notif.fecRegistro != null) ? notif.fecRegistro.ToString("yyyy-MM-dd HH:mm:ss") :null},
                { "marked",notif.marked}
            };

            return this.getUpdate().updateSchemaById(schema, "notificaciones", "idnotification", notif.idnotification);
        }

        //Agrega una nueva notificación.
        public int save(NotificacionBE notif)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"idcliente",notif.cliente.idcliente},
                { "payload",notif.payload},
                { "fecRegistro",(notif.fecRegistro != null) ? notif.fecRegistro.ToString("yyyy-MM-dd HH:mm:ss") :null},
                { "marked",notif.marked}
            };

            return this.getInsert().insertSchema(schema, "notificaciones", true);
        }
    }
}
