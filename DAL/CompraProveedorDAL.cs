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
    public class CompraProveedorDAL : BaseDAL
    {

        /// <summary>
        /// Metodo que permite obtener el listado de todos los objetos Compra
        /// </summary>
        /// <returns></returns>
        public ComprasProveedorCollection getComprasProveedor()
        {
            SqlCommand cmd = new SqlCommand("PACK_COMPRAS_PROVEEDOR.PR_COMPRAS_PROVEEDOR_C", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                ComprasProveedorCollection lsComprasProveedor = new ComprasProveedorCollection();
                CompraProveedor objCompraProveedor = null;

                while (dr.Read())
                {
                    //Apartamos el valor de idCompra de la Compra actual, para luego utilizarla como referencia
                    int idCompra = dr.GetInt16(0);

                    //Creamos un objeto Compra sin DetalleCompra
                    objCompraProveedor = new CompraProveedor(
                        idCompra,
                        DBHelper.getProveedorPorID(dr.GetInt16(1)),
                        dr.GetDateTime(2));

                    //Seteamos el DetalleCompra
                    objCompraProveedor.LsDetalles = DBHelper.getDetallesCompraProveedor(idCompra);

                }

                cmd.Connection.Close();

                return lsComprasProveedor;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                throw e;
            }        
        }

        /// <summary>
        /// Metodo que permite obtener el objeto CompraProveedor especificado en el parametro de entrada
        /// </summary>
        /// <param name="idCompra"></param>
        /// <returns></returns>
        public CompraProveedor getCompraProveedorPorID(int idCompra)
        {
            SqlCommand cmd = new SqlCommand("PACK_COMPRAS_PROVEEDOR.PR_COMPRAS_PROVEEDOR_POR_ID", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@p_id_compra", idCompra);

                SqlDataReader dr = cmd.ExecuteReader();

                CompraProveedor objCompraProveedor = null;

                if(dr.Read())
                {
                    //Creamos CompraProveedor sin Detalle
                    objCompraProveedor = new CompraProveedor(
                        dr.GetInt16(0),
                        DBHelper.getProveedorPorID(dr.GetInt16(1)),
                        dr.GetDateTime(2));

                    //Obtenemos el DetalleCompra
                    objCompraProveedor.LsDetalles = DBHelper.getDetallesCompraProveedor(idCompra);
                }

                cmd.Connection.Close();

                return objCompraProveedor;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                throw e;
            }
        }

        /// <summary>
        /// Metodo que permite insertar el objeto CompraProveedor especificado, con su coleccion de objetos DetalleCompraProveedor
        /// </summary>
        /// <param name="compraProveedor"></param>
        /// <returns></returns>
        public int insertarCompraProveedor(CompraProveedor compraProveedor)
        {
            SqlCommand cmd = new SqlCommand("PACK_COMPRAS_PROVEEDOR.PR_COMPRAS_PROVEEDOR_A", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlParameter paramId = new SqlParameter("@p_id_compra_proveedor", SqlDbType.Int, 4);
                paramId.Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@p_id_proveedor", compraProveedor.Proveedor.IdProveedor);
                cmd.Parameters.AddWithValue("@p_fecha", compraProveedor.Fecha);

                //Abrimos una transaccion para almacenar tanto el objeto CompraProveedor como sus DetallesCompraProveedor
                cmd.Connection.BeginTransaction();

                //Almacenamos el objeto CompraProveedor sin Detalle
                cmd.ExecuteNonQuery();

                //Almacenamos los objetos DetalleCompraProveedor
                DetalleCompraProveedorDAL detalleCompraProveedorDAL = new DetalleCompraProveedorDAL();
                detalleCompraProveedorDAL.insertarDetallesCompraProveedor(compraProveedor);

                cmd.Transaction.Commit();
                cmd.Connection.Close();

                return Convert.ToInt16(paramId);
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
