using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV2.Entidades
{
    public class DetalleCompraProveedor
    {
        #region Miembros Privados

        private Insumo insumo;
        private int cantidad;
        private double precioUnitario;

        #endregion

        #region Constructores

        //Constructor con Parametros
        public DetalleCompraProveedor()
        {
            this.Insumo = null;
            this.Cantidad = 0;
            this.PrecioUnitario = 0;
        }

        //Constructor con Parametros
        public DetalleCompraProveedor(Insumo insumo, int cantidad, double precioUnitario)
        {
            this.Insumo = insumo;
            this.Cantidad = cantidad;
            this.PrecioUnitario = precioUnitario;
        }

        #endregion

        #region Properties

        public Insumo Insumo
        {
            get
            {
                return insumo;
            }

            set
            {
                insumo = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }

        public double PrecioUnitario
        {
            get
            {
                return precioUnitario;
            }

            set
            {
                precioUnitario = value;
            }
        }

        #endregion

        #region Metodos
        #endregion
    }
}
