using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Galeria_WEB.Models.Clases
{
    public class Usuario
    {
        string nombre;
        string username;
        int cedula;
        string direccion;
        string telefono;
        int carnet;
        string tipoUsuario;
        string contraseña;
        string departamento;
        string dependencia;

        public Usuario(string nombre, string username, int cedula, string direccion, string telefono, int carnet, string tipoUsuario, string contraseña, string departamento, string dependencia)
        {
            this.Nombre = nombre;
            this.Username = username;
            this.Cedula = cedula;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Carnet = carnet;
            this.TipoUsuario = tipoUsuario;
            this.Contraseña = contraseña;
            this.Departamento = departamento;
            this.Dependencia = dependencia;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Username { get => username; set => username = value; }
        public int Cedula { get => cedula; set => cedula = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public int Carnet { get => carnet; set => carnet = value; }
        public string TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Departamento { get => departamento; set => departamento = value; }
        public string Dependencia { get => dependencia; set => dependencia = value; }

        public Usuario()
        {
        }
    }
}