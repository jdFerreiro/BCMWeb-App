using System;
using System.Collections.Generic;
using System.Text;

namespace BCMWeb.Models
{
    public class AuditoriaModel : GenericModel
    {
        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private long idEmpresa;
        public long IdEmpresa
        {
            get { return idEmpresa; }
            set { idEmpresa = value; }
        }

        private long idDocumento;
        public long IdDocumento
        {
            get { return idDocumento; }
            set { idDocumento = value; }
        }

        private long idTipoDocumento;
        public long IdTipoDocumento
        {
            get { return idTipoDocumento; }
            set { idTipoDocumento = value; }
        }

        private string ipAddress;
        public string IpAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }

        private string mensaje;
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        private string accion;
        public string Accion
        {
            get { return accion; }
            set { accion = value; }
        }

        private bool negocios;
        public bool Negocios
        {
            get { return negocios; }
            set { negocios = value; }
        }
    }
}
