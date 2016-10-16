using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

using ProyectoPAV2.Entidades;

namespace ProyectoPAV2.DAL
{
    class LocalidadDAL : BaseDAL
    {

        /// <summary>
        /// Metodo que permite obtener una coleccion con todas las Localidades
        /// </summary>
        /// <returns></returns>
        public LocalidadesCollection getLocalidades()
        {
            SqlCommand cmd = new SqlCommand("PACK_LOCALIDADES.PR_LOCALIDADES_C", getConexion());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                LocalidadesCollection lsLocalidades = new LocalidadesCollection();
                Localidad objLocalidad = null;

                while (dr.Read())
                {
                    objLocalidad = new Localidad(
                        dr.GetInt16(0),
                        dr.GetInt16(1),
                        dr.GetString(2));

                    lsLocalidades.Add(objLocalidad);
                }

                cmd.Connection.Close();

                return lsLocalidades;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                throw e;
            }
            


        }

        /// <summary>
        /// Metodo que permite obtener el objeto Localidad especificado en el parametro de entrada
        /// </summary>
        /// <param name="idLocalidad"></param>
        /// <returns></returns>
        public Localidad getLocalidadPorID(int idLocalidad)
        {
            SqlCommand cmd = new SqlCommand("PACK_LOCALIDADES.PR_LOCALIDAD_POR_ID", getConexion());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_localidad", idLocalidad);
            SqlDataReader dr = cmd.ExecuteReader();

            Localidad objLocalidad = null;

            if (dr.Read())
            {
                objLocalidad = new Localidad(
                    dr.GetInt16(0),
                    dr.GetInt16(1),
                    dr.GetString(2));
            }

            cmd.Connection.Close();

            return objLocalidad;
        }
 
    }
}
