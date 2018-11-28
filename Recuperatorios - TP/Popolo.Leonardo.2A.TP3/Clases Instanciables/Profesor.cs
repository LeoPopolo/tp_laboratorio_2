using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_abstractas;

namespace Clases_instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        protected override string MostrarDatos()
        {
            return base.MostrarDatos();
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases c in i.clasesDelDia)
            {
                if (c == clase)
                    return true;
            }

            return false;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("\nCLASES DEL DÍA:\r\n");

            foreach (Universidad.EClases item in clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString(); ;
        }

        private void randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                int RandomClases = random.Next(0, 4);

                switch (RandomClases)
                {
                    case 0:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;
                    case 1:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                        break;
                    case 2:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                        break;
                    case 3:
                        this.clasesDelDia.Enqueue(Universidad.EClases.SPD);
                        break;
                }
            }

        }

        static Profesor()
        {
            Profesor.random = new Random();
        }

        public Profesor()
        {

        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this.randomClases();
        }

        public override string ToString()
        {
            return this.MostrarDatos() + "\r\n" + this.ParticiparEnClase() + "\r\n";
        }
    }
}
