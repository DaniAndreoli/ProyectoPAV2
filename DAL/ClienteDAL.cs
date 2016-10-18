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
    public class ClienteDAL : BaseDAL
    {

        /// <summary>
        /// Metodo empleado para obtener una lista completa de todos los Clientes de la Base de Datos
        /// </summary>
        /// <returns>Coleccion de tipo Generics con objetos de la clase Cliente</returns>
        public ClientesCollection getClientes()
        {
            SqlCommand cmd = new SqlCommand("PK_CLIENTES.PR_CLIENTES_C", getConexion());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                ClientesCollection lsClientes = new ClientesCollection();
                Cliente objCliente = null;

                while (dr.Read())
                {
                    objCliente = new Cliente(
                        dr.GetInt16(0),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetInt64(3),
                        DBHelper.getTipoDocumentoPorID(dr.GetInt16(4)),
                        dr.GetInt64(5),
                        DBHelper.getDomicilioPorID(dr.GetInt16(6)),
                        dr.GetString(7),
                        DBHelper.getUsuarioPorID(dr.GetInt16(8)),
                        DBHelper.getFranquiciasPorCliente(dr.GetInt16(9))
                        );

                    lsClientes.Add(objCliente);               
                }

                cmd.Connection.Close();

                return lsClientes;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                throw e;
            }
        }

        /// <summary>
        /// Metodo empleado para obtener el objeto Cliente especificado en el parametro de entrada
        /// </summary>
        /// <param name="idCliente">Id del cliente que se desea recuperar</param>
        /// <returns>Objeto Cliente</returns>
        public Cliente getClientePorID(int idCliente)
        {
            SqlCommand cmd = new SqlCommand("PK_CLIENTES.PR_CLIENTES_POR_ID", getConexion());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@p_id_cliente", idCliente);

                SqlDataReader dr = cmd.ExecuteReader();

                Cliente objCliente = null;

                if (dr.Read())
                {
                    objCliente = new Cliente(
                        dr.GetInt16(0),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetInt64(3),
                        DBHelper.getTipoDocumentoPorID(dr.GetInt16(4)),
                        dr.GetInt64(5),
                        DBHelper.getDomicilioPorID(dr.GetInt16(6)),
                        dr.GetString(7),
                        DBHelper.getUsuarioPorID(dr.GetInt16(8)),
                        DBHelper.getFranquiciasPorCliente(dr.GetInt16(9))
                        );
                }

                cmd.Connection.Close();

                return objCliente;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                throw e;
            }
            
        }

        /// <summary>
        /// Metodo empleado para insertar el registro Cliente especificado en el parametro de entrada
        /// Abarca una transaccion creando tambien el registro del objeto Domicilio asociado
        /// </summary>
        /// <param name="cliente">Objeto Cliente que se desea almacenar</param>
        /// <returns></returns>
        public int insertarCliente(Cliente cliente)
        {
            SqlCommand cmd = new SqlCommand("PACK_CLIENTES.PR_CLIENTES_A", getConexion());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                SqlParameter paramId = cmd.Parameters.Add("@p_id_cliente", SqlDbType.Int, 4);
                paramId.Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@p_nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@p_apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@p_nro_documento", cliente.NroDocumento);
                cmd.Parameters.AddWithValue("@p_id_tipo_documento", cliente.TipoDocumento.IdTipoDocumento);
                cmd.Parameters.AddWithValue("@p_telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@p_id_domicilio", cliente.Domicilio.IdDomicilio);
                cmd.Parameters.AddWithValue("@p_e_mail", cliente.EMail);
                cmd.Parameters.AddWithValue("@p_id_usuario", cliente.Usuario.IdUsuario);

                //Comenzamos la transaccion de Insertar un Cliente con su Domicilio
                cmd.Connection.BeginTransaction();

                //Almacenamos el objeto Domicilio del Cliente en la base de datos
                DomicilioDAL domicilioDAL = new DomicilioDAL();
                domicilioDAL.insertarDomicilio(cliente.Domicilio);

                //Almacenamos el objeto Cliente
                cmd.ExecuteNonQuery();

                //Realizamos un Commit de la Transaccion y luego cerramos la conexion
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
        /// Metodo empleado para eliminar el registro Cliente especificado en el parametro de entrada
        /// </summary>
        /// <param name="idCliente">Id del Cliente que se desea eliminar</param>
        /// <returns>Valor boolean que indica si la operacion fue realizada con exito o no</returns>
        public bool eliminarCliente(int idCliente)
        {
            bool resultado = false;

            SqlCommand cmd = new SqlCommand("PACK_CLIENTES.PR_CLIENTES_B", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@id_cliente", idCliente);

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
        /// Metodo empleado para modificar el registro CLiente especificado en el parametro de entrada
        /// </summary>
        /// <param name="cliente">Objeto Cliente con los nuevos datos que se desean modificar</param>
        /// <returns></returns>
        public bool modificarCliente(Cliente cliente)
        {
            bool resultado = false;

            SqlCommand cmd = new SqlCommand("PACK_CLIENTES.PR_CLIENTES_M");
            cmd.CommandType = CommandType.StoredProcedure;

            try
            { 
                cmd.Parameters.AddWithValue("@id_cliente", cliente.IdCliente);
                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@nro_documento", cliente.NroDocumento);
                cmd.Parameters.AddWithValue("@id_tipo_documento", cliente.TipoDocumento.IdTipoDocumento);
                cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@id_domicilio", cliente.Domicilio.IdDomicilio);
                cmd.Parameters.AddWithValue("@e_mail", cliente.EMail);
                cmd.Parameters.AddWithValue("@id_usuario", cliente.Usuario.IdUsuario);

                //Comenzamos la transaccion que incluye la modificacion del cliente y de su objeto domicilio en caso que corresponda
                cmd.Connection.BeginTransaction();

                //Modificamos el registro domicilio en caso de haber recibido modificaciones
                DomicilioDAL domicilioDAL = new DomicilioDAL();
                domicilioDAL.modificarDomicilio(cliente.Domicilio);

                //Modificamos el registro Cliente
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
