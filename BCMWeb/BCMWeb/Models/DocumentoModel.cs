using System;
using System.Collections.Generic;
using System.Text;

namespace BCMWeb.Models
{
    public class DocumentoModel : GenericModel
    {
        private long id;

        public long Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChange();
            }
        }

        private string codigo;

        public string Codigo
        {
            get { return codigo; }
            set
            {
                codigo = value;
                OnPropertyChange();
            }
        }

        private long idTipoDocumento;

        public long IdTipoDocumento
        {
            get { return idTipoDocumento; }
            set
            {
                idTipoDocumento = value;
                OnPropertyChange();
            }
        }

        private bool negocios;

        public bool Negocios
        {
            get { return negocios; }
            set
            {
                negocios = value;
                OnPropertyChange();
            }
        }

        private long nroDocumento;

        public long NroDocumento
        {
            get { return nroDocumento; }
            set
            {
                nroDocumento = value;
                OnPropertyChange();
            }
        }

        private int nroVersion;

        public int NroVersion
        {
            get { return nroVersion; }
            set
            {
                nroVersion = value;
                OnPropertyChange();
            }
        }

        private string pdfRoute;

        public string PdfRoute
        {
            get { return pdfRoute; }
            set
            {
                pdfRoute = value;
                OnPropertyChange();
            }
        }

        private string tipoDocumento;

        public string TipoDocumento
        {
            get { return tipoDocumento; }
            set
            {
                tipoDocumento = value;
                OnPropertyChange();
            }
        }

        private int versionOriginal;

        public int VersionOriginal
        {
            get { return versionOriginal; }
            set
            {
                versionOriginal = value;
                OnPropertyChange();
            }
        }

        private string nombreDocumento;

        public string NombreDocumento
        {
            get { return nombreDocumento; }
            set
            {
                nombreDocumento = value;
                OnPropertyChange();
            }
        }


    }
    public class DocumentosPendientesModel
    {
        private List<DocumentoPendienteModel> documentos;

        public List<DocumentoPendienteModel> Documentos
        {
            get { return documentos; }
            set { documentos = value; }
        }

    }
    public class DocumentoPendienteModel
    {
        private long idDocumento;
        public long IdDocumento
        {
            get { return idDocumento; }
            set { idDocumento = value; }
        }

        private long idEmpresa;
        public long IdEmpresa
        {
            get { return idEmpresa; }
            set { idEmpresa = value; }
        }

        private string nombreDocumento;
        public string NombreDocumento
        {
            get { return nombreDocumento; }
            set { nombreDocumento = value; }
        }

        private string rutaDocumento;
        public string RutaDocumento
        {
            get { return rutaDocumento; }
            set { rutaDocumento = value; }
        }
    }
}
