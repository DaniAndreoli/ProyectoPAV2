using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPAV2.Entidades
{
    public class TipoDocumento
    {
        #region Miembros Privados

        private int idTipoDocumento;
        private string nombreTipoDocumento;

        #endregion

        #region Constructores

        //Constructor sin Parametros
        public TipoDocumento()
        {
            this.IdTipoDocumento = 0;
            this.NombreTipoDocumento = string.Empty;
        }

        //Constructor con Parametros
        public TipoDocumento(int idTipoDocumento, string nombreTipoDocumento)
        {
            this.IdTipoDocumento = idTipoDocumento;
            this.NombreTipoDocumento = nombreTipoDocumento;
        }

        #endregion

        #region Properties

        public int IdTipoDocumento
        {
            get
            {
                return idTipoDocumento;
            }

            set
            {
                idTipoDocumento = value;
            }
        }

        public string NombreTipoDocumento
        {
            get
            {
                return nombreTipoDocumento;
            }

            set
            {
                nombreTipoDocumento = value;
            }
        }

        #endregion

        #region Metodos

        

        #endregion
    }
}
