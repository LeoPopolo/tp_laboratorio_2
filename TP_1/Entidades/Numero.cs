using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public string SetNumero
        {
            set
            {     
                double retorno = ValidarNumero(value);
                if (retorno != 0)
                    numero = retorno;
            }
        }

        public static string BinarioDecimal(string binario)
        {
            int i;
            int entero = 0;
            string returnAux = "";

            foreach (char c in binario)
                if (c != '0' && c != '1')
                    return "Valor no binario";

            if (binario == "" || ReferenceEquals(binario, null))
            {
                returnAux = "Valor inválido";
            }
            else
            {
                for (i = 1; i <= binario.Length; i++)
                {
                    entero += int.Parse(binario[i - 1].ToString()) * (int)Math.Pow(2, binario.Length - i);
                }
                returnAux = entero.ToString();
            }

            return returnAux;
        }
        public static string DecimalBinario(string binario)
        {
            int numero;
            string returnValue = "";

            if (int.TryParse(binario, out numero))
            {
                while (numero > 0)
                {
                    returnValue = (numero % 2).ToString() + returnValue;
                    numero = numero / 2;
                }
            }
            else
                returnValue = "Valor inválido";

            return returnValue;
        }
        public static string DecimalBinario(double binario)
        {
            return DecimalBinario(binario.ToString());
        }

        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            if ((object)n1 != null && (object)n2 != null)
            {
                n1.numero += n2.numero;
            }

            return n1.numero;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            if ((object)n1 != null && (object)n2 != null)
            {
                n1.numero -= n2.numero;
            }

            return n1.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            if ((object)n1 != null && (object)n2 != null)
            {
                n1.numero /= n2.numero;
            }

            return n1.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            if ((object)n1 != null && (object)n2 != null)
            {
                n1.numero *= n2.numero;
            }

            return n1.numero;
        }

        private double ValidarNumero(string strNumero)
        {
            double i = 0;
            bool result = double.TryParse(strNumero, out i);

            if (result)
                return i;
            else
                return 0;

        }
    }
}
