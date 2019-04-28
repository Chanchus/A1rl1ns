using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TEST.Models;

namespace TEST.Repositories
{
    public class AsistenteVueloRepository
    {

        public static bool addAsistenteVueloToDB(AsistenteVuelo asistente)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            var query = "INSERT INTO AsistenteVuelo (ID, Nombre, Correo) VALUES ('@ID', '@Nombre', '@Correo')";

            query = query.Replace("@ID", asistente.ID)
                    .Replace("@Nombre", asistente.Nombre)
                    .Replace("@Correo", asistente.Correo);
                    


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

        public static AsistenteVuelo getAsistenteVueloFromDB(string id)
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM AsistenteVuelo WHERE ID='@ID'";

            query = query.Replace("@ID", id);

            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            AsistenteVuelo asistenteVuelo = null;
            while (reader.Read())
            {
                asistenteVuelo = new AsistenteVuelo();
                asistenteVuelo.ID = reader.GetValue(0).ToString();
                asistenteVuelo.Nombre = reader.GetValue(1).ToString();
                asistenteVuelo.Correo = reader.GetValue(2).ToString();

            }
            connection.Close();
            return asistenteVuelo;
        }




        public static List<AsistenteVuelo> getAllAsistentesVueloFromDB()
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM AsistenteVuelo ";



            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            List<AsistenteVuelo> listaAsistenteVuelo = new List<AsistenteVuelo>();

            while (reader.Read())
            {
                AsistenteVuelo asistenteVuelo = null;
                asistenteVuelo = new AsistenteVuelo();
                asistenteVuelo.ID = reader.GetValue(0).ToString();
                asistenteVuelo.Nombre = reader.GetValue(1).ToString();
                asistenteVuelo.Correo = reader.GetValue(2).ToString();

                listaAsistenteVuelo.Add(asistenteVuelo);
            }
            connection.Close();
            return listaAsistenteVuelo;
        }



        public static bool deleteAsistenteVueloFromDB(string id)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";


            var query = "DELETE FROM AsistenteVuelo WHERE ID='@ID'";

            query = query.Replace("@ID", id);


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