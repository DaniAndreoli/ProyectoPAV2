using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV2.Entidades
{
    public class Domicilio
    {
        #region Miembros Privados

        private int idDomicilio;
        private Localidad localidad;
        private int numero;
        private int? piso;
        private string dpto;
        private string barrio;
        private string calle;

        #endregion

        #region Constructores
        
        //Constructor sin Parametros
        public Domicilio()
        {
            this.IdDomicilio = 0;
            this.Localidad = null;
            this.Numero = 0;
            this.Piso = null;
            this.Dpto = string.Empty;
            this.Barrio = string.Empty;
            this.Calle = string.Empty;
        }

        //Constructor con Parametros
        public Domicilio(int idDomicilio, Localidad localidad, int numero, int? piso, string dpto, string barrio, string calle)
        {
            this.IdDomicilio = idDomicilio;
            this.Localidad = localidad;
            this.Numero = numero;
            this.Piso = piso;
            this.Dpto = dpto;
            this.Barrio = barrio;
            this.Calle = calle;
        }

        #endregion

        #region Properties

        public int IdDomicilio
        {
            get
            {
                return idDomicilio;
            }

            set
            {
                idDomicilio = value;
            }
        }

        public Localidad Localidad
        {
            get
            {
                return localidad;
            }

            set
            {
                localidad = value;
            }
        }

        public int Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }

        public int? Piso
        {
            get
            {
                return piso;
            }

            set
            {
                piso = value;
            }
        }

        public string Dpto
        {
            get
            {
                return dpto;
            }

            set
            {
                dpto = value;
            }
        }

        public string Barrio
        {
            get
            {
                return barrio;
            }

            set
            {
                barrio = value;
            }
        }

        public string Calle
        {
            get
            {
                return calle;
            }

            set
            {
                calle = value;
            }
        }

        #endregion

        #region Metodos
        #endregion
    }
}
