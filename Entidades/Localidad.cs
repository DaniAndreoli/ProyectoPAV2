using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV2.Entidades
{
    public class Localidad
    {
        #region Miembros Privados

        private int idLocalidad;
        private int codigoPostal;
        private string nombreLocalidad;

        #endregion

        #region Constructores

        //Constructor sin Parametros
        public Localidad()
        {
            this.IdLocalidad = 0;
            this.codigoPostal = 0;
            this.nombreLocalidad = string.Empty;
        }

        //Constructor sin Parametros
        public Localidad(int idLocalidad, int codigoPostal, string nombreLocalidad)
        {
            this.IdLocalidad = idLocalidad;
            this.codigoPostal = codigoPostal;
            this.nombreLocalidad = nombreLocalidad;
        }

        #endregion

        #region Properties

        public int IdLocalidad
        {
            get
            {
                return idLocalidad;
            }

            set
            {
                idLocalidad = value;
            }
        }

        public int CodigoPostal
        {
            get
            {
                return codigoPostal;
            }

            set
            {
                codigoPostal = value;
            }
        }

        public String NombreLocalidad
        {
            get
            {
                return nombreLocalidad;
            }

            set
            {
                nombreLocalidad = value;
            }
        }


        #endregion

        #region Metodos
        #endregion
    }
}
