using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV2.Entidades
{
    public class EstadoPedido
    {
        #region Miembros Privados

        private int idEstado;
        private string nombreEstado;

        #endregion

        #region Constructores

        //Constructor sin Parametros
        public EstadoPedido()
        {
            this.IdEstado = 0;
            this.NombreEstado = string.Empty;
        }

        //Constructor con Parametros
        public EstadoPedido(int idEstado, string nombreEstado)
        {
            this.IdEstado = idEstado;
            this.NombreEstado = nombreEstado;
        }

        #endregion

        #region Properties

        public int IdEstado
        {
            get
            {
                return idEstado;
            }

            set
            {
                idEstado = value;
            }
        }

        public string NombreEstado
        {
            get
            {
                return nombreEstado;
            }

            set
            {
                nombreEstado = value;
            }
        }

        #endregion

        #region Metodos
        #endregion
    }
}
