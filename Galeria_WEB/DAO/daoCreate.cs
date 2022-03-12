using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using Galeria_WEB.Models.Clases;

namespace Galeria_WEB.DAO
{
    public class daoCreate : BaseDatos
    {

        public int InsertUser(Usuario user)
        {
            this.OpenConnection();
            int sw = 0;
            daoRead dbRead = new daoRead();

            if (dbRead.ValidarExistencia(user))
            {
                try
                {
                    //ingresar datos en la tabla persona
                    string sql = "INSERT INTO `usuario`(`IDusuario`, `Nombre`, `Username`, `Contraseña`, `Cedula`, `Direccion`," +
                        " `Telefono`, `Nrocarnet`, `TipoUsuario`, `IdDependencia`, `IdDepartamento`)" +
                        " VALUES (NULL,'" + user.Nombre + "','" + user.Username + "','" + user.Contraseña + "','" + user.Cedula + "','" + user.Direccion + "','" + user.Telefono + "','" +
                        user.Carnet + "','" + user.TipoUsuario + "','" + user.Dependencia + "','" + user.Departamento + "')";
                    MySqlCommand command = new MySqlCommand(sql);
                    command.Connection = galeriaC;
                    command.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    sw = 1;
                }
                // String Resultado = ""; // Variable aux donde guardaremos la consulta
                //Si a este campo le ponemos el valor que deberia ir en PersonaID(persona) y
                /*                       //el de PersonaID(Usuario), logra hacer la consulta 2
                if (sw == 0)
                {
                    try
                    {
                        //Pasar el ultimo valor de PersonaID a UsuarioID
                        String query = "SELECT MAX(`PersonaID`) AS'RESULT' FROM `persona`;";

                        MySqlCommand command3 = new MySqlCommand(query);
                        command3.Connection = galeriaC;
                        MySqlDataReader reader = command3.ExecuteReader();
                        var dataTable = new DataTable();
                        dataTable.Load(reader);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            Resultado = Resultado + (row["RESULT"]);
                        }
                    }
                    catch (MySqlException e)
                    {
                        sw = 1;
                    }
                }*/
            }
            else
            {
                sw = 2;
            }
            return sw;
        }

        public string CrearTransaccion(string userid, string dispid)
        {
            this.OpenConnection();
            string error = "";
            try
            {
                string sql = "INSERT INTO `transacciones`(`IdTransaccion`, `TipoTransaccion`, `Fecha`, `IdDispositivo`, `IdUsuario`) " +
                    "VALUES (NULL,'Prestamo',('19-04-10'),'" + dispid + "','" + userid + "')";
                MySqlCommand command = new MySqlCommand(sql);
                command.Connection = galeriaC;
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                error += e;
            }
            this.CloseConnection();
            return error;
        }

        public string AgregarDispositivo(Dispositivo disp)
        {
            this.OpenConnection();
            string result = "";
            try
            {
            string sql = "INSERT INTO `dispositivo`(`IdDispositivo`, `Nombre`, `Serial`, `Marca`, `TipoDispositivo`, `Disponibilidad`, `Descripcion`)" +
                " VALUES (NULL,'"+disp.Nombre+"','"+disp.Serial+"','"+disp.Marca+"','"+disp.TipoDispositivo+"','"+disp.Disponibilidad+"','"+disp.Descripcion+"')"; MySqlCommand command = new MySqlCommand(sql);
                command.Connection = galeriaC;
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                result += e;
            }
            return result;
        }
    }
}