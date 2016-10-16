using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV2.Entidades
{
    public class Medida
    {
        #region Miembros Privados

        private int idMedida;
        private string nombreMedida;

        #endregion

        #region Constructores
        
        //Constructor sin Parametros
        public Medida()
        {
            this.IdMedida = idMedida;
            this.NombreMedida = nombreMedida;
        }

        //Constructor con Parametros
        public Medida(int idMedida, string nombreMedida)
        {
            this.IdMedida = idMedida;
            this.NombreMedida = nombreMedida;
        }

        #endregion

        #region Properties

        public int IdMedida
        {
            get
            {
                return idMedida;
            }

            set
            {
                idMedida = value;
            }
        }

        public string NombreMedida
        {
            get
            {
                return nombreMedida;
            }

            set
            {
                nombreMedida = value;
            }
        }

        #endregion

        #region Metodos
        #endregion
    }
}
