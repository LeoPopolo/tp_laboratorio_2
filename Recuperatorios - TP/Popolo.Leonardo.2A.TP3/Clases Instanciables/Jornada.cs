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
        private List<Alumno> alumnos;
        private Profesor instructor;
        private Universidad.EClases clase;

        public List<Alumno> Alumnos { 
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public Profesor Instructor
        {
            get 
            {
                return this.instructor;
            }
            set 
            {
                this.instructor = value;
            }
        }

        public Universidad.EClases Clase
        {
            get 
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        public static bool operator ==(Jornada j, Alumno a)
        {

            foreach (Alumno i in j.alumnos)
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
                j.alumnos.Add(a);
            }

            return j;
        }

        public override string ToString()
        {

            StringBuilder s = new StringBuilder();

            s.AppendLine("Clase de " + this.clase.ToString() + " por " + this.instructor.ToString());
            s.AppendLine("ALUMNOS: \r\n");

            foreach (Alumno i in this.alumnos)
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
