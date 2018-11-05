﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_abstractas
{
    public class DniInvalidoException : Exception
    {
        private string _mensajeBase;

        public DniInvalidoException() : base()
        {
            
        }
        public DniInvalidoException(Exception e) : base()
        {

        }
        public DniInvalidoException(string mensaje) : base(mensaje)
        {
            this._mensajeBase = mensaje;
        }
        public DniInvalidoException(string mensaje, Exception e) : base(mensaje, e)
        {

        }
    }
}
