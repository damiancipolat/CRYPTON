using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class SolicOnboardingDAL : AbstractDAL<SolicOnboardingBE>
    {
        //Bindea la lista de campos de un registro de una consulta, con un objeto BE.
        private SolicOnboardingBE bindSchema(List<Object> fieldData)
        {
            if (fieldData.Count == 0)
                return null;

            //Armo un usuario que sera el cual se actualizara los campos.
            SolicOnboardingBE solicTarget = new SolicOnboardingBE();

            //Bindeo campos con la lista de resultados.
            this.binder.match(fieldData, solicTarget);

            return solicTarget;

        }

        //Este metodo obtiene en base al ID el usuario.
        public SolicOnboardingBE findById(int id)
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectById("solic_onboarding", "idsolic", id);

            //Bindeo con el esquema.
            return this.bindSchema((List<object>)result[0]);

        }

        //Este metodo retorna una lista de clientes.
        public List<SolicOnboardingBE> findAll()
        {
            //Busco en la bd por id.
            List<object> result = this.getSelect().selectAll("solic_onboarding");

            //Lista resultado.
            List<SolicOnboardingBE> lista = new List<SolicOnboardingBE>();

            foreach (List<object> row in result)
                lista.Add(this.bindSchema(row));

            return lista;
        }

        //Agrega un nuevo usuario.
        public int insert(SolicOnboardingBE onboarding)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"fecSolic",onboarding.fecSolic},
                {"idusuario",onboarding.usuario.idusuario},
                { "img_frente",onboarding.img_frente},
                { "img_dorso",onboarding.img_dorso},
                { "img_selfie",onboarding.img_selfie},
                { "solic_estado",(int)onboarding.solicEstado},
                { "fecProceso",onboarding.fecProceso},
                { "operador",onboarding.operador.idusuario}
            };

            return this.getInsert().insertSchema(schema, "solic_onboarding", true);
        }

        //Borra el usuario.
        public int delete(int id)
        {
            return this.getDelete().deleteById("idsolic", id, "solic_onboarding");
        }

        //Actualizar el usuario.
        public int update(SolicOnboardingBE onboarding)
        {
            //Creo un esquema dinamico para ser guardado.
            var schema = new Dictionary<string, Object>{
                {"fecSolic",onboarding.fecSolic},
                {"idusuario",onboarding.usuario.idusuario},
                { "img_frente",onboarding.img_frente},
                { "img_dorso",onboarding.img_dorso},
                { "img_selfie",onboarding.img_selfie},
                { "solic_estado",(int)onboarding.solicEstado},
                { "fecProceso",onboarding.fecProceso},
                { "operador",onboarding.operador.idusuario}
            };

            return this.getUpdate().updateSchemaById(schema, "solic_onboarding", "idsolic", onboarding.idsolic);
        }
    }
}