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
    public class EstadoSolicitudDAL : BaseDAL
    {

        /// <summary>
        /// Metodo que permite obtener el objeto EstadoSolicitud especificado en el parametro de entrada
        /// </summary>
        /// <param name="idEstado"></param>
        /// <returns>Bbjeto EstadoSolicitud</returns>
        public EstadoSolicitud getEstadoPorID(int idEstado)
        {
            SqlCommand cmd = new SqlCommand("PR_ESTADOS_SOLICITUD_POR_ID", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@id_estado",idEstado);
                SqlDataReader dr = cmd.ExecuteReader();

                EstadoSolicitud objEstado = null;

                if (dr.Read())
                {
                    objEstado = new EstadoSolicitud( 

                        dr.GetInt32(0),
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
        /// Metodo que permite insertar el objeto EstadoSolicitud especificado en el parametro de entrada
        /// </summary>
        /// <param name="estadoPedido"></param>
        /// <returns>Id del Estado insertado</returns>
        public int insertarEstado(EstadoSolicitud estadoSolicitud)
        {
            SqlCommand cmd = new SqlCommand("PR_ESTADOS_SOLICITUD_A", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlParameter paramId = new SqlParameter("@p_id_estado", SqlDbType.Int, 4);
                paramId.Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@p_n_estado", estadoSolicitud.NombreEstado);

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
