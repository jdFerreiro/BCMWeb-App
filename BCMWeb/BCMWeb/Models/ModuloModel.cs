using System;
using System.Collections.Generic;
using System.Text;

namespace BCMWeb.Models
{
    public class ModuloModel : GenericModel
    {
        private long id;
        private long idPadre;
        private string nombre;
        private short idTipoElemento;
        private int idCodigoModulo;
        private bool negocios;
        private bool tecnologia;

        public long Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChange();
            }
        }
        public long IdPadre
        {
            get { return idPadre; }
            set
            {
                idPadre = value;
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
        public short IdTipoElemento
        {
            get { return idTipoElemento; }
            set
            {
                idTipoElemento = value;
                OnPropertyChange();
            }
        }
        public int IdCodigoModulo
        {
            get { return idCodigoModulo; }
            set
            {
                idCodigoModulo = value;
                OnPropertyChange();
            }
        }
        public bool Negocios
        {
            get { return negocios; }
            set
            {
                negocios = value;
                OnPropertyChange();
            }
        }
        public bool Tecnologia
        {
            get { return tecnologia; }
            set
            {
                tecnologia = value;
                OnPropertyChange();
            }
        }

    }
}
