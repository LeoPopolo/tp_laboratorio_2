using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GuardaString
    {
        public static bool Guardar(this String text, string archivo)
        {
            try
            {
                //En caso de existir el archivo lo reescribira.
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(archivo, true))
                {
                    file.WriteLine(text);
                    file.Close();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
