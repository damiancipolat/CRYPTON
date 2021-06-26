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
using BL;
using BE;
using SL;

namespace UI
{
    public partial class frm_publish_sell : Form
    {
        private Dictionary<string, BilleteraBE> billeteras;

        public frm_publish_sell()
        {
            InitializeComponent();
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        public void update_resumen()
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Publish_ok_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void cargarSaldos(CuentaBE cuenta)
        {
            this.billeteras = new CuentaBL().traerBilleteras(cuenta);
        }

        private void Frm_publish_sell_Load(object sender, EventArgs e)
        {
            //Cargo las monedas.
            List<MonedaBE> monedas = new MonedaBL().getAll();

            //Cargo los combos.
            foreach (MonedaBE money in monedas)
            {
                this.moneda_a_combo.Items.Add(money.cod);
                this.moneda_b_combo.Items.Add(money.cod);
            }

            //Seteo default.
            this.moneda_a_combo.SelectedIndex = 0;
            this.moneda_b_combo.SelectedIndex = monedas.Count-1;

            //Cargo el saldo.            
            ClienteBE cliente = new ClienteBL().findByUser(Session.GetInstance().getUser());
            Debug.WriteLine("+++00000+++" + cliente.email.ToString());
            //Cargo la cuenta.
            /*    CuentaBE cuenta = new CuentaBL().traerActiva(cliente);
                Debug.WriteLine("++++++"+cuenta.idcuenta.ToString());
                //Cargo las billeteras.
                this.cargarSaldos(cuenta);

                //Seteo valor.
                this.txt_saldo_money.Text = "Saldo actual:"+this.billeteras[monedas[0].cod].saldo.ToString()+" ("+ monedas[0].cod + ")";
    */
        }
    }
}
