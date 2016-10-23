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
    class DomicilioDAL : BaseDAL
    {

        /// <summary>
        /// Metodo que permite obtener el objeto Domicilio especificado en el parametro de entrada
        /// </summary>
        /// <param name="idDomicilio"></param>
        /// <returns>Objeto Domicilio</returns>
        public Domicilio getDomicilioPorID(int idDomicilio)
        {
            SqlCommand cmd = new SqlCommand("PR_DOMICILIOS_POR_ID", getConexion(),Transaccion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_domicilio", idDomicilio);
            SqlDataReader dr = cmd.ExecuteReader();

            Domicilio objDomicilio = null;

            if (dr.Read())
            {
                objDomicilio = new Domicilio(
                    dr.GetInt16(0),
                    DBHelper.getLocalidadPorID(dr.GetInt16(1)),
                    dr.GetInt16(2),
                    dr.GetInt16(3),
                    dr.GetString(4),
                    dr.GetString(5),
                    dr.GetString(6));
            }

            cmd.Connection.Close();

            return objDomicilio;
        }

        /// <summary>
        /// Metodo que permite insertar el registro Domicilio especificado en el parametro de entrada
        /// </summary>
        /// <param name="domicilio"></param>
        /// <returns>Id del Domicilio insertado</returns>
        public int insertarDomicilio(Domicilio domicilio)
        {
            //BeginTransaction();

            SqlCommand cmd = new SqlCommand("PR_DOMICILIOS_A", getConexion(), Transaccion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter pr = new SqlParameter("@id_domicilio", SqlDbType.Int, 4);
            pr.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(pr);

            cmd.Parameters.AddWithValue("@id_localidad", domicilio.Localidad.IdLocalidad);
            cmd.Parameters.AddWithValue("@numero", domicilio.Numero);
            cmd.Parameters.AddWithValue("@piso", domicilio.Piso);
            cmd.Parameters.AddWithValue("@dpto", domicilio.Dpto);
            cmd.Parameters.AddWithValue("@barrio", domicilio.Barrio);
            cmd.Parameters.AddWithValue("@calle", domicilio.Calle);

            try
            {
                cmd.ExecuteNonQuery();

                //Commit();

                return Convert.ToInt32(pr.Value);
            }
            catch (Exception e)
            {
                //Rollback();
                throw e;
            }
        }

        /// <summary>
        /// Metodo que permite modificar el registro Domicilio especificado en el parametro de entrada
        /// </summary>
        /// <param name="domicilio">Objeto Domicilio con los nuevos datos</param>
        /// <returns>Valor bool que indica si la modificacion se realizo correctamente</returns>
        public bool modificarDomicilio(Domicilio domicilio)
        {
            SqlCommand cmd = new SqlCommand("PR_DOMICILIOS_M", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@p_id_localidad", domicilio.Localidad.IdLocalidad);
                cmd.Parameters.AddWithValue("@p_numero", domicilio.Numero);
                cmd.Parameters.AddWithValue("@p_piso", domicilio.Piso);
                cmd.Parameters.AddWithValue("@p_dpto", domicilio.Dpto);
                cmd.Parameters.AddWithValue("@p_barrio", domicilio.Barrio);
                cmd.Parameters.AddWithValue("@p_calle", domicilio.Calle);

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
