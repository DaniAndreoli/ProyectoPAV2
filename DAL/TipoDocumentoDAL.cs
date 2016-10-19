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
    public class TipoDocumentoDAL : BaseDAL
    {
        /// <summary>
        /// Permite obtener una coleccion con todos los registros de  Tipos de Documento de Base de Datos
        /// </summary>
        /// <returns>Coleccion Generics de objetos TipoDocumento</returns>
        public TiposDocumentoCollection getTiposDocumento()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM T_TIPOS_DOCUMENTO", getConexion());
            cmd.CommandType = System.Data.CommandType.Text;

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                TipoDocumento objTipoDocumento = null;

                TiposDocumentoCollection tiposDocumento = new TiposDocumentoCollection();
                while (dr.Read())
                {
                    objTipoDocumento = new TipoDocumento(
                        dr.GetInt32(0),
                        dr.GetString(1));

                    tiposDocumento.Add(objTipoDocumento);
                }

                cmd.Connection.Close();

                return tiposDocumento;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                throw e;
            }
            
        }
        
        /// <summary>
        /// Permite obtener el objeto de la clase TipoDocumento especificado por el parametro de entrada
        /// </summary>
        /// <param name="idTipoDocumento"></param>
        /// <returns></returns>
        public TipoDocumento getTipoDocumentoPorID(int idTipoDocumento)
        {
            SqlCommand cmd = new SqlCommand("PACK_TIPOS_DOCUMENTO.PR_TIPO_DOCUMENTO_POR_ID", getConexion());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_tipo_documento", idTipoDocumento);

            SqlDataReader dr = cmd.ExecuteReader();

            TipoDocumento objTipoDocumento = null;

            if(dr.Read())
            {
                objTipoDocumento = new TipoDocumento(
                    dr.GetInt16(0),
                    dr.GetString(1));
            }

            cmd.Connection.Close();

            return objTipoDocumento;
        }

    }
}
