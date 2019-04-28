using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TEST.Models;

namespace TEST.Repositories
{
    public class UniversidadRepository
    {

        public static bool addUniversidadToDB(Universidad universidad)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            var query = "INSERT INTO Universidad (NombreComp, MIllaEstudiante, Carné) " +
                                        "VALUES ('@NombreComp', '@MIllaEstudiante', '@Carne')";

            query = query.Replace("@NombreComp", universidad.NombreComp)
                    .Replace("@MIllaEstudiante", universidad.MillaEstudiante.ToString())
                    .Replace("@Carne", universidad.Carne.ToString());


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

        public static Universidad getUniversidadFromDB(string nombre)
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Universidad WHERE NombreComp='@NombreComp'";

            query = query.Replace("@NombreComp", nombre);

            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            Universidad universidad = null;
            while (reader.Read())
            {
                universidad = new Universidad();
                universidad.NombreComp = reader.GetValue(0).ToString();
                universidad.MillaEstudiante = Convert.ToInt32(reader.GetValue(1));
                universidad.Carne = Convert.ToInt32(reader.GetValue(2));

            }
            connection.Close();
            return universidad;
        }




        public static List<Universidad> getAllUniversidadesFromDB()
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Universidad ";



            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            List<Universidad> listaUniversidades = new List<Universidad>();

            while (reader.Read())
            {
                Universidad universidad = null;
                universidad = new Universidad();
                universidad.NombreComp = reader.GetValue(0).ToString();
                universidad.MillaEstudiante = Convert.ToInt32(reader.GetValue(1));
                universidad.Carne = Convert.ToInt32(reader.GetValue(2));

                listaUniversidades.Add(universidad);
            }
            connection.Close();
            return listaUniversidades;
        }



        public static bool deleteUniversidadFromDB(string nombre)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";


            var query = "DELETE FROM Universidad WHERE NombreComp='@NombreComp'";

            query = query.Replace("@NombreComp", nombre);


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