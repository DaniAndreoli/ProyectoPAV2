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
        private static string connectionString = @"Data Source=DESKTOP-GP03IIR\SQLEXPRESS;Initial Catalog=ProyectoPAV2_DB;Integrated Security=True";
        private SqlConnection conexion;
        private SqlTransaction transaccion;

        public SqlTransaction Transaccion
        {
            get
            {
                return transaccion;
            }

            set
            {
                transaccion = value;
            }
        }

        /// <summary>
        /// Metodo que permite abrir la conexion con la base de datos especificada en el objeto ConnectionString para poder ejecutar una consulta
        /// Tener en cuenta que luego la conexion debe ser cerrada
        /// </summary>
        /// <returns>Objeto de tipo SqlConnection</returns>
        public SqlConnection getConexion()
        {
            // TODO: Poner la cadena de conexión en un archivo de configuracion
            if(this.conexion == null || conexion.State == System.Data.ConnectionState.Closed)
                AbrirConexion();
            return conexion;
        }

        public void AbrirConexion()
        {
            if (conexion != null)
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                    return;
                else
                {
                    conexion.Open();
                }
            }
            else
            {
                conexion = new SqlConnection(connectionString);
                conexion.Open();
            }
        }

        public void BeginTransaction()
        {
            AbrirConexion();
            Transaccion = conexion.BeginTransaction();
        }

        public void Commit()
        {
            Transaccion.Commit();
            CerrarConexion();
        }

        public void Rollback()
        {
            Transaccion.Rollback();
            CerrarConexion();
        }

        public void CerrarConexion()
        {
            conexion.Close();
        }
    }
}
