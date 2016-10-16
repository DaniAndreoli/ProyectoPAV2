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
    class PedidoDAL : BaseDAL
    {
        /// <summary>
        /// Metodo empleado para obtener una lista completa de todos los Pedidos de la Base de Datos
        /// </summary>
        /// <returns>Coleccion de tipo Generics con objetos de la clase Pedido</returns>
        public PedidosCollection getPedidos()
        {
            SqlCommand cmd = new SqlCommand("PK_PEDIDOS.PR_PEDIDOS_C", getConexion());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                PedidosCollection lsPedidos = new PedidosCollection();
                Pedido objPedido = null;

                while (dr.Read())
                {
                    objPedido = new Pedido(
                        dr.GetInt16(0),
                        dr.GetDateTime(1),
                        dr.GetDateTime(2),
                        dr.GetDateTime(3),
                        DBHelper.getFranquiciaPorID(dr.GetInt16(4)),
                        DBHelper.getEstadoPorID(dr.GetInt16(5)),
                        dr.GetDouble(6));

                    lsPedidos.Add(objPedido);
                }

                cmd.Connection.Close();

                return lsPedidos;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                throw e;
            }
            
        }

        /// <summary>
        /// Metodo empleado para obtener el objeto Pedido especificado en el parametro de entrada
        /// </summary>
        /// <param name="idPedido"></param>
        /// <returns>Objeto Pedido</returns>
        public Pedido getPedidoPorID(int idPedido)
        {
            SqlCommand cmd = new SqlCommand("PK_PEDIDOS.PR_PEDIDOS_POR_ID", getConexion());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@id_pedido", idPedido);

                SqlDataReader dr = cmd.ExecuteReader();

                Pedido objPedido = null;

                if (dr.Read())
                {
                    objPedido = new Pedido(
                        dr.GetInt16(0),
                        dr.GetDateTime(1),
                        dr.GetDateTime(2),
                        dr.GetDateTime(3),
                        DBHelper.getFranquiciaPorID(dr.GetInt16(4)),
                        DBHelper.getEstadoPorID(dr.GetInt16(5)),
                        dr.GetDouble(6));
                }

                cmd.Connection.Close();

                return objPedido;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                throw e;
            }

            
        }

        /// <summary>
        /// Metodo empleado para insertar el registro Pedido especificado en el parametro de entrada
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns></returns>
        public int insertarPedido(Pedido pedido)
        {
            SqlCommand cmd = new SqlCommand("PACK_PEDIDOS.PR_PEDIDOS_A", getConexion());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                SqlParameter paramId = cmd.Parameters.Add("@id_pedido", SqlDbType.Int, 4);
                paramId.Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@fecha_pedido", pedido.FechaPedido);
                cmd.Parameters.AddWithValue("@fecha_entrega_pactada", pedido.FechaEntrega_Pactada);
                cmd.Parameters.AddWithValue("@fecha_entrega_real", pedido.FechaEntrega_Real);
                cmd.Parameters.AddWithValue("@id_franquicia", pedido.Franquicia.IdFranquicia);
                cmd.Parameters.AddWithValue("@id_estado_pedido", pedido.EstadoPedido.IdEstado);
                cmd.Parameters.AddWithValue("@monto_total", pedido.MontoTotal);

                //Abrimos transaccion para almacenar el objeto Pedido sin detalle
                cmd.Connection.BeginTransaction();

                cmd.ExecuteNonQuery();

                DetallePedidoDAL detallePedidoDAL = new DetallePedidoDAL();
                detallePedidoDAL.insertarDetallesPedido(pedido);

                cmd.Transaction.Commit();
                cmd.Connection.Close();

                return Convert.ToInt16(paramId.Value);
            }
            catch (Exception e)
            {
                cmd.Transaction.Rollback();
                cmd.Connection.Close();
                throw e;
            }
        }

        /// <summary>
        /// Metodo empleado para eliminar el registro Pedido especificado en el parametro de entrada
        /// </summary>
        /// <param name="idPedido"></param>
        /// <returns></returns>
        public bool eliminarPedido(int idPedido)
        {
            SqlCommand cmd = new SqlCommand("PACK_PEDIDOS.PR_PEDIDOS_B", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@id_pedido", idPedido);

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return true;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                throw e;
            }
        }

        /// <summary>
        /// Metodo empleado para modificar el registro Pedido especificado en el parametro de entrada
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns></returns>
        public bool modificarPedido(Pedido pedido)
        {
            SqlCommand cmd = new SqlCommand("PACK_PEDIDOS.PR_PEDIDOS_U");
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@fecha_pedido", pedido.FechaPedido);
                cmd.Parameters.AddWithValue("@fecha_entrega_pactada", pedido.FechaEntrega_Pactada);
                cmd.Parameters.AddWithValue("@fecha_entrega_real", pedido.FechaEntrega_Real);
                cmd.Parameters.AddWithValue("@id_franquicia", pedido.Franquicia.IdFranquicia);
                cmd.Parameters.AddWithValue("@id_estado_pedido", pedido.EstadoPedido.IdEstado);
                cmd.Parameters.AddWithValue("@monto_total", pedido.MontoTotal);


                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return true;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                throw e;
            }
        }
    }
}
