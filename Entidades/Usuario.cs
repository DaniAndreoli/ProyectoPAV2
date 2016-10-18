using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV2.Entidades
{
    public class Usuario
    {
        #region Miembros Privados

        private int idUsuario;
        private string contraseña;

        #endregion

        #region Constructores

        //Constructor sin Parametros
        public Usuario()
        {
            this.IdUsuario = 0;
            this.Contraseña = string.Empty;
        }

        //Constructor con Parametros
        public Usuario(int idUsuario, string contraseña)
        {
            this.IdUsuario = idUsuario;
            this.Contraseña = contraseña;
        }

        #endregion

        #region Properties

        public int IdUsuario
        {
            get
            {
                return idUsuario;
            }

            set
            {
                idUsuario = value;
            }
        }

        public string Contraseña
        {
            get
            {
                return contraseña;
            }

            set
            {
                contraseña = value;
            }
        }

        #endregion

        #region Metodos
        #endregion
    }
}
