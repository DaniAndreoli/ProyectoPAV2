using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

using ProyectoPAV2.Entidades;

namespace ProyectoPAV2.DAL
{
    class ProveedorDAL : BaseDAL
    {
        /// <summary>
        /// Metodo que permite obtener el objeto Proveedor especificado en el parametro de entrada
        /// </summary>
        /// <param name="idProveedor"></param>
        /// <returns></returns>
        public Proveedor getProveedorPorID(int idProveedor)
        {
            SqlCommand cmd = new SqlCommand("PACK_PROVEEDORES.PR_PROVEEDORES_POR_ID", getConexion());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@p_id_proveedor", idProveedor);

                SqlDataReader dr = cmd.ExecuteReader();

                Proveedor objProveedor = null;

                if(dr.Read())
                {
                    objProveedor = new Proveedor(
                        dr.GetInt16(0),
                        dr.GetInt64(1),
                        dr.GetString(2),
                        DBHelper.getDomicilioPorID(dr.GetInt16(3)),
                        dr.GetDateTime(4),
                        dr.GetDateTime(5));
                }

                return objProveedor;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                throw e;
            }
            
        }
    }
}
