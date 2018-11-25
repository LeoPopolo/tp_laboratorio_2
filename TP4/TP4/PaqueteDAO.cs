using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        static SqlCommand comando;
        static SqlConnection conexion;


        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.connectionStr);
            PaqueteDAO.comando = new SqlCommand();
            PaqueteDAO.comando.CommandType = System.Data.CommandType.Text;
            PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
        }

        /// <summary>
        /// Insertar en la tabla dbo.Paquetes un paquete. 
        /// En caso de no poder recibe una excepcion y utiliza bandera para cerrar conexion con la base de datos.
        /// </summary>
        /// <param name="p">Paquete a ingresar.</param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            bool bandera = false;
            try
            {
                string query = "insert into dbo.Paquetes (direccionEntrega,trackingID,alumno) values('"
                + p.DireccionEntrega + "','" + p.TrackingID + "','Leonardo Popolo')";

                PaqueteDAO.comando.CommandText = query;
                PaqueteDAO.conexion.Open();
                PaqueteDAO.comando.ExecuteNonQuery();

                bandera = true;
            }
            catch (Exception)
            {
                bandera = false;
            }
            finally
            {
                if (PaqueteDAO.conexion.State == System.Data.ConnectionState.Open)
                {
                    PaqueteDAO.conexion.Close();
                }
            }
            return bandera;
        }


    }
}
