using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV2.Entidades
{
    public class DetalleElaboracionProducto
    {
        #region Miembros Privados

        private Producto producto;
        private int cantidadElaborada;
        private DateTime? fechaVto;

        #endregion

        #region Constructores

        //Constructores sin Parametros
        public DetalleElaboracionProducto()
        {
            this.Producto = null;
            this.CantidadElaborada = 0;
            this.FechaVto = null;
        }

        //Constructores con Parametros
        public DetalleElaboracionProducto(Producto producto, int cantidadElaborada, DateTime fechaVto)
        {
            this.Producto = producto;
            this.CantidadElaborada = cantidadElaborada;
            this.FechaVto = fechaVto;
        }

        #endregion

        #region Properties

        public Producto Producto
        {
            get
            {
                return producto;
            }

            set
            {
                producto = value;
            }
        }

        public int CantidadElaborada
        {
            get
            {
                return cantidadElaborada;
            }

            set
            {
                cantidadElaborada = value;
            }
        }

        public DateTime? FechaVto
        {
            get
            {
                return fechaVto;
            }

            set
            {
                fechaVto = value;
            }
        }

        #endregion

        #region Metodos
        #endregion
    }
}
