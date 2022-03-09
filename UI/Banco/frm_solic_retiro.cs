using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using SL;
using BL;
using BE;
using BE.ValueObject;

namespace UI.Banco
{
    public partial class frm_solic_retiro : Form
    {
        private ClienteBE innerClient;
        private BilleteraBE innerWallet;

        public frm_solic_retiro()
        {
            InitializeComponent();
        }

        private void translateText() 
        {
            this.Text = Idioma.GetInstance().translate("EXTRACT_ARS_TITLE");
            this.extract_ars_title.Text = Idioma.GetInstance().translate("EXTRACT_ARS_TITLE");
            this.extract_ars_descrip.Text = Idioma.GetInstance().translate("EXTRACT_ARS_DESCRIP");
            this.extract_ars_value_label.Text = Idioma.GetInstance().translate("EXTRACT_ARS_VALUE_LABEL");
            this.extract_ars_value_label_descrip.Text = Idioma.GetInstance().translate("EXTRACT_ARS_VALUE_LABEL_DESCRIP");
            this.btn_close.Text= Idioma.GetInstance().translate("BTN_CLOSE");
            this.btn_ok.Text = Idioma.GetInstance().translate("SIGNUP_OK");
        }

        private void Activ_title_Click(object sender, EventArgs e)
        {

        }

        private void frm_solic_retiro_Load(object sender, EventArgs e)
        {
            this.innerClient = Session.GetInstance().getActiveClient();
            this.innerWallet = new CuentaBL().traerBilleteraArsCliente(this.innerClient);

            this.extract_ars_cbu.Text = Idioma.GetInstance().translate("EXTRACT_ARS_CBU") +" "+this.innerClient.cbu;
            this.extract_ars_ammount.Text = Idioma.GetInstance().translate("EXTRACT_ARS_AMMOUNT") +" $ "+this.innerWallet.saldo.getValue().ToString();

            this.translateText();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            //Muestro la barra.
            this.waiting_bar.Visible = true;

            //Valida formato numerico.
            if (!Decimal.TryParse(this.extract_ars_input.Text, out _)) 
            {
                MessageBox.Show(Idioma.GetInstance().translate("GRAL_UNABLE_TO_PROCESS"));
                return;
            }

            //Transformo.
            this.waiting_bar.Value = 1;
            this.Update();
            Money moneda = new Money(this.extract_ars_input.Text);

            //Si el saldo es mayor al valor ingresado.
            if (this.innerWallet.saldo.getValue() >= moneda.getValue()) 
            {
                this.waiting_bar.Value = 2;
                this.Update();

                //Busco comisiones pendientes.
                List<ComisionBE> comisiones = new CommisionBL().searchByClientPendings(Session.GetInstance().getActiveClient());
                Debug.WriteLine("Comisiones encontradas:"+comisiones.Count.ToString());

                if (comisiones.Count== 0)
                {
                    //Armo la solicitud.
                    SolicOperacionBE solic = new SolicOperacionBE();
                    solic.usuario = this.innerClient.usuario;
                    solic.tipoOperacion = TipoSolicOperacion.RETIRO_SALDO;
                    solic.billetera = this.innerWallet;
                    solic.valor = moneda;
                    solic.cbu = this.innerClient.cbu;
                    solic.fecRegistro = DateTime.Now;
                    solic.fecProceso = DateTime.Now;
                    solic.estadoSolic = SolicEstados.PENDIENTES;
                    
                    this.waiting_bar.Value = 3;
                    this.Update();

                    //Proceso la extraccion.
                    new OperacionesBL().extraer(solic);

                    this.waiting_bar.Value = 4;
                    this.Update();

                    //Mnesaje de exito.
                    MessageBox.Show(Idioma.GetInstance().translate("EXTRACT_ARS_OK"));
                    this.Close();
                }
                else 
                {
                    MessageBox.Show(Idioma.GetInstance().translate("EXTRACT_ARS_PENDING_DEBTS"));
                }                
            }
            else 
            {
                MessageBox.Show(Idioma.GetInstance().translate("EXTRACT_ARS_NO_FOUNDS"));
            }
        }

        private void frm_solic_retiro_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManual.GetInstance().openForClient("solic_extraccion");
        }
    }
}
