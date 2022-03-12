using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Galeria_WEB.Models.Clases
{
    public class Dispositivo
    {
        string nombre;
        string serial;
        string marca;
        string tipoDispositivo;
        string disponibilidad;
        string descripcion;

        public Dispositivo(string nombre, string serial, string marca, string tipoDispositivo, string disponibilidad, string descripcion)
        {
            this.Nombre = nombre;
            this.Serial = serial;
            this.Marca = marca;
            this.TipoDispositivo = tipoDispositivo;
            this.Disponibilidad = disponibilidad;
            this.Descripcion = descripcion;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Serial { get => serial; set => serial = value; }
        public string Marca { get => marca; set => marca = value; }
        public string TipoDispositivo { get => tipoDispositivo; set => tipoDispositivo = value; }
        public string Disponibilidad { get => disponibilidad; set => disponibilidad = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}