using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TEST.Models;

namespace TEST.Repositories
{
    public class AeropuertoRepository
    {
        public static bool addAeropuertoToDB(Aeropuerto aeropuerto)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            var query = "INSERT INTO Aeropuerto (Nombre) VALUES ('@Nombre')";

            query = query.Replace("@Nombre", aeropuerto.Nombre);



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

        public static Aeropuerto getAeropuertoFromDB(string nombre)
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Aeropuerto WHERE Nombre='@Nombre'";

            query = query.Replace("@Nombre", nombre);

            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            Aeropuerto aeropuerto = null;
            while (reader.Read())
            {
                aeropuerto = new Aeropuerto();
                aeropuerto.Nombre = reader.GetValue(0).ToString();

            }
            connection.Close();
            return aeropuerto;
        }




        public static List<Aeropuerto> getAllAeropuertosFromDB()
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Aeropuerto ";



            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            List<Aeropuerto> listaAeropuertos = new List<Aeropuerto>();

            while (reader.Read())
            {
                Aeropuerto aeropuerto = null;
                aeropuerto = new Aeropuerto();
                aeropuerto.Nombre = reader.GetValue(0).ToString();
                
                listaAeropuertos.Add(aeropuerto);
            }
            connection.Close();
            return listaAeropuertos;
        }



        public static bool deleteAeropuertoFromDB(string nombre)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";


            var query = "DELETE FROM Aeropuerto WHERE Nombre='@Nombre'";

            query = query.Replace("@Nombre", nombre);


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