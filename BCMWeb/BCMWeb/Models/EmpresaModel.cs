using System;
using System.Collections.Generic;
using System.Text;

namespace BCMWeb.Models
{
    public class EmpresaModel : GenericModel
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

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChange();
            }
        }

        private string imageUrl;

        public string ImageUrl
        {
            get { return imageUrl; }
            set
            {
                imageUrl = value;
                OnPropertyChange();
            }
        }

        private long idNivelUsuario;

        public long IdNivelUsuario
        {
            get { return idNivelUsuario; }
            set
            {
                idNivelUsuario = value;
                OnPropertyChange();
            }
        }

    }
}
