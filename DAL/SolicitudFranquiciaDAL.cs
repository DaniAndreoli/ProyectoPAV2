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
    public class SolicitudFranquiciaDAL : BaseDAL
    {

        /// <summary>
        /// Metodo empleado para obtener una lista completa de todas las SolicitudFranquicia de la base de datos
        /// </summary>
        /// <returns>Coleccion de tipo Generics con objetos de la clase SolicitudFranquicia</returns>
        public SolicitudesFranquiciaCollection getSolicitud()
        {
            SqlCommand cmd = new SqlCommand("PK_SOLICITUD_FRANQUICIA.PR_SOLICITUD_FRANQUICIA_C", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                SolicitudesFranquiciaCollection lsSolicitudes = new SolicitudesFranquiciaCollection();
                SolicitudFranquicia objSolicitud = null;

                while (dr.Read())
                {
                    objSolicitud = new SolicitudFranquicia(
                        dr.GetInt16(0),
                        DBHelper.getClientePorID(dr.GetInt16(1)),
                        DBHelper.getEstadoSolicitud(dr.GetInt16(2)),
                        dr.GetDateTime(3),
                        dr.GetDateTime(4));

                    lsSolicitudes.Add(objSolicitud);
                }

                cmd.Connection.Close();

                return lsSolicitudes;

            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                throw e;
            }

        }

        public SolicitudFranquicia getSolicitudPorID(int idSolicitud)
        {
            SqlCommand cmd = new SqlCommand("PK_SOLICITUD_FRANQUICIA.PR_SOLICITUD_FRANQUICIA_POR_ID", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);

                SqlDataReader dr = cmd.ExecuteReader();

                SolicitudFranquicia objSolicitud = null;

                while (dr.Read())
                {
                    objSolicitud = new SolicitudFranquicia(
                        dr.GetInt16(0),
                        DBHelper.getClientePorID(dr.GetInt16(1)),
                        DBHelper.getEstadoSolicitud(dr.GetInt16(2)),
                        dr.GetDateTime(3),
                        dr.GetDateTime(4));
                }

                cmd.Connection.Close();

                return objSolicitud;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                throw e;
            }
        
        }

        /// <summary>
        /// Metodo empleado para insertar un registro SolicitudFranquicia especificado en el parametro de entrada
        /// </summary>
        /// <param name="solicitud"></param>
        /// <returns></returns>
        public int insertarSolicitudFranquicia(SolicitudFranquicia solicitud)
        {
            SqlCommand cmd = new SqlCommand("PACK_SOLICITUD_FRANQUICIA.PR_SOLICITUD_FRANQUICIA_A", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlParameter paramId = cmd.Parameters.Add("@id_solicitud", SqlDbType.Int, 4);
                paramId.Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@id_cliente", solicitud.Cliente.IdCliente);
                cmd.Parameters.AddWithValue("@fecha_solicitud", solicitud.FechaSolicitud);
                cmd.Parameters.AddWithValue("@fecha_aprobacion", solicitud.FechaAprobacion);
                cmd.Parameters.AddWithValue("@id_estado", solicitud.EstadoSolicitud.IdEstado);

                //Abrimos transaccion para almacenar primero el objeto cliente y luego la solicitudFranquicia
                cmd.Connection.BeginTransaction();
                ClienteDAL clienteDAL = new ClienteDAL();

                clienteDAL.insertarCliente(solicitud.Cliente);

                cmd.ExecuteNonQuery();

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
        /// Metodo empleado para borrar el registro SolicitudFranquicia especificado en el parametro de entrada
        /// </summary>
        /// <param name="idSolicitud"></param>
        /// <returns></returns>
        public bool eliminarSolicitud(int idSolicitud)
        {
            SqlCommand cmd = new SqlCommand("PACK_SOLICITUD_FRANQUICIA.PR_SOLICITUD_FRANQUICIA_B", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return true;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                return false;
                throw e;
            }

        }

        /// <summary>
        /// Metodo que permite modificar un registro especificado por la solicitudFranquicia enviada por parametro
        /// </summary>
        /// <param name="solicitud"></param>
        /// <returns></returns>
        public bool modificarSolicitudFranquicia(SolicitudFranquicia solicitud)
        {
            SqlCommand cmd = new SqlCommand("PACK_SOLICITUD_FRANQUICIA.PR_SOLICITUD_FRANQUICIA_U",getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@id_solicitud", solicitud.IdSolicitud);
                cmd.Parameters.AddWithValue("@id_cliente", solicitud.Cliente.IdCliente);
                cmd.Parameters.AddWithValue("@id_estado", solicitud.EstadoSolicitud.IdEstado);
                cmd.Parameters.AddWithValue("@fecha_solicitud", solicitud.FechaSolicitud);
                cmd.Parameters.AddWithValue("@fecha_aprobacion", solicitud.FechaAprobacion);

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return true;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                return false;
                throw e;
                throw;
            }
        }
    }
}
