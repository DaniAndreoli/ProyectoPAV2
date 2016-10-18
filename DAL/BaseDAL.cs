using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

using ProyectoPAV2.Entidades;


namespace ProyectoPAV2.DAL
{
    public class BaseDAL
    {
        private SqlConnection conexion;

        /// <summary>
        /// Metodo que permite abrir la conexion con la base de datos especificada en el objeto ConnectionString para poder ejecutar una consulta
        /// Tener en cuenta que luego la conexion debe ser cerrada
        /// </summary>
        /// <returns>Objeto de tipo SqlConnection</returns>
        protected SqlConnection getConexion()
        {
            // TODO: Poner la cadena de conexión en un archivo de configuracion
            string connectionString = @"Data Source=DESKTOP-GP03IIR\SQLEXPRESS;Initial Catalog=ProyectoPAV2_DB;Integrated Security=True";

            if (this.conexion != null)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                    return this.conexion;
                else
                {
                    this.conexion.Open();
                }
            }
            else
            {
                this.conexion = new SqlConnection(connectionString);
                this.conexion.Open();
            }
            
            return this.conexion;
        }
    }
}
