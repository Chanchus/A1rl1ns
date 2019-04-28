using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TEST.Models;

namespace TEST.Repositories
{
    public class AsientoRepository
    {

        public static bool addAsientoToDB(Asiento asiento)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            var query = "INSERT INTO Asiento (Numero, Categoría) VALUES ('@Numero', '@Categoria')";

            query = query.Replace("@Numero", asiento.Numero.ToString())
                    .Replace("@Categoria", asiento.Categoria);


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

        public static Asiento getAsientoFromDB(int numero)
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Asiento WHERE Numero='@Numero'";

            query = query.Replace("@Numero", numero.ToString());

            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            Asiento asiento = null;
            while (reader.Read())
            {
                asiento = new Asiento();
                asiento.Numero = Convert.ToInt32(reader.GetValue(0));
                asiento.Categoria = reader.GetValue(1).ToString();

            }
            connection.Close();
            return asiento;
        }




        public static List<Asiento> getAllAsientosFromDB()
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Asiento ";



            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            List<Asiento> listaAsientos = new List<Asiento>();

            while (reader.Read())
            {
                Asiento asiento = null;
                asiento = new Asiento();
                asiento.Numero = Convert.ToInt32(reader.GetValue(0));
                asiento.Categoria = reader.GetValue(1).ToString();

                listaAsientos.Add(asiento);
            }
            connection.Close();
            return listaAsientos;
        }



        public static bool deleteAsientoFromDB(int numero)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";


            var query = "DELETE FROM Asiento WHERE Numero='@Numero'";

            query = query.Replace("@Numero", numero.ToString());


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