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
    class InsumoDAL : BaseDAL
    {

        /// <summary>
        /// Metodo que permite obtener el objeto Insumo especificado en el parametro de entrada
        /// </summary>
        /// <param name="idInsumo"></param>
        /// <returns></returns>
        public Insumo getInsumoPorID(int idInsumo)
        {
            SqlCommand cmd = new SqlCommand("PACK_INSUMOS.PR_INSUMOS_POR_ID", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@p_id_insumo", idInsumo);

                SqlDataReader dr = cmd.ExecuteReader();

                Insumo objInsumo = null;

                if(dr.Read())
                {
                    objInsumo = new Insumo(
                        dr.GetInt16(0),
                        dr.GetString(1),
                        DBHelper.getMedidaPorID(dr.GetInt16(2)),
                        dr.GetInt16(3));
                }

                cmd.Connection.Close();

                return objInsumo;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
