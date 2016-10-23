using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV2.Entidades
{
    public class Insumo
    {
        #region Miembros Privados

        private int idInsumo;
        private string nombreInsumo;
        private Medida medida;
        private int stock;

        #endregion

        #region Constructores

        //Constructor sin Parametros
        public Insumo()
        {
            this.IdInsumo = 0;
            this.NombreInsumo = string.Empty;
            this.Medida = null;
            this.Stock = 0;
        }

        //Constructor con Parametros para Insert
        public Insumo(string nombreInsumo, Medida medida)
        {
            this.NombreInsumo = nombreInsumo;
            this.Medida = medida;
            this.Stock = stock;
        }

        //Constructor con Parametros para insert de detalles producto
        public Insumo(int idInsumo, string nombreInsumo, Medida medida)
        {
            this.IdInsumo = idInsumo;
            this.NombreInsumo = nombreInsumo;
            this.Medida = medida;
            this.Stock = 0;
        }

        //Constructor con Parametros para select general
        public Insumo(int idInsumo, string nombreInsumo, Medida medida, int stock)
        {
            this.IdInsumo = idInsumo;
            this.NombreInsumo = nombreInsumo;
            this.Medida = medida;
            this.Stock = stock;
        }

        #endregion

        #region Properties

        public int IdInsumo
        {
            get
            {
                return idInsumo;
            }

            set
            {
                idInsumo = value;
            }
        }

        public string NombreInsumo
        {
            get
            {
                return nombreInsumo;
            }

            set
            {
                nombreInsumo = value;
            }
        }

        public Medida Medida
        {
            get
            {
                return medida;
            }

            set
            {
                medida = value;
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

        #endregion

        #region Metodos
        #endregion
    }
}
