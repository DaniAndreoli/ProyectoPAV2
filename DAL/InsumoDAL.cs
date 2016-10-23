using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using ProyectoPAV2.Entidades;

using ProyectoPAV2.Excepciones;

namespace ProyectoPAV2.DAL
{
    public class InsumoDAL : BaseDAL
    {

        /// <summary>
        /// Metodo que permite obtener el objeto Insumo especificado en el parametro de entrada
        /// </summary>
        /// <param name="idInsumo"></param>
        /// <returns></returns>
        public Insumo getInsumoPorID(int idInsumo)
        {
            SqlCommand cmd = new SqlCommand("PR_INSUMOS_POR_ID", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@id_insumo", idInsumo);

                SqlDataReader dr = cmd.ExecuteReader();

                Insumo objInsumo = null;

                if (dr.Read())
                {
                    objInsumo = new Insumo(
                        idInsumo,
                        dr.GetString(0),
                        DBHelper.getMedidaPorID(dr.GetInt32(1)));
                }

                cmd.Connection.Close();

                return objInsumo;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public InsumosCollection getInsumos()
        {
            SqlCommand cmd = new SqlCommand("PR_INSUMOS_C", getConexion());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                Insumo objInsumo = null;

                InsumosCollection lsInsumos = new InsumosCollection();

                while (dr.Read())
                {
                    objInsumo = new Insumo(
                        dr.GetInt32(0),
                        dr.GetString(1),
                        DBHelper.getMedidaPorID(dr.GetInt32(2)),
                        dr.GetInt32(3));

                    lsInsumos.Add(objInsumo);
                }

                cmd.Connection.Close();

                return lsInsumos;
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                throw e;
            }

        }

        public int insertarInsumo(Insumo insumo)
        {
            SqlCommand cmd = new SqlCommand("PR_INSUMOS_A", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@id_insumo", SqlDbType.Int, 4);
            param.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(param);

            cmd.Parameters.AddWithValue("@n_insumo", insumo.NombreInsumo);
            cmd.Parameters.AddWithValue("@id_medida", insumo.Medida.IdMedida);

            try
            {                
                cmd.ExecuteNonQuery();

                CerrarConexion();

                return Convert.ToInt32(param.Value);
            }
            catch (Exception e)
            {
                CerrarConexion();
                throw e;
            }
        }

        public void eliminarInsumo(int idInsumo)
        {
            SqlCommand cmd = new SqlCommand("PR_INSUMOS_B", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_insumo", idInsumo);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

            finally
            {
                CerrarConexion();
            }

        }

        public void modificarInsumo(Insumo insumo)
        {
            SqlCommand cmd = new SqlCommand("PR_INSUMOS_M", getConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_insumo",insumo.IdInsumo);
            cmd.Parameters.AddWithValue("@n_insumo",insumo.NombreInsumo);
            cmd.Parameters.AddWithValue("@id_medida",insumo.Medida.IdMedida);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                CerrarConexion();
            }

        }
    }
}
