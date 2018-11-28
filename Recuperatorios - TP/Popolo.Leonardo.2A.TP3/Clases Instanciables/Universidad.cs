using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;
using Clases_abstractas;

namespace Clases_instanciables
{
    public class Universidad
    {
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public List<Alumno> Alumnos 
        {
            get 
            { 
                return this.alumnos; 
            } 
            set
            { 
                this.alumnos = value; 
            } 
        }

        public List<Jornada> Jornadas 
        {
            get 
            { 
                return this.jornada; 
            } 
            set 
            {
                this.jornada = value; 
            } 
        }

        public List<Profesor> Profesores 
        {
            get
            { 
                return this.profesores;
            }
            set 
            { 
                this.profesores = value; 
            }
        }

        public Jornada this[int i]
        {
            get 
            {
                return this.jornada[i];
            }
            set 
            {
                this.jornada[i] = value; 
            }
        }

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        public static void Guardar(Universidad gim)
        {
            Xml<Universidad> xmlFile = new Xml<Universidad>();
            xmlFile.Guardar("Universidad.xml", gim);
        }

        public static Universidad Leer()
        {
            Universidad uni;

            try
            {
                Xml<Universidad> auxLeer = new Xml<Universidad>();
                auxLeer.Leer("Universidad.xml", out uni);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return uni;
        }

        private string MostrarDatos(Universidad gim)
        {

            StringBuilder a = new StringBuilder();

            a.AppendLine("JORNADA: \r\n");

            foreach (Jornada i in gim.jornada)
            {
                a.AppendLine(i.ToString());
                a.AppendLine("<------------------------------------------------------------------->");
            }

            return a.ToString();
        }

        public static bool operator ==(Universidad g, Alumno a)
        {

            foreach (Alumno i in g.alumnos)
            {
                if (i == a)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor auxPro = new Profesor();

            foreach (Profesor item in u.profesores)
            {
                if (item == clase)
                {
                    auxPro = item;
                    break;
                }
                else
                {
                    throw new SinProfesorException();
                }
            }

            return auxPro;
        }

        public static Profesor operator !=(Universidad g, EClases clase)
        {

            foreach (Profesor i in g.profesores)
            {
                if (i != clase)
                {
                    return i;
                }
            }

            throw new SinProfesorException();
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor p in g.profesores)
            {
                if (p == i)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Universidad operator +(Universidad g, Alumno a)
        {

            if (g != a)
            {
                g.alumnos.Add(a);
                return g;
            }
            else
                throw new AlumnoRepetidoException();

        }

        public static Universidad operator +(Universidad u, Profesor p)
        {
            if (u != p)
                u.profesores.Add(p);
            return u;
        }

        public static Universidad operator +(Universidad u, Universidad.EClases clase)
        {
            try
            {
                Jornada jornada = new Jornada(clase, (u == clase));

                u.jornada.Add(jornada);

                foreach (Alumno item in u.alumnos)
                {
                    if (item == clase)
                        jornada.Alumnos.Add(item);
                }

                return u;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
    }
}
