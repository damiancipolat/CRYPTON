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
using DAL.DAO;
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
            
            UsuarioBE damian = new UsuarioBE();
            QuerySelect builder = new QuerySelect();
            //List<object> result = builder.selectAll("permiso");

            List<object> result = builder.selectById("usuario","idusuario",1);      
            EntityBinder.bindOne(result,damian);

            Debug.WriteLine("RESULTADO"+ damian.idusuario.ToString() + "  " + damian.nombre + " " + damian.apellido);

            List<object> row = ((IEnumerable)result[0]).Cast<object>().ToList();
            Debug.WriteLine("........"+row.Count.ToString());
            
            Dictionary<string, object> mapa = builder.getAsDictionary(row);

            UsuarioTipo tmpEnum = (UsuarioTipo)mapa["tipo_usuario"];
            
            Debug.WriteLine("ENUM:" + tmpEnum);
            Debug.WriteLine("*************"+mapa["tipo_usuario"]);
            */

            UsuarioBE userData = new UsuarioDAL().findById(1);
            Debug.WriteLine(userData.idusuario+"--"+userData.nombre);
        }
    }
}