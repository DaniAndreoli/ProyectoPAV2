using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV2.Entidades
{
    public class SolicitudFranquicia
    {
        #region Miembros Privados

        private int idSolicitud;
        private Cliente cliente;
        private EstadoSolicitud estadoSolicitud;
        private DateTime? fechaSolicitud;
        private DateTime? fechaAprobacion;

        #endregion

        #region Constructores

        //Constructor sin Parametros
        public SolicitudFranquicia()
        {
            this.IdSolicitud = 0;
            this.Cliente = null;
            this.EstadoSolicitud = null;
            this.FechaSolicitud = null;
            this.FechaAprobacion = null;
        }

        //Constructor con Parametros
        public SolicitudFranquicia(int idSolicitud, Cliente cliente, EstadoSolicitud estadoSolicitud, DateTime? fechaSolicitud, DateTime? fechaAprobacion)
        {
            this.IdSolicitud = idSolicitud;
            this.Cliente = cliente;
            this.EstadoSolicitud = estadoSolicitud;
            this.FechaSolicitud = fechaSolicitud;
            this.FechaAprobacion = fechaAprobacion;
        }

        #endregion

        #region Properties

        public int IdSolicitud
        {
            get
            {
                return idSolicitud;
            }

            set
            {
                idSolicitud = value;
            }
        }

        public Cliente Cliente
        {
            get
            {
                return cliente;
            }

            set
            {
                cliente = value;
            }
        }

        public EstadoSolicitud EstadoSolicitud
        {
            get
            {
                return estadoSolicitud;
            }

            set
            {
                estadoSolicitud = value;
            }
        }

        public DateTime? FechaSolicitud
        {
            get
            {
                return fechaSolicitud;
            }

            set
            {
                fechaSolicitud = value;
            }
        }

        public DateTime? FechaAprobacion
        {
            get
            {
                return fechaAprobacion;
            }

            set
            {
                fechaAprobacion = value;
            }
        }

        #endregion

        #region Metodos
        #endregion
    }
}
