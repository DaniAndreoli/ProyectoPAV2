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
    class DetalleCompraProveedorDAL : BaseDAL
    {

        /// <summary>
        /// Metodo que permite obtener la coleccion de objetos DetalleCompraProveedor de la CompraProveedor especificada en el parametro de entrada
        /// </summary>
        /// <param name="idCompra"></param>
        /// <returns></returns>
        public DetallesCompraProveedorCollection getDetallesCompraProveedor(int idCompra)
        {
            SqlCommand cmd = new SqlCommand("PACK_DETALLES_COMPRA_PROVEEDOR.PR_DETALLES_POR_COMPRA", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@p_id_compra", idCompra);

                SqlDataReader dr = cmd.ExecuteReader();

                DetallesCompraProveedorCollection lsDetallesCompraProveedor = new DetallesCompraProveedorCollection();
                DetalleCompraProveedor objDetalle = null;

                while(dr.Read())
                {
                    objDetalle = new DetalleCompraProveedor(
                        DBHelper.getInsumoPorID(dr.GetInt16(0)),
                        dr.GetInt16(1),
                        dr.GetDouble(2));

                    lsDetallesCompraProveedor.Add(objDetalle);
                }

                cmd.Connection.Close();

                return lsDetallesCompraProveedor;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                throw e;
            }
        }

        /// <summary>
        /// Metodo que permite insertar una coleccion de objetos DetalleCompraProveedor de una CompraProveedor especificada en el parametro de entrada
        /// </summary>
        /// <param name="compraProveedor"></param>
        /// <returns>Valor Int con la cantidad de objetos DetalleCompraProveedor insertados en la Base de Datos</returns>
        public int insertarDetallesCompraProveedor(CompraProveedor compraProveedor)
        {
            SqlCommand cmd = new SqlCommand("PACK_DETALLES_COMPRA_PROVEEDOR.PR_DETALLES_COMPRA_PROVEEDOR_A", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            int cantidadDetallesInsertados = 0;

            try
            {
                cmd.Connection.BeginTransaction();

                foreach (DetalleCompraProveedor itemDetalle in compraProveedor.LsDetalles)
                {
                    cmd.Parameters.AddWithValue("@p_id_compra", compraProveedor.IdCompra);
                    cmd.Parameters.AddWithValue("@p_id_insumo", itemDetalle.Insumo.IdInsumo);
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
