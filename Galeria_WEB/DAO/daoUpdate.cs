using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Galeria_WEB.Models.Clases;
using System.Data;

namespace Galeria_WEB.DAO
{
    public class daoUpdate : BaseDatos
    {
        public void ActualizarDisponibilidad(string serial)
        {
            this.OpenConnection();
            try
            {
                string sql = "UPDATE `dispositivo`d SET `Disponibilidad`= 'No' WHERE d.`Serial`='"+serial+"'";
                MySqlCommand command = new MySqlCommand(sql);
                command.Connection = galeriaC;
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
            }
            this.CloseConnection();
        }
    }
}