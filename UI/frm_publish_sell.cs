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
using SL;
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

        //Traducir textos.
        private void translateTexts()
        { 
            this.Text = Idioma.GetInstance().translate("SELL_TITLE");
            this.sell_title.Text = Idioma.GetInstance().translate("SELL_TITLE");
            this.sell_input.Text = Idioma.GetInstance().translate("SELL_INPUT");
            this.sell_receive.Text = Idioma.GetInstance().translate("SELL_RECEIVE");
            this.sell_money1.Text = Idioma.GetInstance().translate("SELL_MONEY");
            this.sell_money2.Text = Idioma.GetInstance().translate("SELL_MONEY");
            this.sell_close.Text = Idioma.GetInstance().translate("SELL_CLOSE");
            this.sell_publish.Text = Idioma.GetInstance().translate("SELL_PUBLISH");
            this.radioButton1.Text = Idioma.GetInstance().translate("SELL_MONEY_FREE_PRICE");
            this.radioButton2.Text = Idioma.GetInstance().translate("SELL_MONEY_MARKET_PRICE");
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
            //Traigo valores y conversiones.
            double input = Convert.ToDouble(this.txt_ammount_enter.Text);
            double value = Convert.ToDouble(this.txt_ammount_receive.Text);
            double cotiz = this.getConversion();
            string destiny = this.moneda_b_combo.Items[this.moneda_b_combo.SelectedIndex].ToString();

            //Valido que no sea la misma moneda.
            if (this.moneda_a_combo.Items[this.moneda_a_combo.SelectedIndex] == this.moneda_b_combo.Items[this.moneda_b_combo.SelectedIndex])
            {
                MessageBox.Show(Idioma.GetInstance().translate("SELL_MONEY_MISMATCH"));                
                return;
            }

            //Valido que si esta seleccionado libre eleccion no supere la cotizacion.
            if (this.radioButton1.Checked && value >= cotiz)
            {
                MessageBox.Show(Idioma.GetInstance().translate("SELL_MONEY_EXCED") + cotiz.ToString()+" "+destiny);
                return;
            }

            //Traigo las monedas.
            MonedaBE origen = new MonedaBL().getByCode(this.moneda_a_combo.Items[this.moneda_a_combo.SelectedIndex].ToString());
            MonedaBE destino = new MonedaBL().getByCode(this.moneda_b_combo.Items[this.moneda_b_combo.SelectedIndex].ToString());

            //Creo el objeto venta.
            OrdenVentaBE order = new OrdenVentaBE();
            order.cantidad = input;
            order.precio = value;
            order.ofrece = origen;
            order.pide = destino;
            order.fecCreacion = DateTime.Now;
            order.fecFin = DateTime.Now;
            order.ordenEstado = OrdenEstado.DISPONIBLE;
            order.vendedor = new ClienteBL().findByUser(Session.GetInstance().getUser()); ;

            //Creo la orden.
            new OrdenVentaBL().create(order);

            MessageBox.Show("exito");
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
            //Traduzco textos.
            this.translateTexts();

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
