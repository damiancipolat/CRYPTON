using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.ValueObject;
using DAL;

namespace BL
{
    public class CommisionBL
    {
        public List<ComisionBE> search(string type, string from, string to)
        {
            return new ComisionDAL().findByDate(type, from, to);
        }

        public List<ComisionBE> searchByClient(ClienteBE client)
        {
            return new ComisionDAL().searchByClient(client, true);
        }

        //TODO
        public List<(ClienteBE, Money)> getClientPendingAmmounts()
        {
            return new ComisionDAL().getClientPendingAmmounts();
        }

        //TODO
        public List<ComisionBE> getPendings()
        {
            return new List<ComisionBE>();
        }

        //TODO
        public void processPayments()
        {
            //traigo los pendientes: new ComisionDAL().getPaymentsPending();
            //si hay datos, proceso.
                //traigo la billetera en ars del cliente
                    //si tiene monto como para debitar
                        //debito y notifico.
                    //si no tengo saldo, envio un email al deudor.
            //si no hay datos no hago nada.
        }

        //TODO
        public void reclaimPayment(int clientId){ }

    }
}