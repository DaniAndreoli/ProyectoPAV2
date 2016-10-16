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
    class DetallePedidoDAL : BaseDAL
    {
        
        /// <summary>
        /// Metodo que permite insertar una coleccion de objetos DetallePedido de un Pedido especificado por parametro
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns>Cantidad de DetallePedido ingresado</returns>
        public int insertarDetallesPedido(Pedido pedido)
        {
            SqlCommand cmd = new SqlCommand("PACK_DETALLES_PEDIDO.PR_DETALLES_PEDIDO_A", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            int cantidadDetallesInsertados = 0;

            try
            {
                cmd.Connection.BeginTransaction();

                foreach (DetallePedido itemDetalle in pedido.LsDetallesPedido)
                {
                    cmd.Parameters.AddWithValue("@p_id_pedido", pedido.IdPedido);
                    cmd.Parameters.AddWithValue("@p_id_producto", itemDetalle.Producto.IdProducto);
                    cmd.Parameters.AddWithValue("@p_cantidad", itemDetalle.Cantidad);
                    cmd.Parameters.AddWithValue("@p_precio_unitario", itemDetalle.PrecioUnitario);

                    cmd.ExecuteNonQuery();
                    cantidadDetallesInsertados++;
                    cmd.Parameters.Clear();
                }

                cmd.Transaction.Commit();
                cmd.Connection.Close();

                return cantidadDetallesInsertados;
            }
            catch (Exception e)
            {
                cmd.Transaction.Rollback();
                cmd.Connection.Close();
                throw e;
            }
        }

    }
}
