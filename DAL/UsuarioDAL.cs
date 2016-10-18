using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

using ProyectoPAV2.Entidades;

namespace ProyectoPAV2.DAL
{
    class UsuarioDAL : BaseDAL
    {

        public Usuario getUsuarioPorID(int idUsuario)
        {
            SqlCommand cmd = new SqlCommand("PACK_USUARIOS.PR_USUARIO_POR_ID", getConexion());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
            SqlDataReader dr = cmd.ExecuteReader();

            Usuario objUsuario = null;

            if (dr.Read())
            {
                objUsuario = new Usuario(
                    dr.GetInt16(0),
                    dr.GetString(1));
            }

            cmd.Connection.Close();

            return objUsuario;
        }
    }
}
