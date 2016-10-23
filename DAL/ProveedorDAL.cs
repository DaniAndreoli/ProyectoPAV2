using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

using ProyectoPAV2.Entidades;
using System.Data;


namespace ProyectoPAV2.DAL
{
    public class ProveedorDAL : BaseDAL
    {

        /// <summary>
        /// Metodo empleado para obtener una lista completa de todos los Proveedores de la Base de Datos
        /// </summary>
        /// <returns>Coleccion de tipo Generics con objetos de la clase Proveedor</returns>
        public ProveedorCollection getProveedores()
        {
            SqlCommand cmd = new SqlCommand("PR_PROVEEDORES_C", getConexion());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                ProveedorCollection lsProveedor = new ProveedorCollection();
                Proveedor objProveedor = null;

                while (dr.Read())
                {
                    objProveedor = new Proveedor(
                        dr.GetInt16(0),
                        dr.GetInt64(1),
                        dr.GetString(2),
                        DBHelper.getDomicilioPorID(dr.GetInt16(3)),
                        dr.GetDateTime(4),
                        dr.GetDateTime(5)
                        );

                    lsProveedor.Add(objProveedor);
                }

                cmd.Connection.Close();

                return lsProveedor;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                throw e;
            }
        }


        /// <summary>
        /// Metodo que permite obtener el objeto Proveedor especificado en el parametro de entrada
        /// </summary>
        /// <param name="idProveedor"></param>
        /// <returns></returns>
        public Proveedor getProveedorPorID(int idProveedor)
        {
            SqlCommand cmd = new SqlCommand("PR_PROVEEDORES_POR_ID", getConexion());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@id_proveedor", idProveedor);
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
        /// <summary>
        /// Metodo empleado para insertar el registro Proveedor especificado en el parametro de entrada
        /// Abarca una transaccion creando tambien el registro del objeto Domicilio asociado
        /// </summary>
        /// <param name="proveedor">Objeto Proveedor que se desea almacenar</param>
        /// <returns></returns>
        public int insertarProveedor(Proveedor proveedor)
        {
            SqlCommand cmd = new SqlCommand("PR_PROVEEDORES_A", getConexion());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                int valor = 0;

                cmd.Parameters.AddWithValue("@cuit", proveedor.Cuit);
                cmd.Parameters.AddWithValue("@n_proveedor", proveedor.NombreProveedor);             
                cmd.Parameters.AddWithValue("@id_domicilio", proveedor.Domicilio.IdDomicilio);
                cmd.Parameters.AddWithValue("@fecha_alta", proveedor.FechaAlta);
                

                //Comenzamos la transaccion de Insertar un Proveedor con su Domicilio
                cmd.Connection.BeginTransaction();

                //Almacenamos el objeto Domicilio del Proveedor en la base de datos
                DomicilioDAL domicilioDAL = new DomicilioDAL();
                domicilioDAL.insertarDomicilio(proveedor.Domicilio);

                //Almacenamos el objeto Proveedor
                valor = cmd.ExecuteNonQuery();

                //Realizamos un Commit de la Transaccion y luego cerramos la conexion
                cmd.Transaction.Commit();
                cmd.Connection.Close();

                return valor;
            }
            catch (Exception e)
            {
                cmd.Transaction.Rollback();
                cmd.Connection.Close();
                throw e;
            }
        }

        /// <summary>
        /// Metodo empleado para eliminar el registro Proveedor especificado en el parametro de entrada
        /// </summary>
        /// <param name="idProveedor">Id del Proveedor que se desea eliminar</param>
        /// <returns>Valor boolean que indica si la operacion fue realizada con exito o no</returns>
        public bool eliminarProveedor(int idProveedor)
        {
            bool resultado = false;

            SqlCommand cmd = new SqlCommand("PR_PROVEEDORES_B", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@id_proveedor", idProveedor);

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                resultado = true;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                throw e;

            }

            return resultado;
        }
        /// <summary>
        /// Metodo empleado para modificar el registro Proveedor especificado en el parametro de entrada
        /// </summary>
        /// <param name="proveedor">Objeto Proveedor con los nuevos datos que se desean modificar</param>
        /// <returns></returns>
        public bool modificarProveedor(Proveedor proveedor)
        {
            bool resultado = false;

            SqlCommand cmd = new SqlCommand("PR_PROVEEDORES_M");
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@id_proveedor", proveedor.IdProveedor);
                cmd.Parameters.AddWithValue("@nombre", proveedor.NombreProveedor);
                cmd.Parameters.AddWithValue("@cuit", proveedor.Cuit);
                cmd.Parameters.AddWithValue("@id_domicilio", proveedor.Domicilio.IdDomicilio);
                cmd.Parameters.AddWithValue("@fecha_baja", proveedor.FechaBaja);


                //Comenzamos la transaccion que incluye la modificacion del Proveedor y de su objeto domicilio en caso que corresponda
                cmd.Connection.BeginTransaction();

                //Modificamos el registro domicilio en caso de haber recibido modificaciones
                DomicilioDAL domicilioDAL = new DomicilioDAL();
                domicilioDAL.modificarDomicilio(proveedor.Domicilio);

                //Modificamos el registro Proveedor
                cmd.ExecuteNonQuery();

                cmd.Transaction.Commit();
                cmd.Connection.Close();

                resultado = true;
            }
            catch (Exception e)
            {
                cmd.Transaction.Rollback();
                cmd.Connection.Close();
                throw e;
            }

            return resultado;
        }
    }
}
