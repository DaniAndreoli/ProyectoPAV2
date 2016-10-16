using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV2.Entidades
{
    public class ElaboracionProducto
    {
        #region Miembros Privados

        private int idElaboracion;
        private EstadoElaboracion estado;
        private DateTime? fechaElaboracion;

        #endregion

        #region Constructores

        //Constructor sin Parametros
        public ElaboracionProducto()
        {
            this.IdElaboracion = 0;
            this.Estado = null;
            this.FechaElaboracion = null;
        }

        //Constructor sin Parametros
        public ElaboracionProducto(int idElaboracion, EstadoElaboracion estado, DateTime fechaElaboracion)
        {
            this.IdElaboracion = idElaboracion;
            this.Estado = estado;
            this.FechaElaboracion = fechaElaboracion;
        }

        #endregion

        #region Properties

        public int IdElaboracion
        {
            get
            {
                return idElaboracion;
            }

            set
            {
                idElaboracion = value;
            }
        }

        public EstadoElaboracion Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public DateTime? FechaElaboracion
        {
            get
            {
                return fechaElaboracion;
            }

            set
            {
                fechaElaboracion = value;
            }
        }

        #endregion

        #region Metodos
        #endregion
    }
}
