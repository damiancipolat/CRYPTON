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
            double value = Convert.ToDouble(this.txt_ammount_receive.Text);
            double cotiz = this.getConversion();
            string destiny = this.moneda_b_combo.Items[this.moneda_b_combo.SelectedIndex].ToString();

            //Valido que no sea la misma moneda.
            if (this.moneda_a_combo.Items[this.moneda_a_combo.SelectedIndex] == this.moneda_b_combo.Items[this.moneda_b_combo.SelectedIndex])
            {
                MessageBox.Show("No puede elegirse la misma moneda!");
                return;
            }

            //Valido que si esta seleccionado libre eleccion no supere la cotizacion.
            if (this.radioButton1.Checked && value >= cotiz)
            {
                MessageBox.Show("El valor ingresado no puede superar la cotizacion de mercado de "+cotiz.ToString()+" "+destiny);
                return;
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void cargarSaldos(CuentaBE cuenta)
        {
            //this.billeteras = new CuentaBL().traerBilleteras(cuenta);
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

            //Seteo defaults.
            this.moneda_a_combo.SelectedIndex = 0;
            this.moneda_b_combo.SelectedIndex = 0;

            /*
            //Seteo default.
            this.moneda_a_combo.SelectedIndex = 0;
            this.moneda_b_combo.SelectedIndex = monedas.Count-1;
            */
            //Cargo el saldo.            
            //   ClienteBE cliente = new ClienteBL().findByUser(Session.GetInstance().getUser());
            //Debug.WriteLine("+++00000+++" + cliente.email.ToString());
            //Cargo la cuenta.
            /*    CuentaBE cuenta = new CuentaBL().traerActiva(cliente);
                Debug.WriteLine("++++++"+cuenta.idcuenta.ToString());
                //Cargo las billeteras.
                this.cargarSaldos(cuenta);

                //Seteo valor.
                this.txt_saldo_money.Text = "Saldo actual:"+this.billeteras[monedas[0].cod].saldo.ToString()+" ("+ monedas[0].cod + ")";
    */
        }

        private void Signup_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private double getConversion()
        {
            //Traigo las monedas.
            MonedaBE origen = new MonedaBL().getByCode(this.moneda_a_combo.Items[this.moneda_a_combo.SelectedIndex].ToString());
            MonedaBE destino = new MonedaBL().getByCode(this.moneda_b_combo.Items[this.moneda_b_combo.SelectedIndex].ToString());

            //Convierto input a valor.
            double inputValue = Convert.ToDouble(this.txt_ammount_enter.Text);
            return new MonedaBL().convertMoney(origen, destino, inputValue);
        }

        private void applyConversion()
        {
            try
            {
                //Si esta seleccionado aplico conversion automatica.
                if (this.radioButton2.Checked)
                {
                    double value = this.getConversion();
                    this.txt_ammount_receive.Text = value.ToString();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Txt_ammount_receive_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_ammount_receive_Click(object sender, EventArgs e)
        {
            this.applyConversion();
        }

        private void Txt_ammount_receive_Enter(object sender, EventArgs e)
        {
            this.applyConversion();
        }

        private void Txt_ammount_enter_Leave(object sender, EventArgs e)
        {
            this.applyConversion();
        }

        private void Txt_ammount_enter_Click(object sender, EventArgs e)
        {
            this.applyConversion();
        }
    }
}
