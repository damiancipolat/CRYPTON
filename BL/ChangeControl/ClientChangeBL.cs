using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BL.ChangeControl
{
    public class ClientChangeBL
    {
        public int recordChange(ClienteBE client)
        {
            return new ClienteChangeDAL().insert(client);
        }

        public List<ClienteChangeBE> findFromClient(long id)
        {
            return new ClienteChangeDAL().findByCliente(id);
        }

        public int recoverFrom(long changeId)
        {
            //Busco el cambio.
            ClienteChangeBE change = new ClienteChangeDAL().findById(changeId);

            if (change == null)
                throw new Exception("Change not found");

            //Armo la copia.
            ClienteBE client = new ClienteBE();
            client.tipoDoc = change.tipoDoc;
            client.numero = change.numero;
            client.fec_nac = change.fec_nac;
            client.num_tramite = change.num_tramite;
            client.telefono = change.telefono;

            //Actualizo en base al cambio.
            return new ClienteDAL().update(client);
        }
    }
}