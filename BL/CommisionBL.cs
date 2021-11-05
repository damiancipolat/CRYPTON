using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
using BE;
using BE.ValueObject;
using DAL;
using IO;
using SL;

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

        public List<ComisionBE> getPendingsToPay() 
        {
            return new ComisionDAL().getPendingsToPay();
        }

        //REPORT

        public List<(int, int, string, float)> getDebtors()
        {
            return new ComisionDAL().getDebtors();
        }

        //Reclama el pago.
        public void reclaimPayment(int idclient, float valor) 
        {
            ClienteBE client = new ClienteBL().findById(idclient);

            //Get administrator account.
            string emailHost = ConfigurationManager.AppSettings["EmailHost"];

            //Get system delivery.
            string delivery = "Crypton System <" + "crypton.system@" + emailHost + ">";
            string payload = "Hola "+client.nombre+" necesitamos que ingreses en tu cuenta de ARS el valor de $"+valor.ToString()+" para saldar tus deudas.";

            //Envio el email.
            new Mailer().send(delivery, client.email, "CRYPTON - Ponte al dia", payload);

            //Notificacion interna.
            NotificacionBE notif = new NotificacionBE();
            notif.cliente = client;
            notif.payload = payload;
            notif.fecRegistro = DateTime.Now;
            notif.marked = 0;

            //Grabo.
            new NotificacionBL().save(notif);
        }

        //Notifico la operacion por email y notificacion interna.
        private void notifyDebit(ComisionBE comision,bool isDebit=false) 
        {
            //Get administrator account.
            string emailHost = ConfigurationManager.AppSettings["EmailHost"];
            string delivery = "Crypton System <" + "crypton.system@" + emailHost + ">";
            string debitLabel = "";

            //Si se pudo debitar.
            if (isDebit)
            {
                //Envio email.
                debitLabel = "Hemos debitado de cuenta de ARS el valor de $" + comision.valor.getValue().ToString();
                new Mailer().send(delivery, comision.cliente.usuario.email, "Hemos debitado nuestras comisiones...", debitLabel);

                //Marco la comision como computada.
                comision.fecCobro = DateTime.Now;
                comision.processed = 1;

                //Actualizo y marco.
                new CommisionBL().update(comision);
            }
            else
            {
                //Envio email.
                debitLabel = "No hemos podido debitar de cuenta de ARS el valor de $" + comision.valor.getValue().ToString();
                new Mailer().send(delivery, comision.cliente.usuario.email, "No hemos podido debitar nuestras comisiones...", debitLabel);
            }

            //Envio notificacion interna.
            NotificacionBE notif = new NotificacionBE();
            notif.payload = debitLabel;
            notif.cliente = comision.cliente;
            notif.fecRegistro = DateTime.Now;
            notif.marked = 0;

            new NotificacionBL().save(notif);
        }

        //Procesa el pago en ARS de un dto comision.
        public bool processPayment(ComisionBE comision) 
        {
            try
            {
                //Reviso si alcanza para hacer la extraccion.
                decimal ammount = comision.wallet.saldo.getValue();
                decimal value = comision.valor.getValue();

                if (ammount >= value)
                {
                    Debug.WriteLine(">>> Descontando valor de :" + value.ToString() + " de cuenta:" + comision.wallet.idwallet.ToString());
                    new BilleteraBL().descontarARS(comision.wallet, comision.valor.getValue());
                    this.notifyDebit(comision, true);

                    return true;
                }
                else
                {
                    Debug.WriteLine(">>> No alcanza para descontar el valor de :" + value.ToString() + " de cuenta:" + comision.wallet.idwallet.ToString());
                    this.notifyDebit(comision, false);

                    return false;
                }
            }
            catch (Exception error) 
            {
                Bitacora.GetInstance().log("DEBIT","Unable to process commision N°"+comision.idcobro.ToString(),true);
                Bitacora.GetInstance().log("DEBIT", "Error processing payment:" + error.Message,true);
                return false;
            }            
        }

        //Busqueda por fechas.
        public List<ComisionBE> findByDate(string type, string from, string to) 
        {
            return new ComisionDAL().findByDate(type, from, to);
        }

        //-----------------------------------

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
    }
}