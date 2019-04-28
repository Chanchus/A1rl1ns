using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TEST.Models;

namespace TEST.Repositories
{
    public class EscalaRepository
    {

        public static bool addEscalaToDB(Escala escala)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            var query = "INSERT INTO Escala (Millas, Duración, Fecha) VALUES ('@Nombre', '@Duracion', '@Fecha')";

            query = query.Replace("@Nombre", escala.Millas.ToString())
                        .Replace("@Duracion", escala.Duracion.ToString())
                        .Replace("@Fecha", escala.Fecha.ToString());


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

        public static Escala getEscalaFromDB(int fecha)
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Escala WHERE Fecha='@Fecha'";

            query = query.Replace("@Fecha", fecha.ToString());

            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            Escala escala = null;
            while (reader.Read())
            {
                escala = new Escala();
                escala.Millas = Convert.ToInt32(reader.GetValue(0));
                escala.Duracion = Convert.ToInt32(reader.GetValue(1)); 
                escala.Fecha = Convert.ToInt32(reader.GetValue(2)); 

            }
            connection.Close();
            return escala;
        }




        public static List<Escala> getAllEscalasFromDB()
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Escala ";



            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            List<Escala> listaEscalas = new List<Escala>();

            while (reader.Read())
            {
                Escala escala = null;
                escala.Millas = Convert.ToInt32(reader.GetValue(0));
                escala.Duracion = Convert.ToInt32(reader.GetValue(1));
                escala.Fecha = Convert.ToInt32(reader.GetValue(2));

                listaEscalas.Add(escala);
            }
            connection.Close();
            return listaEscalas;
        }



        public static bool deleteEscalaFromDB(int fecha)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";


            var query = "DELETE FROM Escala WHERE Fecha='@Fecha'";

            query = query.Replace("@Fecha", fecha.ToString());


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