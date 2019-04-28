using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TEST.Models;

namespace TEST.Repositories
{
    public class PasajeroRepository
    {

        public static bool addPasajeroToDB(Pasajero pasajero)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            var query = "INSERT INTO Pasajero (Pasaporte, Nombre, Estado, Reservacion, Tiquete, CantidadMaletas, NTarjeta) " +
                        "VALUES ('@Pasaporte', '@Nombre', '@Estado', '@Reservacion', '@Tiquete', '@CantidadMaletas', '@NTarjeta')";


            query = query.Replace("@Pasaporte", pasajero.Pasaporte.ToString())
                    .Replace("@Nombre", pasajero.Nombre)
                    .Replace("@Estado", pasajero.Estado)
                    .Replace("@Reservacion", pasajero.Reservacion.ToString())
                    .Replace("@Tiquete", pasajero.Tiquete.ToString())
                    .Replace("@CantidadMaletas", pasajero.CantidadMaletas.ToString())
                    .Replace("@NTarjeta", pasajero.NTarjeta.ToString());

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static Pasajero getPasajeroFromDB(int pasaporte)
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Pasajero WHERE Pasaporte='@Pasaporte'";

            query = query.Replace("@Pasaporte", pasaporte.ToString());

            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            Pasajero pasajero = null;
            while (reader.Read())
            {

                pasajero = new Pasajero();
                pasajero.Pasaporte = Convert.ToInt32(reader.GetValue(0));
                pasajero.Nombre = reader.GetValue(1).ToString();
                pasajero.Estado = reader.GetValue(2).ToString();
                pasajero.Reservacion = Convert.ToInt32(reader.GetValue(5));
                pasajero.Tiquete = Convert.ToInt32(reader.GetValue(4));
                pasajero.CantidadMaletas = Convert.ToInt32(reader.GetValue(5));
                pasajero.NTarjeta = Convert.ToInt32(reader.GetValue(6));

            }
            connection.Close();
            return pasajero;
        }




        public static List<Pasajero> getAllPasajerosFromDB()
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Pasajero ";



            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            List<Pasajero> listaPasajeros = new List<Pasajero>();

            while (reader.Read())
            {
                Pasajero pasajero = null;

                pasajero = new Pasajero();
                pasajero.Pasaporte = Convert.ToInt32(reader.GetValue(0));
                pasajero.Nombre = reader.GetValue(1).ToString();
                pasajero.Estado = reader.GetValue(2).ToString();
                pasajero.Reservacion = Convert.ToInt32(reader.GetValue(5));
                pasajero.Tiquete = Convert.ToInt32(reader.GetValue(4));
                pasajero.CantidadMaletas = Convert.ToInt32(reader.GetValue(5));
                pasajero.NTarjeta = Convert.ToInt32(reader.GetValue(6));

                listaPasajeros.Add(pasajero);
            }
            connection.Close();
            return listaPasajeros;
        }



        public static bool deletePasajeroFromDB(int pasaporte)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";


            var query = "DELETE FROM Pasajero WHERE Pasaporte='@Pasaporte'";

            query = query.Replace("@Pasaporte", pasaporte.ToString());


            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}