using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV2.Entidades
{
    public class Producto
    {
        #region Miembros Privados

        private int idProducto;
        private string nombreProducto;
        private TipoProducto tipoProducto;
        private double precioUnitario;
        private int stock;
        private DetallesProductoCollection lsDetalles;

        #endregion

        #region Constructores

        //Constructor sin Parametros
        public Producto()
        {
            this.IdProducto = 0;
            this.NombreProducto = string.Empty;
            this.TipoProducto = null;
            this.PrecioUnitario = 0;
            this.Stock = 0;
            this.LsDetalles = new DetallesProductoCollection();
        }

        //Constructor con Parametros
        public Producto(int idProducto, string nombreProducto, TipoProducto tipoProducto, double precioUnitario, int stock)
        {
            this.IdProducto = idProducto;
            this.NombreProducto = nombreProducto;
            this.TipoProducto = tipoProducto;
            this.PrecioUnitario = precioUnitario;
            this.Stock = stock;
            this.LsDetalles = new DetallesProductoCollection();
        }

        #endregion

        #region Properties

        public int IdProducto
        {
            get
            {
                return idProducto;
            }

            set
            {
                idProducto = value;
            }
        }

        public string NombreProducto
        {
            get
            {
                return nombreProducto;
            }

            set
            {
                nombreProducto = value;
            }
        }

        public TipoProducto TipoProducto
        {
            get
            {
                return tipoProducto;
            }

            set
            {
                tipoProducto = value;
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

        public int Stock
        {
            get
            {
                return stock;
            }

            set
            {
                stock = value;
            }
        }

        public DetallesProductoCollection LsDetalles
        {
            get
            {
                return lsDetalles;
            }

            set
            {
                lsDetalles = value;
            }
        }

        #endregion

        #region Metodos
        #endregion
    }
}
