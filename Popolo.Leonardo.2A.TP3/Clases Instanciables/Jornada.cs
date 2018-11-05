using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_instanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Profesor _instructor;
        private Universidad.EClases _clase;

        public List<Alumno> Alumnos { 
            get
            {
                return this._alumnos;
            }
            set
            {
                this._alumnos = value;
            }
        }

        public Profesor Instructor
        {
            get 
            {
                return this._instructor;
            }
            set 
            {
                this._instructor = value;
            }
        }

        public Universidad.EClases Clase
        {
            get 
            {
                return this._clase;
            }
            set
            {
                this._clase = value;
            }
        }

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        public static bool operator ==(Jornada j, Alumno a)
        {

            foreach (Alumno i in j._alumnos)
            {

                if (i == a)
                {
                    return true;
                }

            }
            return false;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {

            if (j != a)
            {
                j._alumnos.Add(a);
            }

            return j;
        }

        public override string ToString()
        {

            StringBuilder s = new StringBuilder();

            s.AppendLine("Clase de " + this._clase.ToString() + " por " + this._instructor.ToString());
            s.AppendLine("ALUMNOS: \r\n");

            foreach (Alumno i in this._alumnos)
            {
                s.AppendLine(i.ToString());
            }

            s.AppendLine("\r\n");

            return s.ToString();

        }

        public static bool Guardar(Jornada jornada)
        {
            Texto writing = new Texto();
            return writing.Guardar("jornada.txt", jornada.ToString());

        }
    }
}
