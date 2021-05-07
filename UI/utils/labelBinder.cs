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
        //Este metodo bindea la lista con las palabras cargadas en el diccionario de la sesion.
        public void bindKeys(Form target, Dictionary<string, string> labelKeys)
        {
            //Obtengo el diccionario.
            Dictionary<string, string> words = Session.GetInstance().getLanguangeWords();

            //Bind controls.
            foreach (Control controlReference in target.Controls)
            {
                string controlName = controlReference.Name;

                if (labelKeys.ContainsKey(controlName) &&words.ContainsKey(labelKeys[controlName]))
                {
                    controlReference.Text = words[labelKeys[controlName]];
                }
            }

        }
    }
}
