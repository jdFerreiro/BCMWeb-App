using System;
using System.Collections.Generic;
using System.Text;

namespace BCMWeb.Models
{
    public class IntSelectionModel : GenericModel
    {
        private int valor;

        public int Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

    }
}
