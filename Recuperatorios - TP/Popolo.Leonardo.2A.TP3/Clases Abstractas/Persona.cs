using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_abstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad { Argentino, Extranjero }

        #region Atributos
        protected string nombre;
        protected string apellido;
        protected ENacionalidad nacionalidad;
        protected int dni;
        #endregion

        #region Propiedades
        public int DNI {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public string stringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);;
            }
        }
        #endregion

        #region Constructores
        public Persona()
        {
            this.nacionalidad = ENacionalidad.Argentino;
            this.nombre = "";
            this.apellido = "";
            this.dni = 0;
        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, int.Parse(dni), nacionalidad)
        {

        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return "NOMBRE COMPLETO: " + this.apellido + ", " + this.nombre + "\r\nNACIONALIDAD: " + this.nacionalidad.ToString();
        }

        public int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                    }
                    break;

                case ENacionalidad.Extranjero:
                    if (dato < 89999999 || dato > 99999999)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                    }
                    break;
            }

            return dato;
        }

        public int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (dato.Length < 1 || dato.Length > 8)
            {
                throw new DniInvalidoException("Dni invalido. tamaño incorrecto.");
            }
            else
            {
                int dni;

                if (int.TryParse(dato, out dni))
                {
                    return this.ValidarDni(nacionalidad, dni);
                }
                else
                {
                    throw new DniInvalidoException("Error, DNI invalido");
                }
            }       
        }

        public string ValidarNombreApellido(string dato)
        {
            foreach (char c in dato)
            {
                if (!Char.IsLetter(c))
                {
                    throw new DniInvalidoException("Dato invalido. Solo puede contener letras");
                }
            }

            return dato;
        }
        #endregion

    }
}
