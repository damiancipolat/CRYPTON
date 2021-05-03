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
            UsuarioDAL pepe = new UsuarioDAL();

            UsuarioBE result = pepe.login("damian.cipolat@gmail.com", "15234");
            Debug.WriteLine(">"+result.idusuario.ToString()+"sss"+result.nombre);
        }
    }
}