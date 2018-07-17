using System;
using System.Collections.Generic;
using System.Text;

namespace BCMWeb.Models
{
    public class DispositivoModel : GenericModel
    {
        private long _id;
        private DateTime _fechaRegistro;
        private string _idUnico;
        private string _fabricante;
        private string _modelo;
        private string _plataforma;
        private string _version;
        private string _nombre;
        private string _tipo;

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public DateTime FechaRegistro
        {
            get { return _fechaRegistro; }
            set { _fechaRegistro = value; }
        }
        public string IdUnicoDispositivo
        {
            get { return _idUnico; }
            set { _idUnico = value; }
        }
        public string Fabricante
        {
            get { return _fabricante; }
            set { _fabricante = value; }
        }
        public string Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }
        public string Plataforma
        {
            get { return _plataforma; }
            set { _plataforma = value; }
        }
        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
    }
    public class ConexionDispositivoModel : GenericModel
    {
        private long idEmpresa;
        private long idDispositivo;
        private DateTime fechaConexion;
        private string direccionIP;

        public long IdEmpresa
        {
            get { return idEmpresa; }
            set { idEmpresa = value; }
        }
        public long IdDispositivo
        {
            get { return idDispositivo; }
            set { idDispositivo = value; }
        }
        public DateTime FechaConexion
        {
            get { return fechaConexion; }
            set { fechaConexion = value; }
        }
        public string DireccionIP
        {
            get { return direccionIP; }
            set { direccionIP = value; }
        }

    }
}
