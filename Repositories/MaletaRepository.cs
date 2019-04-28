using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TEST.Models;

namespace TEST.Repositories
{
    public class MaletaRepository
    {

        public static bool addMaletaToDB(Maleta maleta)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            var query = "INSERT INTO Maleta (codigoM, peso, IDPropietario, InfoU) VALUES ('@CodigoM', @peso, @IDPropietario, '@InfoU')";

            query = query.Replace("@CodigoM", maleta.CodigoM)
                        .Replace("@peso", maleta.Peso.ToString())
                        .Replace("@IDPropietario", maleta.IDPropietario.ToString())
                        .Replace("@InfoU", maleta.InfoU);


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

        public static Maleta getMaletaFromDB(string codigoM)
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Maleta WHERE codigoM='@codigoM'";

            query = query.Replace("@codigoM", codigoM);

            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            Maleta maleta = null;
            while (reader.Read())
            {
                maleta = new Maleta();
                maleta.CodigoM = reader.GetValue(0).ToString();
                maleta.Peso = Convert.ToInt32(reader.GetValue(1));
                maleta.IDPropietario = Convert.ToInt32(reader.GetValue(2));
                maleta.InfoU = reader.GetValue(3).ToString();

            }
            connection.Close();
            return maleta;
        }




        public static List<Maleta> getAllMaletasFromDB()
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Maleta ";



            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            List<Maleta> listaMaletas = new List<Maleta>();

            while (reader.Read())
            {
                Maleta maleta = null;
                maleta = new Maleta();
                maleta.CodigoM = reader.GetValue(0).ToString();
                maleta.Peso = Convert.ToInt32(reader.GetValue(1));
                maleta.IDPropietario = Convert.ToInt32(reader.GetValue(2));
                maleta.InfoU = reader.GetValue(3).ToString();

                listaMaletas.Add(maleta);
            }
            connection.Close();
            return listaMaletas;
        }



        public static bool deleteMaletaFromDB(string codigoM)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";


            var query = "DELETE FROM Maleta WHERE codigoM='@codigoM'";

            query = query.Replace("@codigoM", codigoM);


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