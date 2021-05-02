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

            var dict = new Dictionary<string, Object>{
                {"nombre","Sebastian"},
                { "apellido","Cipolat"},
                { "alias","mrSebasC"},
                { "email","s@gmail.com"},
                { "tipo_usuario",2},
                { "pwd","123456"}
            };

            QueryInsert builder = new QueryInsert();
            builder.insertSchema(dict,"usuario");

            /*foreach (var kvp in dict) {
                Debug.WriteLine(kvp.Key + "*---"+kvp.Value);
                //expando.Add(kvp.Key, kvp.Value)
            }*/



            /*
                        var players = new[] {
                new  {name = "Joe",score = 25, color = "red", attribs = new int[]{ 0,1,2,3,4}},
                new  {name = "Jenny",score = 1, color = "black", attribs = new int[]{4,3,2,1,0}}
            };

                        var player = new
                        {
                            name = "damian",
                            apellido = "cipolat",
                            edad = 12
                        };

                        Debug.WriteLine(player.name+"  "+player.apellido+"  "+player.edad.ToString());
                        */
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

            /* UsuarioBE userData = new UsuarioDAL().findById(1);
             Debug.WriteLine(userData.idusuario+"--"+userData.nombre);*/

        }
    }
}