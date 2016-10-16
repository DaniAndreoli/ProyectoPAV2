using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

using ProyectoPAV2.Entidades;

namespace ProyectoPAV2.DAL
{
    class FranquiciaDAL : BaseDAL
    {
    
        /// <summary>
        /// Metodo que permite ejecutar el procedimiento PR_FRANQUICIA_POR_ID en la Basde de Datos, para obtener el objeto Franquicia
        /// especificado en el parametro de entrada
        /// </summary>
        /// <param name="idFranquicia"></param>
        /// <returns>Objeto Franquicia</returns>
        public Franquicia getFranquiciaPorID(int idFranquicia)
        {
            SqlCommand cmd = new SqlCommand("PACK_FRANQUICIAS.PR_FRANQUICIAS_POR_ID", getConexion());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_franquicia", idFranquicia);

            SqlDataReader dr = cmd.ExecuteReader();

            Franquicia objFranquicia = null;

            if(dr.Read())
            {
                objFranquicia = new Franquicia(
                    dr.GetInt16(0),
                    DBHelper.getDomicilioPorID(dr.GetInt16(1)),
                    dr.GetString(2),
                    dr.GetInt64(3));
            }

            cmd.Connection.Close();

            return objFranquicia;
        }

        /// <summary>
        /// Metodo que permite ejecutar el procedimiento PR_FRANQUICIAS_POR_CLIENTE en la Base de Datos, para obtener una coleccion
        /// de todos los objetos Franquicia del Cliente especificado en el parametro de entrada
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns>Objeto FranquiciaCollection</returns>
        public FranquiciasCollection getFranquiciasPorCliente(int idCliente)
        {
            SqlCommand cmd = new SqlCommand("PACK_FRANQUICIAS.PR_FRANQUICIAS_POR_CLIENTE", getConexion());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_cliente", idCliente);

            SqlDataReader dr = cmd.ExecuteReader();

            FranquiciasCollection lsFranquicias = new FranquiciasCollection();
            Franquicia objFranquicia = null;

            while(dr.Read())
            {
                objFranquicia = new Franquicia(
                    dr.GetInt16(0),
                    DBHelper.getDomicilioPorID(dr.GetInt16(1)),
                    dr.GetString(2),
                    dr.GetInt64(3));

                lsFranquicias.Add(objFranquicia);
            }

            cmd.Connection.Close();

            return lsFranquicias;
        }
    }
}
