using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using SL;
using SEC;
using BE;
using BE.ValueObject;
using BL;

namespace UI.Banco
{
    public partial class frm_buscar_cbu : Form
    {
        private ClienteBE innerClient;

        public frm_buscar_cbu()
        {
            InitializeComponent();
        }

        private void translateTexts() 
        {
            this.search_cbu_title.Text = Idioma.GetInstance().translate("SEARCH_CBU_TITLE");
            this.search_cbu_title_descrip.Text = Idioma.GetInstance().translate("SEARCH_CBU_TITLE_DESCRIP");
            this.search_cbu_write.Text = Idioma.GetInstance().translate("SEARCH_CBU_WRITE");
            this.search_cbu_btn_search.Text = Idioma.GetInstance().translate("SEARCH_CBU_BTN_SEARCH");
            this.search_cbu_btn_cashin.Text = Idioma.GetInstance().translate("SEARCH_CBU_BTN_CASHIN");
            this.search_cbu_btn_close.Text = Idioma.GetInstance().translate("SEARCH_CBU_BTN_CLOSE");
        }

        private void loadGrid()
        {
            //Load columns.
            this.usr_search_data.ReadOnly = true;
            this.usr_search_data.Columns.Clear();
            this.usr_search_data.Columns.Add(Idioma.GetInstance().translate("SEARCH_CBU_CLIENT"), Idioma.GetInstance().translate("SEARCH_CBU_CLIENT"));
            this.usr_search_data.Columns.Add(Idioma.GetInstance().translate("SEARCH_CBU_TDOC"), Idioma.GetInstance().translate("SEARCH_CBU_TDOC"));
            this.usr_search_data.Columns.Add(Idioma.GetInstance().translate("SEARCH_CBU_DNI"), Idioma.GetInstance().translate("SEARCH_CBU_DNI"));
            this.usr_search_data.Columns.Add(Idioma.GetInstance().translate("SEARCH_CBU_EMAIL"), Idioma.GetInstance().translate("SEARCH_CBU_EMAIL"));
        }

        private void frm_buscar_cbu_Load(object sender, EventArgs e)
        {
            this.translateTexts();

            //Grilla.
            this.loadGrid();
            this.usr_search_data.Rows.Clear();
        }
        
        private void fillData(ClienteBE client)
        {
            this.usr_search_data.Rows.Clear();
            this.usr_search_data.Rows.Add(new string[] {client.cbu,client.tipoDoc,client.numero,client.email});
            this.innerClient = client;
        }

        private void search_cbu_btn_search_Click(object sender, EventArgs e)
        {
            string cbu = this.search_cbu_txt_input.Text;

            if (cbu != "")
            {
                ClienteBE client = new ClienteBL().findByCBU(cbu);

                if (client != null)
                    this.fillData(client);
                else 
                {
                    this.innerClient = null;
                    this.usr_search_data.Rows.Clear();
                    MessageBox.Show(Idioma.GetInstance().translate("GRAL_NO_RESULTS"));
                }                    
            }
            else 
            {
                MessageBox.Show(Idioma.GetInstance().translate("GRAL_YOU_MUST_ENTER_A_VALUE"));
            }

        }

        private void search_cbu_btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void search_cbu_btn_cashin_Click(object sender, EventArgs e)
        {
            if (this.innerClient == null)
                throw new Exception(Idioma.GetInstance().translate("GRAL_UNABLE_TO_PROCESS"));

            //Cargo y muestro.
            InputForm frm = new InputForm(Idioma.GetInstance().translate("CBU_CASHIN_TITLE"), Idioma.GetInstance().translate("CBU_CASHIN_LABEL"));
            frm.ShowDialog();

            //Obtengo el valor. 
            string value = frm.getValue();

            if (value != null)
            {
                //Traigo la cuenta activa.
                CuentaBE cuenta = new CuentaBL().traerActiva(this.innerClient);

                //Traigo la billeteras.
                Dictionary<string,BilleteraBE> wallets = new CuentaBL().traerBilleteras(cuenta, false);
                BilleteraBE wallet = wallets["ARS"];

                //Armo la solicitud.
                SolicOperacionBE solic = new SolicOperacionBE();
                solic.usuario = this.innerClient.usuario;
                solic.tipoOperacion = TipoSolicOperacion.INGRESO_SALDO;
                solic.billetera = wallet;
                solic.valor = new Money(value);
                solic.cbu = this.innerClient.cbu;
                solic.operador = Session.GetInstance().getUser();
                solic.estadoSolic = SolicEstados.APROBADA;
                solic.fecRegistro = DateTime.Now;
                solic.fecProceso = DateTime.Now;

                //Registro la operacion.
                new OperacionesBL().acreditar(solic);

                MessageBox.Show(Idioma.GetInstance().translate("GRAL_OPERATION_SUCCESS"));
            }
        }

        private void frm_buscar_cbu_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManual.GetInstance().openForEmpleado("acreditar_fondos");
        }
    }
}
