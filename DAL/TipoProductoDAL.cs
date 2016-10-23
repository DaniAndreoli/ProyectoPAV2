using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using ProyectoPAV2.Entidades;

namespace ProyectoPAV2.DAL
{
    public class TipoProductoDAL : BaseDAL
    {

        /// <summary>
        /// Metodo que permite obtener una coleccion con todos los registros de Tipos de Producto de Base de Datos
        /// </summary>
        /// <returns></returns>
        public TiposProductoCollection getTiposProducto()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM T_TIPOS_PRODUCTO", getConexion());
            cmd.CommandType = System.Data.CommandType.Text;

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                TiposProductoCollection lsTiposProducto = new TiposProductoCollection();
                TipoProducto objTipoProducto = null;

                while (dr.Read())
                {
                    objTipoProducto = new TipoProducto(
                        dr.GetInt32(0),
                        dr.GetString(1));

                    lsTiposProducto.Add(objTipoProducto);
                }

                cmd.Connection.Close();

                return lsTiposProducto;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                throw e;
            }
        }

        public TipoProducto getTipoProductoPorID(int idTipoProducto)
        {
            SqlCommand cmd = new SqlCommand("PR_TIPOS_PRODUCTO_POR_ID", getConexion());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_tipo_producto", idTipoProducto);

            SqlDataReader dr = cmd.ExecuteReader();

            TipoProducto objTipoProducto = null;

            if (dr.Read())
            {
                objTipoProducto = new TipoProducto(
                    dr.GetInt32(0),
                    dr.GetString(1));
            }

            cmd.Connection.Close();

            return objTipoProducto;
        }
    }
}
