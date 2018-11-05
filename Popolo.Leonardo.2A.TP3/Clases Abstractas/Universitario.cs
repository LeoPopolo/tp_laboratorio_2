using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_abstractas
{
    public abstract class Universitario : Persona
    {
        private int _legajo;

        public Universitario() : base()
        {
            this._legajo = 0;
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }

        public override bool Equals(object obj)
        {
            bool retValue = false;

            if (obj is Universitario)
            {

                retValue = true;

            }

            return retValue;
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (Object.Equals(pg1, pg2) && (pg1._legajo == pg2._legajo || pg1._dni == pg2._dni))
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        protected virtual string MostrarDatos()
        {
            return base.ToString() + "\r\nLEGAJO: " + this._legajo.ToString() + "\r\n";
        }

        protected abstract string ParticiparEnClase();
    }
}
