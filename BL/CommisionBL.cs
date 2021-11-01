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
        //CRUD
        public ComisionBE findById(int id) 
        {
            return new ComisionDAL().findById(id);
        }

        public List<ComisionBE> findAll()
        {
            return new ComisionDAL().findAll();
        }
        public int delete(int id) 
        {
            return new ComisionDAL().delete(id);
        }

        public int update(ComisionBE comision)
        {
            return new ComisionDAL().update(comision);
        }

        public int save(ComisionBE comision)
        {
            return new ComisionDAL().save(comision);
        }

        //SEARCH
        public List<ComisionBE> search(string type, string from, string to)
        {
            return new ComisionDAL().findByDate(type, from, to);
        }

        public List<ComisionBE> searchByClient(ClienteBE client)
        {
            return new ComisionDAL().searchByClient(client);
        }

        public List<ComisionBE> searchByClientPendings(ClienteBE client)
        {
            return new ComisionDAL().searchByClientPendings(client);
        }     

        //-----------------------------------

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