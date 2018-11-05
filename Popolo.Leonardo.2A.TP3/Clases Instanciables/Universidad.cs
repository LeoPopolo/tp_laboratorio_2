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

        private List<Alumno> _alumnos;
        private List<Jornada> _jornada;
        private List<Profesor> _profesores;

        public List<Alumno> Alumnos 
        {
            get 
            { 
                return this._alumnos; 
            } 
            set
            { 
                this._alumnos = value; 
            } 
        }

        public List<Jornada> Jornadas 
        {
            get 
            { 
                return this._jornada; 
            } 
            set 
            {
                this._jornada = value; 
            } 
        }

        public List<Profesor> Profesores 
        {
            get
            { 
                return this._profesores;
            }
            set 
            { 
                this._profesores = value; 
            }
        }

        public Jornada this[int i]
        {
            get 
            {
                return this._jornada[i];
            }
            set 
            {
                this._jornada[i] = value; 
            }
        }

        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._jornada = new List<Jornada>();
            this._profesores = new List<Profesor>();
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

            foreach (Jornada i in gim._jornada)
            {
                a.AppendLine(i.ToString());
                a.AppendLine("<------------------------------------------------------------------->");
            }

            return a.ToString();
        }

        public static bool operator ==(Universidad g, Alumno a)
        {

            foreach (Alumno i in g._alumnos)
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

            foreach (Profesor item in u._profesores)
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

            foreach (Profesor i in g._profesores)
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
            foreach (Profesor p in g._profesores)
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
                g._alumnos.Add(a);
                return g;
            }
            else
                throw new AlumnoRepetidoException();

        }

        public static Universidad operator +(Universidad u, Profesor p)
        {
            if (u != p)
                u._profesores.Add(p);
            return u;
        }

        public static Universidad operator +(Universidad u, Universidad.EClases clase)
        {
            try
            {
                Jornada jornada = new Jornada(clase, (u == clase));

                u._jornada.Add(jornada);

                foreach (Alumno item in u._alumnos)
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
