using System;
using System.Collections.Generic;
using System.Text;

namespace BCMWeb.Models
{
    public class UsuarioModel : GenericModel
    {
        private long id;
        private string nombre;
        private string email;
        private List<EmpresaModel> empresas;
        private List<ModuloModel> modulos;
        private List<IntSelectionModel> tiposDocumento;
        private List<DocumentoModel> documentos;
        private EmpresaModel empresaSelected;
        private ModuloModel moduloSelected;
        private IntSelectionModel tipoDocumentoSelected;
        private long idDispositivo;

        public long Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChange();
            }
        }
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChange();
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChange();
            }
        }
        public List<EmpresaModel> Empresas
        {
            get { return empresas; }
            set
            {
                empresas = value;
                OnPropertyChange();
            }
        }
        public List<ModuloModel> Modulos
        {
            get { return modulos; }
            set
            {
                modulos = value;
                OnPropertyChange();
            }
        }
        public List<IntSelectionModel> TiposDocumento
        {
            get { return tiposDocumento; }
            set
            {
                tiposDocumento = value;
                OnPropertyChange();
            }
        }
        public List<DocumentoModel> Documentos
        {
            get { return documentos; }
            set
            {
                documentos = value;
                OnPropertyChange();
            }
        }
        public EmpresaModel EmpresaSelected
        {
            get { return empresaSelected; }
            set
            {
                empresaSelected = value;
                OnPropertyChange();
            }
        }
        public ModuloModel ModuloSelected
        {
            get { return moduloSelected; }
            set
            {
                moduloSelected = value;
                OnPropertyChange();
            }
        }
        public IntSelectionModel TipoDocumentoSelected
        {
            get { return tipoDocumentoSelected; }
            set
            {
                tipoDocumentoSelected = value;
                OnPropertyChange();
            }
        }
        public long IdDispositivo
        {
            get { return idDispositivo; }
            set { idDispositivo = value; }
        }


        public UsuarioModel()
        {
            this.id = 0;
            this.nombre = string.Empty;
            this.email = string.Empty;
            this.empresas = new List<EmpresaModel>();
            this.modulos = new List<ModuloModel>();
            this.tiposDocumento = new List<IntSelectionModel>();
            this.documentos = new List<DocumentoModel>();
            this.tiposDocumento = new List<IntSelectionModel>
            {
                    new IntSelectionModel
                    {
                        Descripcion = "Negocios",
                        Valor = 1
                    },
                    new IntSelectionModel
                    {
                        Descripcion = "Tecnología",
                        Valor = 2
                    }
            };
            this.idDispositivo = 0;
        }
    }
}
