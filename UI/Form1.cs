using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Dynamic;
using System.Reflection;
using System.Collections;
using BE;
using DAL;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            /*
             Moneda bitcoin = new Moneda();
            var monedaBinding = new ArrayList(){
                new KeyValuePair<string, object>("cod", "aa"),
                new KeyValuePair<string, object>("descripcion", "sadsadasdsa")
            };

            EntityBinder.applyBindingList(monedaBinding, bitcoin);
            Debug.WriteLine(bitcoin.cod+"----"+bitcoin.descripcion);
            */
            Usuario damian = new Usuario();
            QueryBuilder builder = new QueryBuilder();
            //List<object> result = builder.selectAll("permiso");

            List<object> result = builder.selectById("usuario","idusuario",1);
            EntityBinder.bindOne(result,damian);

            Debug.WriteLine("RESULTADO"+ damian.idusuario.ToString() + "  " + damian.nombre + " " + damian.apellido);
            

        }
    }
}