using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using ProyectoPAV2.Entidades;

namespace ProyectoPAV2.DAL
{
    class EstadoPedidoDAL : BaseDAL
    {

        /// <summary>
        /// Metodo que permite obtener el objeto EstadoPedido especificado en el parametro de entrada
        /// </summary>
        /// <param name="idEstado"></param>
        /// <returns>Bbjeto EstadoPedido</returns>
        public EstadoPedido getEstadoPorID(int idEstado)
        {
            SqlCommand cmd = new SqlCommand("PK_ESTADOS_PEDIDO.PR_ESTADOS_POR_ID", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                EstadoPedido objEstado = null;

                if(dr.Read())
                {
                    objEstado = new EstadoPedido(
                        dr.GetInt16(0),
                        dr.GetString(1));
                }

                cmd.Connection.Close();

                return objEstado;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                throw e;
            }
            
        }

        /// <summary>
        /// Metodo que permite insertar el objeto EstadoPedido especificado en el parametro de entrada
        /// </summary>
        /// <param name="estadoPedido"></param>
        /// <returns>Id del Estado insertado</returns>
        public int insertarEstado(EstadoPedido estadoPedido)
        {
            SqlCommand cmd = new SqlCommand("PACK_ESTADOS_PEDIDO.PR_ESTADOS_PEDIDO_A", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlParameter paramId = new SqlParameter("@p_id_estado", SqlDbType.Int, 4);
                paramId.Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@p_n_estado", estadoPedido.NombreEstado);

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return Convert.ToInt16(paramId);
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                throw e;
            }
            

        }
    }
}
