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
using BE.ValueObject;
using SL;

namespace UI
{
    public partial class frm_publish_sell : Form
    {
        private Dictionary<string, BilleteraBE> billeteras;
        private double tax;

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
            this.sell_tax.Text = Idioma.GetInstance().translate("SELL_TAX");
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
            /*.
            this.txt_ammount_enter.Text = this.txt_ammount_enter.Text.Replace(',', '.');
            this.txt_ammount_receive.Text = this.txt_ammount_receive.Text.Replace(',', '.');
            */
            /*
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
            MonedaBE origen = new MonedaBL2().getByCode(this.moneda_a_combo.Items[this.moneda_a_combo.SelectedIndex].ToString());
            MonedaBE destino = new MonedaBL2().getByCode(this.moneda_b_combo.Items[this.moneda_b_combo.SelectedIndex].ToString());

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
            MessageBox.Show(Idioma.GetInstance().translate("SELL_MONEY_SUCCESS"));

            //Cierro.
            this.Close();*/
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Frm_publish_sell_Load(object sender, EventArgs e)
        {
            //Traduzco textos.
            this.translateTexts();

            //Cargo las monedas.
            List<MonedaBE> monedas = new MonedaBL2().getAll();

            //Cargo los combos.
            foreach (MonedaBE money in monedas)
            {
                this.moneda_a_combo.Items.Add(money.cod);
                this.moneda_b_combo.Items.Add(money.cod);
            }

            //Seteo defaults.
            this.moneda_a_combo.SelectedIndex = 0;
            this.moneda_b_combo.SelectedIndex = 0;

            //Cargo el label.
            this.tax = new ComisionValorBL().getSellCost();
            this.sell_tax.Text = Idioma.GetInstance().translate("SELL_TAX")+" "+ tax.ToString()+"%";
        }

        private void Signup_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Obtengo el valor en impuestos por la operacion de venta.
        private decimal getTaxes(decimal value)
        {
            //Obtengo el valor de la operación.
            decimal comissionValue = Convert.ToDecimal(new ComisionValorBL().getSellCost());

            //Calculo usando regla de 3.
            return (comissionValue * value) / 100;
        }

        //Obtengo la conversion de la moneda de una a otra.
        private decimal getConversion(MonedaBE origen,MonedaBE destino, string monto)
        {
            //Obtengo el valor del valor ingresado por el usuario.
            Money offerValue = new Money(monto);

            //Convierto el valor ingresado al valor pedido.
            decimal convertedValue = new MonedaBL2().convertMoney(origen, destino, offerValue.getValue());

            //Tengo en cuenta que si es ARS tengo que redondear
            return (destino.cod == "ARS") ? Convert.ToDecimal(Math.Round(convertedValue, 2)) : convertedValue;           
        }

        private void calculateValues()
        {           
            //Obtengo las monedas
            MonedaBE origen = new MonedaBL2().getByCode(this.moneda_a_combo.Items[this.moneda_a_combo.SelectedIndex].ToString());
            MonedaBE destino = new MonedaBL2().getByCode(this.moneda_b_combo.Items[this.moneda_b_combo.SelectedIndex].ToString());

            //Obtengo el valor de la conversion.
            decimal convertedValue = this.getConversion(origen,destino, this.txt_ammount_enter.Text);

            //Calculo los impuestos de esta operacion.
            decimal taxes = this.getTaxes(convertedValue);

            //Seteo valor de conversion.
            this.txt_ammount_receive.Text = new Money(convertedValue).ToString();

            //Seteo valor de impuesto.
            this.sell_tax.Text = Idioma.GetInstance().translate("SEEL_TAX_LABEL").Replace("%d", new Money(taxes).ToString()+" "+origen.cod);
        }

        private void applyConversion()
        {
            try
            {
                //Si esta seleccionado aplico conversion automatica.
                if (this.radioButton2.Checked)
                {
                    //Obtengo las monedas
                    MonedaBE origen = new MonedaBL2().getByCode(this.moneda_a_combo.Items[this.moneda_a_combo.SelectedIndex].ToString());
                    MonedaBE destino = new MonedaBL2().getByCode(this.moneda_b_combo.Items[this.moneda_b_combo.SelectedIndex].ToString());




                    //Actualizo la conversion de la moneda.
                    //Money value = new Money(this.getConversion());
                    //this.txt_ammount_receive.Text = value.ToString();

                    //Actualizo y muestro el de impuestos de la operación.
                    /*
                    //Convierto input a valor.
                    double inputValue = Convert.ToDouble(this.txt_ammount_enter.Text);
                    double result = 0;// new MonedaBL2().convertMoney(origen, destino, inputValue);

                    //Actualizo los costos.
                    double taxValue = (result * this.tax) / 100;
                    this.sell_tax.Text=Idioma.GetInstance().translate("SELL_TAX") + " " + tax.ToString() + "% = "+taxValue.ToString()+destino.cod;

                    return result;
                    */
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error en la convesion:"+ex.Message);
            }

            //0.00003090
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

        private void Button1_Click(object sender, EventArgs e)
        {
            string val = this.txt_ammount_enter.Text;
            string money = string.Format("{0:C}",val);
            Debug.WriteLine("--->"+money);
        }

        private void Moneda_a_combo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Moneda_b_combo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            this.calculateValues();
        }
    }
}
