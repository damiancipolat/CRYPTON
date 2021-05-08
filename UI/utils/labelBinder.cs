using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SL;
using System.Diagnostics;

namespace UI.utils
{
    public class labelBinder
    {
        //Retorno la lista de contoles.
        private List<Control> FindTag(Control.ControlCollection controls)
        {
            List<Control> ctrList = new List<Control>();

            foreach (Control c in controls)
            {
                ctrList.Add(c);

                if (c.Controls.Count > 0)
                    ctrList.AddRange(FindTag(c.Controls));
            }

            return ctrList;
        }

        //Este metodo bindea la lista con las palabras cargadas en el diccionario de la sesion.
        public void bindKeys(Control.ControlCollection target, Dictionary<string, string> labelKeys)
        {
            //Obtengo el diccionario.
            Dictionary<string, string> words = Session.GetInstance().getLanguangeWords();

            //Traigo la lista de controles del parametro.
            List<Control> controlList = this.FindTag(target);

            //Bindeo controles.
            foreach (Control controlReference in controlList)
            {
                string controlName = controlReference.Name;
                
                //Si coincide actualizo.
                if (labelKeys.ContainsKey(controlName) && words.ContainsKey(labelKeys[controlName]))                    
                    controlReference.Text = words[labelKeys[controlName]];
            }
        }
    }
}
