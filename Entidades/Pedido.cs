using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV2.Entidades
{
    public class Pedido
    {
        #region Miembros Privados

        private int idPedido;
        private DateTime? fechaPedido;
        private DateTime? fechaEntrega_Pactada;
        private DateTime? fechaEntrega_Real;
        private Franquicia franquicia;
        private EstadoPedido estadoPedido;
        private double montoTotal;
        private DetallesPedidoCollection lsDetallesPedido;

        #endregion

        #region Constructores

        //Constructor sin Parametros
        public Pedido()
        {
            this.IdPedido = 0;
            this.FechaPedido = null;
            this.FechaEntrega_Pactada = null;
            this.FechaEntrega_Real = null;
            this.Franquicia = null;
            this.EstadoPedido = null;
            this.MontoTotal = 0;
            this.LsDetallesPedido = null;
        }

        //Constructor con Parametros sin detalle
        public Pedido(int idPedido, DateTime fechaPedido, DateTime fechaEntrega_Pactada, DateTime fechaEntrega_Real, Franquicia franquicia, EstadoPedido estadoPedido, double montoTotal)
        {
            this.IdPedido = idPedido;
            this.FechaPedido = fechaPedido;
            this.FechaEntrega_Pactada = fechaEntrega_Pactada;
            this.FechaEntrega_Real = fechaEntrega_Real;
            this.Franquicia = franquicia;
            this.EstadoPedido = estadoPedido;
            this.MontoTotal = montoTotal;
            this.LsDetallesPedido = null;
        }

        //Constructor con Parametros
        public Pedido(int idPedido, DateTime fechaPedido, DateTime fechaEntrega_Pactada, DateTime fechaEntrega_Real, Franquicia franquicia, EstadoPedido estadoPedido, double montoTotal, DetallesPedidoCollection lsDetalles)
        {
            this.IdPedido = idPedido;
            this.FechaPedido = fechaPedido;
            this.FechaEntrega_Pactada = fechaEntrega_Pactada;
            this.FechaEntrega_Real = fechaEntrega_Real;
            this.Franquicia = franquicia;
            this.EstadoPedido = estadoPedido;
            this.MontoTotal = montoTotal;
            this.LsDetallesPedido = lsDetalles;
        }

        #endregion

        #region Properties

        public int IdPedido
        {
            get
            {
                return idPedido;
            }

            set
            {
                idPedido = value;
            }
        }

        public DateTime? FechaPedido
        {
            get
            {
                return fechaPedido;
            }

            set
            {
                fechaPedido = value;
            }
        }

        public DateTime? FechaEntrega_Pactada
        {
            get
            {
                return fechaEntrega_Pactada;
            }

            set
            {
                fechaEntrega_Pactada = value;
            }
        }

        public DateTime? FechaEntrega_Real
        {
            get
            {
                return fechaEntrega_Real;
            }

            set
            {
                fechaEntrega_Real = value;
            }
        }

        public Franquicia Franquicia
        {
            get
            {
                return franquicia;
            }

            set
            {
                franquicia = value;
            }
        }

        public EstadoPedido EstadoPedido
        {
            get
            {
                return estadoPedido;
            }

            set
            {
                estadoPedido= value;
            }
        }

        public double MontoTotal
        {
            get
            {
                return montoTotal;
            }

            set
            {
                montoTotal = value;
            }
        }

        public DetallesPedidoCollection LsDetallesPedido
        {
            get
            {
                return lsDetallesPedido;
            }

            set
            {
                lsDetallesPedido = value;
            }
        }

        #endregion

        #region Metodos
        #endregion
    }
}
