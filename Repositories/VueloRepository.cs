using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TEST.Models;

namespace TEST.Repositories
{
    public class VueloRepository
    {

        public static bool addVueloToDB(Vuelo vuelo)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            var query = "INSERT INTO Vuelo (Pasajeros, CantMaletas, Ruta, Fecha, Destino, PesoTotal) " +
                                    "VALUES ('@Pasajeros', @CantMaletas, '@Ruta', @Fecha, '@Destino', @PesoTotal)";

            query = query.Replace("@Pasajeros", vuelo.Pasajeros)
                    .Replace("@CantMaletas", vuelo.CantMaletas.ToString())
                    .Replace("@Ruta", vuelo.Ruta.ToString())
                    .Replace("@Fecha", vuelo.Fecha.ToString())
                    .Replace("@Destino", vuelo.Destino)
                    .Replace("@PesoTotal", vuelo.PesoTotal.ToString());
                    
        


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

        public static Vuelo getVueloFromDB(string ruta)
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Vuelo WHERE Ruta='@Ruta'";

            query = query.Replace("@Ruta", ruta);

            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            Vuelo vuelo = null;
            while (reader.Read())
            {
                vuelo = new Vuelo();
                vuelo.Pasajeros = reader.GetValue(0).ToString();
                vuelo.CantMaletas = Convert.ToInt32(reader.GetValue(1));
                vuelo.Ruta = Convert.ToInt32(reader.GetValue(2));
                vuelo.Fecha = Convert.ToInt32(reader.GetValue(3));
                vuelo.Destino = reader.GetValue(4).ToString();
                vuelo.PesoTotal = Convert.ToInt32(reader.GetValue(5));
                
            }
            connection.Close();
            return vuelo;
        }




        public static List<Vuelo> getAllVuelosFromDB()
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Vuelo ";



            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            List<Vuelo> listaVuelos = new List<Vuelo>();

            while (reader.Read())
            {
                Vuelo vuelo = null;
                vuelo = new Vuelo();
                vuelo.Pasajeros = reader.GetValue(0).ToString();
                vuelo.CantMaletas = Convert.ToInt32(reader.GetValue(1));
                vuelo.Ruta = Convert.ToInt32(reader.GetValue(2));
                vuelo.Fecha = Convert.ToInt32(reader.GetValue(3));
                vuelo.Destino = reader.GetValue(4).ToString();
                vuelo.PesoTotal = Convert.ToInt32(reader.GetValue(5));
                listaVuelos.Add(vuelo);
            }
            connection.Close();
            return listaVuelos;
        }



        public static bool deleteVueloFromDB(string ruta)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";


            var query = "DELETE  FROM Vuelo WHERE Ruta='@Ruta'";

            query = query.Replace("@Ruta", ruta);


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