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
        protected string _nombre;
        protected string _apellido;
        protected ENacionalidad _nacionalidad;
        protected int _dni;
        #endregion

        #region Propiedades
        public int DNI {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = this.ValidarDni(this._nacionalidad, value);
            }
        }

        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = this.ValidarNombreApellido(value);
            }
        }

        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = this.ValidarNombreApellido(value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }

        public string stringToDNI
        {
            set
            {
                this._dni = this.ValidarDni(this._nacionalidad, value);;
            }
        }
        #endregion

        #region Constructores
        public Persona()
        {
            this._nacionalidad = ENacionalidad.Argentino;
            this._nombre = "";
            this._apellido = "";
            this._dni = 0;
        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._apellido = apellido;
            this._nombre = nombre;
            this._nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this._dni = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, int.Parse(dni), nacionalidad)
        {

        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return "NOMBRE COMPLETO: " + this._apellido + ", " + this._nombre + "\r\nNACIONALIDAD: " + this._nacionalidad.ToString();
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
                foreach (char c in dato)
                {
                    if (!Char.IsNumber(c)) 
                    { 
                        throw new DniInvalidoException("Dni invalido. no puede contener letras ni caracteres. ingrese dni sin puntos");
                    }
                }
            }

            return int.Parse(dato);
            
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
