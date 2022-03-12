using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Galeria_WEB.Models.Clases;
using System.Data;

namespace Galeria_WEB.DAO
{
    public class daoRead : BaseDatos
    {

        public List<Dispositivo> TraerDispositivos()  //    Muestra los usuarios registrados en la db
        {
            this.OpenConnection();
            string nombre          ="";
            string serial          ="";
            string marca           ="";
            string tipoDispositivo ="";
            string disponibilidad  ="";
            string descripcion = "";
            List<Dispositivo> UserList = new List<Dispositivo>();
            try
            {
                string sql = "SELECT * FROM `dispositivo` ";
                MySqlCommand comando = new MySqlCommand(sql);
                comando.Connection = galeriaC;
                MySqlDataReader reader = comando.ExecuteReader();
                var tb = new DataTable();
                tb.Load(reader);

                foreach (DataRow row in tb.Rows)
                {
                    Dispositivo disp = new Dispositivo(nombre + row["Nombre"], serial + row["Serial"], marca + row["Marca"], tipoDispositivo + row["TipoDispositivo"], disponibilidad + row["Disponibilidad"],descripcion + row["Descripcion"]);
                    UserList.Add(disp);
                }
            }
            catch (MySqlException e)
            {
            }

            this.CloseConnection();
            return UserList;
        }

        public string ValidarUserPass(Usuario user) // Valida el usuario y la contraseña
        {
            this.OpenConnection();
            string result = "";
            try
            {
                string sql = "SELECT `TipoUsuario` FROM `usuario` WHERE (Username ='" + user.Username + "')&&(contraseña = '" + user.Contraseña + "')";
                MySqlCommand comando = new MySqlCommand(sql);
                comando.Connection = galeriaC;
                MySqlDataReader reader = comando.ExecuteReader();
                var tb = new DataTable();
                tb.Load(reader);

                foreach (DataRow row in tb.Rows)
                {
                    result += row["TipoUsuario"];

                }
            }
            catch (MySqlException e)
            {
                result = "Ocurrio el siguiente error: " + e;
            }

            this.CloseConnection();
            return result;
        }

        public bool ValidarExistencia(Usuario user) //Valida que no me ingresen un nombre de usuario que ya exista
        {
            this.OpenConnection();
            string result = "";
            try
            {
                string sql = "SELECT `Cedula` FROM `usuario` WHERE (Cedula ='" + user.Cedula + "')";
                MySqlCommand comando = new MySqlCommand(sql);
                comando.Connection = galeriaC;
                MySqlDataReader reader = comando.ExecuteReader();
                var tb = new DataTable();
                tb.Load(reader);

                foreach (DataRow row in tb.Rows)
                {
                    result += row["Cedula"];
                }
            }
            catch (MySqlException e)
            {
                result = "Ocurrio el siguiente error: " + e;
            }
            try
            {
                string sql = "SELECT `Username` FROM `usuario` WHERE (Username ='" + user.Username + "')";
                MySqlCommand comando = new MySqlCommand(sql);
                comando.Connection = galeriaC;
                MySqlDataReader reader = comando.ExecuteReader();
                var tb = new DataTable();
                tb.Load(reader);

                foreach (DataRow row in tb.Rows)
                {
                    result += row["Username"];
                }
            }
            catch (MySqlException e)
            {
                result = "Ocurrio el siguiente error: " + e;
            }
            this.CloseConnection();
            if (result.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string TraerPersonaID(string user)
        {
            this.OpenConnection();
            string result = "";
            try
            {
                string sql = "SELECT `IDusuario` FROM `usuario` WHERE Username ='" + user + "'";
                MySqlCommand comando = new MySqlCommand(sql);
                comando.Connection = galeriaC;
                MySqlDataReader reader = comando.ExecuteReader();
                var tb = new DataTable();
                tb.Load(reader);

                foreach (DataRow row in tb.Rows)
                {
                    result += row["IDUsuario"];
                }
            }
            catch (MySqlException e)
            {
                result = "Ocurrio el siguiente error: " + e;
            }

            this.CloseConnection();
            return result;
        }

        public string TraerDispositivoID(string serial)
        {
            this.OpenConnection();
            string result = "";
            try
            {
                string sql = "SELECT `IdDispositivo` FROM `dispositivo` WHERE Serial ='" + serial + "'";
                MySqlCommand comando = new MySqlCommand(sql);
                comando.Connection = galeriaC;
                MySqlDataReader reader = comando.ExecuteReader();
                var tb = new DataTable();
                tb.Load(reader);

                foreach (DataRow row in tb.Rows)
                {
                    result += row["IdDispositivo"];
                }
            }
            catch (MySqlException e)
            {
                result = "Ocurrio el siguiente error: " + e;
            }

            this.CloseConnection();
            return result;
        }

    }
}