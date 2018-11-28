using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto
    {
        public bool Guardar(string archivo,string datos)
        {

            try
            {
                using(StreamWriter s = new StreamWriter(archivo,true))
                {

                    s.WriteLine(datos);

                }

                return true;

            }
            catch(Exception a)
            {
                throw new ArchivosException(a);
            }

        }

        public bool Leer(string archivo, out string datos)
        {
            string Leido;

            StringBuilder stringbuilder = new StringBuilder();

            try
            {

                using (StreamReader s = new StreamReader(archivo))
                {

                    while ((Leido = s.ReadLine()) != null)
                    {

                        stringbuilder.AppendLine(Leido);

                    }

                }

                datos = stringbuilder.ToString();

                return true;

            }
            catch (Exception a)
            {

                throw new ArchivosException(a);

            }
        }
    }
}
